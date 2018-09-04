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
using Elite_Hockey_Manager.Forms;

namespace Elite_Hockey_Manager
{
    public partial class homeForm : Form
    {
        public homeForm()
        {
            InitializeComponent();
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
            PlayersForm form = new PlayersForm();
            form.ShowDialog();
        }

        private void teamsButton_Click(object sender, EventArgs e)
        {
            TeamForm form = new TeamForm();
            form.ShowDialog();
        }

        private void leagueButton_Click(object sender, EventArgs e)
        {
            LeagueForm form = new LeagueForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            League league = new Classes.League("Elite Hockey League", "EHL", 32);
            league.FillRemainingTeams();
            league.FillLeagueWithPlayers();

        }
    }
}
