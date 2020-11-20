using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
                    ChangeLabelCount(value.GetLength());
                    _displayLength = StatsDisplayLength.Long;
                }
                else if (value == StatsDisplayLength.Medium)
                {
                    ChangeLabelCount(value.GetLength());
                    _displayLength = StatsDisplayLength.Medium;
                }
                else if (value == StatsDisplayLength.Short)
                {
                    ChangeLabelCount(value.GetLength());
                    _displayLength = StatsDisplayLength.Short;
                }
            }
        }

        /// <summary>
        /// Array of Goalies that will be sorted by their statistics from the current season.
        /// Setting of property will cause the display to be updated if it is set to goalie mode.
        /// </summary>
        public Goalie[] StoredGoalies
        {
            get
            {
                return _storedGoalies;
            }
            set
            {
                _storedGoalies = value;
                if (_displayType == StatsDisplayType.Goalie && value != null)
                {
                    SortDisplayGoalieStats();
                }
            }
        }

        /// <summary>
        /// Array of Skaters that will be sorted by their statistics from the current season.
        /// Setting of property will cause the display to be updated if it is set to skater mode.
        /// </summary>
        public Skater[] StoredSkaters
        {
            get
            {
                return _storedSkaters;
            }
            set
            {
                _storedSkaters = value;
                if (_displayType == StatsDisplayType.Skater && value != null)
                {
                    SortDisplaySkaterStats();
                }
            }
        }

        /// <summary>
        /// Sets the number of child PlayerStatslistControl to be displayed. 4 for goalie and 5 for skater
        /// </summary>
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

        public bool DisplayTeamAbbreviation
        {
            get
            {
                return _displayTeamAbbreviation;
            }
            set
            {
                _displayTeamAbbreviation = value;
                //Changes the property of all the playerStatsListControls within this control
                UpdatePlayerStatsListControlToDisplayAbbreviations();
            }
        }

        //public variables
        //Data to be used for sorting into stat displays. Placed into class by container class

        //private variables

        private StatsDisplayType _displayType;
        private StatsDisplayLength _displayLength = StatsDisplayLength.Long;
        private int _statsDisplayedCount = 0;
        private bool _displayTeamAbbreviation = false;
        private Goalie[] _storedGoalies = null;
        private Skater[] _storedSkaters = null;
        private PlayerStatsListControl[] _statsListControlsArray = null;

        public PlayerStatsControl()
        {
            InitializeComponent();
            //Sets the control display for skaters
            //DisplayType = StatsDisplayType.Skater;
        }

        public void UpdateStats()
        {
            if (DisplayType == StatsDisplayType.Goalie)
            {
                SortDisplayGoalieStats();
            }
            else
            {
                SortDisplaySkaterStats();
            }
        }

        private void SetSkaterDisplay()
        {
            //Titles of the 5 stat displays
            string[] titles = new string[] { "Points", "Goals", "Assists", "+/-", "PIMs" };
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
            string[] titles = new string[] { "Wins", "Save %", "GAA", "Shutouts" };
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
                //Boolean value set that if true will display team abbreviation next to the players name in playerLabel
                newListX.DisplayTeamAbbreviation = _displayTeamAbbreviation;
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

        private void PlayerStatsControl_Load(object sender, EventArgs e)
        {
            //_statsListControlsArray[0].UpdateDisplay(labelArray);
        }

        /// <summary>
        ///
        /// </summary>
        private void SortDisplayGoalieStats()
        {
            // { "Wins", "Save %", "GAA", "Shutouts" }
            int listSize = this.DisplayLength.GetLength();
            //If there are less goalies than number of players to display, will limit # of stats shown
            if (_storedGoalies.Length < listSize)
            {
                listSize = _storedGoalies.Length;
            }
            double[] numbers;
            //Sort goalies by their property wins, takes the # of goalies to be displayed on the leaderboard, converts to array
            Goalie[] winsSortedGoalies = _storedGoalies.OrderByDescending(goalie => goalie.Stats.Wins).Take(listSize).ToArray();
            numbers = winsSortedGoalies.Select(goalie => (double)goalie.Stats.Wins).ToArray();
            _statsListControlsArray[0].UpdateDisplay(CreatePlayerStatDisplays(winsSortedGoalies, numbers));

            Goalie[] savePctgSortedGoalies = _storedGoalies.OrderByDescending(goalie => goalie.Stats.SavePercentage).Take(listSize).ToArray();
            numbers = savePctgSortedGoalies.Select(goalie => goalie.Stats.SavePercentage).ToArray();
            _statsListControlsArray[1].UpdateDisplay(CreatePlayerStatDisplays(savePctgSortedGoalies, numbers));

            //Inversed, lower GAA is better so uses ascending OrderBy function
            Goalie[] GAASortedGoalies = _storedGoalies.OrderBy(goalie => goalie.Stats.GAA).Take(listSize).ToArray();
            numbers = GAASortedGoalies.Select(goalie => goalie.Stats.GAA).ToArray();
            _statsListControlsArray[2].UpdateDisplay(CreatePlayerStatDisplays(GAASortedGoalies, numbers));

            Goalie[] shutoutSortedGoalies = _storedGoalies.OrderByDescending(goalie => goalie.Stats.Shutouts).Take(listSize).ToArray();
            numbers = shutoutSortedGoalies.Select(goalie => (double)goalie.Stats.Shutouts).ToArray();
            _statsListControlsArray[3].UpdateDisplay(CreatePlayerStatDisplays(shutoutSortedGoalies, numbers));
        }

        private void SortDisplaySkaterStats()
        {
            //{ "Points", "Goals", "Assists", "+/-", "PIMs" };
            int listSize = this.DisplayLength.GetLength();
            //If there are less goalies than number of players to display, will limit # of stats shown
            if (_storedSkaters.Length < listSize)
            {
                listSize = _storedGoalies.Length;
            }
            double[] numbers;
            Skater[] pointSortedSkaters = _storedSkaters.OrderByDescending(skater => skater.Stats.Points).Take(listSize).ToArray();
            numbers = pointSortedSkaters.Select(skater => (double)skater.Stats.Points).ToArray();
            _statsListControlsArray[0].UpdateDisplay(CreatePlayerStatDisplays(pointSortedSkaters, numbers));

            Skater[] goalSortedSkaters = _storedSkaters.OrderByDescending(skater => skater.Stats.Goals).Take(listSize).ToArray();
            numbers = goalSortedSkaters.Select(skater => (double)skater.Stats.Goals).ToArray();
            _statsListControlsArray[1].UpdateDisplay(CreatePlayerStatDisplays(goalSortedSkaters, numbers));

            Skater[] assistSortedSkaters = _storedSkaters.OrderByDescending(skater => skater.Stats.Assists).Take(listSize).ToArray();
            numbers = assistSortedSkaters.Select(skater => (double)skater.Stats.Assists).ToArray();
            _statsListControlsArray[2].UpdateDisplay(CreatePlayerStatDisplays(assistSortedSkaters, numbers));

            Skater[] plusMinusSortedSkaters = _storedSkaters.OrderByDescending(skater => skater.Stats.PlusMinus).Take(listSize).ToArray();
            numbers = plusMinusSortedSkaters.Select(skater => (double)skater.Stats.PlusMinus).ToArray();
            _statsListControlsArray[3].UpdateDisplay(CreatePlayerStatDisplays(plusMinusSortedSkaters, numbers));

            Skater[] PIMSortedSkaters = _storedSkaters.OrderByDescending(skater => skater.Stats.PenaltyMinutes).Take(listSize).ToArray();
            numbers = PIMSortedSkaters.Select(skater => (double)skater.Stats.PenaltyMinutes).ToArray();
            _statsListControlsArray[4].UpdateDisplay(CreatePlayerStatDisplays(PIMSortedSkaters, numbers));
        }

        private void UpdatePlayerStatsListControlToDisplayAbbreviations()
        {
            foreach (PlayerStatsListControl control in _statsListControlsArray)
            {
                control.DisplayTeamAbbreviation = _displayTeamAbbreviation;
            }
        }

        public static PlayerLabel[] CreatePlayerStatDisplays(Player[] players, double[] stats)
        {
            PlayerLabel[] labels = new PlayerLabel[players.Length];
            for (int i = 0; i < players.Length; i++)
            {
                labels[i] = new PlayerLabel(players[i], stats[i]);
            }
            return labels;
        }
    }

    //Extension methods for StatsDisplayLength
    internal static class StatsDisplayLengthMethods
    {
        public static int GetLength(this StatsDisplayLength displayLength)
        {
            switch (displayLength)
            {
                case StatsDisplayLength.Long:
                    return 10;

                case StatsDisplayLength.Medium:
                    return 5;

                case StatsDisplayLength.Short:
                    return 3;

                default:
                    //If new enum added and not defined, return 10
                    Console.WriteLine("New enum type StatsDisplayLength used in PlayerStatsControl");
                    return 10;
            }
        }
    }
}