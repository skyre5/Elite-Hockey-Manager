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
    public partial class SimLeagueOffseasonControl: SimLeagueControlMiddle
#else
        public partial class SimLeagueOffseasonControl : SimLeagueControl
#endif
    {
        public int StageIndex
        {
            get;
            private set;
        } = 0;
        public readonly string[] Stages = new string[] { "Draft", "Resign Window", "Free Agency" };
        public event Action OpenStageFormEvent;
        public event Action StageAdvancedEvent;
        public event Action SimAllStagesEvent;
        public event Action AdvanceToRegularSeasonEvent;
        public SimLeagueOffseasonControl()
        {
            InitializeComponent();
        }
        private void UpdateTitle()
        {
            stageLabel.Text = String.Format("Stage: {0}", Stages[StageIndex]);
        }
        /// <summary>
        /// Opens form for the cooresponding offseason stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim1Button_Click(object sender, EventArgs e)
        {
            OpenStageFormEvent?.Invoke();
        }
        /// <summary>
        /// Sims to the next stage of the offseason, retirement, draft, signings, etc...
        /// Denoted by the sending of a -1 to signal a sim to the next offseason stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim2Button_Click(object sender, EventArgs e)
        {
            StageAdvancedEvent?.Invoke();
            //If there is a stage to advance to, updates the stage to the next and updates this controls titleLabel
            if (StageIndex < Stages.Count() - 1)
            {
                StageIndex++;
                UpdateTitle();
            }
            else
            {
                advanceStateButton.Visible = true;
                advanceStateButton.Enabled = true;
            }
        }
        /// <summary>
        /// Sims entire rest of offseason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim3Button_Click(object sender, EventArgs e)
        {
            SimAllStagesEvent?.Invoke();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim4Button_Click(object sender, EventArgs e)
        {
            RaiseLeagueSimmedEvent(1);
        }
        /// <summary>
        /// Sims 3 days during the free agency period which lasts a set number of days
        /// Only stage of offseason that tracks days
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Sim5Button_Click(object sender, EventArgs e)
        {
            //Sims 3 days of the free agency period
            RaiseLeagueSimmedEvent(3);
        }
        public override void advanceStateButton_Click(object sender, EventArgs e)
        {
            AdvanceToRegularSeasonEvent?.Invoke();
        }
    }

}
