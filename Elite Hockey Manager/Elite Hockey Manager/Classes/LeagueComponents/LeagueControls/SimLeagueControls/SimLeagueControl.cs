using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls
{
    public abstract partial class SimLeagueControl : UserControl
    {
        #region Constructors

        public SimLeagueControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Events

        public event Action<int> LeagueSimmedEvent;

        #endregion Events

        #region Methods

        public abstract void advanceStateButton_Click(object sender, EventArgs e);

        /// <summary>
        /// Enables and displays button to advance to the next league state
        /// </summary>
        public void SetAdvanceStateButton(bool enabled)
        {
            advanceStateButton.Enabled = enabled;
            advanceStateButton.Visible = enabled;
        }

        public abstract void Sim1Button_Click(object sender, EventArgs e);

        public abstract void Sim2Button_Click(object sender, EventArgs e);

        public abstract void Sim3Button_Click(object sender, EventArgs e);

        public abstract void Sim4Button_Click(object sender, EventArgs e);

        public abstract void Sim5Button_Click(object sender, EventArgs e);

        protected void RaiseLeagueSimmedEvent(int arg)
        {
            //If LeagueSimmedEvent is not null, invoke event
            LeagueSimmedEvent?.Invoke(arg);
        }

        protected abstract void SetControlsText();

        #endregion Methods
    }

    /// <summary>
    /// Debug class with the purpose of displaying children of SimLeagueControl designer without error from abstract class
    /// </summary>
    public partial class SimLeagueControlMiddle : SimLeagueControl
    {
        #region Methods

        public override void advanceStateButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Sim1Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Sim2Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Sim3Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Sim4Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Sim5Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void SetControlsText()
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}