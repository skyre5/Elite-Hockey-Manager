using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents;
//Used for ModifyProgressBarColor
using System.Runtime.InteropServices;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls
{
    public partial class TeamCapControl : UserControl
    {
        private Team _team;
        private double _salaryCap = 40;
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
        public TeamCapControl()
        {
            InitializeComponent();
            _salaryCap = League.SalaryCap;
            capProgressBar.Maximum = (int)_salaryCap;

        }
        private void SetDisplay()
        {
            double capSpent = _team.GetCapSpent();
            salaryCapDisplayLabel.Text = String.Format("{0}/{1}", capSpent, _salaryCap);
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
    }
    //https://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-sharp-net-3-5/9753302#9753302
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
