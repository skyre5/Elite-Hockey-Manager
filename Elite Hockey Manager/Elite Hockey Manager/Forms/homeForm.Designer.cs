namespace Elite_Hockey_Manager
{
    partial class homeForm
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
            this.playersBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.teamsButton = new System.Windows.Forms.Button();
            this.leagueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playersBtn
            // 
            this.playersBtn.Location = new System.Drawing.Point(357, 413);
            this.playersBtn.Margin = new System.Windows.Forms.Padding(2);
            this.playersBtn.Name = "playersBtn";
            this.playersBtn.Size = new System.Drawing.Size(110, 37);
            this.playersBtn.TabIndex = 0;
            this.playersBtn.Text = "Add/Edit Custom Players";
            this.playersBtn.UseVisualStyleBackColor = true;
            this.playersBtn.Click += new System.EventHandler(this.playersBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // teamsButton
            // 
            this.teamsButton.Location = new System.Drawing.Point(357, 371);
            this.teamsButton.Name = "teamsButton";
            this.teamsButton.Size = new System.Drawing.Size(110, 37);
            this.teamsButton.TabIndex = 2;
            this.teamsButton.Text = "Add/Edit Custom Teams";
            this.teamsButton.UseVisualStyleBackColor = true;
            this.teamsButton.Click += new System.EventHandler(this.teamsButton_Click);
            // 
            // leagueButton
            // 
            this.leagueButton.Location = new System.Drawing.Point(357, 328);
            this.leagueButton.Name = "leagueButton";
            this.leagueButton.Size = new System.Drawing.Size(110, 37);
            this.leagueButton.TabIndex = 3;
            this.leagueButton.Text = "Add/Edit Leagues";
            this.leagueButton.UseVisualStyleBackColor = true;
            this.leagueButton.Click += new System.EventHandler(this.leagueButton_Click);
            // 
            // homeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 556);
            this.Controls.Add(this.leagueButton);
            this.Controls.Add(this.teamsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playersBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "homeForm";
            this.Text = "Elite Hockey Manager - Home";
            this.Load += new System.EventHandler(this.homeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playersBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button teamsButton;
        private System.Windows.Forms.Button leagueButton;
    }
}

