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
        Unset,
        Skater,
        Goalie
    }
    public partial class PlayerStatsControl : UserControl
    {
        public StatsDisplayType DisplayType
        {
            get
            {
                return _displayType;
            }
            set
            {
                if (value == StatsDisplayType.Unset)
                {
                    StatsDisplayedCount = 1;
                    _displayType = StatsDisplayType.Unset;
                }
                else if (value == StatsDisplayType.Skater)
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
        private StatsDisplayType _displayType = StatsDisplayType.Unset;
        private int _statsDisplayedCount = 1;
        private PlayerStatsListControl[] _statsListControlsArray = null;
        public PlayerStatsControl()
        {
            InitializeComponent();
        }
        private void SetSkaterDisplay()
        {
            StatsDisplayedCount = 5;
        }
        private void SetGoalieDisplay()
        {
            StatsDisplayedCount = 4;
        }
        private void CreateStatDisplays(int count)
        {
            //Removes all the controls within this control
            RemoveControls();
            int countWidth = 0;
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
