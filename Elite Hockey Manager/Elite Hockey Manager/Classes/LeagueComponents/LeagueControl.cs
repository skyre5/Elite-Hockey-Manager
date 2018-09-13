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
    public partial class LeagueControl : UserControl
    {
        public event EventHandler SelectButtonClicked;

        private League _league;
        public League League
        {
            get
            {
                return _league;
            }
        }
        public LeagueControl(League league)
        {
            _league = league;
            InitializeComponent();

            if (league == null)
            {
                throw new NullReferenceException("League for LeagueControl componenent is null");
            }
            CheckIsLeagueFullTeams();
        }
        private void PlayerValidation()
        {
            lblPlayersHeader.Text = String.Format("Players: {0}", _league.PlayerCount);
            int errorCount = _league.GetTeamErrorCount();
            lblPlayersCheck.Text = String.Format("Teams With Errors: {0}", errorCount);
            if (errorCount == 0)
            {
                picPlayersCheck.Image = Properties.Resources.checkmark;
                btnFillPlayers.Enabled = false;
            }
            else
            {
                picPlayersCheck.Image = Properties.Resources.xmark;
                btnFillPlayers.Enabled = true;
            }
        }

        private void btnFillTeams_Click(object sender, EventArgs e)
        {
            _league.FillRemainingTeams();
            CheckIsLeagueFullTeams();
        }
        private void CheckIsLeagueFullTeams()
        {
            if (_league.IsFull())
            {
                lblName.Text = String.Format("{0}({1})", _league.LeagueName, _league.Abbreviation);
                lblTeamsCount.Text = String.Format("{0}/{1}", _league.TeamCount, _league.NumberOfTeams);
                picTeamsCheck.Image = Properties.Resources.checkmark;
                btnFillTeams.Enabled = false;
                PlayerValidation();
            }
        }

        private void btnFillPlayers_Click(object sender, EventArgs e)
        {
            _league.FillLeagueWithPlayers();
            PlayerValidation();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectButtonClicked(this, e);
        }
    }
}
