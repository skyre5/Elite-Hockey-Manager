namespace Elite_Hockey_Manager.Forms.GameForms
{
    sealed partial class PlayerStatsForm
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
            this.playerStatsDataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.teamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teamSelectLabel = new System.Windows.Forms.Label();
            this.teamSelectionComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playerStatsDataGridView
            // 
            this.playerStatsDataGridView.AllowUserToAddRows = false;
            this.playerStatsDataGridView.AllowUserToDeleteRows = false;
            this.playerStatsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerStatsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.playerStatsDataGridView.Name = "playerStatsDataGridView";
            this.playerStatsDataGridView.ReadOnly = true;
            this.playerStatsDataGridView.Size = new System.Drawing.Size(934, 542);
            this.playerStatsDataGridView.TabIndex = 0;
            // 
            // teamBindingSource
            // 
            this.teamBindingSource.DataSource = typeof(Elite_Hockey_Manager.Classes.Team);
            // 
            // teamSelectLabel
            // 
            this.teamSelectLabel.AutoSize = true;
            this.teamSelectLabel.Location = new System.Drawing.Point(12, 561);
            this.teamSelectLabel.Name = "teamSelectLabel";
            this.teamSelectLabel.Size = new System.Drawing.Size(70, 13);
            this.teamSelectLabel.TabIndex = 1;
            this.teamSelectLabel.Text = "Team Select:";
            // 
            // teamSelectionComboBox
            // 
            this.teamSelectionComboBox.FormattingEnabled = true;
            this.teamSelectionComboBox.Items.AddRange(new object[] {
            "- -"});
            this.teamSelectionComboBox.Location = new System.Drawing.Point(88, 558);
            this.teamSelectionComboBox.Name = "teamSelectionComboBox";
            this.teamSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.teamSelectionComboBox.TabIndex = 2;
            this.teamSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.TeamSelectionComboBox_SelectedIndexChanged);
            // 
            // PlayerStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 597);
            this.Controls.Add(this.teamSelectionComboBox);
            this.Controls.Add(this.teamSelectLabel);
            this.Controls.Add(this.playerStatsDataGridView);
            this.Name = "PlayerStatsForm";
            this.Text = "PlayerStatsForm";
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView playerStatsDataGridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource teamBindingSource;
        private System.Windows.Forms.Label teamSelectLabel;
        private System.Windows.Forms.ComboBox teamSelectionComboBox;
    }
}