using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    public partial class ProgressionAndRetirementForm : Form
    {
        DataTable playerTable = new DataTable();
        private League _league;
        public ProgressionAndRetirementForm()
        {
            InitializeComponent();
        }
        public ProgressionAndRetirementForm(League league) : this()
        {
            _league = league;
            playerTable.Columns.Add("ID", typeof(int));
            playerTable.Columns.Add("TeamID", typeof(int));
            playerTable.Columns.Add("Name", typeof(string));
            playerTable.Columns.Add("Age", typeof(int));
            playerTable.Columns.Add("Base Overall", typeof(int));
            playerTable.Columns.Add("New Overall", typeof(int));
            playerTable.Columns.Add("Total Change", typeof(int));
        }
        private void ProgressionAndRetirementForm_Load(object sender, EventArgs e)
        {
            LoadPlayersIntoTable(_league.AllPlayers);
        }
        private void LoadPlayersIntoTable(List<Player> players)
        {
            var query = from p in players
                        orderby p.ProgressionTracker.LatestTotalChangeInAttributes()
                        select new
                        {
                           p.ID,
                           p.CurrentTeam.TeamID,
                           Name = p.FullName,
                           p.Age,
                           BaseOverall = p.ProgressionTracker.OverallTrackerList[p.ProgressionTracker.OverallTrackerList.Count - 2],
                           NewOverall = p.ProgressionTracker.OverallTrackerList.Last(),
                           TotalChange = p.ProgressionTracker.LatestTotalChangeInAttributes()

                       };
            foreach (var player in query)
            {
                DataRow row = playerTable.Rows.Add();
                row.SetField("ID", player.ID);
                row.SetField("Name", player.Name);
                row.SetField("Age", player.Age);
                row.SetField("Base Overall", player.BaseOverall);
                row.SetField("New Overall", player.NewOverall);
                row.SetField("Total Change", player.TotalChange);
            }
            playerStatsDataView.DataSource = playerTable;
            playerStatsDataView.Columns["ID"].Visible = false;
            playerStatsDataView.Columns["TeamID"].Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void teamBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void playerStatsDataView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
    }
}
