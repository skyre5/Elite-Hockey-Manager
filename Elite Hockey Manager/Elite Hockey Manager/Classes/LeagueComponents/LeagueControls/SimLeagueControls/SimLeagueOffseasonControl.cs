namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls
{
    using System;

    /// <summary>
    /// The offseason stages
    /// </summary>
    public enum OffseasonStage
    {
        /// <summary>
        /// Stage where players attributes are changed and players decide to retire from the league
        /// </summary>
        ProgressionAndRetirement,

        /// <summary>
        /// Stage where new players are drafted to teams based on talent level and attributes
        /// </summary>
        Draft,

        /// <summary>
        /// Stage where players may choose to sign contracts with their team from the prior season
        /// </summary>
        Resign,

        /// <summary>
        /// Stage where players without contracts may join a new team
        /// </summary>
        FreeAgency
    }

#if DEBUG

    /// <summary>
    /// The sim league offseason control
    /// </summary>
    public partial class SimLeagueOffseasonControl : SimLeagueControlMiddle
#else
        public partial class SimLeagueOffseasonControl : SimLeagueControl
#endif
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SimLeagueOffseasonControl"/> class.
        /// </summary>
        public SimLeagueOffseasonControl()
        {
            this.InitializeComponent();
            this.UpdateTitle();
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Event for advancing from the offseason to the regular season
        /// </summary>
        public event Action AdvanceToRegularSeasonEvent;

        /// <summary>
        /// Event to trigger opening one of the offseason stages form
        /// </summary>
        public event Action<OffseasonStage> OpenStageFormEvent;

        /// <summary>
        /// Event for simulating through all remaining stages
        /// </summary>
        public event Action SimAllStagesEvent;

        /// <summary>
        /// Event for advancing to the next offseason stage
        /// </summary>
        public event Action StageAdvancedEvent;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets the current OffseasonStage of the control
        /// </summary>
        public OffseasonStage StageIndex
        {
            get;
            private set;
        }
            = 0;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Advances the offseason to the regular season
        /// </summary>
        /// <param name="sender">button sender</param>
        /// <param name="e">event args</param>
        public override void AdvanceStateButton_Click(object sender, EventArgs e)
        {
            this.AdvanceToRegularSeasonEvent?.Invoke();
        }

        /// <summary>
        /// Resets the control to its initial state and display
        /// Resets stage index and hides advance to regular season button
        /// </summary>
        public void ResetControl()
        {
            this.StageIndex = OffseasonStage.ProgressionAndRetirement;
            this.UpdateTitle();
            advanceStateButton.Visible = false;
            advanceStateButton.Enabled = false;
        }

        /// <summary>
        /// Opens form for the corresponding offseason stage
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">event args</param>
        public override void Sim1Button_Click(object sender, EventArgs e)
        {
            this.OpenStageFormEvent?.Invoke(this.StageIndex);
        }

        /// <summary>
        /// Sims to the next stage of the offseason, retirement, draft, signings, etc...
        /// Denoted by the sending of a -1 to signal a sim to the next offseason stage
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">event args</param>
        public override void Sim2Button_Click(object sender, EventArgs e)
        {
            // If the stage index is not the final stage before the next season which is free agency, advange to the next stage within the enum OffseasonStage
            if (this.StageIndex != OffseasonStage.FreeAgency)
            {
                this.StageIndex++;
                this.UpdateTitle();
                if (this.StageIndex == OffseasonStage.FreeAgency)
                {
                    advanceStateButton.Visible = true;
                    advanceStateButton.Enabled = true;
                }

                this.StageAdvancedEvent?.Invoke();
            }
        }

        /// <summary>
        /// Simulates the remaining stages of offseason
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">event args</param>
        public override void Sim3Button_Click(object sender, EventArgs e)
        {
            // If the stage advance event isn't set, then the offseason cannot be simmed
            if (this.StageAdvancedEvent == null)
            {
                return;
            }

            while (this.StageIndex != OffseasonStage.FreeAgency)
            {
                this.StageIndex++;
                this.StageAdvancedEvent?.Invoke();
            }

            this.UpdateTitle();
            advanceStateButton.Visible = true;
            advanceStateButton.Enabled = true;
        }

        /// <summary>
        /// Updates the title label within the control to reflect current offseason stage
        /// </summary>
        private void UpdateTitle()
        {
            this.stageLabel.Text = $@"Stage: {this.StageIndex}";
        }

        #endregion Methods
    }
}