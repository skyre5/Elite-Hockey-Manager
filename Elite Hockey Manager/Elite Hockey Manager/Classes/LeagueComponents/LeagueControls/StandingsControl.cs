using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public partial class StandingsControl : UserControl
    {
        public League ActiveLeague
        {
            get;
            set;
        }
        public StandingsControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// If ActiveLeague is set, will load conferences from set ActiveLeague
        /// </summary>
        public void LoadSortConferences()
        {
            //If no league is set, will not load conferences
            if (ActiveLeague == null)
            {
                return;
            }
            //If load conferences is used to sort an already loaded in league, delete all controls and remake
            if (firstConferenceLayout.Controls.Count > 0 || secondConferenceLayout.Controls.Count > 0)
            {
                firstConferenceLayout.Controls.Clear();
                secondConferenceLayout.Controls.Clear();
            }
            //Puts the names of the conference into the top of the control
            firstConfereneLabel.Text = ActiveLeague.FirstConferenceName;
            secondConferenceLabel.Text = ActiveLeague.SecondConferenceName;

            //Sorts both leagues by there record before behing placed on standings
            League.SortTeamList(ActiveLeague.FirstConference);
            League.SortTeamList(ActiveLeague.SecondConference);


            //Number of playoff teams in each of the 2 conferences
            int playoffPositionCount = ActiveLeague.PlayoffRounds.GetTotalPlayoffTeams() / 2;

            for (int i = 0; i < ActiveLeague.FirstConference.Count; i++)
            {
                Team team = ActiveLeague.FirstConference[i];
                TeamLogoStandingViewControl control = new TeamLogoStandingViewControl(team);
                control.Team.TeamStatsUpdated += UpdateLeagueStandings;

                //If the new teams control is in a playoff position, update it 
                if (i + 1 <= playoffPositionCount)
                {
                    control.UpdatePlayoffPosition(true);
                }
                //Adds control to parent group
                firstConferenceLayout.Controls.Add(control);
            }
            for (int i = 0; i < ActiveLeague.SecondConference.Count; i++)
            {
                Team team = ActiveLeague.SecondConference[i];
                TeamLogoStandingViewControl control = new TeamLogoStandingViewControl(team);
                control.Team.TeamStatsUpdated += UpdateLeagueStandings;

                //If the new teams control is in a playoff position, update it 
                if (i + 1 <= playoffPositionCount)
                {
                    control.UpdatePlayoffPosition(true);
                }
                //Adds control to parent group
                secondConferenceLayout.Controls.Add(control);
            }
        }
        private void UpdateLeagueStandings(object sender, EventArgs e)
        {
            Team team;
            try
            {
                team = (Team)sender;
                //If team is in first conference
                if (ActiveLeague.FirstConference.Contains(team))
                {
                    SortConferenceLayout(firstConferenceLayout, team);
                }
                else
                {
                    SortConferenceLayout(secondConferenceLayout, team);
                }
            }
            catch
            {
                MessageBox.Show("Failed to update team standings, invalid StandingsControl.UpdateLeagueStandings event sender");
            }
            
        }
        private void SortConferenceLayout(FlowLayoutPanel panel, Team team)
        {
            int index = -1;
            for (int i = 0; i <= panel.Controls.Count - 1; i++)
            {
                if (((TeamLogoStandingViewControl)panel.Controls[i]).Team == team)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                //Sets the standings controller to have updated record
                ((TeamLogoStandingViewControl)panel.Controls[index]).RedrawRecord();
                //Goes from team in the standings to the top swapping them if they surpass them in the standings
                //Repeats until the standings are right
                for (int i = index; i >= 1; i--)
                {
                    //If the team lower in the standings is higher than the team above it in the standings
                    if (((TeamLogoStandingViewControl)panel.Controls[i]).Team.CompareTo(
                        ((TeamLogoStandingViewControl)panel.Controls[i - 1]).Team) > 0)
                    {
                        //Swats the 2 controls if the index team is greater than the one higher in the standings
                        panel.Controls.SetChildIndex(panel.Controls[i], i - 1);

                        //If the team being swapped down is in the last playoff spot for the conference
                        //Swap the index team to a playoff team and remove playoffs from the swapped team
                        if (i - 1 == (ActiveLeague.PlayoffRounds.GetTotalPlayoffTeams() / 2) - 1)
                        {
                            //The new position that the index control is in
                            ((TeamLogoStandingViewControl)panel.Controls[i - 1]).UpdatePlayoffPosition(true);
                            //The new position of the team being swapped with the index team
                            ((TeamLogoStandingViewControl)panel.Controls[i]).UpdatePlayoffPosition(false);
                        }
                    }
                }
            }
        }
    }
}
