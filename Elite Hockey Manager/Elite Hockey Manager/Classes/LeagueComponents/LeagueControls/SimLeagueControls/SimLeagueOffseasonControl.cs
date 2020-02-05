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
    public partial class SimLeagueOffseasonControl : SimLeagueControl
    {
        public SimLeagueOffseasonControl()
        {
            InitializeComponent();
        }
        protected override void SetControlsText()
        {
            simDisplayLabel.Text = "Sim Offseason:";
            simFirstButton.Text = "1 Day";
            simSecondButton.Text = "3 Days";
            simThirdButton.Text = "1 Week";
            simFourthButton.Text = "Next Offseason Stage";
            simFifthButton.Text = "To Regular Season";
        }
        /// <summary>
        /// Sims to the next day of the offseason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim1Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(1);
        }
        /// <summary>
        /// Sims 3 days into the offseason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim2Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(3);
        }
        /// <summary>
        /// Sims 1 week into the offseason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim3Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(7);
        }
        /// <summary>
        /// Sims to the next stage of the offseason, retirement, draft, signings, etc...
        /// Denoted by the sending of a -1 to signal a sim to the next offseason stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim4Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(-1);
        }
        /// <summary>
        /// Sims to the regular season
        /// Denoted by the sending of a -2 to sim to the regular season
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim5Button_Click(object sender, EventArgs e)
        {
            //Sims entire rest of regular season
            RaiseLeagueSimmedEvent(-2);
        }
    }
}
