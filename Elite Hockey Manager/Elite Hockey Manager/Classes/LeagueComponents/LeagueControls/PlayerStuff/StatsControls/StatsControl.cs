using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls
{
    public partial class StatsControl : UserControl
    {
        public StatsDisplayType DisplayType
        {
            get
            {
                return this.playerStatsControl.DisplayType;
            }
            set
            {
                //Gets the width of the playerStatsControl within this control before it is redrawn with a new size
                int pastWidth = playerStatsControl.Width;
                //Sets the new Display type which goes to child PlayerStatsControl and redraws it using childs logic
                this.playerStatsControl.DisplayType = value;
                //Adjusts controls within this control to the resized playerStatsControl
                AdjustDisplayForDisplayTypeChange(pastWidth);
                AdjustButtonsToNewDisplayType(value);
            }
        }

        public String Title
        {
            get
            {
                return titleLabel.Text;
            }
            set
            {
                titleLabel.Text = value;
            }
        }

        public bool DisplayTeamAbbreviation
        {
            get
            {
                return playerStatsControl.DisplayTeamAbbreviation;
            }
            set
            {
                playerStatsControl.DisplayTeamAbbreviation = value;
            }
        }

        public StatsControl()
        {
            InitializeComponent();
        }

        private void skaterStatsButton_Click(object sender, EventArgs e)
        {
            DisplayType = StatsDisplayType.Skater;
            skaterStatsButton.Enabled = false;
            goalieStatsButton.Enabled = true;
            playerStatsControl.UpdateStats();
        }

        private void goalieStatsButton_Click(object sender, EventArgs e)
        {
            DisplayType = StatsDisplayType.Goalie;
            skaterStatsButton.Enabled = true;
            goalieStatsButton.Enabled = false;
            playerStatsControl.UpdateStats();
        }

        private void statsFormButton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Helper function that takes an array of players and sorts them into skaters and goalies.
        /// Takes those 2 sorted new arrays and places them into InsertSkaterList and InsertGoalieList functions
        /// </summary>
        /// <param name="players">Arraay of Player objects to be sorted into Skaters and Goalies and sorted by their respective statistics</param>
        public void InsertPlayerList(Player[] players)
        {
            //Sorts the list of players that are skaters, casts them to skater, converts to array
            InsertSkaterList(players.Where(player => player is Skater).Cast<Skater>().ToArray());
            //Sorts the list of players that are goalies, casts them to goalie, converts to array
            InsertGoalieList(players.Where(player => player is Goalie).Cast<Goalie>().ToArray());
        }

        /// <summary>
        /// Sets desired array of skaters to be stored and sorted within child playerStatsControl class
        /// Only updates display if skater display type is active
        /// </summary>
        /// <param name="skaters"></param>
        public void InsertSkaterList(Skater[] skaters)
        {
            //Logic handled within PlayerStatsControl class
            this.playerStatsControl.StoredSkaters = skaters;
        }

        /// <summary>
        /// Sets desired array of goalies to be stored and sorted within child playerStatsControl class
        /// Only updates display if goalie display type is active
        /// </summary>
        /// <param name="goalies"></param>
        public void InsertGoalieList(Goalie[] goalies)
        {
            //Logic handled within PlayerStatsControl class
            this.playerStatsControl.StoredGoalies = goalies;
        }

        private void AdjustDisplayForDisplayTypeChange(int pastWidth)
        {
            //Adjusts the width of the titleLabel so that it will be center alligned again, and adjust size for auto size
            titleLabel.Width = playerStatsControl.Width;
            //Sets the location of the statsFormButton to align with the right side of the control
            statsFormButton.Location = new Point(playerStatsControl.Width + playerStatsControl.Location.X - statsFormButton.Size.Width,
                statsFormButton.Location.Y);
            //Moves the entire control so that the autosize difference will stay aligned with the right side of where it was initially placed
            this.Location = new Point(this.Location.X + (pastWidth - this.Width), this.Location.Y);
        }

        private void AdjustButtonsToNewDisplayType(StatsDisplayType newDisplayType)
        {
            if (newDisplayType == StatsDisplayType.Goalie)
            {
                skaterStatsButton.Enabled = true;
                goalieStatsButton.Enabled = false;
            }
            else
            {
                skaterStatsButton.Enabled = false;
                goalieStatsButton.Enabled = true;
            }
        }
    }
}