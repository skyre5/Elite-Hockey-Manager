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
            this.SuspendLayout();
            // 
            // createLeagueBtn
            // 
            this.createLeagueBtn.Location = new System.Drawing.Point(13, 13);
            this.createLeagueBtn.Name = "createLeagueBtn";
            this.createLeagueBtn.Size = new System.Drawing.Size(167, 35);
            this.createLeagueBtn.TabIndex = 0;
            this.createLeagueBtn.Text = "Create League";
            this.createLeagueBtn.UseVisualStyleBackColor = true;
            this.createLeagueBtn.Click += new System.EventHandler(this.createLeagueBtn_Click);
            // 
            // LeagueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 517);
            this.Controls.Add(this.createLeagueBtn);
            this.Name = "LeagueForm";
            this.Text = "Create/Edit Leagues";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createLeagueBtn;
    }
}