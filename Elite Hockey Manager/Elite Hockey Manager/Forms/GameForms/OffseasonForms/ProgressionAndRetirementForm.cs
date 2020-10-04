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
    public partial class ProgressionAndRetirementForm : Form
    {
        private League _league;
        public ProgressionAndRetirementForm()
        {
            InitializeComponent();
        }
        public ProgressionAndRetirementForm(League league)
        {
            InitializeComponent();
            _league = league;
        }
        private void ProgressionAndRetirementForm_Load(object sender, EventArgs e)
        {
            LoadPlayersIntoTable(_league.AllPlayers);
        }
        private void LoadPlayersIntoTable(List<Player> players)
        {
            var data = from p in players
                       orderby p.ProgressionTracker.LatestTotalChangeInAttributes()
                       select new
                       {
                           Player = p.FullName,
                           p.Age,
                           Base_Overall = p.ProgressionTracker.OverallTrackerList[p.ProgressionTracker.OverallTrackerList.Count - 2],
                           New_Overall = p.ProgressionTracker.OverallTrackerList.Last(),
                           Total_Change = p.ProgressionTracker.LatestTotalChangeInAttributes()

                       };
            playerStatsDataView.DataSource = data.ToList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
