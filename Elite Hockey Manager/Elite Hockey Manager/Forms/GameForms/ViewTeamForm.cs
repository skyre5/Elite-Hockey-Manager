using Elite_Hockey_Manager.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    using Elite_Hockey_Manager.Classes.Players;

    public partial class ViewTeamForm : Form
    {
        #region Fields

        private Team _team;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor for ViewTeamForm
        /// </summary>
        /// <param name="team">Team to show information about in form</param>
        public ViewTeamForm(Team team)
        {
            // Throws error when form is loaded without team
            if (team == null)
            {
                throw new ArgumentNullException("Team entered was null in ViewTeamForm");
            }

            _team = team;

            // Class needs team loaded prior to Component being initialized
            InitializeComponent();

            teamLinesControl.Team = team;
            teamCapControl.Team = team;
            this.Text = team.FullName;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// When open stats page button is pressed on the StatsControl
        /// </summary>
        private void StatsControl_OpenStatsPageEvent()
        {
            // Opens up the stats form with current season stats only and only this players teams selected
            PlayerStatsForm form = new PlayerStatsForm(false, this._team);
            form.ShowDialog();
        }

        private void ViewTeamForm_Load(object sender, EventArgs e)
        {
            statsControl.InsertSkaterList(_team.Roster.Where(player => player is Skater).Cast<Skater>().ToArray());
            statsControl.InsertGoalieList(_team.Goalies);
        }

        #endregion Methods
    }
}