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
        private Timer timer;
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
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            //1.5 seconds
            timer.Interval = 1500;
            timer.Tick += TimerFinished;
        }
        private void goalsTab_Click(object sender, EventArgs e)
        {

        }

        private void GameControlLoad()
        {
            if (Game.Finished)
            {
                simGroupbox.Visible = false;
                InsertEventsInTabPage(eventsTabControl.SelectedTab, Game.GameEvents);
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
        private void TimerSimulate()
        {
            timer.Start();
        }
        private void TimerFinished(object sender, EventArgs e)
        {
            timer.Stop();
            //Increments 1-8 periods of time
            Game.IncrementTime(SimSpeed);
            List<Event> newGameEvents = Game.GameEvents.GetRange(eventIndex, Game.GameEvents.Count - eventIndex);
            gameEvents.AddRange(newGameEvents);
        }

        private void eventsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            playersTabControl.Controls.Clear();
            switch ((sender as TabControl).SelectedIndex)
            {
                //All events
                case 0:
                    eventType = typeof(Event);
                    break;
                //Goals
                case 1:
                    eventType = typeof(GoalEvent);
                    break;
                //Penalties
                case 2:
                    eventType = typeof(PenaltyEvent);
                    break;
                //Shots
                case 3:
                    eventType = typeof(ShotEvent);
                    break;
            }

            List<Event> sortedEvents = gameEvents.Where(x => x.GetType() == eventType).ToList();
            InsertEventsInTabPage(eventsTabControl.SelectedTab, sortedEvents);
        }
        private void InsertEventsInTabPage(TabPage tabPage, List<Event> events)
        {
            tabPage.Controls.Clear();
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.FlowDirection = FlowDirection.TopDown;
            foreach (Event x in events)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = x.ToString();
                panel.Controls.Add(label);
            }
            tabPage.Controls.Add(panel);
        }
    }
}
