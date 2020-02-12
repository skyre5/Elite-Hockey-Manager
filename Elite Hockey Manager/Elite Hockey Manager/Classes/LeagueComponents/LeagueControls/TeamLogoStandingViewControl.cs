using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Forms.GameForms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public partial class TeamLogoStandingViewControl : UserControl
    {
        public Team Team
        {
            get
            {
                return _team;
            }
            set
            {
                _team = value;
                UpdateDisplay();
            }
        }
        private Team _team = null;
        public TeamLogoStandingViewControl(Team team)
        {
            InitializeComponent();
            if (team == null)
            {
                throw new ArgumentNullException("Team entered was null in TeamLogoStandingViewControl");
            }
            Team = team; 
        }
        /// <summary>
        /// Base constructor for child class TeamLogoPlayoffViewControl to have a designer view
        /// </summary>
        public TeamLogoStandingViewControl()
        {
            InitializeComponent();
        }
        public void RedrawRecord()
        {
                teamLabel.Text = Team?.TeamNameWithRecord;

        }
        /// <summary>
        /// If the team is in the playoff their text in the label will be bold
        /// </summary>
        /// <param name="playoffs">
        /// True - In playoffs
        /// False - Out of playoffs
        /// </param>
        public void UpdatePlayoffPosition(bool playoffs)
        {
            if (playoffs)
            {
                teamLabel.Font = new Font(teamLabel.Font, FontStyle.Bold);
            }
            else
            {
                teamLabel.Font = new Font(teamLabel.Font, FontStyle.Regular);
            }
        }
        private void TeamLogoStandingViewControl_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            //Null checks the 2 displays
            if (Team?.Logo != null)
            {
                logoPictureBox.Image = Team.Logo;
            }
            teamLabel.Text = Team?.TeamNameWithRecord;
        }
        private void TeamLogoStandingViewControl_DoubleClick(object sender, EventArgs e)
        {
            if (Team != null)
            {
                ViewTeamForm form = new ViewTeamForm(Team);
                form.Show();
            }
        }
    }
}
