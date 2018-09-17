namespace Elite_Hockey_Manager.Forms
{
    partial class CreateTeamForm
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
            this.teamListBox = new System.Windows.Forms.ListBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.addGrup = new System.Windows.Forms.GroupBox();
            this.editCloseButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.createEditButton = new System.Windows.Forms.Button();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.clearLogoButton = new System.Windows.Forms.Button();
            this.imageListView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageTreeView = new System.Windows.Forms.TreeView();
            this.importButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.imageLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.cityText = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.imageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageSystemWatcher = new System.IO.FileSystemWatcher();
            this.saveExitButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteTeamButton = new System.Windows.Forms.Button();
            this.addGrup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // teamListBox
            // 
            this.teamListBox.FormattingEnabled = true;
            this.teamListBox.Location = new System.Drawing.Point(13, 13);
            this.teamListBox.Name = "teamListBox";
            this.teamListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.teamListBox.Size = new System.Drawing.Size(206, 277);
            this.teamListBox.TabIndex = 0;
            this.teamListBox.DoubleClick += new System.EventHandler(this.teamListBox_DoubleClick);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(13, 422);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(110, 38);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit Without Saving";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // addGrup
            // 
            this.addGrup.Controls.Add(this.editCloseButton);
            this.addGrup.Controls.Add(this.resetButton);
            this.addGrup.Controls.Add(this.createEditButton);
            this.addGrup.Controls.Add(this.openDirectoryButton);
            this.addGrup.Controls.Add(this.directoryLabel);
            this.addGrup.Controls.Add(this.clearLogoButton);
            this.addGrup.Controls.Add(this.imageListView);
            this.addGrup.Controls.Add(this.imageTreeView);
            this.addGrup.Controls.Add(this.importButton);
            this.addGrup.Controls.Add(this.logoPictureBox);
            this.addGrup.Controls.Add(this.imageLabel);
            this.addGrup.Controls.Add(this.nameLabel);
            this.addGrup.Controls.Add(this.nameText);
            this.addGrup.Controls.Add(this.cityText);
            this.addGrup.Controls.Add(this.cityLabel);
            this.addGrup.Location = new System.Drawing.Point(375, 13);
            this.addGrup.Name = "addGrup";
            this.addGrup.Size = new System.Drawing.Size(563, 447);
            this.addGrup.TabIndex = 2;
            this.addGrup.TabStop = false;
            this.addGrup.Text = "Create Team";
            // 
            // editCloseButton
            // 
            this.editCloseButton.Location = new System.Drawing.Point(11, 406);
            this.editCloseButton.Name = "editCloseButton";
            this.editCloseButton.Size = new System.Drawing.Size(172, 32);
            this.editCloseButton.TabIndex = 14;
            this.editCloseButton.Text = "Exit Edit Mode";
            this.editCloseButton.UseVisualStyleBackColor = true;
            this.editCloseButton.Visible = false;
            this.editCloseButton.Click += new System.EventHandler(this.editCloseButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(190, 367);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(162, 32);
            this.resetButton.TabIndex = 13;
            this.resetButton.Text = "Reset Fields";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // createEditButton
            // 
            this.createEditButton.Location = new System.Drawing.Point(11, 367);
            this.createEditButton.Name = "createEditButton";
            this.createEditButton.Size = new System.Drawing.Size(172, 32);
            this.createEditButton.TabIndex = 12;
            this.createEditButton.Text = "Create Team";
            this.createEditButton.UseVisualStyleBackColor = true;
            this.createEditButton.Click += new System.EventHandler(this.createEditButton_Click);
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(145, 74);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(128, 23);
            this.openDirectoryButton.TabIndex = 11;
            this.openDirectoryButton.Text = "Open Current Directory";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            this.openDirectoryButton.Click += new System.EventHandler(this.openDirectoryButton_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(142, 53);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(89, 13);
            this.directoryLabel.TabIndex = 10;
            this.directoryLabel.Text = "Current Directory:";
            // 
            // clearLogoButton
            // 
            this.clearLogoButton.Location = new System.Drawing.Point(11, 237);
            this.clearLogoButton.Name = "clearLogoButton";
            this.clearLogoButton.Size = new System.Drawing.Size(128, 23);
            this.clearLogoButton.TabIndex = 9;
            this.clearLogoButton.Text = "Clear Logo";
            this.clearLogoButton.UseVisualStyleBackColor = true;
            this.clearLogoButton.Click += new System.EventHandler(this.clearLogoButton_Click);
            // 
            // imageListView
            // 
            this.imageListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.imageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.imageListView.Location = new System.Drawing.Point(319, 103);
            this.imageListView.MultiSelect = false;
            this.imageListView.Name = "imageListView";
            this.imageListView.ShowGroups = false;
            this.imageListView.Size = new System.Drawing.Size(68, 229);
            this.imageListView.SmallImageList = this.imageList;
            this.imageListView.TabIndex = 8;
            this.imageListView.TileSize = new System.Drawing.Size(1, 1);
            this.imageListView.UseCompatibleStateImageBehavior = false;
            this.imageListView.View = System.Windows.Forms.View.SmallIcon;
            this.imageListView.DoubleClick += new System.EventHandler(this.imageListView_DoubleClick);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(44, 44);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageTreeView
            // 
            this.imageTreeView.Location = new System.Drawing.Point(145, 103);
            this.imageTreeView.Name = "imageTreeView";
            this.imageTreeView.Size = new System.Drawing.Size(167, 229);
            this.imageTreeView.TabIndex = 7;
            this.imageTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.imageTreeView_AfterSelect);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(145, 338);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(128, 23);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Import Logo(s)";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.Location = new System.Drawing.Point(11, 103);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(128, 128);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 5;
            this.logoPictureBox.TabStop = false;
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Location = new System.Drawing.Point(11, 75);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(64, 13);
            this.imageLabel.TabIndex = 4;
            this.imageLabel.Text = "Team Logo:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(233, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(68, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Team Name:";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(307, 19);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(100, 20);
            this.nameText.TabIndex = 2;
            // 
            // cityText
            // 
            this.cityText.Location = new System.Drawing.Point(72, 20);
            this.cityText.Name = "cityText";
            this.cityText.Size = new System.Drawing.Size(155, 20);
            this.cityText.TabIndex = 1;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(8, 23);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(58, 13);
            this.cityLabel.TabIndex = 0;
            this.cityLabel.Text = "City Name:";
            // 
            // imageFileDialog
            // 
            this.imageFileDialog.Filter = "Images|*.png";
            this.imageFileDialog.Multiselect = true;
            // 
            // imageSystemWatcher
            // 
            this.imageSystemWatcher.EnableRaisingEvents = true;
            this.imageSystemWatcher.IncludeSubdirectories = true;
            //this.imageSystemWatcher.Path = "Files\\Images";
            this.imageSystemWatcher.SynchronizingObject = this;
            this.imageSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.imageSystemWatcherUpdate);
            this.imageSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.imageSystemWatcherUpdate);
            // 
            // saveExitButton
            // 
            this.saveExitButton.Location = new System.Drawing.Point(13, 380);
            this.saveExitButton.Name = "saveExitButton";
            this.saveExitButton.Size = new System.Drawing.Size(110, 38);
            this.saveExitButton.TabIndex = 3;
            this.saveExitButton.Text = "Save and Exit";
            this.saveExitButton.UseVisualStyleBackColor = true;
            this.saveExitButton.Click += new System.EventHandler(this.saveExitButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(13, 336);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(110, 38);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteTeamButton
            // 
            this.deleteTeamButton.Location = new System.Drawing.Point(225, 12);
            this.deleteTeamButton.Name = "deleteTeamButton";
            this.deleteTeamButton.Size = new System.Drawing.Size(110, 33);
            this.deleteTeamButton.TabIndex = 5;
            this.deleteTeamButton.Text = "Delete Team(s)";
            this.deleteTeamButton.UseVisualStyleBackColor = true;
            this.deleteTeamButton.Click += new System.EventHandler(this.deleteTeamButton_Click);
            // 
            // TeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 472);
            this.Controls.Add(this.deleteTeamButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.saveExitButton);
            this.Controls.Add(this.addGrup);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.teamListBox);
            this.Name = "TeamForm";
            this.Text = "Edit/Add Teams";
            this.Load += new System.EventHandler(this.TeamForm_Load);
            this.addGrup.ResumeLayout(false);
            this.addGrup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSystemWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox teamListBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.GroupBox addGrup;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.OpenFileDialog imageFileDialog;
        private System.Windows.Forms.TreeView imageTreeView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView imageListView;
        private System.Windows.Forms.Button clearLogoButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button openDirectoryButton;
        private System.IO.FileSystemWatcher imageSystemWatcher;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button createEditButton;
        private System.Windows.Forms.Button editCloseButton;
        private System.Windows.Forms.Button saveExitButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteTeamButton;
    }
}