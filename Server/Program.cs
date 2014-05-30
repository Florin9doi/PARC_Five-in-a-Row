using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using System.Net;
using System.Net.Sockets;

namespace Server {
    class Program {
        public const int port = 3000;
        private static TCPConnection con = new TCPConnection ();

        public struct GameStruct {
            public UInt64 gameNr;
            public String player1, player2;
            public UInt64 status;
            public Byte[,] gameBoard;

            public GameStruct ( UInt64 gameNr, string player1, UInt16 status ) {
                this.gameNr = gameNr;
                this.player1 = player1;
                this.player2 = "";
                this.status = status;
                gameBoard = new Byte[15, 15];
            }

            public GameStruct ( UInt64 gameNr, string player1, string player2, UInt16 status ) {
                this.gameNr = gameNr;
                this.player1 = player1;
                this.player2 = player2;
                this.status = status;
                gameBoard = new Byte[15, 15];
            }
        }
        private static UInt64 nrOfGame = 0;
        private static Dictionary<string, UInt64> gamePointer = new Dictionary<string, UInt64> ();
        private static Dictionary<UInt64, GameStruct> gameRooms = new Dictionary<UInt64, GameStruct> ();

        static void Main ( string[] args ) {
            con.reserve ( port );
            con.OnReceiveCompleted += con_OnReceiveCompleted;
            con.OnExceptionRaised += con_OnExceptionRaised;

            Console.WriteLine ( "waiting connection from clients" );
            System.Threading.Thread.Sleep ( System.Threading.Timeout.Infinite );
        }

        static void con_OnExceptionRaised ( object sender, ExceptionRaiseEventArgs args ) {
            if ( !( sender.GetType () == typeof ( Socket ) ) ) {
                Console.WriteLine ( "exception source : " + args.raisedException.Source );
                Console.WriteLine ( "exception raised : " + args.raisedException.Message );
                Console.WriteLine ( "exception detail : " + args.raisedException.InnerException );
            }
        }

        static void con_OnReceiveCompleted ( object sender, ReceiveCompletedEventArgs args ) {
            string text = Encoding.Unicode.GetString ( args.data );
            IPEndPoint iep = ( args.remoteSock.RemoteEndPoint as IPEndPoint );
            string clientAddr = iep.Address.ToString () + iep.Port;

            // list games
            if ( text.StartsWith ( "0GL" ) ) {
                foreach ( var game in gameRooms ) {
                    con.sendBySpecificSocket ( Encoding.Unicode.GetBytes ( "0GH_" + game.Value.player1 + ";" + game.Value.status ), args.remoteSock );
                }
            }

            // host game
            else if ( text.StartsWith ( "0GH_" ) ) {
                string player1 = text.Substring ( 4 );
                Console.WriteLine ( player1 + " has created a game" );

                gameRooms.Add ( nrOfGame, new GameStruct ( nrOfGame, player1, 0 ) );
                gamePointer.Add ( player1, nrOfGame );

                /* register new game */
                con.send ( Encoding.Unicode.GetBytes ( "0GH_" + gameRooms[nrOfGame].player1 + ";" + gameRooms[nrOfGame].status ) );
                nrOfGame++;
            }

            // join game
            else if ( text.StartsWith ( "0GJ_" ) ) {
                string[] player = text.Substring ( 4 ).Split ( new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries );
                Console.WriteLine ( player[1] + " has joied " + player[0] + "'s game" );

                UInt64 nrOfGame = gamePointer[player[0]];
                gameRooms[nrOfGame] = new GameStruct ( nrOfGame, player[0], player[1], 1 );
                gamePointer.Add ( player[1], nrOfGame );

                //start games
                con.send ( Encoding.Unicode.GetBytes ( "0GS_" + player[0] + ";" + 1 ) );
                con.send ( Encoding.Unicode.GetBytes ( "0GJ_" + player[0] + ";" + player[1] ) );
            }

            // exit game
            else if ( text.StartsWith ( "0GE_" ) ) {
                string player = text.Substring ( 4 );
                Console.WriteLine ( player + " has closed the game" );

                UInt64 nrOfGame = gamePointer[player];
                con.send ( Encoding.Unicode.GetBytes ( "0GE_" + gameRooms[nrOfGame].player1 ) );
                con.send ( Encoding.Unicode.GetBytes ( "0GE_" + gameRooms[nrOfGame].player2 ) );
                gamePointer.Remove ( gameRooms[nrOfGame].player1 );
                gamePointer.Remove ( gameRooms[nrOfGame].player2 );
                gameRooms.Remove ( nrOfGame );
            }

            //reset game
            else if ( text.StartsWith ( "0GR_" ) ) {
                string game = text.Substring ( 4 );
                
                UInt64 nrOfGame = gamePointer[game];
                gameRooms[nrOfGame] = new GameStruct ( nrOfGame, gameRooms[nrOfGame].player1, gameRooms[nrOfGame].player2, 1 );

                con.send ( Encoding.Unicode.GetBytes ( text ) );
            }

            // chat
            else if ( text.StartsWith ( "00C_" ) ) {
                Console.WriteLine ( text.Substring ( 4 ) );
                con.send ( Encoding.Unicode.GetBytes ( "00C_" + text.Substring ( 4 ) ) );
            }

            // game move
            else if ( text.StartsWith ( "0GM_" ) ) {
                string[] tmp = text.Substring ( 4 ).Split ( new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries );

                int x = int.Parse ( tmp[1] );
                int y = int.Parse ( tmp[2] );
                Byte c = Byte.Parse ( tmp[3] );

                if ( gameRooms[gamePointer[tmp[0]]].status == UInt64.Parse ( tmp[3] ) ) { // right player
                    Console.WriteLine ( tmp[0] + " has choosed [" + x + "," + y + "]" );
                    gameRooms[gamePointer[tmp[0]]].gameBoard[x, y] = c;

                    con.send ( Encoding.Unicode.GetBytes ( "0GM_" + gameRooms[gamePointer[tmp[0]]].player1
                        + ";" + tmp[1] + ";" + tmp[2] + ";" + tmp[3] ) );

                    // check wins
                    bool win = false;
                    int same = 0;
                    for ( int i = Math.Max ( 0, x - 4 ); i < Math.Min ( 14, x + 4 ) && win == false; i++ ) {
                        if ( gameRooms[gamePointer[tmp[0]]].gameBoard[i, y] == gameRooms[gamePointer[tmp[0]]].gameBoard[i + 1, y]
                            && gameRooms[gamePointer[tmp[0]]].gameBoard[i, y] == c )
                            same++;
                        else same = 0;

                        if ( same >= 4 )
                            win = true;
                    }

                    same = 0;
                    for ( int i = Math.Max ( 0, y - 4 ); i < Math.Min ( 14, y + 4 ) && win == false; i++ ) {
                        if ( gameRooms[gamePointer[tmp[0]]].gameBoard[x, i] == gameRooms[gamePointer[tmp[0]]].gameBoard[x, i + 1]
                            && gameRooms[gamePointer[tmp[0]]].gameBoard[x, i] == c )
                            same++;
                        else same = 0;

                        if ( same >= 4 )
                            win = true;
                    }

                    // DIAGONAL CHECKS WILL BE ADDED IN VERSION 2.0
                    // maybe :D

                    if ( win ) {
                        con.send ( Encoding.Unicode.GetBytes ( "0GW_" + tmp[0] ) );
                        Console.WriteLine ( tmp[0] + " has won !!" );
                    } else {
                        GameStruct g = gameRooms[gamePointer[tmp[0]]];
                        g.status = int.Parse ( tmp[3] ) == 1 ? (UInt64)2 : (UInt64)1;
                        gameRooms[gamePointer[tmp[0]]] = g;
                    }
                }
            } else {
                Console.WriteLine ( text );
            }
        }
    }
}
