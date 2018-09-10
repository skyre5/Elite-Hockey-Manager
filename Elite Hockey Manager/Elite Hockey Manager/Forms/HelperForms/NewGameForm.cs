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
using Elite_Hockey_Manager.Classes.LeagueComponents;

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

        private void button1_Click(object sender, EventArgs e)
        {
            League league1 = new League("Test", "Test", 32);
            LeagueControl lg1 = new LeagueControl(league1);
            flowLayoutPanel1.Controls.Add(lg1);
            league1.FillRemainingTeams();
            LeagueControl lg2 = new LeagueControl(league1);
            flowLayoutPanel1.Controls.Add(lg2);
        }
    }
}
