using System;

//Used for ModifyProgressBarColor
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls
{
    //https://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-sharp-net-3-5/9753302#9753302
    public static class ModifyProgressBarColor
    {
        #region Methods

        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        #endregion Methods
    }

    public partial class TeamCapControl : UserControl
    {
        #region Fields

        private double _salaryCap = 40;
        private Team _team;

        #endregion Fields

        #region Constructors

        public TeamCapControl()
        {
            InitializeComponent();
            _salaryCap = League.SalaryCap;
            capProgressBar.Maximum = (int)_salaryCap;
        }

        #endregion Constructors

        #region Properties

        public Double SalaryCap
        {
            get
            {
                return _salaryCap;
            }
            set
            {
                if (value < 50)
                {
                    throw new ArgumentException("Salary Cap must be at least 50 million");
                }
                else
                {
                    _salaryCap = value;
                }
            }
        }

        public Team Team
        {
            get
            {
                return _team;
            }
            set
            {
                if (value != null)
                {
                    _team = value;
                    SetDisplay();
                }
            }
        }

        #endregion Properties

        #region Methods

        private void SetDisplay()
        {
            double capSpent = _team.GetCapSpent();
            salaryCapDisplayLabel.Text = $"{capSpent}/{_salaryCap}";
            int capToInt = (int)capSpent;
            if (capToInt > capProgressBar.Maximum)
            {
                capProgressBar.Value = capProgressBar.Maximum;
                //Turns the progress bar Red
                ModifyProgressBarColor.SetState(capProgressBar, 2);
            }
            else
            {
                capProgressBar.Value = capToInt;
            }
        }

        #endregion Methods
    }
}