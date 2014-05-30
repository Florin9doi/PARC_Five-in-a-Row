using Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Client {
    public partial class step1_con : Form {
        private const int port = 3000;
        private Image[] GameStatus;
        private TCPConnection con;
        private String name;
        private bool gameCreated = false;
        private step2_game step2;

        // INIT
        public step1_con () {
            InitializeComponent ();

            GameStatus = new Image[3];
            GameStatus[0] = Image.FromFile ( Directory.GetCurrentDirectory () + @"\Imagini\status0.png" );
            GameStatus[1] = Image.FromFile ( Directory.GetCurrentDirectory () + @"\Imagini\status1.png" );
            GameStatus[2] = Image.FromFile ( Directory.GetCurrentDirectory () + @"\Imagini\status1.png" );
        }

        // CONNECT
        private void btnConnect_Click ( object sender, EventArgs e ) {
            con = new TCPConnection ();
            con.OnConnectCompleted += con_OnConnectCompleted;
            con.OnReceiveCompleted += con_OnReceiveCompleted;
            con.OnExceptionRaised += con_OnExceptionRaised;

            IPAddress srvAddr;
            if ( !IPAddress.TryParse ( textIP.Text, out srvAddr ) ) {
                MessageBox.Show ( "Invalid server address." );
            } else {
                con.connect ( new IPEndPoint ( srvAddr, port ) );
            }
        }

        delegate void FunctionConnect ();
        void con_OnConnectCompleted ( object sender, EventArgs args ) {
            this.BeginInvoke ( new FunctionConnect ( FuncConnect ) );
        }

        private void FuncConnect () {
            this.name = textName.Text;
            con.send ( Encoding.Unicode.GetBytes ( "0GL" ) );
            this.Text = name; // window title
            panel1.Visible = false;
            panel2.Visible = true;
        }

        // RECEIVE
        delegate void FunctionReceive ( string text );
        void con_OnReceiveCompleted ( object sender, ReceiveCompletedEventArgs args ) {
            string text = Encoding.Unicode.GetString ( args.data );
            this.BeginInvoke ( new FunctionReceive ( ReceieveMessage ), text );
        }

        private void ReceieveMessage ( string text ) {

            /* add game */
            if ( text.StartsWith ( "0GH_" ) ) {
                string[] games = text.Split ( new string[] { "0GH_" }, StringSplitOptions.RemoveEmptyEntries );
                foreach ( string game in games ) {
                    string[] tmp = game.Split ( new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries );
                    gameList.Rows.Add ( tmp[0], GameStatus[UInt64.Parse ( tmp[1] )] );
                }
            }

            /* update game status */
            else if ( text.StartsWith ( "0GS_" ) ) {
                string[] tmp = text.Substring ( 4 ).Split ( new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries );

                foreach ( DataGridViewRow r in gameList.Rows )
                    if ( r.Cells[0].Value.Equals ( tmp[0] ) )
                        r.Cells[1].Value = GameStatus[UInt64.Parse ( tmp[1] )];
            }

            /* remove game */
            else if ( text.StartsWith ( "0GE_" ) ) {
                foreach ( DataGridViewRow row in gameList.Rows )
                    if ( row.Cells[0].Value.ToString () == text.Substring ( 4 ) )
                        gameList.Rows.Remove ( row );

                if ( text.Substring ( 4 ).Equals ( name ) && step2 != null ) {
                    gameCreated = false;
                    btnHost.Text = "Host game";
                    this.Show ();
                    step2.Hide ();
                }
            }

            /* start game */
            else if ( text.StartsWith ( "0GJ_" ) ) {
                string[] tmp = text.Substring ( 4 ).Split ( new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries );
                if ( tmp[0].Equals ( name ) ) { // host
                    step2 = new step2_game ( con, this, tmp[0], tmp[1], 1 );
                    step2.Show ();
                    this.Hide ();
                } else if ( tmp[1].Equals ( name ) ) { // guest
                    step2 = new step2_game ( con, this, tmp[0], tmp[1], 2 );
                    step2.Show ();
                    this.Hide ();
                }
            }
        }

        void con_OnExceptionRaised ( object sender, ExceptionRaiseEventArgs args ) {
            Application.Exit ();
        }

        // host game
        private void btnHost_Click ( object sender, EventArgs e ) {
            if ( gameCreated == false ) {
                gameCreated = true;
                btnHost.Text = "Delete game";
                con.send ( Encoding.Unicode.GetBytes ( "0GH_" + name ) );
            } else if ( gameCreated == true ) {
                gameCreated = false;
                btnHost.Text = "Host game";
                con.send ( Encoding.Unicode.GetBytes ( "0GE_" + name ) );
            }
        }

        // join game
        private void btnJoin_Click ( object sender, EventArgs e ) {
            if ( gameList.SelectedRows.Count == 1 // !outOfRange
                && gameList[1, gameList.CurrentCell.RowIndex].Value.Equals ( GameStatus[0] )  // available
                && !gameList[0, gameList.CurrentCell.RowIndex].Value.Equals ( name ) ) //  && !myself
                con.send ( Encoding.Unicode.GetBytes ( "0GJ_" + gameList[0, gameList.CurrentCell.RowIndex].Value + ";" + name ) );
            else
                MessageBox.Show ( "Not allowed" );
        }

        private void btnExit_Click ( object sender, EventArgs e ) {
            Application.Exit ();
        }
    }
}
