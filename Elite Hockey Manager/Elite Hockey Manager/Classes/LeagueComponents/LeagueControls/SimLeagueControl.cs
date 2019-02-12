using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public partial class SimLeagueControl : UserControl
    {
        public event Action<int> LeagueSimmedEvent;
        public int DaysSimmed
        {
            get;
            private set;
        }
        public SimLeagueControl()
        {
            InitializeComponent();
        }

        private void simOneButton_Click(object sender, EventArgs e)
        {
            LeagueSimmedEvent(1);
        }
        private void simThreeButton_Click(object sender, EventArgs e)
        {
            LeagueSimmedEvent(3);
        }
        private void simWeekButton_Click(object sender, EventArgs e)
        {
            LeagueSimmedEvent(7);
        }
        private void simMonthButton_Click(object sender, EventArgs e)
        {
            LeagueSimmedEvent(30);
        }
        private void simSeasonButton_Click(object sender, EventArgs e)
        {
            LeagueSimmedEvent(-1);
        }
    }
}
