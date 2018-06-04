using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                foreach (string x in imageFileDialog.SafeFileNames)
                {
                    MessageBox.Show(x);
                }
            }
        }

        private void TeamForm_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(@"Files\Images"))
            {
                Directory.Delete(@"Files\Images", true);
            }
            if (File.Exists(@"Files\Images.zip"))
            {
                ZipFile.ExtractToDirectory(@"Files\Images.zip", @"Files\");
            }
            if (Directory.Exists(@"Files\Images"))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@"Files\Images");
                BuildTree(directoryInfo, imageTreeView.Nodes);
            }
            
        }
        private void BuildTree(DirectoryInfo directory, TreeNodeCollection parent)
        {
            TreeNode thisNode = parent.Add(directory.Name);
            //Finds the amount of images within that directory
            //Of type png
            int imageCount = directory.GetFiles("*.png").Length;
            if (imageCount > 0)
            {
                thisNode.Nodes.Add(String.Format("{0} Image(s)", imageCount));
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
    }
}
