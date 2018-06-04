using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
