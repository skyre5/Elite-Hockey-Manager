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
            this.ForwardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.defenseLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.goalieLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // ForwardLayoutPanel
            // 
            this.ForwardLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ForwardLayoutPanel.ColumnCount = 3;
            this.ForwardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ForwardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ForwardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ForwardLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.ForwardLayoutPanel.Name = "ForwardLayoutPanel";
            this.ForwardLayoutPanel.RowCount = 4;
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ForwardLayoutPanel.Size = new System.Drawing.Size(655, 185);
            this.ForwardLayoutPanel.TabIndex = 1;
            // 
            // defenseLayoutPanel
            // 
            this.defenseLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.defenseLayoutPanel.ColumnCount = 2;
            this.defenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.defenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.defenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.defenseLayoutPanel.Location = new System.Drawing.Point(3, 194);
            this.defenseLayoutPanel.Name = "defenseLayoutPanel";
            this.defenseLayoutPanel.RowCount = 3;
            this.defenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.defenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.defenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.defenseLayoutPanel.Size = new System.Drawing.Size(435, 165);
            this.defenseLayoutPanel.TabIndex = 2;
            // 
            // goalieLayoutPanel
            // 
            this.goalieLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.goalieLayoutPanel.ColumnCount = 1;
            this.goalieLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.goalieLayoutPanel.Location = new System.Drawing.Point(3, 365);
            this.goalieLayoutPanel.Name = "goalieLayoutPanel";
            this.goalieLayoutPanel.RowCount = 2;
            this.goalieLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.goalieLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.goalieLayoutPanel.Size = new System.Drawing.Size(219, 100);
            this.goalieLayoutPanel.TabIndex = 3;
            // 
            // TeamLinesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.defenseLayoutPanel);
            this.Controls.Add(this.ForwardLayoutPanel);
            this.Controls.Add(this.goalieLayoutPanel);
            this.Name = "TeamLinesControl";
            this.Size = new System.Drawing.Size(662, 469);
            this.Load += new System.EventHandler(this.TeamLinesControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel ForwardLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel defenseLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel goalieLayoutPanel;
    }
}
