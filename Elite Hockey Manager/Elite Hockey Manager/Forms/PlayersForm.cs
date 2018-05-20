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
    public partial class PlayersForm : Form
    {
        int randomChoice = 0;
        public PlayersForm()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {

        }

        private void randomCheckChange(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            string tag = (string)button.Tag;
            try
            {
                randomChoice = int.Parse(tag);
                
            }
            catch (Exception ex)
            {
                randomChoice = -1;
                Console.WriteLine(ex);
                Console.WriteLine("Error: invalid tag was entered " + tag);
            }
        }

        private void createRandomBtn_Click(object sender, EventArgs e)
        {
            if (randomChoice == -1)
            {
                MessageBox.Show("Invalid choice, Select one of the positions");
                return;
            }

        }
    }
}
