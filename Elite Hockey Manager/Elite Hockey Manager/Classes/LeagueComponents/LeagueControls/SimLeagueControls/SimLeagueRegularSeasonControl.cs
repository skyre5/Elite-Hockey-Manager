using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls
{
#if DEBUG
    public partial class SimLeagueRegularSeasonControl : SimLeagueControlMiddle
#else
        public partial class SimLeagueOffseasonControl : SimLeagueControl
#endif
    {
        public EventHandler AdvanceLeagueStateToPlayoffs;
        public SimLeagueRegularSeasonControl()
        {
            InitializeComponent();
            SetControlsText();
        }
        protected override void SetControlsText()
        {
            simDisplayLabel.Text = "Sim Regular Season:";
            simFirstButton.Text = "1 Day";
            simSecondButton.Text = "3 Days";
            simThirdButton.Text = "7 Days";
            simFourthButton.Text = "30 Days";
            simFifthButton.Text = "Season";
            advanceStateButton.Text = "Advance To Playoffs";
        }
        /// <summary>
        /// Sims the remaining games from the current day and moves to the next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim1Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(1);
        }
        /// <summary>
        /// Sims 3 days
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim2Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(3); 
        }
        /// <summary>
        /// Sims 1 week
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim3Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(7);
        }
        /// <summary>
        /// Sims 1 month (30 days)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim4Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(30);
        }
        /// <summary>
        /// Sims the entire remaining regular season, passes a -1 to denote the simming of the rest of the season
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim5Button_Click(object sender, EventArgs e)
        {
            //Sims entire rest of regular season
            RaiseLeagueSimmedEvent(-1);
        }
        public override void advanceStateButton_Click(object sender, EventArgs e)
        {
            AdvanceLeagueStateToPlayoffs(this, null);
        }
    }
}
