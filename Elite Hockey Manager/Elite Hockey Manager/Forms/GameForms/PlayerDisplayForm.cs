using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class PlayerDisplayForm : Form
    {
        public PlayerDisplayForm(Player player)
        {
            InitializeComponent();
        }

        private void PlayerDisplayForm_Load(object sender, EventArgs e)
        {
        }
    }
}
