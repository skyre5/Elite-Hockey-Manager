using System;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.GameComponents.GameControls
{
    using Elite_Hockey_Manager.Classes.Players;

    public partial class GameControl : UserControl
    {
        #region Fields

        private Game _game;
        private int _simSpeed = 1;
        private FlowLayoutPanel activeEventPanel = new FlowLayoutPanel();
        private int eventIndex = 0;
        private Type eventType = typeof(Event);
        private int period = 1;
        private Timer timer;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// GameControl constuctor
        /// </summary>
        public GameControl()
        {
            InitializeComponent();
            InitializeTimer();
            activeEventPanel.AutoSize = true;
            activeEventPanel.FlowDirection = FlowDirection.TopDown;
        }

        #endregion Constructors

        #region Properties

        public Game Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
                GameControlLoad();
            }
        }

        public int SimSpeed
        {
            get
            {
                return _simSpeed;
            }
            private set
            {
                _simSpeed = value;

                // If timer is active reset timer, set new interval and restart timer
                if (timer.Enabled == true)
                {
                    timer.Stop();
                    timer.Start();
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds events to layoutpanel holding new events
        /// </summary>
        /// <param name="events">New events held in a list</param>
        private void AddEventsToLayout(List<Event> events)
        {
            foreach (Event x in events)
            {
                Label label = new Label
                {
                    AutoSize = true,
                    Text = x.ToString()
                };
                activeEventPanel.Controls.Add(label);
            }
        }

        /// <summary>
        /// Sets sim speed to 8 (2 minutes)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eightRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 8;
        }

        /// <summary>
        /// Event when a new tabpage is selected in tabcontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Deep copy to avoid errors
            List<Event> gameEvents = new List<Event>(Game.GameEvents);

            switch ((sender as TabControl).SelectedIndex)
            {
                // All events
                case 0:
                    eventType = typeof(Event);
                    break;
                // Goals
                case 1:
                    eventType = typeof(GoalEvent);
                    break;
                // Penalties
                case 2:
                    eventType = typeof(PenaltyEvent);
                    break;
                // Shots
                case 3:
                    eventType = typeof(ShotEvent);
                    break;
            }

            // Sorts the list of events to only include type that the user chose
            SortEvents(ref gameEvents);
            InsertEventsInTabPage(eventsTabControl.SelectedTab, gameEvents);
        }

        /// <summary>
        /// Sets sim speed to 4 (1 minute)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fourRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 4;
        }

        /// <summary>
        /// Event when sim game button is pressed
        /// Entire game will be simmed and form will be updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            // Sims the entire/rest of the game
            Game.PlayGame();
            SetTime(Game.TimeInterval);

            // Updates to the final period and score of the finished game
            UpdatePeriodLabel();
            UpdateScoreLabel();

            // Updates current faceoff stats
            UpdateFaceoffChart();

            // Sets the line displays to the current players on the ice
            SetPlayerLineControls();
            shotCounterControl.UpdateShotControl(Game);

            // Gets all the new events since the last time it the eventspanel was updated
            List<Event> newGameEvents = Game.GameEvents.GetRange(eventIndex, Game.GameEvents.Count - eventIndex);

            // Sets the new event index for incoming new events
            eventIndex = Game.GameEvents.Count == 0 ? eventIndex = 0 : eventIndex = Game.GameEvents.Count;
            SortEvents(ref newGameEvents);

            // Adds events to layoutpanel
            AddEventsToLayout(newGameEvents);
        }

        /// <summary>
        /// Loads controls after the Game property is set
        /// </summary>
        private void GameControlLoad()
        {
            // Updates the score label with the games current info
            UpdateScoreLabel();
            UpdatePeriodLabel();

            // Updates current faceoff stats
            UpdateFaceoffChart();

            // Sets the starting goalies for the team at the time of opening the form
            Game.SetStartingGoalies();

            // Sets goalies for the game into the linedisplays, only needs to be updated with a goalie replacement
            homeLineControl.SetGoalie(
                $@"{Game.PlayersOnIce.HomeGoalie.LastName}({Game.PlayersOnIce.HomeGoalie.PositionAbbreviation})");
            awayLineControl.SetGoalie(
                $@"{Game.PlayersOnIce.AwayGoalie.LastName}({Game.PlayersOnIce.AwayGoalie.PositionAbbreviation})");
            eventsTabControl.SelectedTab.Controls.Add(activeEventPanel);
            if (Game.Finished)
            {
                timeLabel.Text = "";
                simGroupbox.Visible = false;

                // Deep copy to avoid errors
                List<Event> gameEvents = new List<Event>(Game.GameEvents);

                // Inserts events into page, no sorting is ever decided upon load so unnecessary to sort it
                InsertEventsInTabPage(eventsTabControl.SelectedTab, gameEvents);

                // Updates shot control to finished game stats
                shotCounterControl.UpdateShotControl(Game);

                // Sets the players on the ice if the game was loaded in finished
                SetPlayerLineControls();
            }
        }

        /// <summary>
        /// Initializes the timer with its event handlers, and the rate at which the event will fire when on
        /// </summary>
        private void InitializeTimer()
        {
            timer = new Timer
            {
                // Base interval set at 1.5 seconds between events
                Interval = 1500
            };

            // Sets TimerFinished function to Timer.Tick event each increment
            timer.Tick += TimerFinished;
        }

        /// <summary>
        /// Inserts events into new tabpage when a new tabpage is selected
        /// </summary>
        /// <param name="tabPage">Tabpage being selected</param>
        /// <param name="events">List of events for that tabpage's sorted criteria</param>
        private void InsertEventsInTabPage(TabPage tabPage, List<Event> events)
        {
            // Clears all the labels from the activeEventPanel so that the newly sorted events may be added
            activeEventPanel.Controls.Clear();

            // Removes the activeEventPanel from the current tab, panel will only exist in the active tab
            tabPage.Controls.Clear();

            // Adds display of selected events to the active tabPage
            AddEventsToLayout(events);
            tabPage.Controls.Add(activeEventPanel);
        }

        /// <summary>
        /// Sets sim speed to 1 (15 seconds)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 1;
        }

        /// <summary>
        /// Pauses simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        /// <summary>
        /// Event when period button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodButton_Click(object sender, EventArgs e)
        {
            // Pauses the game for user input
            timer.Stop();

            //Finishes the current period the game is in
            Game.PlayPeriod();

            // Updates displays to current state of the game
            SetTime(Game.TimeInterval);
            UpdatePeriodLabel();
            UpdateScoreLabel();
            UpdateFaceoffChart();
            shotCounterControl.UpdateShotControl(Game);

            // Sets player controls to the active lines
            SetPlayerLineControls();

            // Gets all the new events since the last time it the eventspanel was updated
            List<Event> newGameEvents = Game.GameEvents.GetRange(eventIndex, Game.GameEvents.Count - eventIndex);
            // Sets the new event index for incoming new events
            eventIndex = Game.GameEvents.Count == 0 ? eventIndex = 0 : eventIndex = Game.GameEvents.Count;

            // sorts and adds events to layoutpanel
            SortEvents(ref newGameEvents);
            AddEventsToLayout(newGameEvents);
        }

        /// <summary>
        /// Enables the game to start simming in increments by unpausing simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playButton_Click(object sender, EventArgs e)
        {
            if (Game.Finished)
            {
                MessageBox.Show("Game is finished");
            }
            else
            {
                TimerSimulate();
            }
        }

        /// <summary>
        /// Helper function for SetPlayerLineControls, puts all players from a line into a string with name and position
        /// </summary>
        /// <param name="players">Array of skater objects</param>
        /// <returns>String of all players last names and positions in a string</returns>
        private string PlayerLineToString(Skater[] players)
        {
            string lineString = "";
            foreach (Skater skater in players)
            {
                lineString += $@"{skater.LastName}({skater.PositionAbbreviation}) ";
            }
            return lineString.Trim();
        }

        /// <summary>
        /// Takes the forwards and defenders currently on the ice from each team and gives them to each team's display control
        /// </summary>
        private void SetPlayerLineControls()
        {
            homeLineControl.SetForwards(PlayerLineToString(Game.PlayersOnIce.HomeForwards));
            homeLineControl.SetDefenders(PlayerLineToString(Game.PlayersOnIce.HomeDefenders));

            awayLineControl.SetForwards(PlayerLineToString(Game.PlayersOnIce.AwayForwards));
            awayLineControl.SetDefenders(PlayerLineToString(Game.PlayersOnIce.AwayDefenders));
        }

        /// <summary>
        /// Sets the time Label to show time in the game
        /// </summary>
        /// <param name="timeIntervals">
        /// the amount of intervals the game is into the current period
        /// </param>
        private void SetTime(int timeIntervals)
        {
            // Sets a TimeSpan object to 20 minutes (Length of a period)
            TimeSpan clockTime = new TimeSpan(0, 20, 0);

            // Sets a timeSpan object to 15 seconds to be multiplied to find the current time remaining in period
            TimeSpan intervalSeconds = TimeSpan.FromSeconds(15);

            // No multiply functionality directly for timespan so multiplies ticks of the interval in ticks by the total intervals of period
            TimeSpan difference = TimeSpan.FromTicks(intervalSeconds.Ticks * (timeIntervals));

            // Subtracts the total amount of time into the period from 20 minutes to get game time
            clockTime = (clockTime - difference);

            // 2 spaces for both minutes and seconds display
            timeLabel.Text = clockTime.ToString(@"mm\:ss");
        }

        /// <summary>
        /// Sorts events in a list by their subclass of event
        /// </summary>
        /// <param name="events">List of events</param>
        private void SortEvents(ref List<Event> events)
        {
            if (eventType == typeof(Event))
            {
                events = events.Where(x => x is Event).ToList();
            }
            else if (eventType == typeof(GoalEvent))
            {
                events = events.Where(x => x is GoalEvent).ToList();
            }
            else if (eventType == typeof(PenaltyEvent))
            {
                events = events.Where(x => x is PenaltyEvent).ToList();
            }
            else if (eventType == typeof(ShotEvent))
            {
                events = events.Where(x => x is ShotEvent).ToList();
            }
        }

        /// <summary>
        /// Event when timer finishes simming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerFinished(object sender, EventArgs e)
        {
            timer.Stop();
            // Increments 1-8 periods of time
            Game.IncrementTime(SimSpeed);
            // Update time of game
            SetTime(Game.TimeInterval);
            // Updates shot totals
            shotCounterControl.UpdateShotControl(Game);

            // Gets all the new events since the last time it the eventspanel was updated
            List<Event> newGameEvents = Game.GameEvents.GetRange(eventIndex, Game.GameEvents.Count - eventIndex);
            // If the newly simulated events contained a goal, change the score
            if (newGameEvents.OfType<GoalEvent>().Any())
            {
                UpdateScoreLabel();
            }
            // Change periodlabel if the game period changes
            if (period != Game.Period)
            {
                UpdatePeriodLabel();
            }
            // Updates current faceoff stats
            UpdateFaceoffChart();
            // Sets player controls to the active lines
            SetPlayerLineControls();
            // Sets the new event index for incoming new events
            eventIndex = Game.GameEvents.Count == 0 ? eventIndex = 0 : eventIndex = Game.GameEvents.Count;

            // Sorts the events and adds them to display panel
            SortEvents(ref newGameEvents);
            AddEventsToLayout(newGameEvents);
            if (Game.Finished == false)
            {
                timer.Start();
            }
        }

        /// <summary>
        /// Starts the timer when start button is pressed
        /// </summary>
        private void TimerSimulate()
        {
            timer.Start();
        }

        /// <summary>
        /// Sets sim speed to 2 (30 seconds)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 2;
        }

        /// <summary>
        /// Updates the chart with the current faceoff stats in the game
        /// </summary>
        private void UpdateFaceoffChart()
        {
            // Clears the faceoffs series point data and readds them when updated
            faceoffChart.Series[0].Points.Clear();
            faceoffChart.Series[0].Points.AddXY("Away", Game.AwayFaceoffWins);
            faceoffChart.Series[0].Points.AddXY("Home", Game.HomeFaceoffWins);
        }

        /// <summary>
        /// Sets the period into the periodlabel
        /// </summary>
        private void UpdatePeriodLabel()
        {
            periodLabel.Text = $"Period: {Game.Period}";
            period = Game.Period;
        }

        /// <summary>
        /// Sets the score label to the score and team abbreviations
        /// </summary>
        private void UpdateScoreLabel()
        {
            // Updates score in format of away abbreviation and score first them home score and home abbreviation
            scoreLabel.Text =
                $"{Game.AwayTeam.Abbreviation} {Game.AwayScore}-{Game.HomeScore} {Game.HomeTeam.Abbreviation}";
        }

        #endregion Methods
    }
}