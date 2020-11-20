using Elite_Hockey_Manager.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
            statsControl.InsertSkaterList(_team.Roster.Where(player => player is Skater).Cast<Skater>().ToArray());
            statsControl.InsertGoalieList(_team.Goalies);
        }
    }
}