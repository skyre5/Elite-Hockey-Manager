using Elite_Hockey_Manager.Classes;
using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.HelperForms
{
    public partial class LeagueInfoForm : Form
    {
        #region Fields

        public League createdLeague = null;

        #endregion Fields

        #region Constructors

        public LeagueInfoForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

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

        private void LeagueInfoForm_Load(object sender, EventArgs e)
        {
            numTeamsLabel.Text = $"Number of Teams: {leagueSizeBar.Value}";
        }

        private void leagueSizeBar_Scroll(object sender, EventArgs e)
        {
            numTeamsLabel.Text = $"Number of Teams: {leagueSizeBar.Value}";
        }

        #endregion Methods
    }
}