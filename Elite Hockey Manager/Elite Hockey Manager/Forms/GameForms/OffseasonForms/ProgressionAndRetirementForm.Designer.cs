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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.playerStatsDataView = new System.Windows.Forms.DataGridView();
            this.playerStatsDisplayPanel = new System.Windows.Forms.Panel();
            this.teamSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.teamSelectionLabel = new System.Windows.Forms.Label();
            this.retirementCheckBox = new System.Windows.Forms.CheckBox();
            this.rosterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.forwardsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rosterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playerStatsDataView
            // 
            this.playerStatsDataView.AllowUserToAddRows = false;
            this.playerStatsDataView.AllowUserToDeleteRows = false;
            this.playerStatsDataView.AllowUserToResizeColumns = false;
            this.playerStatsDataView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.playerStatsDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.playerStatsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.playerStatsDataView.DefaultCellStyle = dataGridViewCellStyle2;
            this.playerStatsDataView.Location = new System.Drawing.Point(12, 12);
            this.playerStatsDataView.Name = "playerStatsDataView";
            this.playerStatsDataView.ReadOnly = true;
            this.playerStatsDataView.RowHeadersVisible = false;
            this.playerStatsDataView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.playerStatsDataView.Size = new System.Drawing.Size(612, 480);
            this.playerStatsDataView.TabIndex = 0;
            this.playerStatsDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.playerStatsDataView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.playerStatsDataView_ColumnHeaderMouseClick);
            // 
            // playerStatsDisplayPanel
            // 
            this.playerStatsDisplayPanel.Location = new System.Drawing.Point(793, 49);
            this.playerStatsDisplayPanel.Name = "playerStatsDisplayPanel";
            this.playerStatsDisplayPanel.Size = new System.Drawing.Size(306, 409);
            this.playerStatsDisplayPanel.TabIndex = 1;
            // 
            // teamSelectionComboBox
            // 
            this.teamSelectionComboBox.FormattingEnabled = true;
            this.teamSelectionComboBox.Items.AddRange(new object[] {
            "- -"});
            this.teamSelectionComboBox.Location = new System.Drawing.Point(76, 509);
            this.teamSelectionComboBox.Name = "teamSelectionComboBox";
            this.teamSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.teamSelectionComboBox.TabIndex = 2;
            this.teamSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.teamSelectionComboBox_SelectedIndexChanged);
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
            this.retirementCheckBox.CheckedChanged += new System.EventHandler(this.retirementCheckBox_CheckedChanged);
            // 
            // rosterBindingSource
            // 
            this.rosterBindingSource.DataMember = "Roster";
            this.rosterBindingSource.DataSource = this.teamBindingSource;
            // 
            // forwardsBindingSource
            // 
            this.forwardsBindingSource.DataMember = "Forwards";
            this.forwardsBindingSource.DataSource = this.teamBindingSource;
            // 
            // teamBindingSource
            // 
            this.teamBindingSource.DataSource = typeof(Elite_Hockey_Manager.Classes.Team);
            this.teamBindingSource.CurrentChanged += new System.EventHandler(this.teamBindingSource_CurrentChanged);
            // 
            // ProgressionAndRetirementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 615);
            this.Controls.Add(this.retirementCheckBox);
            this.Controls.Add(this.teamSelectionLabel);
            this.Controls.Add(this.teamSelectionComboBox);
            this.Controls.Add(this.playerStatsDisplayPanel);
            this.Controls.Add(this.playerStatsDataView);
            this.Name = "ProgressionAndRetirementForm";
            this.Text = "Player Progression and Player Retirements";
            this.Load += new System.EventHandler(this.ProgressionAndRetirementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rosterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView playerStatsDataView;
        private System.Windows.Forms.Panel playerStatsDisplayPanel;
        private System.Windows.Forms.ComboBox teamSelectionComboBox;
        private System.Windows.Forms.Label teamSelectionLabel;
        private System.Windows.Forms.CheckBox retirementCheckBox;
        private System.Windows.Forms.BindingSource teamBindingSource;
        private System.Windows.Forms.BindingSource rosterBindingSource;
        private System.Windows.Forms.BindingSource forwardsBindingSource;
    }
}