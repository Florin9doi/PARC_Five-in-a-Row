namespace Client
{
    partial class step1_con
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
            this.gameList = new System.Windows.Forms.DataGridView();
            this.btnHost = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.textIP = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Game = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExit0 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameList
            // 
            this.gameList.AllowUserToAddRows = false;
            this.gameList.AllowUserToDeleteRows = false;
            this.gameList.AllowUserToResizeColumns = false;
            this.gameList.AllowUserToResizeRows = false;
            this.gameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Game,
            this.Status});
            this.gameList.Location = new System.Drawing.Point(6, 6);
            this.gameList.MultiSelect = false;
            this.gameList.Name = "gameList";
            this.gameList.RowHeadersVisible = false;
            this.gameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gameList.Size = new System.Drawing.Size(213, 200);
            this.gameList.TabIndex = 0;
            // 
            // btnHost
            // 
            this.btnHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHost.Location = new System.Drawing.Point(225, 6);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(75, 23);
            this.btnHost.TabIndex = 1;
            this.btnHost.Text = "Host game";
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoin.Location = new System.Drawing.Point(225, 35);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 2;
            this.btnJoin.Text = "Join game";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(47, 29);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(172, 20);
            this.textName.TabIndex = 6;
            this.textName.Text = "PlayerName";
            // 
            // textIP
            // 
            this.textIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textIP.Location = new System.Drawing.Point(47, 3);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(172, 20);
            this.textIP.TabIndex = 5;
            this.textIP.Text = "127.21.5.99";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnExit0);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.textName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textIP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 209);
            this.panel1.TabIndex = 9;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(225, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 46);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnJoin);
            this.panel2.Controls.Add(this.gameList);
            this.panel2.Controls.Add(this.btnHost);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(303, 209);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // Game
            // 
            this.Game.FillWeight = 150F;
            this.Game.Frozen = true;
            this.Game.HeaderText = "Player";
            this.Game.Name = "Game";
            this.Game.ReadOnly = true;
            this.Game.Width = 150;
            // 
            // Status
            // 
            this.Status.FillWeight = 55F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 55;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(225, 183);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExit0
            // 
            this.btnExit0.Location = new System.Drawing.Point(225, 183);
            this.btnExit0.Name = "btnExit0";
            this.btnExit0.Size = new System.Drawing.Size(75, 23);
            this.btnExit0.TabIndex = 10;
            this.btnExit0.Text = "Exit";
            this.btnExit0.UseVisualStyleBackColor = true;
            this.btnExit0.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // step1_con
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 233);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "step1_con";
            this.Text = "Five Stones";
            ((System.ComponentModel.ISupportInitialize)(this.gameList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gameList;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Game;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExit0;

    }
}