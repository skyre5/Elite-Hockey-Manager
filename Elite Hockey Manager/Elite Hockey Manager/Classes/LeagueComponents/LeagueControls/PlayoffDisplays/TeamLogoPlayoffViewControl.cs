using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays
{
    public partial class TeamLogoPlayoffViewControl : TeamLogoStandingViewControl
    {
        public int Seed
        {
            get;
            set;
        }
        public int Wins
        {
            get
            {
                return _wins;
            }
            set
            {
                _wins = value;
            }
        }
        private int _wins = 0;
        public TeamLogoPlayoffViewControl() : base()
        {
            InitializeComponent();
        }
        public TeamLogoPlayoffViewControl(Team team, int playoffSeed) : base(team)
        {
            InitializeComponent();
            Seed = playoffSeed;
            UpdateText();
        }

        public void UpdateText()
        {
            teamLabel.Text = String.Format("({0}) {1}: {2}", Seed, _wins,  this.Team.TeamName);
        }
        public void DenoteHigherSeedInTie()
        {
            teamLabel.Text = String.Format("({0}*) - {1}", Seed, _wins, this.Team.TeamName);
        }
    }
}
