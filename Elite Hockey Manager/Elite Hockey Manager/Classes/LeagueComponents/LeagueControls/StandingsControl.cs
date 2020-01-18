using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ActiveLeague.FirstConference.Sort();
            ActiveLeague.FirstConference.Reverse();

            ActiveLeague.SecondConference.Sort();
            ActiveLeague.SecondConference.Reverse();

            foreach (Team team in ActiveLeague.FirstConference)
            {
                TeamLogoStandingViewControl control = new TeamLogoStandingViewControl(team);
                control.Team.TeamStatsUpdated += UpdateLeagueStandings;
                firstConferenceLayout.Controls.Add(control);
            }
            foreach (Team team in ActiveLeague.SecondConference)
            {
                TeamLogoStandingViewControl control = new TeamLogoStandingViewControl(team);
                control.Team.TeamStatsUpdated += UpdateLeagueStandings;
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
                        //Swats the 2 controls if the team is greater than the one higher in the standings
                        panel.Controls.SetChildIndex(panel.Controls[i], i - 1);
                    }
                }
            }
        }
    }
}
