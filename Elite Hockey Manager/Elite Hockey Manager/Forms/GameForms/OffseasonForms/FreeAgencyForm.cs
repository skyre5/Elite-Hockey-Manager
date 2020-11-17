using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    public partial class FreeAgencyForm : Form
    {
        private List<Player> _freeAgents = new List<Player>();
        public FreeAgencyForm(League league)
        {
            InitializeComponent();
            if (league != null)
            {
                GetFreeAgents(league);
            }
        }
        private void GetFreeAgents(League league)
        {

        }
        private void FreeAgencyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
