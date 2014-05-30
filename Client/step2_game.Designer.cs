namespace Client
{
    partial class step2_game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guestPlayer = new System.Windows.Forms.Label();
            this.hostPlayer = new System.Windows.Forms.Label();
            this.chatOut = new System.Windows.Forms.TextBox();
            this.chatAdd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gameBoard = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // guestPlayer
            // 
            this.guestPlayer.BackColor = System.Drawing.Color.Green;
            this.guestPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guestPlayer.ForeColor = System.Drawing.Color.White;
            this.guestPlayer.Location = new System.Drawing.Point(409, 77);
            this.guestPlayer.Name = "guestPlayer";
            this.guestPlayer.Size = new System.Drawing.Size(65, 23);
            this.guestPlayer.TabIndex = 16;
            this.guestPlayer.Text = "Player 2";
            this.guestPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hostPlayer
            // 
            this.hostPlayer.BackColor = System.Drawing.Color.Green;
            this.hostPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostPlayer.ForeColor = System.Drawing.Color.White;
            this.hostPlayer.Location = new System.Drawing.Point(336, 77);
            this.hostPlayer.Name = "hostPlayer";
            this.hostPlayer.Size = new System.Drawing.Size(66, 23);
            this.hostPlayer.TabIndex = 15;
            this.hostPlayer.Text = "Player 1";
            this.hostPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chatOut
            // 
            this.chatOut.Location = new System.Drawing.Point(337, 133);
            this.chatOut.Multiline = true;
            this.chatOut.Name = "chatOut";
            this.chatOut.ReadOnly = true;
            this.chatOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatOut.Size = new System.Drawing.Size(137, 193);
            this.chatOut.TabIndex = 21;
            // 
            // chatAdd
            // 
            this.chatAdd.Location = new System.Drawing.Point(337, 323);
            this.chatAdd.Name = "chatAdd";
            this.chatAdd.Size = new System.Drawing.Size(137, 20);
            this.chatAdd.TabIndex = 20;
            this.chatAdd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(337, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Chat Box";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameBoard
            // 
            this.gameBoard.AllowUserToAddRows = false;
            this.gameBoard.AllowUserToDeleteRows = false;
            this.gameBoard.AllowUserToResizeColumns = false;
            this.gameBoard.AllowUserToResizeRows = false;
            this.gameBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameBoard.ColumnHeadersVisible = false;
            this.gameBoard.Location = new System.Drawing.Point(12, 12);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.RowHeadersVisible = false;
            this.gameBoard.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gameBoard.Size = new System.Drawing.Size(318, 331);
            this.gameBoard.TabIndex = 0;
            this.gameBoard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameBoard_CellContentClick);
            this.gameBoard.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameBoard_CellContentDoubleClick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(337, 43);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(137, 25);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit to lobby";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(337, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(137, 25);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset round";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // step2_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 357);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chatOut);
            this.Controls.Add(this.chatAdd);
            this.Controls.Add(this.guestPlayer);
            this.Controls.Add(this.hostPlayer);
            this.Controls.Add(this.gameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "step2_game";
            this.Text = "Five Stones";
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guestPlayer;
        private System.Windows.Forms.Label hostPlayer;
        private System.Windows.Forms.TextBox chatOut;
        private System.Windows.Forms.TextBox chatAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gameBoard;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
    }
}

