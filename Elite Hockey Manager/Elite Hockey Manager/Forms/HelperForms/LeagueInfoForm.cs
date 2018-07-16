using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.HelperForms
{
    public partial class LeagueInfoForm : Form
    {
        public LeagueInfoForm()
        {
            InitializeComponent();
        }

        private void leagueSizeBar_Scroll(object sender, EventArgs e)
        {
            numTeamsLabel.Text = String.Format("Number of Teams: {0}", leagueSizeBar.Value);
        }

        private void LeagueInfoForm_Load(object sender, EventArgs e)
        {
            numTeamsLabel.Text = String.Format("Number of Teams: {0}", leagueSizeBar.Value);
        }
    }
}
