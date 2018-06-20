namespace FruityMatch
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.salfetkiInfo = new System.Windows.Forms.PictureBox();
            this.endButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.avatarPicture = new System.Windows.Forms.PictureBox();
            this.player1Name = new System.Windows.Forms.Label();
            this.changeUserButton = new System.Windows.Forms.Button();
            this.secoudPlayerPicture = new System.Windows.Forms.PictureBox();
            this.secondPlayerName = new System.Windows.Forms.Label();
            this.fullScreenButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rankingsButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.salfetkiInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secoudPlayerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // salfetkiInfo
            // 
            this.salfetkiInfo.BackColor = System.Drawing.Color.Transparent;
            this.salfetkiInfo.Image = global::FruityMatch.Properties.Resources.salfetki_info;
            this.salfetkiInfo.Location = new System.Drawing.Point(421, 55);
            this.salfetkiInfo.Name = "salfetkiInfo";
            this.salfetkiInfo.Size = new System.Drawing.Size(137, 135);
            this.salfetkiInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.salfetkiInfo.TabIndex = 0;
            this.salfetkiInfo.TabStop = false;
            this.salfetkiInfo.Visible = false;
            // 
            // endButton
            // 
            this.endButton.BackColor = System.Drawing.Color.Maroon;
            this.endButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.endButton.ForeColor = System.Drawing.SystemColors.Control;
            this.endButton.Location = new System.Drawing.Point(492, 13);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(92, 36);
            this.endButton.TabIndex = 1;
            this.endButton.Text = "End Game";
            this.endButton.UseVisualStyleBackColor = false;
            this.endButton.Visible = false;
            this.endButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // newButton
            // 
            this.newButton.BackColor = System.Drawing.Color.Maroon;
            this.newButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newButton.ForeColor = System.Drawing.SystemColors.Control;
            this.newButton.Location = new System.Drawing.Point(394, 13);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(92, 36);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "New Game";
            this.newButton.UseVisualStyleBackColor = false;
            this.newButton.Visible = false;
            this.newButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel.Location = new System.Drawing.Point(234, 13);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(60, 24);
            this.welcomeLabel.TabIndex = 4;
            this.welcomeLabel.Text = "label2";
            // 
            // avatarPicture
            // 
            this.avatarPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avatarPicture.Location = new System.Drawing.Point(239, 45);
            this.avatarPicture.Name = "avatarPicture";
            this.avatarPicture.Size = new System.Drawing.Size(90, 105);
            this.avatarPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarPicture.TabIndex = 5;
            this.avatarPicture.TabStop = false;
            this.avatarPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.avatarPicture_Paint);
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.BackColor = System.Drawing.Color.Transparent;
            this.player1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player1Name.Location = new System.Drawing.Point(244, 153);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(46, 18);
            this.player1Name.TabIndex = 6;
            this.player1Name.Text = "label2";
            this.player1Name.Visible = false;
            // 
            // changeUserButton
            // 
            this.changeUserButton.BackColor = System.Drawing.Color.Maroon;
            this.changeUserButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeUserButton.ForeColor = System.Drawing.SystemColors.Control;
            this.changeUserButton.Location = new System.Drawing.Point(239, 156);
            this.changeUserButton.Name = "changeUserButton";
            this.changeUserButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.changeUserButton.Size = new System.Drawing.Size(90, 42);
            this.changeUserButton.TabIndex = 7;
            this.changeUserButton.Text = "Change user";
            this.changeUserButton.UseVisualStyleBackColor = false;
            this.changeUserButton.Click += new System.EventHandler(this.changeUserButton_Click);
            // 
            // secoudPlayerPicture
            // 
            this.secoudPlayerPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secoudPlayerPicture.Location = new System.Drawing.Point(652, 45);
            this.secoudPlayerPicture.Name = "secoudPlayerPicture";
            this.secoudPlayerPicture.Size = new System.Drawing.Size(90, 105);
            this.secoudPlayerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.secoudPlayerPicture.TabIndex = 8;
            this.secoudPlayerPicture.TabStop = false;
            this.secoudPlayerPicture.Visible = false;
            this.secoudPlayerPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.secoudPlayerPicture_Paint);
            // 
            // secondPlayerName
            // 
            this.secondPlayerName.AutoSize = true;
            this.secondPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.secondPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondPlayerName.Location = new System.Drawing.Point(658, 153);
            this.secondPlayerName.Name = "secondPlayerName";
            this.secondPlayerName.Size = new System.Drawing.Size(46, 18);
            this.secondPlayerName.TabIndex = 9;
            this.secondPlayerName.Text = "label2";
            this.secondPlayerName.Visible = false;
            // 
            // fullScreenButton
            // 
            this.fullScreenButton.BackColor = System.Drawing.Color.Maroon;
            this.fullScreenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fullScreenButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.fullScreenButton.FlatAppearance.BorderSize = 0;
            this.fullScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullScreenButton.ForeColor = System.Drawing.SystemColors.Control;
            this.fullScreenButton.Location = new System.Drawing.Point(296, 576);
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.Size = new System.Drawing.Size(100, 42);
            this.fullScreenButton.TabIndex = 10;
            this.fullScreenButton.Text = "Exit Full Screen";
            this.fullScreenButton.UseVisualStyleBackColor = false;
            this.fullScreenButton.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Maroon;
            this.quitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quitButton.FlatAppearance.BorderSize = 0;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quitButton.Location = new System.Drawing.Point(595, 576);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(100, 42);
            this.quitButton.TabIndex = 11;
            this.quitButton.Text = "Quit Game";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Biting My Nails", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 636);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click Anywhere to Start";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // rankingsButton
            // 
            this.rankingsButton.BackColor = System.Drawing.Color.Maroon;
            this.rankingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rankingsButton.FlatAppearance.BorderSize = 0;
            this.rankingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rankingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rankingsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rankingsButton.Location = new System.Drawing.Point(652, 13);
            this.rankingsButton.Name = "rankingsButton";
            this.rankingsButton.Size = new System.Drawing.Size(100, 42);
            this.rankingsButton.TabIndex = 12;
            this.rankingsButton.Text = "Rankings";
            this.rankingsButton.UseVisualStyleBackColor = false;
            this.rankingsButton.Click += new System.EventHandler(this.button1_Click_5);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(12, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "How To Play";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_6);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(863, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 32);
            this.button2.TabIndex = 15;
            this.button2.Text = "Controls";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.BackgroundImage = global::FruityMatch.Properties.Resources.image_play;
            this.ClientSize = new System.Drawing.Size(973, 698);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rankingsButton);
            this.Controls.Add(this.fullScreenButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.secondPlayerName);
            this.Controls.Add(this.secoudPlayerPicture);
            this.Controls.Add(this.changeUserButton);
            this.Controls.Add(this.player1Name);
            this.Controls.Add(this.avatarPicture);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.salfetkiInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.salfetkiInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secoudPlayerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox salfetkiInfo;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox avatarPicture;
        private System.Windows.Forms.Label player1Name;
        private System.Windows.Forms.Button changeUserButton;
        private System.Windows.Forms.PictureBox secoudPlayerPicture;
        private System.Windows.Forms.Label secondPlayerName;
        private System.Windows.Forms.Button fullScreenButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rankingsButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button2;
    }
}

