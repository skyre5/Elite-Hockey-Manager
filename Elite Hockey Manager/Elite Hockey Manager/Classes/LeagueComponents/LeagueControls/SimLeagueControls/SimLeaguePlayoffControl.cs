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
    public partial class SimLeaguePlayoffControl : SimLeagueControl
    {
        public EventHandler AdvanceLeagueStateToOffseason;
        public SimLeaguePlayoffControl()
        {
            InitializeComponent();
            SetControlsText();
        }
        protected override void SetControlsText()
        {
            simDisplayLabel.Text = "Sim Playoffs:";
            simFirstButton.Text = "1 Game";
            simSecondButton.Text = "3 Games";
            simThirdButton.Text = "Current Round";
            simFourthButton.Text = "Entire Playoffs";
            //5th button not used in playoff sim, turn invisible and unenable the button
            simFifthButton.Enabled = false;
            simFifthButton.Visible = false;
        }
        /// <summary>
        /// Sims 1 game of the series across the league
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim1Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(1);
        }
        /// <summary>
        /// Sims 3 days of the series in the league
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim2Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(3);
        }
        /// <summary>
        /// Sims the entire current round of the playoffs and moves it to the next round
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim3Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(7);
        }
        /// <summary>
        /// Sims the entire playoffs, passes -1 to denote the rest of the playoffs to be simmed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim4Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(-1);
        }
        /// <summary>
        /// Not used in this control
        /// Invisible and unenabled in setControlsText function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim5Button_Click(object sender, EventArgs e)
        {
        }
        public override void advanceStateButton_Click(object sender, EventArgs e)
        {
            AdvanceLeagueStateToOffseason(this, null);
        }
    }
}
