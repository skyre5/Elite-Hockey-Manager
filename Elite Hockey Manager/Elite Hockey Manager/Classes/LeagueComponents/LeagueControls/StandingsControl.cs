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
        public void LoadConferences()
        {
            //If no league is set, will not load conferences
            if (ActiveLeague == null)
            {
                return;
            }
            //Puts the names of the conference into the top of the control
            firstConfereneLabel.Text = ActiveLeague.FirstConferenceName;
            secondConferenceLabel.Text = ActiveLeague.SecondConferenceName;
            foreach (Team team in ActiveLeague.FirstConference)
            {
                TeamLogoStandingViewControl control = new TeamLogoStandingViewControl(team);
                firstConferenceLayout.Controls.Add(control);
            }
            foreach (Team team in ActiveLeague.SecondConference)
            {
                TeamLogoStandingViewControl control = new TeamLogoStandingViewControl(team);
                secondConferenceLayout.Controls.Add(control);
            }
        }
    }
}
