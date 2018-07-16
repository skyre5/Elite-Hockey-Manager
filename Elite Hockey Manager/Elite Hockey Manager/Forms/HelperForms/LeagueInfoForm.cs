using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms.HelperForms
{
    public partial class LeagueInfoForm : Form
    {
        public League createdLeague = null;
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

        private void createLeagueButton_Click(object sender, EventArgs e)
        {
            string leagueName = leagueNameText.Text.Trim();
            string abbreviation = leagueAbbreviationText.Text.Trim();
            int numOfTeams = leagueSizeBar.Value;
            try
            {
                League newLeague = new League(leagueName, abbreviation, numOfTeams);
                createdLeague = newLeague;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error making league");
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
