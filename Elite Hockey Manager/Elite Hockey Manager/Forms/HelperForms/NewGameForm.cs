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
using Elite_Hockey_Manager.Forms.GameForms;

namespace Elite_Hockey_Manager.Forms.HelperForms
{
    public partial class NewGameForm : Form
    {
        public NewGameForm()
        {
            InitializeComponent();
        }

        private void newLeagueButton_Click(object sender, EventArgs e)
        {
            LeagueInfoForm newTeamForm = new LeagueInfoForm();
            newTeamForm.ShowDialog();
            if (newTeamForm.createdLeague != null)
            {
                League league = newTeamForm.createdLeague;
                league.FillRemainingTeams();
                league.FillLeagueWithPlayers();
                MainMenuForm gameForm = new MainMenuForm(league);
                gameForm.Show();
                this.Close();
            }
        }
    }
}
