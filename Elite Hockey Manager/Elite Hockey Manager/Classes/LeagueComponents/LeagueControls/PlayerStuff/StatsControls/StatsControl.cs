using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
