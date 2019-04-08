using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;

namespace Elite_Hockey_Manager.Classes.GameComponents.GameControls
{
    public partial class GameControl : UserControl
    {
        private Game _game;
        private int _simSpeed = 1;
        private int eventIndex = 0;
        private int period = 1;
        private Timer timer;
        private FlowLayoutPanel activeEventPanel = new FlowLayoutPanel();
        private List<Event> gameEvents = new List<Event>();
        private Type eventType = typeof(Event);
        public int SimSpeed
        {
            get
            {
                return _simSpeed;
            }
            set
            {
                _simSpeed = value;
                //If timer is active reset timer, set new interval and restart timer
                if (timer.Enabled == true)
                {
                    timer.Stop();
                    timer.Start();
                }
            }
        }
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
        public GameControl()
        {
            InitializeComponent();
            InitializeTimer();
            activeEventPanel.AutoSize = true;
            activeEventPanel.FlowDirection = FlowDirection.TopDown;

        }
        private void InitializeTimer()
        {
            timer = new Timer();
            //1.5 seconds
            timer.Interval = 1500;
            timer.Tick += TimerFinished;
        }
        private void GameControlLoad()
        {
            //Updates the score label with the games current info
            UpdateScoreLabel();
            UpdatePeriodLabel();
            if (Game.Finished)
            {
                timeLabel.Text = "";
                simGroupbox.Visible = false;
                gameEvents = Game.GameEvents;
                InsertEventsInTabPage(eventsTabControl.SelectedTab, gameEvents);
            }
        }
        /// <summary>
        /// Sets sim speed to 1 increments per sim period
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 1;
        }
        /// <summary>
        /// Sets sim speed to 2 increments per sim period
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 2;
        }
        /// <summary>
        /// Sets sim speed to 4 increments per sim period
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fourRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 4;
        }
        /// <summary>
        /// Sets sim speed to 8 increments per sim period
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eightRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SimSpeed = 8;
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
        /// Pauses simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
        /// <summary>
        /// Starts the timer when start button is pressed
        /// </summary>
        private void TimerSimulate()
        {
            timer.Start();
        }
        /// <summary>
        /// Sets the score label to the score and team abbreviations
        /// </summary>
        private void UpdateScoreLabel()
        {
            //Updates score in format of away abbreviation and score first them home score and home abbreviation
            scoreLabel.Text = String.Format("{0} {1}-{2} {3}", Game.AwayTeam.Abbreviation, Game.AwayScore, Game.HomeScore, Game.HomeTeam.Abbreviation);
        }
        /// <summary>
        /// Sets the time Label to show time in the game 
        /// </summary>
        /// <param name="timeInterval">
        /// 
        /// </param>
        private void SetTime(int timeInterval)
        {
            TimeSpan clockTime = new TimeSpan(0, 20, 0);
            TimeSpan second = TimeSpan.FromSeconds(15);
            //No multiply functionality directly for timespan so multiplies ticks of the interval in ticks by the total intervals
            TimeSpan difference = TimeSpan.FromTicks(second.Ticks * (timeInterval));
            clockTime = (clockTime - difference);
            //2 spaces for both minutes and seconds display
            timeLabel.Text = clockTime.ToString(@"mm\:ss");
        }
        /// <summary>
        /// Sets the period into the periodlabel
        /// </summary>
        private void UpdatePeriodLabel()
        {
            periodLabel.Text = String.Format("Period: {0}", Game.Period);
            period = Game.Period;
        }
        /// <summary>
        /// Event when timer finishes simming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerFinished(object sender, EventArgs e)
        {
            timer.Stop();
            //Increments 1-8 periods of time
            Game.IncrementTime(SimSpeed);
            //Update time of game
            SetTime(Game.TimeInterval);
            //Gets all the new events since the last time it the eventspanel was updated
            List<Event> newGameEvents = Game.GameEvents.GetRange(eventIndex, Game.GameEvents.Count - eventIndex);
            //If the newly simulated events contained a goal, change the score
            if (newGameEvents.OfType<GoalEvent>().Any())
            {
                UpdateScoreLabel();
            }
            //Change periodlabel if the game period changes
            if (period != Game.Period)
            {
                UpdatePeriodLabel();
            }
            //Sets the new event index for incoming new events
            eventIndex = Game.GameEvents.Count == 0 ? eventIndex = 0 : eventIndex = Game.GameEvents.Count;
            SortEvents(newGameEvents, eventType);
            gameEvents.AddRange(newGameEvents);
            AddEventsToLayout(newGameEvents);
            if (Game.Finished == false)
            {
                timer.Start();
            }
        }
        /// <summary>
        /// Sorts events in a list by their subclass of event
        /// </summary>
        /// <param name="events">List of events</param>
        /// <param name="type">Subtype to get events of only that type</param>
        private void SortEvents(List<Event> events, Type type)
        {
            if (type == typeof(Event))
            {
                events = events.Where(x => x is Event).ToList();
            }
            else if (type == typeof(GoalEvent))
            {
                events = events.Where(x => x is GoalEvent).ToList();
            }
            else if (type == typeof(PenaltyEvent))
            {
                events = events.Where(x => x is PenaltyEvent).ToList();
            }
            else if (type == typeof(ShotEvent))
            {
                events = events.Where(x => x is ShotEvent).ToList();
            }
        }
        /// <summary>
        /// Event when a new tabpage is selected in tabcontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            playersTabControl.Controls.Clear();
            //Does a copy without reference so the logic within this class doesn't affect the game's functionality or cause undesired effects on this class' logic
            gameEvents = new List<Event>(Game.GameEvents);
            List<Event> sortedEvents = new List<Event>();
            switch ((sender as TabControl).SelectedIndex)
            {
                //All events
                case 0:
                    eventType = typeof(Event);
                    sortedEvents = gameEvents.Where(x => x is Event).ToList();
                    break;
                //Goals
                case 1:
                    eventType = typeof(GoalEvent);
                    sortedEvents = gameEvents.Where(x => x is GoalEvent).ToList();
                    break;
                //Penalties
                case 2:
                    eventType = typeof(PenaltyEvent);
                    sortedEvents = gameEvents.Where(x => x is PenaltyEvent).ToList();
                    break;
                //Shots
                case 3:
                    eventType = typeof(ShotEvent);
                    sortedEvents = gameEvents.Where(x => x is ShotEvent).ToList();
                    break;
            }
            InsertEventsInTabPage(eventsTabControl.SelectedTab, sortedEvents);
        }
        /// <summary>
        /// Inserts events into new tabpage when a new tabpage is selected
        /// </summary>
        /// <param name="tabPage">Tabpage being selected</param>
        /// <param name="events">List of events for that tabpage's sorted criteria</param>
        private void InsertEventsInTabPage(TabPage tabPage, List<Event> events)
        {
            activeEventPanel.Controls.Clear();
            tabPage.Controls.Clear();
            foreach (Event x in events)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = x.ToString();
                activeEventPanel.Controls.Add(label);
            }
            tabPage.Controls.Add(activeEventPanel);
        }
        /// <summary>
        /// Adds events to layoutpanel holding new events
        /// </summary>
        /// <param name="events">New events held in a list</param>
        private void AddEventsToLayout(List<Event> events)
        {
            foreach (Event x in events)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = x.ToString();
                activeEventPanel.Controls.Add(label);
            }
        }
        /// <summary>
        /// Event when period button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Game.PlayPeriod();
            SetTime(Game.TimeInterval);
            UpdatePeriodLabel();
            UpdateScoreLabel();
            //Gets all the new events since the last time it the eventspanel was updated
            List<Event> newGameEvents = Game.GameEvents.GetRange(eventIndex, Game.GameEvents.Count - eventIndex);
            //Sets the new event index for incoming new events
            eventIndex = Game.GameEvents.Count == 0 ? eventIndex = 0 : eventIndex = Game.GameEvents.Count;
            SortEvents(newGameEvents, eventType);
            //Adds events to layoutpanel
            AddEventsToLayout(newGameEvents);
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Game.PlayGame();
            SetTime(Game.TimeInterval);
            UpdatePeriodLabel();
            UpdateScoreLabel();
            //Gets all the new events since the last time it the eventspanel was updated
            List<Event> newGameEvents = Game.GameEvents.GetRange(eventIndex, Game.GameEvents.Count - eventIndex);
            //Sets the new event index for incoming new events
            eventIndex = Game.GameEvents.Count == 0 ? eventIndex = 0 : eventIndex = Game.GameEvents.Count;
            SortEvents(newGameEvents, eventType);
            //Adds events to layoutpanel
            AddEventsToLayout(newGameEvents);
        }
    }
}
