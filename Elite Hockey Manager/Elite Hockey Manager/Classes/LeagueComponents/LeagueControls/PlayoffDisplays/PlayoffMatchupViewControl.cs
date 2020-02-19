using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays
{
    public partial class PlayoffMatchupViewControl : UserControl
    {
        public PlayoffSeries Series
        {
            get
            {
                return _series;
            }
        }
        private PlayoffSeries _series;
        public PlayoffMatchupViewControl()
        {
            InitializeComponent();
        }
        public void UpdateDisplayByManualUserSim(object obj, EventArgs e)
        {
            Game game = (Game)obj;
            if (game.Winner == Side.Home)
            {
                highSeedTeamPlayoffControl.Wins++;
                highSeedTeamPlayoffControl.UpdateText();
            }
            else
            {
                lowSeedTeamPlayoffControl.Wins++;
                lowSeedTeamPlayoffControl.UpdateText();
            }
        }
        public void SetSeries(PlayoffSeries series)
        {
            _series = series;
            highSeedTeamPlayoffControl.Team = series.HighSeedTeam;
            highSeedTeamPlayoffControl.Seed = series.HighSeed;
            highSeedTeamPlayoffControl.Wins = series.HighWins;
            highSeedTeamPlayoffControl.UpdateText();
            lowSeedTeamPlayoffControl.Team = series.LowSeedTeam;
            lowSeedTeamPlayoffControl.Seed = series.LowSeed;
            lowSeedTeamPlayoffControl.Wins = series.LowWins;
            lowSeedTeamPlayoffControl.UpdateText();
        }
    }
}
