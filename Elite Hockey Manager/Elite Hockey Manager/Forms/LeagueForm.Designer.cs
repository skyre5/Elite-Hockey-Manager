namespace Elite_Hockey_Manager.Forms
{
    partial class LeagueForm
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
            this.createLeagueBtn = new System.Windows.Forms.Button();
            this.leagueListBox = new System.Windows.Forms.ListBox();
            this.fillBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.firstConferenceListBox = new System.Windows.Forms.ListBox();
            this.secondConferenceListBox = new System.Windows.Forms.ListBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.saveExitBtn = new System.Windows.Forms.Button();
            this.userTeamsListBox = new System.Windows.Forms.ListBox();
            this.addFirstConferenceBtn = new System.Windows.Forms.Button();
            this.addSecondConferenceBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createLeagueBtn
            // 
            this.createLeagueBtn.Location = new System.Drawing.Point(12, 295);
            this.createLeagueBtn.Name = "createLeagueBtn";
            this.createLeagueBtn.Size = new System.Drawing.Size(171, 35);
            this.createLeagueBtn.TabIndex = 0;
            this.createLeagueBtn.Text = "Create League";
            this.createLeagueBtn.UseVisualStyleBackColor = true;
            this.createLeagueBtn.Click += new System.EventHandler(this.createLeagueBtn_Click);
            // 
            // leagueListBox
            // 
            this.leagueListBox.FormattingEnabled = true;
            this.leagueListBox.Location = new System.Drawing.Point(12, 12);
            this.leagueListBox.Name = "leagueListBox";
            this.leagueListBox.Size = new System.Drawing.Size(282, 277);
            this.leagueListBox.TabIndex = 1;
            this.leagueListBox.SelectedIndexChanged += new System.EventHandler(this.leagueListBox_SelectedIndexChanged);
            // 
            // fillBtn
            // 
            this.fillBtn.Location = new System.Drawing.Point(190, 295);
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(104, 35);
            this.fillBtn.TabIndex = 2;
            this.fillBtn.Text = "Fill League";
            this.fillBtn.UseVisualStyleBackColor = true;
            this.fillBtn.Click += new System.EventHandler(this.fillBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(12, 337);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(171, 37);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete League";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // firstConferenceListBox
            // 
            this.firstConferenceListBox.FormattingEnabled = true;
            this.firstConferenceListBox.Location = new System.Drawing.Point(301, 12);
            this.firstConferenceListBox.Name = "firstConferenceListBox";
            this.firstConferenceListBox.Size = new System.Drawing.Size(207, 277);
            this.firstConferenceListBox.TabIndex = 4;
            // 
            // secondConferenceListBox
            // 
            this.secondConferenceListBox.FormattingEnabled = true;
            this.secondConferenceListBox.Location = new System.Drawing.Point(515, 12);
            this.secondConferenceListBox.Name = "secondConferenceListBox";
            this.secondConferenceListBox.Size = new System.Drawing.Size(207, 277);
            this.secondConferenceListBox.TabIndex = 5;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(242, 488);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(109, 23);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(127, 488);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(109, 23);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // saveExitBtn
            // 
            this.saveExitBtn.Location = new System.Drawing.Point(12, 488);
            this.saveExitBtn.Name = "saveExitBtn";
            this.saveExitBtn.Size = new System.Drawing.Size(109, 23);
            this.saveExitBtn.TabIndex = 8;
            this.saveExitBtn.Text = "Save And Exit";
            this.saveExitBtn.UseVisualStyleBackColor = true;
            this.saveExitBtn.Click += new System.EventHandler(this.saveExitBtn_Click);
            // 
            // userTeamsListBox
            // 
            this.userTeamsListBox.FormattingEnabled = true;
            this.userTeamsListBox.Location = new System.Drawing.Point(672, 295);
            this.userTeamsListBox.Name = "userTeamsListBox";
            this.userTeamsListBox.Size = new System.Drawing.Size(170, 212);
            this.userTeamsListBox.TabIndex = 9;
            // 
            // addFirstConferenceBtn
            // 
            this.addFirstConferenceBtn.Location = new System.Drawing.Point(547, 335);
            this.addFirstConferenceBtn.Name = "addFirstConferenceBtn";
            this.addFirstConferenceBtn.Size = new System.Drawing.Size(119, 40);
            this.addFirstConferenceBtn.TabIndex = 10;
            this.addFirstConferenceBtn.Text = "Add To First Conference";
            this.addFirstConferenceBtn.UseVisualStyleBackColor = true;
            this.addFirstConferenceBtn.Click += new System.EventHandler(this.addFirstConferenceBtn_Click);
            // 
            // addSecondConferenceBtn
            // 
            this.addSecondConferenceBtn.Location = new System.Drawing.Point(547, 380);
            this.addSecondConferenceBtn.Name = "addSecondConferenceBtn";
            this.addSecondConferenceBtn.Size = new System.Drawing.Size(119, 40);
            this.addSecondConferenceBtn.TabIndex = 11;
            this.addSecondConferenceBtn.Text = "Add To Second Conference";
            this.addSecondConferenceBtn.UseVisualStyleBackColor = true;
            // 
            // LeagueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 517);
            this.Controls.Add(this.addSecondConferenceBtn);
            this.Controls.Add(this.addFirstConferenceBtn);
            this.Controls.Add(this.userTeamsListBox);
            this.Controls.Add(this.saveExitBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.secondConferenceListBox);
            this.Controls.Add(this.firstConferenceListBox);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.fillBtn);
            this.Controls.Add(this.leagueListBox);
            this.Controls.Add(this.createLeagueBtn);
            this.Name = "LeagueForm";
            this.Text = "Create/Edit Leagues";
            this.Load += new System.EventHandler(this.LeagueForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createLeagueBtn;
        private System.Windows.Forms.ListBox leagueListBox;
        private System.Windows.Forms.Button fillBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListBox firstConferenceListBox;
        private System.Windows.Forms.ListBox secondConferenceListBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button saveExitBtn;
        private System.Windows.Forms.ListBox userTeamsListBox;
        private System.Windows.Forms.Button addFirstConferenceBtn;
        private System.Windows.Forms.Button addSecondConferenceBtn;
    }
}