namespace Elite_Hockey_Manager.Forms
{
    partial class PlayersForm
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
            this.exitBtn = new System.Windows.Forms.Button();
            this.playerListBox = new System.Windows.Forms.ListBox();
            this.createRandomBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.searchGroup = new System.Windows.Forms.GroupBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.positionGroup = new System.Windows.Forms.GroupBox();
            this.randomGRadio = new System.Windows.Forms.RadioButton();
            this.randomRdRadio = new System.Windows.Forms.RadioButton();
            this.randomLdRadio = new System.Windows.Forms.RadioButton();
            this.randomRwRadio = new System.Windows.Forms.RadioButton();
            this.randomLwRadio = new System.Windows.Forms.RadioButton();
            this.randomCRadio = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.searchGroup.SuspendLayout();
            this.positionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(12, 588);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(165, 53);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // playerListBox
            // 
            this.playerListBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerListBox.FormattingEnabled = true;
            this.playerListBox.ItemHeight = 16;
            this.playerListBox.Location = new System.Drawing.Point(12, 25);
            this.playerListBox.Name = "playerListBox";
            this.playerListBox.Size = new System.Drawing.Size(360, 388);
            this.playerListBox.TabIndex = 1;
            // 
            // createRandomBtn
            // 
            this.createRandomBtn.Location = new System.Drawing.Point(378, 25);
            this.createRandomBtn.Name = "createRandomBtn";
            this.createRandomBtn.Size = new System.Drawing.Size(165, 45);
            this.createRandomBtn.TabIndex = 2;
            this.createRandomBtn.Text = "Create Random Player";
            this.createRandomBtn.UseVisualStyleBackColor = true;
            this.createRandomBtn.Click += new System.EventHandler(this.createRandomBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete Player";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // searchGroup
            // 
            this.searchGroup.Controls.Add(this.radioButton10);
            this.searchGroup.Controls.Add(this.radioButton9);
            this.searchGroup.Controls.Add(this.radioButton8);
            this.searchGroup.Controls.Add(this.radioButton7);
            this.searchGroup.Controls.Add(this.radioButton6);
            this.searchGroup.Controls.Add(this.radioButton5);
            this.searchGroup.Controls.Add(this.radioButton4);
            this.searchGroup.Controls.Add(this.radioButton3);
            this.searchGroup.Controls.Add(this.radioButton2);
            this.searchGroup.Controls.Add(this.radioButton1);
            this.searchGroup.Location = new System.Drawing.Point(12, 420);
            this.searchGroup.Name = "searchGroup";
            this.searchGroup.Size = new System.Drawing.Size(360, 162);
            this.searchGroup.TabIndex = 4;
            this.searchGroup.TabStop = false;
            this.searchGroup.Text = "Sort Players By Category";
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Checked = true;
            this.radioButton10.Location = new System.Drawing.Point(17, 21);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(44, 21);
            this.radioButton10.TabIndex = 9;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "All";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton9.Location = new System.Drawing.Point(95, 127);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(49, 21);
            this.radioButton9.TabIndex = 8;
            this.radioButton9.Text = "RD";
            this.radioButton9.UseVisualStyleBackColor = false;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(42, 127);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(47, 21);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.Text = "LD";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(118, 101);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(52, 21);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.Text = "RW";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(61, 100);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(50, 21);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Text = "LW";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(17, 101);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(38, 21);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "C";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(109, 44);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(77, 21);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Goalies";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(109, 73);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(95, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Defenders";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 73);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Forwards";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 45);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Skaters";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // positionGroup
            // 
            this.positionGroup.Controls.Add(this.randomGRadio);
            this.positionGroup.Controls.Add(this.randomRdRadio);
            this.positionGroup.Controls.Add(this.randomLdRadio);
            this.positionGroup.Controls.Add(this.randomRwRadio);
            this.positionGroup.Controls.Add(this.randomLwRadio);
            this.positionGroup.Controls.Add(this.randomCRadio);
            this.positionGroup.Location = new System.Drawing.Point(570, 12);
            this.positionGroup.Name = "positionGroup";
            this.positionGroup.Size = new System.Drawing.Size(454, 58);
            this.positionGroup.TabIndex = 5;
            this.positionGroup.TabStop = false;
            this.positionGroup.Text = "Position";
            // 
            // randomGRadio
            // 
            this.randomGRadio.AutoSize = true;
            this.randomGRadio.Location = new System.Drawing.Point(274, 22);
            this.randomGRadio.Name = "randomGRadio";
            this.randomGRadio.Size = new System.Drawing.Size(40, 21);
            this.randomGRadio.TabIndex = 5;
            this.randomGRadio.Tag = "5";
            this.randomGRadio.Text = "G";
            this.randomGRadio.UseVisualStyleBackColor = true;
            this.randomGRadio.CheckedChanged += new System.EventHandler(this.randomCheckChange);
            // 
            // randomRdRadio
            // 
            this.randomRdRadio.AutoSize = true;
            this.randomRdRadio.Location = new System.Drawing.Point(218, 22);
            this.randomRdRadio.Name = "randomRdRadio";
            this.randomRdRadio.Size = new System.Drawing.Size(49, 21);
            this.randomRdRadio.TabIndex = 4;
            this.randomRdRadio.Tag = "4";
            this.randomRdRadio.Text = "RD";
            this.randomRdRadio.UseVisualStyleBackColor = true;
            this.randomRdRadio.CheckedChanged += new System.EventHandler(this.randomCheckChange);
            // 
            // randomLdRadio
            // 
            this.randomLdRadio.AutoSize = true;
            this.randomLdRadio.Location = new System.Drawing.Point(164, 22);
            this.randomLdRadio.Name = "randomLdRadio";
            this.randomLdRadio.Size = new System.Drawing.Size(47, 21);
            this.randomLdRadio.TabIndex = 3;
            this.randomLdRadio.Tag = "3";
            this.randomLdRadio.Text = "LD";
            this.randomLdRadio.UseVisualStyleBackColor = true;
            this.randomLdRadio.CheckedChanged += new System.EventHandler(this.randomCheckChange);
            // 
            // randomRwRadio
            // 
            this.randomRwRadio.AutoSize = true;
            this.randomRwRadio.Location = new System.Drawing.Point(105, 22);
            this.randomRwRadio.Name = "randomRwRadio";
            this.randomRwRadio.Size = new System.Drawing.Size(52, 21);
            this.randomRwRadio.TabIndex = 2;
            this.randomRwRadio.Tag = "2";
            this.randomRwRadio.Text = "RW";
            this.randomRwRadio.UseVisualStyleBackColor = true;
            this.randomRwRadio.CheckedChanged += new System.EventHandler(this.randomCheckChange);
            // 
            // randomLwRadio
            // 
            this.randomLwRadio.AutoSize = true;
            this.randomLwRadio.Location = new System.Drawing.Point(49, 22);
            this.randomLwRadio.Name = "randomLwRadio";
            this.randomLwRadio.Size = new System.Drawing.Size(50, 21);
            this.randomLwRadio.TabIndex = 1;
            this.randomLwRadio.Tag = "1";
            this.randomLwRadio.Text = "LW";
            this.randomLwRadio.UseVisualStyleBackColor = true;
            this.randomLwRadio.CheckedChanged += new System.EventHandler(this.randomCheckChange);
            // 
            // randomCRadio
            // 
            this.randomCRadio.AutoSize = true;
            this.randomCRadio.Checked = true;
            this.randomCRadio.Location = new System.Drawing.Point(7, 22);
            this.randomCRadio.Name = "randomCRadio";
            this.randomCRadio.Size = new System.Drawing.Size(38, 21);
            this.randomCRadio.TabIndex = 0;
            this.randomCRadio.TabStop = true;
            this.randomCRadio.Tag = "0";
            this.randomCRadio.Text = "C";
            this.randomCRadio.UseVisualStyleBackColor = true;
            this.randomCRadio.CheckedChanged += new System.EventHandler(this.randomCheckChange);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(809, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 653);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.positionGroup);
            this.Controls.Add(this.searchGroup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createRandomBtn);
            this.Controls.Add(this.playerListBox);
            this.Controls.Add(this.exitBtn);
            this.Name = "PlayersForm";
            this.Text = "Edit/Add Players";
            this.Load += new System.EventHandler(this.PlayersForm_Load);
            this.searchGroup.ResumeLayout(false);
            this.searchGroup.PerformLayout();
            this.positionGroup.ResumeLayout(false);
            this.positionGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.ListBox playerListBox;
        private System.Windows.Forms.Button createRandomBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox searchGroup;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox positionGroup;
        private System.Windows.Forms.RadioButton randomGRadio;
        private System.Windows.Forms.RadioButton randomRdRadio;
        private System.Windows.Forms.RadioButton randomLdRadio;
        private System.Windows.Forms.RadioButton randomRwRadio;
        private System.Windows.Forms.RadioButton randomLwRadio;
        private System.Windows.Forms.RadioButton randomCRadio;
        private System.Windows.Forms.Button button2;
    }
}