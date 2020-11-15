using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;
using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays;
using Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses;

namespace Elite_Hockey_Manager.Classes
{
    public enum LeagueState
    {
        Unset,
        RegularSeason,
        Playoffs,
        Offseason
    }
    [Serializable]
    public class League : ISerializable
    {
        private int _numberOfTeams;
        private int _scheduleLength;
        private static double _salaryCap = 50;
        public const double MINSALARYCAP = 40;

        private Random rand = new Random();
        //Stores all the years of league games played, the last element in the list is the current year of the league
        private List<Schedule> _leagueHistorySchedules = new List<Schedule>();
        //Stores all the years of playoffs, last element in list is the current year of playoffs
        private List<Playoff> _leagueHistoryPlayoffs = new List<Playoff>();
        //Stores all the drafts that occur in the leagues history
        private List<Draft> _leagueHistoryDrafts = new List<Draft>();
        public int Year { get; private set; } = 1;
        public int DayIndex
        {
            get;
            private set;
        } = 0;
        public LeagueState State
        {
            get;
            private set;
        } = LeagueState.Unset;
        /// <summary>
        /// Amount of teams the league will contain
        /// </summary>
        public int NumberOfTeams
        {
            get
            {
                return _numberOfTeams;
            }
            private set
            {
                if (value < 6 || value > 32)
                {
                    throw new ArgumentException("Error: Team value must be between 6 and 32");
                }
                else
                {
                    _numberOfTeams = value;
                    //Sets the number of playoff teams based on the set NumberOfTeams
                    SetPlayoffRounds(_numberOfTeams);
                }
            }
        }
        /// <summary>
        /// Gets the number of playoff rounds by the number of playoff teams, determined by n in 2^n of playoff teams
        /// </summary>
        public PlayoffRounds PlayoffRounds
        {
            get;
            private set;
        } = PlayoffRounds.Two;
        public Schedule LeagueSchedule
        {
            get
            {
                return _leagueHistorySchedules.Last();
            }
        }
        public Playoff currentPlayoff
        {
            get
            {
                if (_leagueHistoryPlayoffs.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _leagueHistoryPlayoffs.Last();
                }

            }
        }
        /// <summary>
        /// The current draft is set as the latest draft occuring, if you wish to look back on further drafts use the function to pull up the list of drafts
        /// </summary>
        public Draft CurrentDraft
        {
            get
            {
                if (_leagueHistoryDrafts.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _leagueHistoryDrafts.Last();
                }
            }
        }
        /// <summary>
        /// The amount of teams that currently are within the league
        /// </summary>
        public int TeamCount
        {
            get
            {
                return AllTeams.Count;
            }
        }
        public static double SalaryCap
        {
            get
            {
                return _salaryCap;
            }
            set
            {
                if (value < MINSALARYCAP)
                {
                    throw new ArgumentException("SalaryCap must be lower than MinimumSalaryCap constant");
                }
                else
                {
                    _salaryCap = value;
                }
            }
        }
        public string LeagueName
        {
            get;
            private set;
        }
        public string Abbreviation
        {
            get;
            private set;
        }
        /// <summary>
        /// The number of players within all the leagues teams
        /// </summary>
        public int ActivePlayerCount
        {
            get
            {
                return ActivePlayers.Count;
            }
        }
        public string FirstConferenceName
        {
            get;
            private set;
        }
        public string SecondConferenceName
        {
            get;
            private set;
        }
        public List<Team> FirstConference
        {
            get;
            private set;
        } = new List<Team>();
        public List<Team> SecondConference
        {
            get;
            private set;
        } = new List<Team>();
        public List<Team> AllTeams
        {
            get
            {
                return FirstConference.Concat(SecondConference).ToList();
            }
        }
        public List<Player> ActivePlayers
        {
            get
            {
                List<Player> players = new List<Player>();
                players.AddRange(SignedPlayers);
                players.AddRange(UnsignedPlayers);
                return players;

            }
        }
        public List<Player> Players
        {
            get
            {
                List<Player> players = new List<Player>();
                players.AddRange(SignedPlayers);
                players.AddRange(UnsignedPlayers);
                players.AddRange(RetiredPlayers);
                return players;
            }
        }
        public List<Player> SignedPlayers
        {
            get
            {
                List<Team> teams = this.AllTeams;
                List<Player> players = new List<Player>();
                foreach (Team team in teams)
                {
                    players.AddRange(team.Roster);
                }
                return players;

            }
        }
        public List<Player> RetiredPlayers { get; private set; } = new List<Player>();
        public List<Player> UnsignedPlayers { get; private set; } = new List<Player>();
        public League(string name, string abbreviation, int teamsCount)
        {
            this.LeagueName = name;
            this.Abbreviation = abbreviation;
            this.NumberOfTeams = teamsCount;

            this.FirstConferenceName = "West";
            this.SecondConferenceName = "East";
        }
        public League(string name, string abbreviation, int teamsCount, string firstConferenceName, string secondConferenceName)
        {
            this.LeagueName = name;
            this.Abbreviation = abbreviation;
            this.NumberOfTeams = teamsCount;

            this.FirstConferenceName = firstConferenceName;
            this.SecondConferenceName = secondConferenceName;
        }
        /// <summary>
        /// Starts the season by adding a new generated schedule. Sets the day index and LeagueState
        /// </summary>
        public void StartSeason()
        {
            //Only needs to be called upon leagues first startup which is only time state will be unset
            if (State == LeagueState.Unset)
            {
                InitializePlayersProgressionTrackers();
            }
            _leagueHistorySchedules.Add(new LeagueComponents.Schedule(FirstConference, SecondConference, rand));
            //Sets the day counter to the first day of the schedule
            DayIndex = 0;
            //Sets the League State to the regular season state
            State = LeagueState.RegularSeason;
            _scheduleLength = this.LeagueSchedule.SeasonSchedule.Count;
        }
        private void InitializePlayersProgressionTrackers()
        {
            //Sets each player in this league to have an initial progression tracker, only needs to be done upon leagues first ever setup
            foreach (Player player in this.ActivePlayers)
            {
                player.InitializePlayerProgressionTracker(this.Year);
            }
        }
        /// <summary>
        /// Creates random teams to fill out the rest of the leagues teams
        /// </summary>
        public  void FillRemainingTeams()
        {
            //If the league is full
            if (IsFull())
            {
                return;
            }
            //If the number of teams is odd
            if (NumberOfTeams % 2 == 1)
            {
                //gets the max conference size
                int largeConferenceSize = (NumberOfTeams + 1) / 2;
                if (FirstConference.Count != largeConferenceSize && SecondConference.Count != largeConferenceSize)
                {
                    FillConference(FirstConference, largeConferenceSize);
                    FillConference(SecondConference, largeConferenceSize - 1);
                }
                else
                {
                    if (FirstConference.Count == largeConferenceSize)
                    {
                        FillConference(SecondConference, largeConferenceSize - 1);
                    }
                    else
                    {
                        FillConference(FirstConference, largeConferenceSize - 1);
                    }
                }
            }
            //If the number of teams is even
            else
            {
                int maxConferenceSize = (NumberOfTeams / 2);
                FillConference(FirstConference, maxConferenceSize);
                FillConference(SecondConference, maxConferenceSize);
            }
        }
        /// <summary>
        /// Fills a conference with randomly generated teams to fill the conferences size
        /// </summary>
        /// <param name="conference">Conference that will have teams added onto it</param>
        /// <param name="desiredSize">Desired size of conference</param>
        public static void FillConference(List<Team> conference, int desiredSize)
        {
            if (desiredSize < 0)
            {
                throw new ArgumentOutOfRangeException("Argument must be 0 or greater");
            }
            int addCount = desiredSize - conference.Count;
            for (int i = 0; i < addCount; i++)
            {
                Tuple<string, string> teamInfo = TeamGenerator.GetFullTeamName();
                Team addTeam = new Team(teamInfo.Item1, teamInfo.Item2);
                conference.Add(addTeam);
            }
        }
        /// <summary>
        /// Function that returns whether the league is at its specified size
        /// </summary>
        /// <returns>Returns boolean of whether league is full of teams</returns>
        public bool IsFull()
        {
            return FirstConference.Count + SecondConference.Count == _numberOfTeams;
        }
        public override string ToString()
        {
            return String.Format("{0} - {1} - Teams:{2}", this.Abbreviation, this.LeagueName, this.NumberOfTeams);
        }
        /// <summary>
        /// Checks if a team exists within the league. Exists for avoiding duplicates within the league
        /// </summary>
        /// <param name="team">Team to be checked within the league for its existence</param>
        /// <returns></returns>
        private bool DoesTeamExist(Team team)
        {
            return AllTeams.Contains(team);
        }
        /// <summary>
        /// Checks if a team can be added to a certain conference. 
        /// Used primarily for odd sized league logic
        /// </summary>
        /// <param name="conference">
        /// 1 - First Conference
        /// 2 - Second conference
        /// </param>
        /// <returns></returns>
        private bool ConferenceSpaceCheck(int conference)
        {
            int selectedConferenceSize;
            if (conference == 1)
            {
                selectedConferenceSize = FirstConference.Count;
            }
            else if (conference == 2)
            {
                selectedConferenceSize = SecondConference.Count;
            }
            else
            {
                //Error, not specified conference
                throw new ArgumentException("Invalid conference selection");
            }
            if (_numberOfTeams % 2 == 0)
            {
                int maxTeams = _numberOfTeams / 2;
                return !(selectedConferenceSize == maxTeams);
            }
            //If odd
            else
            {
                int maxTeams = (_numberOfTeams + 1) / 2;
                return !(selectedConferenceSize == maxTeams);

            }
        }
        public void AddTeam(Team team, int conference = 1)
        {
            if (team == null)
            {
                throw new ArgumentNullException("Team is not defined. Cannot be added to conference");
            }
            //Throws exception if an exact team object already exists in league
            if (DoesTeamExist(team))
            {
                throw new ArgumentException("Team already exists within the league, league can't have mutliples of a single team");
            }
            if (AllTeams.Count == _numberOfTeams)
            {
                throw new ArgumentException("League is full, can not add another team");
            }
            if (!ConferenceSpaceCheck(conference))
            {
                throw new ArgumentException("Conference is full, can only add to the other conference");
            }
            switch (conference)
            {
                case 1:
                    FirstConference.Add(team);
                    break;
                case 2:
                    SecondConference.Add(team);
                    break;
                default:
                    throw new ArgumentException("Conference is not defined");
            }
        }
        /// <summary>
        /// Fills each team in the league with the minimum number of players to function
        /// </summary>
        public void FillLeagueWithPlayers()
        {
            foreach (Team team in FirstConference)
            {
                TeamGenerator.FillTeam(team);
            }
            foreach (Team team in SecondConference)
            {
                TeamGenerator.FillTeam(team);
            }
        }
        public int GetTeamErrorCount()
        {
            int teamErrors = 0;
            teamErrors += (this._numberOfTeams - this.TeamCount);
            foreach (Team team in AllTeams)
            {
                if (!team.ValidMinimumTeamSize())
                {
                    teamErrors++;
                }
            }
            return teamErrors;
        }
        public string GetTeamErrorMessage()
        {
            string errorMessage = "";
            foreach (Team team in AllTeams)
            {
                if (!team.ValidMinimumTeamSize())
                {
                    errorMessage += String.Format("{0}\n", team.FullName);
                }
            }
            return errorMessage;
        }
        public void SimLeague(int days)
        {
            if (DayIndex + days > LeagueSchedule.Length)
            {
                days = LeagueSchedule.Length - DayIndex;
            }
            for (int i = 0; i < days; i++) {
                LeagueSchedule.SimDay(DayIndex);
                DayIndex++;
            }
        }
        public void SimLeagueDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            int gameSimmedCount = 0;
            int simLength = (int)e.Argument;
            //If days passed is -1, sim remaining games in the season, calculates number of days left on the schedule
            if (simLength == -1)
            {
                simLength = LeagueSchedule.SeasonSchedule.Count - DayIndex;
            }
           //If the requested amount to sim is greater than the rest of the seasons schedule, lowers the sim amount to only remaining days
           if (simLength > (LeagueSchedule.SeasonSchedule.Count - (DayIndex)))
            {
                simLength = LeagueSchedule.SeasonSchedule.Count - DayIndex;
            }
           //Goes through each day requested to sim and sims that day, returns progress to calling form
           for (int i = 0; i < simLength; i++)
            {
                //Adds the amount of games simmed that day to the gameSimmedCount variable to show progress
                gameSimmedCount += LeagueSchedule.SeasonSchedule[DayIndex].Where(game => !game.Finished).Count();
                //Sims 1 day in the league
                SimLeague(1);
                worker.ReportProgress(gameSimmedCount);      
            }
        }
        public void AdvanceToPlayoffs(object sender, EventArgs e)
        {
            //In case this function is called without the regular season being complete, display error to console and force a finish to all simming of regular season
            if (!LeagueSchedule.IsFinishedSimming())
            {
                Console.Error.WriteLine("League schedule did not finish simming at the time of the League.StartPlayoffs function call");
                //Forces the remaining games in the schedule to be simmed
                LeagueSchedule.ForceFinishSimming();
            }
            if (this.State == LeagueState.Playoffs)
            {
                Console.Error.WriteLine("League already in playoff state when League.AdvanceToPlayoffs called");
            }
            else
            {
                //Turns the state of the league to playoffs
                this.State = LeagueState.Playoffs;
                //Confirms the two conferences are sorted so the playoff teams are correct
                SortTeamList(FirstConference);
                SortTeamList(SecondConference);
                this._leagueHistoryPlayoffs.Add(new Playoff(this.PlayoffRounds, this.Year, FirstConference, SecondConference));
            }
        }
        public void AdvanceToOffseason(object sender, EventArgs e)
        {
            Year++;
            State = LeagueState.Offseason;

            //Updates each teams internal year variable
            foreach (Team team in AllTeams)
                team.AdvanceYear();
            //Generates draft order based on league standings and playoff performance 
            Team[] draftOrder = GenerateDraftOrder();
            _leagueHistoryDrafts.Add(new Draft(Year, _numberOfTeams, draftOrder));
            //Ages every rostered player in the league and updates attributes
            foreach (Player player in ActivePlayers)
            {
                player.AgePlayerAndProgress();
                if (Retirement.ChooseToRetire(player, player.CurrentTeam, rand)) {
                    player.Retired = true;
                }
                //Advances a year in the players contract
                //if the contract remaining becomes 0 then the player is a free agent
                if (player.CurrentContract.YearsRemaining > 0) { 
                    player.CurrentContract.YearsRemaining -= 1;
                }

            }

        }
        public void SimulateResignPhase()
        {
            //Beginning of the next year will begin tracking at start of resign phase
            this.Year++;
            List<Player> newlyRetiredPlayers = ActivePlayers.Where(p => p.Retired == true).ToList();
            //Moves all retired players into retiredPlayers list and removes them from the active list
            foreach (Player player in newlyRetiredPlayers)
            {
                RetiredPlayers.Add(player);
                ActivePlayers.Remove(player);
                if (player.CurrentTeam != null)
                {
                    player.CurrentTeam.Roster.Remove(player);
                }
            }
            //Will simulate the resigning of active players with expiring contracts
            Resign.SimulateResignPeriod(this, rand);
        }
        public void SimulateFreeAgencyPhase()
        {
            FreeAgency.SimulateFreeAgencyPeriod(this, rand);
        }
        /// <summary>
        /// Generates the order of the draft based on standings from the previous season
        /// Non playoff teams are ordered worst to best
        /// Playoff teams are ordered by round placement from worst to best with regular season tiebreakers for teams ending in same rounds
        /// </summary>
        /// <returns>An ordered array from worst to best of all the teams in the league for drafting</returns>
        private Team[] GenerateDraftOrder()
        {
            Team[] DraftOrder = new Team[AllTeams.Count()];
            //Playoff teams in order for draft selection
            Team[] orderedPlayoffTeams = currentPlayoff.DraftOrderedPlayoffTeams();
            //All non playoff teams 
            Team[] nonPlayoffTeams = AllTeams.Except(orderedPlayoffTeams.ToList()).ToArray();
            //Sort by regular season standing in ascending order
            Array.Sort(nonPlayoffTeams);
            //Combine 2 arrays together into draft order
            Array.Copy(nonPlayoffTeams, 0, DraftOrder, 0, nonPlayoffTeams.Count());
            Array.Copy(orderedPlayoffTeams, 0, DraftOrder, nonPlayoffTeams.Count(), orderedPlayoffTeams.Count());
            return DraftOrder;
            
        }
        /// <summary>
        /// Sets the number of playoff teams and rounds by how many teams are in the league
        /// Number of teams between 6-10 will have 2 rounds with 4 playoff teams
        /// Number of teams between 11-23 will have 3 rounds with 8 playoff teams
        /// Number of teams greater than 23 will have 4 rounds with 16 playoff teams
        /// </summary>
        /// <param name="numberOfTeams">Number of teams in the league, will be called each time the number of times league property is set</param>
        private void SetPlayoffRounds(int numberOfTeams)
        {
            if (numberOfTeams > 23)
            {
                PlayoffRounds = PlayoffRounds.Four;
            }
            else if (numberOfTeams > 11)
            {
                PlayoffRounds = PlayoffRounds.Three;
            }
            else
            {
                PlayoffRounds = PlayoffRounds.Two;
            }
        }
        #region Player Progression
        private void ProgressAllLeagueActivePlayers()
        {

        }



        #endregion 
        /// <summary>
        /// Sorts a list of teams by their record
        /// </summary>
        /// <param name="teamList">List of team objects</param>
        public static void SortTeamList(List<Team> teamList)
        {
            teamList.Sort();
            teamList.Reverse();
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LeagueName", this.LeagueName);
            info.AddValue("LeagueAbbreviation", this.Abbreviation);
            info.AddValue("TeamAmount", this.NumberOfTeams);

            info.AddValue("FirstConference", this.FirstConference);
            info.AddValue("FirstConferenceName", this.FirstConferenceName);

            info.AddValue("SecondConference", this.SecondConference);
            info.AddValue("SecondConferenceName", this.SecondConferenceName);

            info.AddValue("Random", this.rand);

            info.AddValue("State", this.State);

            info.AddValue("Schedules", this._leagueHistorySchedules);
            info.AddValue("Playoffs", this._leagueHistoryPlayoffs);
            info.AddValue("Drafts", this._leagueHistoryDrafts);
        }
        protected League(SerializationInfo info, StreamingContext context)
        {
            this.LeagueName = (string)info.GetValue("LeagueName", typeof(string));
            this.Abbreviation = (string)info.GetValue("LeagueAbbreviation", typeof(string));
            this.NumberOfTeams = (int)info.GetValue("TeamAmount", typeof(int));

            this.FirstConference = (List<Team>)info.GetValue("FirstConference", typeof(List<Team>));
            this.FirstConferenceName = (string)info.GetValue("FirstConferenceName", typeof(string));

            this.SecondConference = (List<Team>)info.GetValue("SecondConference", typeof(List<Team>));
            this.SecondConferenceName = (string)info.GetValue("SecondConferenceName", typeof(string));

            this.rand = (Random)info.GetValue("Random", typeof(Random));

            this.State = (LeagueState)info.GetValue("State", typeof(LeagueState));

            this._leagueHistorySchedules = (List<Schedule>)info.GetValue("Schedules", typeof(List<Schedule>));
            this._leagueHistoryPlayoffs = (List<Playoff>)info.GetValue("Playoffs", typeof(List<Playoff>));
            this._leagueHistoryDrafts = (List<Draft>)info.GetValue("Drafts", typeof(List<Draft>));
        }
    }
}
