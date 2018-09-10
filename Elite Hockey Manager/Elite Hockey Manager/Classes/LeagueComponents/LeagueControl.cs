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
            lblName.Text = String.Format("{0}({1})", league.LeagueName, league.Abbreviation);
            lblTeamsCount.Text = String.Format("{0}/{1}", league.TeamCount, league.NumberOfTeams);
            if (league.IsFull())
            {
                picTeamsCheck.Image = Properties.Resources.checkmark;
                btnFillTeams.Enabled = false;
                SetupPlayerValidation();
            }
        }
        private void SetupPlayerValidation()
        {
            lblPlayersHeader.Text = String.Format("Players: {0}", _league.PlayerCount);
            int errorCount = _league.GetTeamErrorCount();
            lblPlayersCheck.Text = String.Format("Teams With Errors: {0}", errorCount);
            if (errorCount == 0)
            {
                picPlayersCheck.Image = Properties.Resources.checkmark;
            }
            else
            {
                picPlayersCheck.Image = Properties.Resources.xmark;
                btnFillPlayers.Enabled = true;
            }
        }
    }
}
