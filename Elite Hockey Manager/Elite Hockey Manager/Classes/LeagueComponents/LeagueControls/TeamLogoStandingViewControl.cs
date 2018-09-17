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
        private Team _team;
        public TeamLogoStandingViewControl(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("Team entered was null in TeamLogoStandingViewControl");
            }
            _team = team;
            InitializeComponent();
        }

        private void TeamLogoStandingViewControl_Load(object sender, EventArgs e)
        {
                logoPictureBox.Image = _team.Logo;
                teamLabel.Text = _team.FullName;
        }

        private void TeamLogoStandingViewControl_DoubleClick(object sender, EventArgs e)
        {
            ViewTeamForm form = new ViewTeamForm(_team);
            form.Show();
        }
    }
}
