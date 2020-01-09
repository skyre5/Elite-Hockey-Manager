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

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class MainMenuForm : Form
    {
        private League _league;
        public League League
        {
            get
            {
                return _league;
            }
        }
        public MainMenuForm(League league)
        {
            _league = league;
            this.Text = String.Format("{0} - Home", _league.LeagueName);
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            standingsControl.ActiveLeague = _league;
            //If this is a new league being loaded, create a schedule and set state to regular season
            if (_league.State == LeagueState.Unset)
            {
                _league.StartSeason();
            }
            standingsControl.LoadConferences();
            if (League.DayIndex >= League.Schedule.SeasonSchedule.Count)
            {
                leagueGamesDisplay.SetSchedule(new List<Game>());
            }
            else
            {
                leagueGamesDisplay.SetSchedule(_league.Schedule.SeasonSchedule[_league.DayIndex]);
            }
            //Ofsets the variable which is base 0 to the respective day it cooresponds to. Day 0 to 1...
            leagueGamesDisplay.SetDay(League.DayIndex + 1);
            //Sets the statsControls list of player that will be sorted by their statistics, displays league leaders for each category
            leagueLeadersStatsControl.InsertPlayerList(_league.AllPlayers.ToArray());
            simLeagueControl.LeagueSimmedEvent += SimLeague;

        }
        private void SimLeague(int days)
        {
            League.SimLeague(days);
            if (League.DayIndex >= League.Schedule.SeasonSchedule.Count)
            {
                leagueGamesDisplay.SetSchedule(new List<Game>());
            }
            else
            {
                leagueGamesDisplay.SetSchedule(_league.Schedule.SeasonSchedule[_league.DayIndex]);
            }
            leagueGamesDisplay.SetDay(League.DayIndex + 1);
            //Updates the league leaders stats box when the league has been simmed, new stats to be re-sorted
            leagueLeadersStatsControl.InsertPlayerList(_league.AllPlayers.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(League);
        }
    }
}
