namespace FruityMatch
{
    partial class ChangeUser
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tiesNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lossesNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.winsNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.done = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(335, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(197, 224);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FruityMatch.Properties.Resources.avatar1;
            this.pictureBox1.Location = new System.Drawing.Point(20, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change Avatar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(167, 44);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(144, 22);
            this.name.TabIndex = 3;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tiesNumber);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lossesNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.winsNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 226);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Settings";
            // 
            // tiesNumber
            // 
            this.tiesNumber.AutoSize = true;
            this.tiesNumber.Location = new System.Drawing.Point(212, 151);
            this.tiesNumber.Name = "tiesNumber";
            this.tiesNumber.Size = new System.Drawing.Size(16, 17);
            this.tiesNumber.TabIndex = 10;
            this.tiesNumber.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ties:";
            // 
            // lossesNumber
            // 
            this.lossesNumber.AutoSize = true;
            this.lossesNumber.Location = new System.Drawing.Point(228, 125);
            this.lossesNumber.Name = "lossesNumber";
            this.lossesNumber.Size = new System.Drawing.Size(16, 17);
            this.lossesNumber.TabIndex = 8;
            this.lossesNumber.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Losses:";
            // 
            // winsNumber
            // 
            this.winsNumber.AutoSize = true;
            this.winsNumber.Location = new System.Drawing.Point(216, 95);
            this.winsNumber.Name = "winsNumber";
            this.winsNumber.Size = new System.Drawing.Size(16, 17);
            this.winsNumber.TabIndex = 6;
            this.winsNumber.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wins:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your name";
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(32, 258);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(109, 35);
            this.done.TabIndex = 11;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(182, 258);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(109, 35);
            this.cancel.TabIndex = 12;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 35);
            this.button2.TabIndex = 11;
            this.button2.Text = "Add New User";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChangeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FruityMatch.Properties.Resources.change_user_bg;
            this.ClientSize = new System.Drawing.Size(556, 305);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.done);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "ChangeUser";
            this.Text = "Choose your user";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label winsNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tiesNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lossesNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button button2;
    }
}