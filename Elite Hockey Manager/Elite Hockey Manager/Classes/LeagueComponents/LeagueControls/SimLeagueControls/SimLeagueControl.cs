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
    public abstract partial class SimLeagueControl : UserControl
    {
        public event Action<int> LeagueSimmedEvent;
        public SimLeagueControl()
        {
            InitializeComponent();
        }
        protected void RaiseLeagueSimmedEvent(int arg)
        {
            LeagueSimmedEvent(arg);
        }
        /// <summary>
        /// Enables and displays button to advance to the next league state
        /// </summary>
        public void EnableAdvanceStateButton()
        {
            advanceStateButton.Enabled = false;
            advanceStateButton.Visible = true;
        }
        protected abstract void SetControlsText();
        public abstract void Sim1Button_Click(object sender, EventArgs e);
        public abstract void Sim2Button_Click(object sender, EventArgs e);
        public abstract void Sim3Button_Click(object sender, EventArgs e);
        public abstract void Sim4Button_Click(object sender, EventArgs e);
        public abstract void Sim5Button_Click(object sender, EventArgs e);
        public abstract void advanceStateButton_Click(object sender, EventArgs e);
    }
}
