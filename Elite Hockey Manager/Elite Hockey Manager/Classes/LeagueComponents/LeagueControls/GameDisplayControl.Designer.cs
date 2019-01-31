namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    partial class GameDisplayControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewSimButton = new System.Windows.Forms.Button();
            this.autoSimButton = new System.Windows.Forms.Button();
            this.gameDisplayLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewSimButton
            // 
            this.viewSimButton.Location = new System.Drawing.Point(3, 74);
            this.viewSimButton.Name = "viewSimButton";
            this.viewSimButton.Size = new System.Drawing.Size(96, 23);
            this.viewSimButton.TabIndex = 0;
            this.viewSimButton.Text = "View Sim";
            this.viewSimButton.UseVisualStyleBackColor = true;
            this.viewSimButton.Click += new System.EventHandler(this.viewSimButton_Click);
            // 
            // autoSimButton
            // 
            this.autoSimButton.Location = new System.Drawing.Point(106, 74);
            this.autoSimButton.Name = "autoSimButton";
            this.autoSimButton.Size = new System.Drawing.Size(75, 23);
            this.autoSimButton.TabIndex = 1;
            this.autoSimButton.Text = "Auto Sim";
            this.autoSimButton.UseVisualStyleBackColor = true;
            this.autoSimButton.Click += new System.EventHandler(this.autoSimButton_Click);
            // 
            // gameDisplayLabel
            // 
            this.gameDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDisplayLabel.Location = new System.Drawing.Point(3, 2);
            this.gameDisplayLabel.Name = "gameDisplayLabel";
            this.gameDisplayLabel.Size = new System.Drawing.Size(186, 33);
            this.gameDisplayLabel.TabIndex = 2;
            this.gameDisplayLabel.Text = "Team1 @ Team2";
            this.gameDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Location = new System.Drawing.Point(0, 44);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(192, 23);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "-";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.gameDisplayLabel);
            this.Controls.Add(this.autoSimButton);
            this.Controls.Add(this.viewSimButton);
            this.Name = "GameDisplayControl";
            this.Size = new System.Drawing.Size(192, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button viewSimButton;
        private System.Windows.Forms.Button autoSimButton;
        private System.Windows.Forms.Label gameDisplayLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}
