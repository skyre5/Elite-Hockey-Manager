using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class ViewTeamForm : Form
    {
        private Team _team;


        public ViewTeamForm(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("Team entered was null in ViewTeamForm");
            }
            _team = team;
            InitializeComponent();
            teamLinesControl.Team = team;
            teamCapControl.Team = team;
            this.Text = team.FullName;
        }

        private void ViewTeamForm_Load(object sender, EventArgs e)
        {

        }


    }
}
