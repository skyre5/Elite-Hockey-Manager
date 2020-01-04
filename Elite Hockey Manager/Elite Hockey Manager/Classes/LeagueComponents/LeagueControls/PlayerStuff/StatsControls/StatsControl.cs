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
        }
        private void goalieStatsButton_Click(object sender, EventArgs e)
        {
            DisplayType = StatsDisplayType.Goalie;
            skaterStatsButton.Enabled = true;
            goalieStatsButton.Enabled = false;
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

            titleLabel.Width = playerStatsControl.Width;
            statsFormButton.Location = new Point(playerStatsControl.Width + playerStatsControl.Location.X - statsFormButton.Size.Width,
                statsFormButton.Location.Y);
            this.Location = new Point(this.Location.X + (pastWidth - this.Width), this.Location.Y);
        }
    }
}
