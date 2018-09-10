namespace Elite_Hockey_Manager.Forms.HelperForms
{
    partial class NewGameForm
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
            this.newLeagueButton = new System.Windows.Forms.Button();
            this.loadLeagueButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newLeagueButton
            // 
            this.newLeagueButton.Location = new System.Drawing.Point(13, 13);
            this.newLeagueButton.Name = "newLeagueButton";
            this.newLeagueButton.Size = new System.Drawing.Size(152, 44);
            this.newLeagueButton.TabIndex = 0;
            this.newLeagueButton.Text = "Create New League";
            this.newLeagueButton.UseVisualStyleBackColor = true;
            this.newLeagueButton.Click += new System.EventHandler(this.newLeagueButton_Click);
            // 
            // loadLeagueButton
            // 
            this.loadLeagueButton.Location = new System.Drawing.Point(13, 64);
            this.loadLeagueButton.Name = "loadLeagueButton";
            this.loadLeagueButton.Size = new System.Drawing.Size(152, 48);
            this.loadLeagueButton.TabIndex = 1;
            this.loadLeagueButton.Text = "Load Existing League";
            this.loadLeagueButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 119);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(495, 220);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.loadLeagueButton);
            this.Controls.Add(this.newLeagueButton);
            this.Name = "NewGameForm";
            this.Text = "Create New Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newLeagueButton;
        private System.Windows.Forms.Button loadLeagueButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}