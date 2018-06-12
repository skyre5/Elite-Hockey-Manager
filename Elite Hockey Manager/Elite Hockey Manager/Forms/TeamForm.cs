using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms
{
    public partial class TeamForm : Form
    {
        string currentDirectory = null;
        public TeamForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void CopyImage(string filePath)
        {
            try
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                System.IO.File.Copy(filePath, currentDirectory + fileName);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TeamForm_Load(object sender, EventArgs e)
        {
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
            DirectoryInfo directoryInfo = new DirectoryInfo(@"Files\Images");
            BuildTree(directoryInfo, imageTreeView.Nodes);
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
        private void BuildTree(DirectoryInfo directory, TreeNodeCollection parent)
        {
            TreeNode thisNode = parent.Add(directory.FullName, directory.Name);
            //Finds the amount of images within that directory
            //Of type png
            int imageCount = directory.GetFiles("*.png").Length;
            if (imageCount > 0)
            {
                thisNode.Nodes.Add("Count", String.Format("{0} Image(s)", imageCount));
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
        private void setDirectoryName(string name)
        {
            directoryLabel.Text = String.Format("Current Directory: {0}", name);
        }
        private void imageListView_DoubleClick(object sender, EventArgs e)
        {

            ListViewItem item = imageListView.SelectedItems[0];
            logoPictureBox.Image = Image.FromFile((string)item.Tag);


        }

        private void clearLogoButton_Click(object sender, EventArgs e)
        {
            logoPictureBox.Image = null;
        }

        private void openDirectoryButton_Click(object sender, EventArgs e)
        {
            if (currentDirectory != null)
            {
                Process.Start(System.IO.Path.GetFullPath(currentDirectory));
            }
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
    }
}
