using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;
using System;
using System.Windows.Forms;

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
            Team winningTeam = game.Winner == Side.Home ? game.HomeTeam : game.AwayTeam;
            if (winningTeam == highSeedTeamPlayoffControl.Team)
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