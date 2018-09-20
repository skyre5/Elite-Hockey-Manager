namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    partial class TeamLinesControl
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
            this.playerLabel1 = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls.PlayerLabel();
            this.ForwardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.defenseLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.goalieLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // playerLabel1
            // 
            this.playerLabel1.AutoSize = true;
            this.playerLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.playerLabel1.Location = new System.Drawing.Point(402, 277);
            this.playerLabel1.Name = "playerLabel1";
            this.playerLabel1.Player = null;
            this.playerLabel1.Size = new System.Drawing.Size(30, 13);
            this.playerLabel1.TabIndex = 0;
            this.playerLabel1.Text = "LW1";
            this.playerLabel1.DoubleClick += new System.EventHandler(this.playerLabel_DoubleClick);
            // 
            // ForwardLayoutPanel
            // 
            this.ForwardLayoutPanel.ColumnCount = 3;
            this.ForwardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ForwardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ForwardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ForwardLayoutPanel.Location = new System.Drawing.Point(21, 42);
            this.ForwardLayoutPanel.Name = "ForwardLayoutPanel";
            this.ForwardLayoutPanel.RowCount = 4;
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.Size = new System.Drawing.Size(305, 187);
            this.ForwardLayoutPanel.TabIndex = 1;
            // 
            // defenseLayoutPanel
            // 
            this.defenseLayoutPanel.ColumnCount = 2;
            this.defenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.defenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.defenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.defenseLayoutPanel.Location = new System.Drawing.Point(332, 42);
            this.defenseLayoutPanel.Name = "defenseLayoutPanel";
            this.defenseLayoutPanel.RowCount = 3;
            this.defenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.defenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.defenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.defenseLayoutPanel.Size = new System.Drawing.Size(226, 137);
            this.defenseLayoutPanel.TabIndex = 2;
            // 
            // goalieLayoutPanel
            // 
            this.goalieLayoutPanel.ColumnCount = 1;
            this.goalieLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.goalieLayoutPanel.Location = new System.Drawing.Point(564, 42);
            this.goalieLayoutPanel.Name = "goalieLayoutPanel";
            this.goalieLayoutPanel.RowCount = 2;
            this.goalieLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.goalieLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.goalieLayoutPanel.Size = new System.Drawing.Size(133, 100);
            this.goalieLayoutPanel.TabIndex = 3;
            // 
            // TeamLinesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goalieLayoutPanel);
            this.Controls.Add(this.defenseLayoutPanel);
            this.Controls.Add(this.ForwardLayoutPanel);
            this.Controls.Add(this.playerLabel1);
            this.Name = "TeamLinesControl";
            this.Size = new System.Drawing.Size(782, 385);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LineupControls.PlayerLabel playerLabel1;
        private System.Windows.Forms.TableLayoutPanel ForwardLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel defenseLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel goalieLayoutPanel;
    }
}
