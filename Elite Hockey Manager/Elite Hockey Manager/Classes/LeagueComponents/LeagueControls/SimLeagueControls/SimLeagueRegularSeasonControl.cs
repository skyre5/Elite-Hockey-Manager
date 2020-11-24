using System;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls
{
#if DEBUG

    public partial class SimLeagueRegularSeasonControl : SimLeagueControlMiddle
#else
        public partial class SimLeagueRegularSeasonControl : SimLeagueControl
#endif
    {
        #region Fields

        public EventHandler AdvanceLeagueStateToPlayoffs;

        #endregion Fields

        #region Constructors

        public SimLeagueRegularSeasonControl()
        {
            InitializeComponent();
            SetControlsText();
        }

        #endregion Constructors

        #region Methods

        public override void AdvanceStateButton_Click(object sender, EventArgs e)
        {
            AdvanceLeagueStateToPlayoffs(this, null);
        }

        /// <summary>
        /// Sims the remaining games from the current day and moves to the next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim1Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(1);
        }

        /// <summary>
        /// Sims 3 days
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim2Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(3);
        }

        /// <summary>
        /// Sims 1 week
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim3Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(7);
        }

        /// <summary>
        /// Sims 1 month (30 days)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim4Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(30);
        }

        /// <summary>
        /// Sims the entire remaining regular season, passes a -1 to denote the simming of the rest of the season
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim5Button_Click(object sender, EventArgs e)
        {
            //Sims entire rest of regular season
            RaiseLeagueSimmedEvent(-1);
        }

        protected override void SetControlsText()
        {
            simDisplayLabel.Text = "Sim Regular Season:";
            simFirstButton.Text = "1 Day";
            simSecondButton.Text = "3 Days";
            simThirdButton.Text = "7 Days";
            simFourthButton.Text = "30 Days";
            simFifthButton.Text = "Season";
            advanceStateButton.Text = "Advance To Playoffs";
        }

        #endregion Methods
    }
}