namespace Elite_Hockey_Manager.Forms
{
    partial class EditPlayerForm
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
            this.generalGroup = new System.Windows.Forms.GroupBox();
            this.overallLabel = new System.Windows.Forms.Label();
            this.idText = new System.Windows.Forms.TextBox();
            this.ageText = new System.Windows.Forms.TextBox();
            this.lastText = new System.Windows.Forms.TextBox();
            this.firstText = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.lastLabel = new System.Windows.Forms.Label();
            this.firstLabel = new System.Windows.Forms.Label();
            this.statsGroup = new System.Windows.Forms.GroupBox();
            this.generalGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalGroup
            // 
            this.generalGroup.Controls.Add(this.overallLabel);
            this.generalGroup.Controls.Add(this.idText);
            this.generalGroup.Controls.Add(this.ageText);
            this.generalGroup.Controls.Add(this.lastText);
            this.generalGroup.Controls.Add(this.firstText);
            this.generalGroup.Controls.Add(this.idLabel);
            this.generalGroup.Controls.Add(this.ageLabel);
            this.generalGroup.Controls.Add(this.lastLabel);
            this.generalGroup.Controls.Add(this.firstLabel);
            this.generalGroup.Location = new System.Drawing.Point(15, 15);
            this.generalGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.generalGroup.Name = "generalGroup";
            this.generalGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.generalGroup.Size = new System.Drawing.Size(351, 174);
            this.generalGroup.TabIndex = 0;
            this.generalGroup.TabStop = false;
            this.generalGroup.Text = "General Information";
            // 
            // overallLabel
            // 
            this.overallLabel.AutoSize = true;
            this.overallLabel.Location = new System.Drawing.Point(11, 154);
            this.overallLabel.Name = "overallLabel";
            this.overallLabel.Size = new System.Drawing.Size(63, 15);
            this.overallLabel.TabIndex = 8;
            this.overallLabel.Text = "Overall:";
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(203, 116);
            this.idText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idText.Name = "idText";
            this.idText.ReadOnly = true;
            this.idText.Size = new System.Drawing.Size(116, 21);
            this.idText.TabIndex = 7;
            // 
            // ageText
            // 
            this.ageText.Location = new System.Drawing.Point(203, 85);
            this.ageText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(116, 21);
            this.ageText.TabIndex = 6;
            this.ageText.Tag = "Age";
            this.ageText.Enter += new System.EventHandler(this.TextBoxEnter);
            this.ageText.Leave += new System.EventHandler(this.GeneralTextBoxLeave);
            // 
            // lastText
            // 
            this.lastText.Location = new System.Drawing.Point(203, 54);
            this.lastText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lastText.Name = "lastText";
            this.lastText.Size = new System.Drawing.Size(116, 21);
            this.lastText.TabIndex = 5;
            this.lastText.Tag = "LastName";
            this.lastText.Enter += new System.EventHandler(this.TextBoxEnter);
            this.lastText.Leave += new System.EventHandler(this.GeneralTextBoxLeave);
            // 
            // firstText
            // 
            this.firstText.Location = new System.Drawing.Point(203, 22);
            this.firstText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.firstText.Name = "firstText";
            this.firstText.Size = new System.Drawing.Size(116, 21);
            this.firstText.TabIndex = 4;
            this.firstText.Tag = "FirstName";
            this.firstText.Enter += new System.EventHandler(this.TextBoxEnter);
            this.firstText.Leave += new System.EventHandler(this.GeneralTextBoxLeave);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(8, 116);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(77, 15);
            this.idLabel.TabIndex = 3;
            this.idLabel.Text = "Player ID:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(7, 85);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(35, 15);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Age:";
            // 
            // lastLabel
            // 
            this.lastLabel.AutoSize = true;
            this.lastLabel.Location = new System.Drawing.Point(8, 54);
            this.lastLabel.Name = "lastLabel";
            this.lastLabel.Size = new System.Drawing.Size(77, 15);
            this.lastLabel.TabIndex = 1;
            this.lastLabel.Text = "Last Name:";
            // 
            // firstLabel
            // 
            this.firstLabel.AutoSize = true;
            this.firstLabel.Location = new System.Drawing.Point(8, 22);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(84, 15);
            this.firstLabel.TabIndex = 0;
            this.firstLabel.Text = "First Name:";
            // 
            // statsGroup
            // 
            this.statsGroup.Location = new System.Drawing.Point(15, 197);
            this.statsGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statsGroup.Name = "statsGroup";
            this.statsGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statsGroup.Size = new System.Drawing.Size(351, 322);
            this.statsGroup.TabIndex = 1;
            this.statsGroup.TabStop = false;
            this.statsGroup.Text = "Stats:";
            // 
            // EditPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 532);
            this.Controls.Add(this.statsGroup);
            this.Controls.Add(this.generalGroup);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditPlayerForm";
            this.Text = "editPlayerForm";
            this.Load += new System.EventHandler(this.EditPlayerForm_Load);
            this.generalGroup.ResumeLayout(false);
            this.generalGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox generalGroup;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label lastLabel;
        private System.Windows.Forms.Label firstLabel;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.TextBox ageText;
        private System.Windows.Forms.TextBox lastText;
        private System.Windows.Forms.TextBox firstText;
        private System.Windows.Forms.GroupBox statsGroup;
        private System.Windows.Forms.Label overallLabel;
    }
}