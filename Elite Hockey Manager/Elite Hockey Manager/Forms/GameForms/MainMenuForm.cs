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

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class MainMenuForm : Form
    {
        public League League
        {
            get
            {
                return _league;
            }
        }
        private League _league;
        private int gamesToSim;
        public MainMenuForm(League league)
        {
            InitializeComponent();
            _league = league;
            this.Text = String.Format("{0} - Home", _league.LeagueName);
            //Adds the doWork function in league the background worker in the MainMenuForm for multithreading 
            simLeagueBackgroundWorker.DoWork += league.SimLeagueDoWork;
            //Events for switch from regular season to playoffs
            simLeagueRegularSeasonControl.AdvanceLeagueStateToPlayoffs += _league.AdvanceToPlayoffs;
            simLeagueRegularSeasonControl.AdvanceLeagueStateToPlayoffs += ChangeLayoutToPlayoffs;
            //Events for switch from playoffs to offseason 
            simLeaguePlayoffControl.AdvanceLeagueStateToOffseason += _league.AdvanceToOffseason;
            simLeaguePlayoffControl.AdvanceLeagueStateToOffseason += ChangeLayoutToOffseason;
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            standingsControl.ActiveLeague = _league;
            //If this is a new league being loaded, create a schedule and set state to regular season
            if (_league.State == LeagueState.Unset)
            {
                _league.StartSeason();
            }
            standingsControl.LoadSortConferences();
            if (League.DayIndex >= League.LeagueSchedule.SeasonSchedule.Count)
            {
                leagueGamesDisplay.SetSchedule(new List<Game>());
            }
            else
            {
                leagueGamesDisplay.SetSchedule(_league.LeagueSchedule.SeasonSchedule[_league.DayIndex]);
            }
            //Ofsets the variable which is base 0 to the respective day it cooresponds to. Day 0 to 1...
            leagueGamesDisplay.SetDay(League.DayIndex + 1);
            //Sets the statsControls list of player that will be sorted by their statistics, displays league leaders for each category
            leagueLeadersStatsControl.InsertPlayerList(_league.AllPlayers.ToArray());
            simLeagueRegularSeasonControl.LeagueSimmedEvent += SimLeague;

        }
        private void SimLeague(int days)
        {
            if (!simLeagueBackgroundWorker.IsBusy){
                //League.SimLeague(days);
                this.gamesToSim = League.LeagueSchedule.RemainingGamesToSim(League.DayIndex, days);
                simProgressBar.Maximum = gamesToSim;
                simProgressLabel.Text = String.Format("{0}/{1} Games Simmed", 0, gamesToSim);
                simLeagueBackgroundWorker.RunWorkerAsync(days);
            }
            else
            {
                MessageBox.Show("League is currently simming, please wait");
            }
        }
        private void SimPlayoffs(int days)
        {
            if (!simPlayoffBackgroundWorker.IsBusy)
            {
                simProgressLabel.Text = String.Format("{0} Games Simmed", 0);
                simPlayoffBackgroundWorker.RunWorkerAsync(days);
            }
            else
            {
                MessageBox.Show("League is currently simming playoffs, please wait for sim to complete");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(League);
        }

        private void ChangeLayoutToPlayoffs(object obj, EventArgs e)
        {
            standingsControl.Visible = false;
            standingsControl.Enabled = false;

            //leagueLeadersStatsControl.Visible = false;
            //leagueLeadersStatsControl.Enabled = false;
            leagueLeadersStatsControl.InsertPlayerList(League.currentPlayoff.GetAllPlayoffPlayers().ToArray());

            playoffDisplayControl.Visible = true;
            playoffDisplayControl.Enabled = true;
            playoffDisplayControl.League = this.League;
            playoffDisplayControl.UpdatePlayoffs();

            simLeagueRegularSeasonControl.Visible = false;
            simLeagueRegularSeasonControl.Enabled = false;

            simLeaguePlayoffControl.Visible = true;
            simLeaguePlayoffControl.Enabled = true;

            simProgressBar.Visible = false;
            simProgressBar.Enabled = false;

            Playoff playoff = _league.currentPlayoff;
            leagueGamesDisplay.SetSchedule(playoff.GetCurrentPlayoffGames());
            leagueGamesDisplay.SetPlayoffRoundAndDay(playoff.CurrentRound, playoff.CurrentDay);
            leagueGamesDisplay.LinkPlayoffMatchupViewControlEvents(playoffDisplayControl.GetActivePlayoffMatchupViewControls(playoff.CurrentRound));
            //Background worker for playoff will use Playoff.SimPlayoffsDoWork function
            simPlayoffBackgroundWorker.DoWork += playoff.SimPlayoffsDoWork;

            //Sim events from the simLeaguePlayoffControl will go to the main menus SimPlayoffs function
            simLeaguePlayoffControl.LeagueSimmedEvent += SimPlayoffs;
        }
        private void ChangeLayoutToOffseason(object obj, EventArgs e)
        {
            playoffDisplayControl.Visible = false;
            simLeaguePlayoffControl.Visible = false;
            simLeagueOffseasonControl1.Visible = true;
        }
        /// <summary>
        /// Function for display progress changed of simBackgroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simLeagueBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            simProgressLabel.Text = String.Format("{0}/{1} Games Simmed", e.ProgressPercentage, this.gamesToSim);
            simProgressBar.Value = e.ProgressPercentage;
        }
        /// <summary>
        /// Code that runs when the simBackgroundWorker is complete or cancelled 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simLeagueBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Updates the standingsControl to show updated results from games played
            standingsControl.LoadSortConferences();
            //Once simming is complete or cancelled, will display the new games on the schedule. if there are none, produces an empty game section and goes to playoffs
            if (League.DayIndex >= League.LeagueSchedule.SeasonSchedule.Count)
            {
                leagueGamesDisplay.SetSchedule(new List<Game>());
            }
            else
            {
                leagueGamesDisplay.SetSchedule(_league.LeagueSchedule.SeasonSchedule[_league.DayIndex]);
            }
            leagueGamesDisplay.SetDay(League.DayIndex + 1);
            //Updates the league leaders stats box when the league has been simmed, new stats to be re-sorted
            leagueLeadersStatsControl.InsertPlayerList(_league.AllPlayers.ToArray());

            if (_league.LeagueSchedule.IsFinishedSimming())
            {
                simLeagueRegularSeasonControl.EnableAdvanceStateButton();
            }
        }
        /// <summary>
        /// Report progress function for simPlayoffBackgroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simPlayoffBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            simProgressLabel.Text = String.Format("{0} Games Simmed", e.ProgressPercentage);
        }

        private void simPlayoffBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            playoffDisplayControl.UpdatePlayoffs();
            leagueGamesDisplay.SetSchedule(League.currentPlayoff.GetCurrentPlayoffGames());
            leagueGamesDisplay.SetPlayoffRoundAndDay(League.currentPlayoff.CurrentRound, League.currentPlayoff.CurrentDay);
            leagueLeadersStatsControl.InsertPlayerList(League.currentPlayoff.GetAllPlayoffPlayers().ToArray());
            //If the playoffs are not done being simmed, there are still games to be played
            if (!League.currentPlayoff.FinishedSimming)
            {
                leagueGamesDisplay.LinkPlayoffMatchupViewControlEvents(playoffDisplayControl.GetActivePlayoffMatchupViewControls(League.currentPlayoff.CurrentRound));
            }
            else
            {
                simLeaguePlayoffControl.EnableAdvanceStateButton();
            }
        }
    }
}
