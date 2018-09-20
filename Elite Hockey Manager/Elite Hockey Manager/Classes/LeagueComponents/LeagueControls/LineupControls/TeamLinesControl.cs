using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Forms.GameForms;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public partial class TeamLinesControl : UserControl
    {
        public TeamLinesControl()
        {
            InitializeComponent();
        }

        private void playerLabel_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Player player = ((PlayerLabel)sender).Player;
                if (player != null)
                {
                    PlayerDisplayForm form = new PlayerDisplayForm(player);
                    form.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Error loading player to display");
            }
        }

    }
}
