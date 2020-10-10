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
        private DataTable _playerTable = new DataTable();
        private League _league;
        private bool _retiredPlayers = false;
        private Team _selectedTeam = null;
        public ProgressionAndRetirementForm()
        {
            InitializeComponent();
        }
        public ProgressionAndRetirementForm(League league) : this()
        {
            _league = league;
            _playerTable.Columns.Add("ID", typeof(int));
            _playerTable.Columns.Add("TeamID", typeof(int));
            _playerTable.Columns.Add("Name", typeof(string));
            _playerTable.Columns.Add("Age", typeof(int));
            _playerTable.Columns.Add("Base Overall", typeof(int));
            _playerTable.Columns.Add("New Overall", typeof(int));
            _playerTable.Columns.Add("Total Change", typeof(int));
            _playerTable.Columns.Add("Retired", typeof(bool));
        }
        private void ProgressionAndRetirementForm_Load(object sender, EventArgs e)
        {
            LoadPlayersIntoTable(_league.AllPlayers);
            LoadTeamsIntoComboBox(_league.AllTeams);
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
                           TotalChange = p.ProgressionTracker.LatestTotalChangeInAttributes(),
                           Retired = p.ProgressionTracker.IsRetired

                       };
            foreach (var player in query)
            {
                DataRow row = _playerTable.Rows.Add();
                row.SetField("ID", player.ID);
                row.SetField("TeamID", player.TeamID);
                row.SetField("Name", player.Name);
                row.SetField("Age", player.Age);
                row.SetField("Base Overall", player.BaseOverall);
                row.SetField("New Overall", player.NewOverall);
                row.SetField("Total Change", player.TotalChange);
                row.SetField("Retired", player.Retired);
            }
            playerStatsDataView.DataSource = _playerTable;
            ChangeColorOfTotalChangeRows();
            playerStatsDataView.Columns["ID"].Visible = false;
            playerStatsDataView.Columns["TeamID"].Visible = false;
        }
        private void LoadTeamsIntoComboBox(List<Team> teams)
        {
            foreach (Team team in teams) {
                teamSelectionComboBox.Items.Add(team);
            }
        }
        private void ChangeColorOfTotalChangeRows()
        {
            foreach (DataGridViewRow row in playerStatsDataView.Rows)
            {
                DataGridViewCell cell = row.Cells["Total Change"];
                switch ((int)cell.Value)
                {
                    case int n when (n >= 10):
                        cell.Style.BackColor = Color.LightBlue;
                        break;
                    case int n when (n >= 5):
                        cell.Style.BackColor = Color.Green;
                        break;
                    case int n when (n > 0):
                        cell.Style.BackColor = Color.LightGreen;
                        break;
                    case int n when (n <= -10):
                        cell.Style.BackColor = Color.Red;
                        break;
                    case int n when (n <= -5):
                        cell.Style.BackColor = Color.Orange;
                        break;
                    case int n when (n < 0):
                        cell.Style.BackColor = Color.PaleVioletRed;
                        break;

                }
            }
        }
        private void SelectByTeamAndRetirement()
        {
            if (_playerTable == null)
            {
                return;
            }
            var query = from p in _playerTable.AsEnumerable()
                        where (_selectedTeam == null || p.Field<int?>("TeamID") == _selectedTeam.TeamID)
                        where p.Field<bool>("Retired") == _retiredPlayers
                        select p;
            playerStatsDataView.DataSource = query.CopyToDataTable() ;
            ChangeColorOfTotalChangeRows();

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

        private void teamSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.SelectedIndex == 0)
            {
                _selectedTeam = null;
            }
            else
            {
                _selectedTeam = (Team)box.SelectedItem;
            }
            SelectByTeamAndRetirement();
        }

        private void retirementCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _retiredPlayers = ((CheckBox)sender).Checked;
        }
    }
}
