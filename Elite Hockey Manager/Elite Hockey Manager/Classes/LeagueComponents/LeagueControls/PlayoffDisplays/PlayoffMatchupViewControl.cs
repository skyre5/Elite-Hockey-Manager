using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;
using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays
{
    public partial class PlayoffMatchupViewControl : UserControl
    {
        #region Fields

        private PlayoffSeries _series;

        #endregion Fields

        #region Constructors

        public PlayoffMatchupViewControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public PlayoffSeries Series
        {
            get
            {
                return _series;
            }
        }

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}