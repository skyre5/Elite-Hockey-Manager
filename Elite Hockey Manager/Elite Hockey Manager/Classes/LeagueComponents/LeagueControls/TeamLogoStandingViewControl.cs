using Elite_Hockey_Manager.Forms.GameForms;
using System;
using System.Drawing;
using System.Windows.Forms;

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
        private Point teamLabelStartingPoint;

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
            teamLabelStartingPoint = teamLabel.Location;
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
                //If the text box was previously moved left and a image is added, move the label back
                if (teamLabel.Location == logoPictureBox.Location)
                {
                    teamLabel.Location = teamLabelStartingPoint;
                }
            }
            else
            {
                //If logo is not available, move text box to the left in place of the image
                logoPictureBox.Visible = false;
                teamLabel.Location = logoPictureBox.Location;
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