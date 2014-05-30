using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Connection;

namespace Client {
    public partial class step2_game : Form {
        private TCPConnection con; // Connection instance
        private step1_con step2_inst; // window instance
        private Image[] GamePieces; // images array

        private bool canPlay = true; // your turn ?
        private UInt16 myColor;
        private String myName;

        private void setPermission ( bool perm ) {
            canPlay = perm;
            if ( myColor == 1 && perm == true ) {
                hostPlayer.BackColor = Color.Green;
                guestPlayer.BackColor = Color.DarkGray;
            } else if ( myColor == 1 && perm == false ) {//|| myColor == 2 && perm == true ) {
                hostPlayer.BackColor = Color.LightCoral;
                guestPlayer.BackColor = Color.DarkGray;
            } else if ( myColor == 2 && perm == true ) {
                hostPlayer.BackColor = Color.DarkGray;
                guestPlayer.BackColor = Color.Green;
            } else if ( myColor == 2 && perm == false ) {
                hostPlayer.BackColor = Color.DarkGray;
                guestPlayer.BackColor = Color.LightCoral;
            }
        }

        public step2_game ( TCPConnection con, step1_con step2_inst, String host, String guest, UInt16 color ) {
            InitializeComponent ();

            this.con = con;
            con.OnExceptionRaised += con_OnExceptionRaised;
            con.OnReceiveCompleted += con_OnReceiveCompleted;

            this.step2_inst = step2_inst;
            hostPlayer.Text = host;
            guestPlayer.Text = guest;
            this.myColor = color;
            this.myName = color == 1 ? host : guest;
            this.Text = myName;
            setPermission ( color == 1 ? true : false );

            GamePieces = new Image[3];
            GamePieces[0] = Image.FromFile ( Directory.GetCurrentDirectory () + @"\Imagini\piece0.png" );
            GamePieces[1] = Image.FromFile ( Directory.GetCurrentDirectory () + @"\Imagini\piece1.png" );
            GamePieces[2] = Image.FromFile ( Directory.GetCurrentDirectory () + @"\Imagini\piece2.png" );

            for ( int i = 0; i < 15; i++ )
                gameBoard.Columns.Add ( new DataGridViewImageColumn () );
            for ( int i = 0; i < 15; i++ )
                gameBoard.Rows.Insert ( 0 );
            for ( int i = 0; i < 15; i++ )
                gameBoard.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for ( int i = 0; i < gameBoard.RowCount; i++ )
                for ( int j = 0; j < gameBoard.ColumnCount; j++ )
                    gameBoard[j, i].Value = GamePieces[0];
        }

        void con_OnExceptionRaised ( object sender, ExceptionRaiseEventArgs args ) {
            if ( con != null )
                con.send ( Encoding.Unicode.GetBytes ( "0GE_" + hostPlayer.Text ) );
            if ( step2_inst != null )
                step2_inst.Show ();
            this.Hide ();
        }

        private delegate void FunctionCall ( string text );
        void con_OnReceiveCompleted ( object sender, ReceiveCompletedEventArgs args ) {
            string text = Encoding.Unicode.GetString ( args.data );
            this.BeginInvoke ( new FunctionCall ( ReceieveMessage ), text );
        }

        private void ReceieveMessage ( string text ) {

            // move received
            if ( text.StartsWith ( "0GM_" ) ) {
                string[] tmp = text.Substring ( 4 ).Split ( new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries );
                if ( tmp[0].Equals ( hostPlayer.Text ) && !tmp[3].Equals ( myColor.ToString () ) ) { // thisGame && !myMove
                    gameBoard[int.Parse ( tmp[1] ), int.Parse ( tmp[2] )].Value = GamePieces[UInt64.Parse ( tmp[3] )];
                    setPermission ( true );
                }
            }

            // reset game
            else if ( text.StartsWith ( "0GR_" ) && text.Substring(4).Equals(hostPlayer.Text) ) {
                for ( int i = 0; i < gameBoard.RowCount; i++ )
                    for ( int j = 0; j < gameBoard.ColumnCount; j++ )
                        gameBoard[j, i].Value = GamePieces[0];
                if ( myName.Equals ( hostPlayer.Text ) )
                    setPermission ( true );
                else setPermission ( false );
            }

           // win
           else if ( text.StartsWith ( "0GW_" ) ) {
                if ( text.Substring ( 4 ).Equals ( hostPlayer.Text )
                    || text.Substring ( 4 ).Equals ( guestPlayer.Text ) ) {
                    setPermission ( false );
                    MessageBox.Show ( text.Substring ( 4 ) + " has won !!" );
                }
            }

           // chat
           else if ( text.StartsWith ( "00C_" ) ) {
                string[] tmp = text.Substring ( 4 ).Split ( new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries );
                if ( tmp[0].Equals ( hostPlayer.Text ) || tmp[0].Equals ( guestPlayer.Text ) ) {
                    chatOut.Text += Environment.NewLine;
                    chatOut.Text += text.Substring ( 4 );
                }
            }
        }

        // send chat message
        private void textBox1_KeyUp ( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Enter ) {
                con.send ( Encoding.Unicode.GetBytes ( "00C_" + myName + ": " + chatAdd.Text ) );
                chatAdd.Text = "";
            }
        }

        // return to lobby
        private void btnExit_Click ( object sender, EventArgs e ) {
            con.send ( Encoding.Unicode.GetBytes ( "0GE_" + hostPlayer.Text ) );
            step2_inst.Show ();
            this.Hide ();
        }

        // make a move
        private void gameBoard_CellContentClick ( object sender, DataGridViewCellEventArgs e ) {
            if ( canPlay == true && gameBoard[e.ColumnIndex, e.RowIndex].Value.Equals ( GamePieces[0] ) ) {
                setPermission ( false );
                gameBoard[e.ColumnIndex, e.RowIndex].Value = GamePieces[myColor];
                con.send ( Encoding.Unicode.GetBytes ( "0GM_" + myName + ";" + e.ColumnIndex + ";" + e.RowIndex + ";" + myColor ) );
            }
        }

        // make a move
        private void gameBoard_CellContentDoubleClick ( object sender, DataGridViewCellEventArgs e ) {
            gameBoard_CellContentClick ( sender, e );
        }

        // reset table
        private void btnReset_Click ( object sender, EventArgs e ) {
            con.send ( Encoding.Unicode.GetBytes ( "0GR_" + hostPlayer.Text ) );
        }
    }
}
