using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Forms.HelperForms;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms
{
    public partial class LeagueForm : Form
    {
        League selectedLeague = null;
        BindingList<Team> firstConference;
        BindingList<Team> secondConference;
        BindingList<League> LeagueList;

        BindingList<Team> UserCreatedTeamList;
        public LeagueForm()
        {
            InitializeComponent();
        }

        private void createLeagueBtn_Click(object sender, EventArgs e)
        {
            LeagueInfoForm leagueForm = new LeagueInfoForm();
            leagueForm.ShowDialog();
            if (leagueForm.createdLeague != null)
            {
                League newLeague = leagueForm.createdLeague;
                LeagueList.Add(newLeague);
                selectedLeague = newLeague;
            }
        }

        private void LeagueForm_Load(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.LoadListToFile<League>("LeagueData.data", out LeagueList))
            {
                MessageBox.Show("Saved player data not loaded in correctly");
            }
            if (!SaveLoadUtils.LoadListToFile<Team>("TeamData.data", out UserCreatedTeamList))
            {
                MessageBox.Show("Teams not loaded correctly");
            }
            leagueListBox.DataSource = LeagueList;
        }

        private void leagueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (leagueListBox.SelectedItem != null)
            {
                selectedLeague = (League)leagueListBox.SelectedItem;
                LoadConferences(selectedLeague);
            }
        }
        private void LoadConferences(League league)
        {
            if (league == null)
            {
                firstConference.Clear();
                secondConference.Clear();
            }
            else
            {
                List<Team> userTeamChoices = UserCreatedTeamList.Except(league.AllTeams).ToList();
                firstConference = new BindingList<Team>(league.FirstConference);
                secondConference = new BindingList<Team>(league.SecondConference);
                firstConferenceListBox.DataSource = firstConference;
                secondConferenceListBox.DataSource = secondConference;
                userTeamsListBox.DataSource = userTeamChoices;
            }

        }

        private void fillBtn_Click(object sender, EventArgs e)
        {
            if (selectedLeague != null)
            {
                selectedLeague.FillRemainingTeams();
                LoadConferences(selectedLeague);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (leagueListBox.SelectedItem != null)
            {
                LeagueList.Remove((League)leagueListBox.SelectedItem);
                LoadConferences((League)leagueListBox.SelectedItem);
            }
        }

        private void saveExitBtn_Click(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.SaveListToFile<League>("LeagueData.data", LeagueList))
            {
                MessageBox.Show("Save Failed: Check console");
            }
            else
            {
                this.Close();
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.SaveListToFile<League>("LeagueData.data", LeagueList))
            {
                MessageBox.Show("Save Failed: Check console");
            }
        }

        private void addFirstConferenceBtn_Click(object sender, EventArgs e)
        {
            if (userTeamsListBox.SelectedItem != null)
            {
            }
        }
    }
}
