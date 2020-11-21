using System.Drawing;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays
{
    public partial class TeamLogoPlayoffViewControl : TeamLogoStandingViewControl
    {
        #region Fields

        private int _wins = 0;

        #endregion Fields

        #region Constructors

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

        #endregion Constructors

        #region Properties

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

        #endregion Properties

        #region Methods

        //public void DenoteHigherSeedInTie()
        //{
        //    if (_wins == 4)
        //    {
        //        DisplayWinnerInSeries();
        //    }
        //    teamLabel.Text = String.Format("({0}*) - {1}", Seed, _wins, this.Team.TeamName);
        //}
        /// <summary>
        /// Turns the font bold if the team won the series by getting 4 wins
        /// </summary>
        public void DisplayWinnerInSeries()
        {
            teamLabel.Font = new Font(teamLabel.Font, FontStyle.Bold);
        }

        public void UpdateText()
        {
            if (_wins == 4)
            {
                DisplayWinnerInSeries();
            }
            teamLabel.Text = $"({Seed}) {_wins}: {this.Team.TeamName}";
        }

        #endregion Methods
    }
}