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
using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Forms;
using Elite_Hockey_Manager.Forms.GameForms;
using Elite_Hockey_Manager.Forms.HelperForms;
using System.Collections;

namespace Elite_Hockey_Manager
{
    public partial class HomeForm : Form
    {
        private Game game;
        public HomeForm()
        {
            InitializeComponent();
            Team team1 = TeamGenerator.GetTeam();
            Team team2 = TeamGenerator.GetTeam();
            TeamGenerator.FillTeam(team1);
            TeamGenerator.FillTeam(team2);
            game = new Game(team1, team2);
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

        private void leagueButton_Click(object sender, EventArgs e)
        {
            CreateLeagueForm form = new CreateLeagueForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGameForm form = new NewGameForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            League league = new Classes.League("National Hockey League", "NHL", 32);
            league.FillRemainingTeams();
            Schedule schedule = new Classes.LeagueComponents.Schedule(league.FirstConference, league.SecondConference);

        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
