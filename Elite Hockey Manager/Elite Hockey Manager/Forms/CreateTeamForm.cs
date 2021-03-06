﻿using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms
{
    public partial class CreateTeamForm : Form
    {
        #region Fields

        private string currentDirectory = null;
        private Team selectedTeam = null;
        private BindingList<Team> teamList;

        #endregion Fields

        #region Constructors

        public CreateTeamForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void BuildTree(DirectoryInfo directory, TreeNodeCollection parent)
        {
            TreeNode thisNode = parent.Add(directory.FullName, directory.Name);
            //Finds the amount of images within that directory
            //Of type png
            int imageCount = directory.GetFiles("*.png").Length;
            if (imageCount > 0)
            {
                thisNode.Nodes.Add("Count", $"{imageCount} Image(s)");
            }
            //Shows all the file names of the current directory
            /*foreach (FileInfo file in directory.GetFiles())
            {
                thisNode.Nodes.Add(file.FullName, file.Name);
            }*/
            //Recursively will show all directories within the base directory
            foreach (DirectoryInfo subdir in directory.GetDirectories())
            {
                BuildTree(subdir, thisNode.Nodes);
            }
        }

        private void clearLogoButton_Click(object sender, EventArgs e)
        {
            logoPictureBox.Image = null;
        }

        private void CopyImage(string filePath)
        {
            try
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                System.IO.File.Copy(filePath, currentDirectory + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createEditButton_Click(object sender, EventArgs e)
        {
            if (selectedTeam == null)
            {
                CreateTeam();
            }
            //Team is being edited
            else
            {
                string location = selectedTeam.Location;
                string teamName = selectedTeam.TeamName;
                string logoPath = selectedTeam.LogoPath;
                try
                {
                    selectedTeam.Location = cityText.Text;
                    selectedTeam.TeamName = nameText.Text;
                    if (logoPictureBox.Image == null || logoPictureBox.Image.Tag != null)
                    {
                        selectedTeam.LogoPath = GetImagePath();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Edit failed: " + ex.Message);
                    //Assigns the values that were initially present back to the team
                    selectedTeam.Location = location;
                    cityText.Text = location;

                    selectedTeam.TeamName = teamName;
                    nameText.Text = teamName;

                    selectedTeam.LogoPath = logoPath;
                    logoPictureBox.Image = selectedTeam.Logo;
                }
            }
        }

        private void CreateTeam()
        {
            string location = cityText.Text;
            string teamName = nameText.Text;
            Team newTeam;
            try
            {
                string imagePath = GetImagePath();
                if (imagePath == null)
                {
                    newTeam = new Team(location, teamName);
                }
                else
                {
                    newTeam = new Team(location, teamName, imagePath);
                }
                teamList.Add(newTeam);
                resetTeamGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteTeamButton_Click(object sender, EventArgs e)
        {
            List<Team> deleteList = teamListBox.SelectedItems.Cast<Team>().ToList();
            foreach (Team x in deleteList)
            {
                teamList.Remove(x);
            }
            if (selectedTeam != null)
            {
                if (!teamList.Contains(selectedTeam))
                {
                    resetTeamGroup();
                    selectedTeam = null;
                    //Should be written into a function instead
                    editCloseButton.PerformClick();
                }
            }
        }

        private void editCloseButton_Click(object sender, EventArgs e)
        {
            selectedTeam = null;
            editCloseButton.Visible = false;
            createEditButton.Text = "Create Team";
            resetTeamGroup();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetImagePath()
        {
            Uri basePath = new Uri(Directory.GetCurrentDirectory() + @"\Files");
            if (logoPictureBox.Image == null || logoPictureBox.Image.Tag == null)
            {
                return null;
            }
            else
            {
                Uri imagePath = new Uri((string)logoPictureBox.Image.Tag);
                string relPath = basePath.MakeRelativeUri(imagePath).ToString();
                return relPath;
            }
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            //System.IO.File.Copy("Source", "Destination");
            if (imageFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in imageFileDialog.FileNames)
                {
                    CopyImage(filePath);
                }
            }
        }

        private void imageListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = imageListView.SelectedItems[0];
            logoPictureBox.Image = Image.FromFile((string)item.Tag);
            logoPictureBox.Image.Tag = item.Tag;
        }

        private void imageSystemWatcherUpdate(object sender, FileSystemEventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"Files\Images");
            imageTreeView.Nodes.Clear();
            BuildTree(directoryInfo, imageTreeView.Nodes);

            //Expands the top level of the treeview
            imageTreeView.TopNode.Expand();
            LoadImagesFromDirectory(currentDirectory);
        }

        private void imageTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = imageTreeView.SelectedNode;
            if (node.Name == "Count")
            {
                setDirectoryName(node.Parent.Text);
                LoadImagesFromDirectory(node.Parent.Name);
            }
            else
            {
                setDirectoryName(node.Text);
                LoadImagesFromDirectory(node.Name);
            }
        }

        private void LoadImagesFromDirectory(string path)
        {
            currentDirectory = path + @"/";
            imageList.Images.Clear();
            imageListView.Clear();
            if (!String.IsNullOrWhiteSpace(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] files = directoryInfo.GetFiles("*.png");
                int i = 0;
                foreach (FileInfo file in files)
                {
                    Image image = Image.FromFile(file.FullName);
                    imageList.Images.Add(image);

                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = i++;
                    item.Tag = file.FullName;
                    imageListView.Items.Add(item);
                }
            }
        }

        private void LoadTreeView()
        {
            if (!Directory.Exists(@"Files\Images"))
            {
                try
                {
                    ZipFile.ExtractToDirectory(@"Files\Images.zip", @"Files\");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (!Directory.Exists(@"Files\Images"))
            {
                System.IO.Directory.CreateDirectory(@"Files\Images");
            }
            this.imageSystemWatcher.Path = "Files\\Images";
            DirectoryInfo directoryInfo = new DirectoryInfo(@"Files\Images");
            BuildTree(directoryInfo, imageTreeView.Nodes);
        }

        private void openDirectoryButton_Click(object sender, EventArgs e)
        {
            if (currentDirectory != null)
            {
                Process.Start(System.IO.Path.GetFullPath(currentDirectory));
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetTeamGroup();
        }

        private void resetTeamGroup()
        {
            cityText.Clear();
            nameText.Clear();
            logoPictureBox.Image = null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.SaveListToFile<Team>("TeamData.data", teamList))
            {
                MessageBox.Show("Save Failed");
            }
        }

        private void saveExitButton_Click(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.SaveListToFile<Team>("TeamData.data", teamList))
            {
                MessageBox.Show("Save Failed");
            }
            else
            {
                this.Close();
            }
        }

        private void setDirectoryName(string name)
        {
            directoryLabel.Text = $"Current Directory: {name}";
        }

        private void TeamForm_Load(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.LoadListToFile<Team>("TeamData.data", out teamList))
            {
                MessageBox.Show("Saved team data not loaded in correctly");
            }
            teamListBox.DataSource = teamList;
            LoadTreeView();
            //If the default folder is found load it
            if (Directory.Exists(@"Files/Images/Default"))
            {
                LoadImagesFromDirectory(@"Files/Images/Default");
                setDirectoryName("Default");
            }
            else
            {
                LoadImagesFromDirectory(imageTreeView.TopNode.Name);
                setDirectoryName(imageTreeView.TopNode.Text);
            }

            //Expands the top level of the treeview
            imageTreeView.TopNode.Expand();
        }

        private void teamListBox_DoubleClick(object sender, EventArgs e)
        {
            createEditButton.Text = "Save Changes";
            editCloseButton.Visible = true;
            selectedTeam = (Team)teamListBox.SelectedItem;
            if (selectedTeam != null)
            {
                cityText.Text = selectedTeam.Location;
                nameText.Text = selectedTeam.TeamName;
                if (selectedTeam.LogoPath != null)
                {
                    logoPictureBox.Image = selectedTeam.Logo;
                }
                else
                {
                    logoPictureBox.Image = null;
                }
            }
        }

        #endregion Methods
    }
}