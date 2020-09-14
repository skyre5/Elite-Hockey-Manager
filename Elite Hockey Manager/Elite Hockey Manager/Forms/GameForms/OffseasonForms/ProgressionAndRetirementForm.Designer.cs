namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    partial class ProgressionAndRetirementForm
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
            this.playerStatsDataView = new System.Windows.Forms.DataGridView();
            this.playerStatsDisplayPanel = new System.Windows.Forms.Panel();
            this.teamSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.teamSelectionLabel = new System.Windows.Forms.Label();
            this.retirementCheckBox = new System.Windows.Forms.CheckBox();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstOverall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewOverall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // playerStatsDataView
            // 
            this.playerStatsDataView.AllowUserToAddRows = false;
            this.playerStatsDataView.AllowUserToDeleteRows = false;
            this.playerStatsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerStatsDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Player,
            this.Age,
            this.FirstOverall,
            this.NewOverall,
            this.ChangeAmount});
            this.playerStatsDataView.Location = new System.Drawing.Point(12, 12);
            this.playerStatsDataView.Name = "playerStatsDataView";
            this.playerStatsDataView.ReadOnly = true;
            this.playerStatsDataView.Size = new System.Drawing.Size(444, 480);
            this.playerStatsDataView.TabIndex = 0;
            this.playerStatsDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // playerStatsDisplayPanel
            // 
            this.playerStatsDisplayPanel.Location = new System.Drawing.Point(505, 21);
            this.playerStatsDisplayPanel.Name = "playerStatsDisplayPanel";
            this.playerStatsDisplayPanel.Size = new System.Drawing.Size(353, 415);
            this.playerStatsDisplayPanel.TabIndex = 1;
            // 
            // teamSelectionComboBox
            // 
            this.teamSelectionComboBox.FormattingEnabled = true;
            this.teamSelectionComboBox.Items.AddRange(new object[] {
            "-All-"});
            this.teamSelectionComboBox.Location = new System.Drawing.Point(76, 509);
            this.teamSelectionComboBox.Name = "teamSelectionComboBox";
            this.teamSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.teamSelectionComboBox.TabIndex = 2;
            // 
            // teamSelectionLabel
            // 
            this.teamSelectionLabel.AutoSize = true;
            this.teamSelectionLabel.Location = new System.Drawing.Point(33, 512);
            this.teamSelectionLabel.Name = "teamSelectionLabel";
            this.teamSelectionLabel.Size = new System.Drawing.Size(37, 13);
            this.teamSelectionLabel.TabIndex = 3;
            this.teamSelectionLabel.Text = "Team:";
            // 
            // retirementCheckBox
            // 
            this.retirementCheckBox.AutoSize = true;
            this.retirementCheckBox.Location = new System.Drawing.Point(305, 511);
            this.retirementCheckBox.Name = "retirementCheckBox";
            this.retirementCheckBox.Size = new System.Drawing.Size(147, 17);
            this.retirementCheckBox.TabIndex = 4;
            this.retirementCheckBox.Text = "View Retired Players Only";
            this.retirementCheckBox.UseVisualStyleBackColor = true;
            // 
            // Player
            // 
            this.Player.HeaderText = "Player";
            this.Player.Name = "Player";
            this.Player.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // FirstOverall
            // 
            this.FirstOverall.HeaderText = "First Overall";
            this.FirstOverall.Name = "FirstOverall";
            this.FirstOverall.ReadOnly = true;
            // 
            // NewOverall
            // 
            this.NewOverall.HeaderText = "NewOverall";
            this.NewOverall.Name = "NewOverall";
            this.NewOverall.ReadOnly = true;
            // 
            // ChangeAmount
            // 
            this.ChangeAmount.HeaderText = "StatsChange";
            this.ChangeAmount.Name = "ChangeAmount";
            this.ChangeAmount.ReadOnly = true;
            // 
            // ProgressionAndRetirementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 615);
            this.Controls.Add(this.retirementCheckBox);
            this.Controls.Add(this.teamSelectionLabel);
            this.Controls.Add(this.teamSelectionComboBox);
            this.Controls.Add(this.playerStatsDisplayPanel);
            this.Controls.Add(this.playerStatsDataView);
            this.Name = "ProgressionAndRetirementForm";
            this.Text = "Player Progression and Player Retirements";
            this.Load += new System.EventHandler(this.ProgressionAndRetirementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView playerStatsDataView;
        private System.Windows.Forms.Panel playerStatsDisplayPanel;
        private System.Windows.Forms.ComboBox teamSelectionComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstOverall;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewOverall;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeAmount;
        private System.Windows.Forms.Label teamSelectionLabel;
        private System.Windows.Forms.CheckBox retirementCheckBox;
    }
}