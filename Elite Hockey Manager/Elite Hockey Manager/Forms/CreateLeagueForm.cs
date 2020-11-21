using Elite_Hockey_Manager.Classes;
using Elite_Hockey_Manager.Forms.HelperForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms
{
    public partial class CreateLeagueForm : Form
    {
        #region Fields

        private BindingList<Team> displayUserCreatedTeamList;
        private BindingList<Team> firstConference;
        private BindingList<League> LeagueList;
        private BindingList<Team> secondConference;
        private League selectedLeague = null;
        private BindingList<Team> UserCreatedTeamList;

        #endregion Fields

        #region Constructors

        public CreateLeagueForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void addFirstConferenceBtn_Click(object sender, EventArgs e)
        {
            if (userTeamsListBox.SelectedItem != null && selectedLeague != null)
            {
                Team addedTeam = (Team)userTeamsListBox.SelectedItem;
                AddTeamToLeague(1, firstConferenceListBox, addedTeam);
            }
        }

        private void addSecondConferenceBtn_Click(object sender, EventArgs e)
        {
            if (userTeamsListBox.SelectedItem != null && selectedLeague != null)
            {
                Team addedTeam = (Team)userTeamsListBox.SelectedItem;
                AddTeamToLeague(2, secondConferenceListBox, addedTeam);
            }
        }

        private void AddTeamToLeague(int conferenceID, ListBox conferenceListBox, Team addedTeam)
        {
            List<Team> conference;
            switch (conferenceID)
            {
                case 1:
                    conference = selectedLeague.FirstConference;
                    break;

                case 2:
                    conference = selectedLeague.SecondConference;
                    break;

                default:
                    conference = new List<Team>();
                    break;
            }
            try
            {
                selectedLeague.AddTeam(addedTeam, conferenceID);
                conferenceListBox.DataSource = null;
                conferenceListBox.DataSource = conference;
                //Doesn't select the newly entered item in listbox
                //For remove item button consistency
                conferenceListBox.ClearSelected();
                displayUserCreatedTeamList.Remove(addedTeam);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConferenceListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox == firstConferenceListBox)
            {
                secondConferenceListBox.ClearSelected();
            }
            else if (listBox == secondConferenceListBox)
            {
                firstConferenceListBox.ClearSelected();
            }
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (leagueListBox.SelectedItem != null)
            {
                LeagueList.Remove((League)leagueListBox.SelectedItem);
                LoadConferences((League)leagueListBox.SelectedItem);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillBtn_Click(object sender, EventArgs e)
        {
            if (selectedLeague != null)
            {
                selectedLeague.FillRemainingTeams();
                LoadConferences(selectedLeague);
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
                displayUserCreatedTeamList = new BindingList<Team>(UserCreatedTeamList.Except(league.AllTeams).ToList());
                firstConference = new BindingList<Team>(league.FirstConference);
                secondConference = new BindingList<Team>(league.SecondConference);
                firstConferenceListBox.DataSource = firstConference;
                secondConferenceListBox.DataSource = secondConference;
                userTeamsListBox.DataSource = displayUserCreatedTeamList;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (firstConferenceListBox.SelectedItem != null)
            {
                Team selectedTeam = (Team)firstConferenceListBox.SelectedItem;
                firstConference.Remove(selectedTeam);
                if (UserCreatedTeamList.Contains(selectedTeam))
                {
                    displayUserCreatedTeamList.Add(selectedTeam);
                }
            }
            else if (secondConferenceListBox.SelectedItem != null)
            {
                Team selectedTeam = (Team)secondConferenceListBox.SelectedItem;
                secondConference.Remove(selectedTeam);
                if (UserCreatedTeamList.Contains(selectedTeam))
                {
                    displayUserCreatedTeamList.Add(selectedTeam);
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.SaveListToFile<League>("LeagueData.data", LeagueList))
            {
                MessageBox.Show("Save Failed: Check console");
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

        #endregion Methods
    }
}