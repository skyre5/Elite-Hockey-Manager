namespace Elite_Hockey_Manager.Forms.GameForms
{
    partial class GameForm
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
        #endregion

        private Classes.GameComponents.GameControls.GameControl gameControl;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameControl = new Elite_Hockey_Manager.Classes.GameComponents.GameControls.GameControl();
            this.SuspendLayout();
            // 
            // gameControl
            // 

            this.gameControl.Location = new System.Drawing.Point(4, 12);
            this.gameControl.Name = "gameControl";
            this.gameControl.Size = new System.Drawing.Size(940, 486);
            this.gameControl.TabIndex = 0;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 564);
            this.Controls.Add(this.gameControl);
            this.Name = "GameForm";
            this.Text = "game title";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);

        }

    }
}