using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public enum StatsDisplayType
    {
        Skater,
        Goalie
    }
    public enum StatsDisplayLength
    {
        Short,
        Medium,
        Long
    }
    public partial class PlayerStatsControl : UserControl
    {
        //Enum property that determines whether the stats are displayed for goalies or skaters
        public StatsDisplayType DisplayType
        {
            get
            {
                return _displayType;
            }
            set
            {
                if (value == StatsDisplayType.Skater)
                {
                    SetSkaterDisplay();
                    _displayType = StatsDisplayType.Skater;
                }
                else if (value == StatsDisplayType.Goalie)
                {
                    SetGoalieDisplay();
                    _displayType = StatsDisplayType.Goalie;
                }
            }
        }
        //Enum property that deterimes how many lables will be listed for each stat category 
        public StatsDisplayLength DisplayLength
        {
            get
            {
                return _displayLength;
            }
            set
            {
                if (value == StatsDisplayLength.Long)
                {
                    ChangeLabelCount(10);
                    _displayLength = StatsDisplayLength.Long;
                }
                else if (value == StatsDisplayLength.Medium)
                {
                    ChangeLabelCount(5);
                    _displayLength = StatsDisplayLength.Medium;
                }
                else if (value == StatsDisplayLength.Short)
                {
                    ChangeLabelCount(3);
                    _displayLength = StatsDisplayLength.Short;
                }
            }
        }
        private int StatsDisplayedCount
        {
            get
            {
                return _statsDisplayedCount;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("StatsDisplayedCount must be greater than 1");
                }
                CreateStatDisplays(value);
                _statsDisplayedCount = value;
            }
        }
        private StatsDisplayType _displayType;
        private StatsDisplayLength _displayLength = StatsDisplayLength.Long;
        private int _statsDisplayedCount = 1;
        private PlayerStatsListControl[] _statsListControlsArray = null;
        public PlayerStatsControl()
        {
            InitializeComponent();
            _displayType = StatsDisplayType.Skater;
        }
        private void SetSkaterDisplay()
        {
            //Titles of the 5 stat displays
            string[] titles = new string[] { "Points", "Goals", "Assists", "+/-", "Shots" };
            //Calls property setter which creates new stat display controls
            StatsDisplayedCount = 5;
            for (int i = 0; i < titles.Count(); i++)
            {
                _statsListControlsArray[i].Title = titles[i];
            }
        }
        private void SetGoalieDisplay()
        {
            //Titles of the 4 stat displays
            string[] titles = new string[] { "Wins", "Save %", "GAA", "Shutouts"};
            //Calls property setter which creates new stat display controls
            StatsDisplayedCount = 4;
            for (int i = 0; i < titles.Count(); i++)
            {
                _statsListControlsArray[i].Title = titles[i];
            }
        }
        private void CreateStatDisplays(int count)
        {
            //Removes all the controls within this container
            RemoveControls();
            int countWidth = 0;
            //Classes private array of PlayerStatsListControls is created
            _statsListControlsArray = new PlayerStatsListControl[count];
            for (int i = 0; i < count; i++)
            {
                PlayerStatsListControl newListX = new PlayerStatsListControl();
                _statsListControlsArray[i] = newListX;
                this.Controls.Add(newListX);
                newListX.Location = new Point(countWidth, newListX.Location.Y);
                countWidth += newListX.Width;
            }
        }
        private void ChangeLabelCount(int length)
        {
            if (_statsListControlsArray != null)
            {
                foreach (PlayerStatsListControl x in _statsListControlsArray)
                {
                    x.LabelCount = length;
                }
            }
        }
        private void RemoveControls()
        {
            if (_statsListControlsArray != null)
            {
                //Removes each control from view and then disposes of them from memory
                foreach (PlayerStatsListControl x in _statsListControlsArray)
                {
                    this.Controls.Remove(x);
                    x.Dispose();
                }
            }
        }
    }
}
