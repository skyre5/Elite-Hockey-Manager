using Elite_Hockey_Manager.Classes;
using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Forms;
using Elite_Hockey_Manager.Forms.HelperForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Elite_Hockey_Manager
{
    using Elite_Hockey_Manager.Classes.Players;

    public partial class HomeForm : Form
    {
        #region Fields

        private Game game;

        #endregion Fields

        #region Constructors

        public HomeForm()
        {
            InitializeComponent();
            Team team1 = TeamGenerator.GetTeam();
            Team team2 = TeamGenerator.GetTeam();
            TeamGenerator.FillTeam(team1);
            TeamGenerator.FillTeam(team2);
            Random rand = new Random();
            game = new Game(team1, team2, rand);
        }

        #endregion Constructors

        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            NewGameForm form = new NewGameForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Team x = TeamGenerator.GetTeam();
            Team y = TeamGenerator.GetTeam();
            TeamGenerator.FillTeam(x);
            TeamGenerator.FillTeam(y);
            x.Roster.Add(PlayerGenerator.GenerateForward(1, 1));
            x.AutoSetForwardLines();
            Game game = new Game(x, y, new Random());
            game.PlayGame();
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void homeForm_Load(object sender, EventArgs e)
        {
            Center c = new Center("1", "2", 20);
            SkaterAttributes attrib = new SkaterAttributes();
            Center center2 = new Center("1", "2", 22, attrib);
            List<Forward> list1 = new List<Forward>();
            List<Center> list2 = new List<Center>();
            //Team x = new Team("Philly Flyers");
        }

        private void leagueButton_Click(object sender, EventArgs e)
        {
            CreateLeagueForm form = new CreateLeagueForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void playersBtn_Click(object sender, EventArgs e)
        {
            CreatePlayerForm form = new CreatePlayerForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void teamsButton_Click(object sender, EventArgs e)
        {
            CreateTeamForm form = new CreateTeamForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        #endregion Methods

        /// <summary>
        /// Opens the importNewGameForm where the player can import existing information from the NHL API
        /// </summary>
        /// <param name="sender">button obj</param>
        /// <param name="e">event args</param>
        private void ImportNewGameButton_Click(object sender, EventArgs e)
        {
            ImportForm form = new ImportForm();
            this.Hide();
            form.ShowDialog();
        }
    }
}