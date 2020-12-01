namespace Elite_Hockey_Manager.Forms.GameForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;

    using Elite_Hockey_Manager.Classes;
    using Elite_Hockey_Manager.Classes.GameComponents;
    using Elite_Hockey_Manager.Classes.LeagueComponents;
    using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls;
    using Elite_Hockey_Manager.Forms.GameForms.OffseasonForms;

    /// <summary>
    /// The main menu form. Where the majority of the game will take place
    /// </summary>
    public partial class MainMenuForm : Form
    {
        #region Fields

        /// <summary>
        /// The games to sim.
        /// </summary>
        private int gamesToSim;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuForm"/> class.
        /// </summary>
        /// <param name="league">
        /// The league.
        /// </param>
        public MainMenuForm(League league)
        {
            this.InitializeComponent();
            League = league;

            // Events for stats menu clicks
            this.currentSeasonPlayerStatsMenuItem.Click += (o, e) => this.PlayerStatsMenuItem_Click(o, e, false);
            this.allTimePlayerStatsMenuItem.Click += (o, e) => this.PlayerStatsMenuItem_Click(o, e, true);

            // Opens the player stats form when the open stats form button is pressed on the stats control
            this.leagueLeadersStatsControl.OpenStatsPageEvent += () => this.PlayerStatsMenuItem_Click(null, null, false);

            this.currentSeasonTeamStatsMenuItem.Click += (o, e) => this.TeamStatsMenuItem_Click(o, e, false);
            this.allTimeTeamStatsMenuItem.Click += (o, e) => this.TeamStatsMenuItem_Click(o, e, true);

            // Adds the doWork function in league the background worker in the MainMenuForm for multi-threading
            this.simLeagueBackgroundWorker.DoWork += league.SimLeagueDoWork;

            // Events for switch from regular season to playoffs
            this.simLeagueRegularSeasonControl.AdvanceLeagueStateToPlayoffs += (o, e) => League.AdvanceToPlayoffs();
            this.simLeagueRegularSeasonControl.AdvanceLeagueStateToPlayoffs += (o, e) => this.ChangeLayoutToPlayoffs();

            // Sim events from the simLeaguePlayoffControl will go to the main menus SimPlayoffs function
            this.simLeaguePlayoffControl.LeagueSimmedEvent += this.SimPlayoffs;

            // Background worker for playoff will use Playoff.SimPlayoffsDoWork function
            this.simPlayoffBackgroundWorker.DoWork += (o, args) =>
            {
                League.currentPlayoff.SimPlayoffsDoWork(o, args);
            };

            // Events for switch from playoffs to offseason
            this.simLeaguePlayoffControl.AdvanceLeagueStateToOffseason += (o, e) => League.AdvanceToOffseason();
            this.simLeaguePlayoffControl.AdvanceLeagueStateToOffseason += (o, e) => this.ChangeLayoutToOffseason();

            // Events for off-season control
            this.simLeagueOffseasonControl1.OpenStageFormEvent += this.SimLeagueOffseasonControl1_OpenStageFormEvent;
            this.simLeagueOffseasonControl1.StageAdvancedEvent += () =>
                {
                    switch (simLeagueOffseasonControl1.StageIndex)
                    {
                        case OffseasonStage.Resign:
                        {
                            if (!League.CurrentDraft.DoneDrafting)
                            {
                                League.CurrentDraft.SimDraft();
                            }

                            League.SimulateResignPhase();
                            break;
                        }

                        case OffseasonStage.FreeAgency:
                            League.SimulateFreeAgencyPhase();
                            break;
                    }
                };
            this.simLeagueOffseasonControl1.AdvanceToRegularSeasonEvent += () =>
            {
                League.AdvanceToRegularSeason();
                ChangeLayoutToRegularSeason();
            };
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the league.
        /// </summary>
        public League League { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Changes the layout of this form to match a view displaying offseason controls
        /// </summary>
        private void ChangeLayoutToOffseason()
        {
            this.playoffDisplayControl.Visible = false;
            this.simLeaguePlayoffControl.Visible = false;
            this.simLeaguePlayoffControl.SetAdvanceStateButton(false);
            this.simLeagueOffseasonControl1.Visible = true;
        }

        /// <summary>
        /// Changes the layout of this form to match a view displaying playoff controls
        /// </summary>
        private void ChangeLayoutToPlayoffs()
        {
            this.standingsControl.Visible = false;
            this.standingsControl.Enabled = false;

            this.leagueLeadersStatsControl.InsertPlayerList(League.currentPlayoff.GetAllPlayoffPlayers().ToArray());

            this.playoffDisplayControl.Visible = true;
            this.playoffDisplayControl.Enabled = true;
            this.playoffDisplayControl.League = this.League;
            this.playoffDisplayControl.UpdatePlayoffs();

            this.simLeagueRegularSeasonControl.Visible = false;
            this.simLeagueRegularSeasonControl.Enabled = false;
            this.simLeagueRegularSeasonControl.SetAdvanceStateButton(false);

            this.simLeaguePlayoffControl.Visible = true;
            this.simLeaguePlayoffControl.Enabled = true;

            this.simProgressBar.Visible = false;
            this.simProgressBar.Enabled = false;

            Playoff playoff = League.currentPlayoff;
            this.leagueGamesDisplay.SetSchedule(playoff.GetCurrentPlayoffGames());
            this.leagueGamesDisplay.SetPlayoffRoundAndDay(playoff.CurrentRound, playoff.CurrentDay);
            this.leagueGamesDisplay.LinkPlayoffMatchupViewControlEvents(this.playoffDisplayControl.GetActivePlayoffMatchupViewControls(playoff.CurrentRound));
        }

        /// <summary>
        /// Changes the layout of this form to match a view displaying regular season controls
        /// </summary>
        private void ChangeLayoutToRegularSeason()
        {
            // Resets the controls behavior so that the next time it appears it will begin at the first offseason stage
            this.simLeagueOffseasonControl1.ResetControl();
            this.simLeagueOffseasonControl1.Visible = false;
            this.simLeagueRegularSeasonControl.Visible = true;
            this.simLeagueRegularSeasonControl.Enabled = true;
            this.standingsControl.Visible = true;
            this.simLeagueRegularSeasonControl.Visible = true;
            this.leagueGamesDisplay.Visible = true;
            this.standingsControl.Enabled = true;
            this.leagueGamesDisplay.SetSchedule(League.LeagueSchedule.SeasonSchedule[League.DayIndex]);
            this.leagueGamesDisplay.SetDay(League.DayIndex + 1);
            this.leagueLeadersStatsControl.InsertPlayerList(League.SignedPlayers.ToArray());

            // Updates the display of the standings to all the teams with their 0-0-0 records
            this.standingsControl.LoadSortConferences();
            this.simProgressBar.Visible = true;
            this.simProgressBar.Enabled = true;
        }

        /// <summary>
        /// Loads the content into the form when the form is loaded into view
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            this.Text = $@"{League.LeagueName} - Home";
            this.standingsControl.ActiveLeague = League;

            // If this is a new league being loaded, create a schedule and set state to regular season
            if (League.State == LeagueState.Unset)
            {
                League.StartSeason();
            }

            this.standingsControl.LoadSortConferences();
            this.leagueGamesDisplay.SetSchedule(League.DayIndex >= League.LeagueSchedule.SeasonSchedule.Count
                                                    ? new List<Game>()
                                                    : League.LeagueSchedule.SeasonSchedule[League.DayIndex]);

            // Offsets the variable which is base 0 to the respective day it corresponds to. Day 0 to 1...
            this.leagueGamesDisplay.SetDay(League.DayIndex + 1);

            // Sets the statsControls list of player that will be sorted by their statistics, displays league leaders for each category
            this.leagueLeadersStatsControl.InsertPlayerList(League.SignedPlayers.ToArray());
            this.simLeagueRegularSeasonControl.LeagueSimmedEvent += this.SimLeague;
        }

        /// <summary>
        /// Event handler for the player stats selections in the menu
        /// </summary>
        /// <param name="sender">Menu item that the user clicked on</param>
        /// <param name="e">event args</param>
        /// <param name="allTime">Whether the form will load all time stats or current season stats</param>
        private void PlayerStatsMenuItem_Click(object sender, EventArgs e, bool allTime)
        {
            PlayerStatsForm form = new PlayerStatsForm(League, allTime);
            form.ShowDialog();
        }

        /// <summary>
        /// Simulates the league given a certain amount of days to move forward in the schedule
        /// </summary>
        /// <param name="days">
        /// Number of days that will be simulated ahead, at least 1 game occurs on each day until the schedule is finished
        /// </param>
        private void SimLeague(int days)
        {
            if (!this.simLeagueBackgroundWorker.IsBusy)
            {
                // League.SimLeague(days);
                this.gamesToSim = League.LeagueSchedule.RemainingGamesToSim(League.DayIndex, days);
                this.simProgressBar.Maximum = this.gamesToSim;
                this.simProgressLabel.Text = $@"{0}/{this.gamesToSim} Games Simulated";
                this.simLeagueBackgroundWorker.RunWorkerAsync(days);
            }
            else
            {
                MessageBox.Show(@"League is currently simulating, please wait");
            }
        }

        /// <summary>
        /// Function for display progress changed of simBackgroundWorker
        /// </summary>
        /// <param name="sender">BackgroundWorker sender</param>
        /// <param name="e">Args that holds the new progress</param>
        private void SimLeagueBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.simProgressLabel.Text = $@"{e.ProgressPercentage}/{this.gamesToSim} Games Simulated";
            this.simProgressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Code that runs when the simBackgroundWorker is complete or cancelled
        /// </summary>
        /// <param name="sender">BackgroundWorker sender</param>
        /// <param name="e">WorkerCompleted args</param>
        private void SimLeagueBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Updates the standingsControl to show updated results from games played
            this.standingsControl.LoadSortConferences();

            // Once simulating is complete or cancelled, will display the new games on the schedule. if there are none, produces an empty game section and goes to playoffs
            this.leagueGamesDisplay.SetSchedule(League.DayIndex >= League.LeagueSchedule.SeasonSchedule.Count
                                                    ? new List<Game>()
                                                    : League.LeagueSchedule.SeasonSchedule[League.DayIndex]);
            this.leagueGamesDisplay.SetDay(League.DayIndex + 1);

            // Updates the league leaders stats box when the league has been simulated, new stats to be re-sorted
            this.leagueLeadersStatsControl.InsertPlayerList(League.SignedPlayers.ToArray());

            if (League.LeagueSchedule.IsFinishedSimming())
            {
                this.simLeagueRegularSeasonControl.SetAdvanceStateButton(true);
            }
        }

        /// <summary>
        /// Opens the form of the chosen offseason stage that is passed
        /// </summary>
        /// <param name="stage">
        /// The offseason stage of the form that will be opened of enum OffseasonStage
        /// </param>
        private void SimLeagueOffseasonControl1_OpenStageFormEvent(OffseasonStage stage)
        {
            switch (stage)
            {
                case OffseasonStage.ProgressionAndRetirement:
                    ProgressionAndRetirementForm progressionForm = new ProgressionAndRetirementForm(League);
                    progressionForm.ShowDialog();
                    break;

                case OffseasonStage.Draft:
                    DraftForm draftForm = new DraftForm(League.CurrentDraft);
                    draftForm.ShowDialog();
                    break;

                case OffseasonStage.Resign:
                    ResignForm resignForm = new ResignForm(League);
                    resignForm.ShowDialog();
                    break;

                case OffseasonStage.FreeAgency:
                    FreeAgencyForm form = new FreeAgencyForm(League);
                    form.ShowDialog();
                    break;
            }
        }

        /// <summary>
        /// Report progress function for simPlayoffBackgroundWorker
        /// </summary>
        /// <param name="sender">BackgroundWorker sender</param>
        /// <param name="e">ProgressChanged args</param>
        private void SimPlayoffBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.simProgressLabel.Text = $@"{e.ProgressPercentage} Games Simulated";
        }

        /// <summary>
        /// The sim playoff background worker_ run worker completed.
        /// </summary>
        /// <param name="sender">
        /// BackgroundWorker sender
        /// </param>
        /// <param name="e">
        /// WorkCompleted args
        /// </param>
        private void SimPlayoffBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.playoffDisplayControl.UpdatePlayoffs();
            this.leagueGamesDisplay.SetSchedule(League.currentPlayoff.GetCurrentPlayoffGames());
            this.leagueGamesDisplay.SetPlayoffRoundAndDay(League.currentPlayoff.CurrentRound, League.currentPlayoff.CurrentDay);
            this.leagueLeadersStatsControl.InsertPlayerList(League.currentPlayoff.GetAllPlayoffPlayers().ToArray());

            // If the playoffs are not done being simulated, there are still games to be played
            if (!League.currentPlayoff.FinishedSimming)
            {
                this.leagueGamesDisplay.LinkPlayoffMatchupViewControlEvents(this.playoffDisplayControl.GetActivePlayoffMatchupViewControls(League.currentPlayoff.CurrentRound));
            }
            else
            {
                this.simLeaguePlayoffControl.SetAdvanceStateButton(true);
            }
        }

        /// <summary>
        /// Simulates the playoffs given a certain number of days to simulate
        /// </summary>
        /// <param name="days">
        /// Number of days to be simulated, at least 1 game will occur on each day
        /// </param>
        private void SimPlayoffs(int days)
        {
            if (!this.simPlayoffBackgroundWorker.IsBusy)
            {
                this.simProgressLabel.Text = @"0 Games Simulated";
                this.simPlayoffBackgroundWorker.RunWorkerAsync(days);
            }
            else
            {
                MessageBox.Show(@"League is currently simulating playoffs, please wait for sim to complete");
            }
        }

        /// <summary>
        /// Event handler for the team stats selections in the menu
        /// </summary>
        /// <param name="sender">Menu item that was pressed</param>
        /// <param name="e">event args</param>
        /// <param name="allTime">Whether the form will load all time stats or current season stats</param>
        private void TeamStatsMenuItem_Click(object sender, EventArgs e, bool allTime)
        {
            TeamStatsForm form = new TeamStatsForm(League, allTime);
            form.ShowDialog();
        }

        #endregion Methods
    }
}