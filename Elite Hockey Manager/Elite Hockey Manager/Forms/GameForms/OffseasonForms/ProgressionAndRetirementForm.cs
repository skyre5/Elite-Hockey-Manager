using Elite_Hockey_Manager.Classes;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    public partial class ProgressionAndRetirementForm : Form
    {
        #region Fields

        private League _league;
        private DataTable _playerTable = new DataTable();
        private bool _retiredPlayers = false;
        private Team _selectedTeam = null;

        #endregion Fields

        #region Constructors

        public ProgressionAndRetirementForm()
        {
            InitializeComponent();
        }

        public ProgressionAndRetirementForm(League league) : this()
        {
            _league = league;
            _playerTable.Columns.Add("Tracker", typeof(PlayerProgressionTracker));
            _playerTable.Columns.Add("TeamID", typeof(int));
            _playerTable.Columns.Add("Name", typeof(string));
            _playerTable.Columns.Add("Age", typeof(int));
            _playerTable.Columns.Add("Base Overall", typeof(int));
            _playerTable.Columns.Add("New Overall", typeof(int));
            _playerTable.Columns.Add("Total Change", typeof(int));
            _playerTable.Columns.Add("Retired", typeof(bool));
        }

        #endregion Constructors

        #region Methods

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

        private int GetLatestDifference(List<int> values)
        {
            return values.Last() - values[values.Count - 2];
        }

        private string GetSign(int value)
        {
            return value > 0 ? "+" : String.Empty;
        }

        private void LoadPlayersIntoTable(List<Player> players)
        {
            var query = from p in players
                        orderby p.ProgressionTracker.LatestTotalChangeInAttributes()
                        select new
                        {
                            p.ProgressionTracker,
                            p.CurrentTeam?.TeamID,
                            Name = p.FullName,
                            p.Age,
                            BaseOverall =
                                           p.ProgressionTracker.OverallTrackerList
                                               [p.ProgressionTracker.OverallTrackerList.Count - 2],
                            NewOverall = p.ProgressionTracker.OverallTrackerList.Last(),
                            TotalChange = p.ProgressionTracker.LatestTotalChangeInAttributes(),
                            p.Retired
                        };
            foreach (var player in query)
            {
                DataRow row = _playerTable.Rows.Add();
                row.SetField("Tracker", player.ProgressionTracker);
                row.SetField("TeamID", player.TeamID);
                row.SetField("Name", player.Name);
                row.SetField("Age", player.Age);
                row.SetField("Base Overall", player.BaseOverall);
                row.SetField("New Overall", player.NewOverall);
                row.SetField("Total Change", player.TotalChange);
                row.SetField("Retired", player.Retired);
            }
            playerStatsDataView.DataSource = _playerTable;
            //ChangeColorOfTotalChangeRows();
            playerStatsDataView.Columns["Tracker"].Visible = false;
            playerStatsDataView.Columns["TeamID"].Visible = false;
            playerStatsDataView.Columns["Retired"].SortMode = DataGridViewColumnSortMode.Automatic;
            playerStatsDataView.Sort(this.playerStatsDataView.Columns["Total Change"], ListSortDirection.Descending);
        }

        private void LoadTeamsIntoComboBox(List<Team> teams)
        {
            foreach (Team team in teams)
            {
                teamSelectionComboBox.Items.Add(team);
            }
        }

        private void playerStatsDataView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void playerStatsDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ChangeColorOfTotalChangeRows();
        }

        private void playerStatsDataView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            //If event is called when a cell is not being clicked such as during the building of the table
            //Return without building the playerDisplayLabel text
            if (view.SelectedRows.Count == 0)
            {
                return;
            }
            //The row of the cell the user clicked up
            DataGridViewRow row = view.SelectedRows[0];
            string name = (string)row.Cells["Name"].Value;

            int newOverall = (int)row.Cells["New Overall"].Value;
            int oldOverall = (int)row.Cells["Base Overall"].Value;
            int overallChange = newOverall - oldOverall;
            string sign = GetSign(overallChange);

            PlayerProgressionTracker tracker = (PlayerProgressionTracker)row.Cells["Tracker"].Value;
            //Sets the text blank from latest call of function
            playerDisplayLabel.Text = "";
            playerDisplayLabel.Text += $"{name}\r\n";
            playerDisplayLabel.Text += $"Overall: {newOverall}({sign}{overallChange})\r\n";
            //For every stat in the attribute dictionary build a new line of the label for its name, new value, and its change since last season
            foreach (string key in tracker.AttributeTrackerDictionary.Keys)
            {
                int difference = GetLatestDifference(tracker.AttributeTrackerDictionary[key]);
                playerDisplayLabel.Text += $"{key}: {tracker.AttributeTrackerDictionary[key].Last()}" +
                    $"({GetSign(difference)}{difference})\r\n";
            }
        }

        private void ProgressionAndRetirementForm_Load(object sender, EventArgs e)
        {
            LoadPlayersIntoTable(_league.ActivePlayers);
            LoadTeamsIntoComboBox(_league.AllTeams);
        }

        private void retirementCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _retiredPlayers = ((CheckBox)sender).Checked;
            SelectByTeamAndRetirement();
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
            playerStatsDataView.DataSource = query.CopyToDataTable();
            ChangeColorOfTotalChangeRows();
        }

        private void teamBindingSource_CurrentChanged(object sender, EventArgs e)
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

        #endregion Methods
    }
}