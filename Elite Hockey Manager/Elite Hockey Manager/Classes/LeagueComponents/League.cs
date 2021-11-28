using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays;
using Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;

    public enum LeagueState
    {
        Unset,
        RegularSeason,
        Playoffs,
        Offseason
    }

    /// <summary>
    /// The offseason stages
    /// </summary>
    public enum OffseasonStage
    {
        /// <summary>
        /// Stage where players attributes are changed and players decide to retire from the league
        /// </summary>
        ProgressionAndRetirement,

        /// <summary>
        /// Stage where new players are drafted to teams based on talent level and attributes
        /// </summary>
        Draft,

        /// <summary>
        /// Stage where players may choose to sign contracts with their team from the prior season
        /// </summary>
        Resign,

        /// <summary>
        /// Stage where players without contracts may join a new team
        /// </summary>
        FreeAgency
    }

    [Serializable]
    public class League
    {
        #region Fields

        public const double MINSALARYCAP = 40;
        private static double _salaryCap = 50;

        private readonly Random rand = new Random();

        //Stores all the drafts that occur in the leagues history
        private List<Draft> _leagueHistoryDrafts = new List<Draft>();

        //Stores all the years of playoffs, last element in list is the current year of playoffs
        private List<Playoff> _leagueHistoryPlayoffs = new List<Playoff>();

        //Stores all the years of league games played, the last element in the list is the current year of the league
        private List<Schedule> _leagueHistorySchedules = new List<Schedule>();

        private int _numberOfTeams;
        private int _scheduleLength;

        #endregion Fields

        #region Constructors

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

        #endregion Constructors

        #region Properties

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

        public List<Team> AllTeams
        {
            get
            {
                return FirstConference.Concat(SecondConference).ToList();
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

        public Playoff CurrentPlayoff
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

        public int DayIndex
        {
            get;
            private set;
        } = 0;

        public List<Team> FirstConference
        {
            get;
            private set;
        } = new List<Team>();

        public string FirstConferenceName
        {
            get;
            private set;
        }

        public string LeagueName
        {
            get;
            private set;
        }

        public Schedule LeagueSchedule
        {
            get
            {
                return _leagueHistorySchedules.Last();
            }
        }

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
        /// Gets the current offseason stage when the league is in the offseason
        /// </summary>
        public OffseasonStage OffseasonStage { get; set; }

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

        /// <summary>
        /// Gets the number of playoff rounds by the number of playoff teams, determined by n in 2^n of playoff teams
        /// </summary>
        public PlayoffRounds PlayoffRounds
        {
            get;
            private set;
        } = PlayoffRounds.Two;

        /// <summary>
        /// Gets the players that are no longer play eligible that have retired
        /// </summary>
        public List<Player> RetiredPlayers { get; private set; } = new List<Player>();

        /// <summary>
        /// Gets a save name to signify details about where the league is currently from its file name
        /// </summary>
        public String SaveStateName
        {
            get
            {
                // Builds the base string with the year and current state that the league is in as the Enums name
                string returnString = $@"Y{this.Year}{this.State}";

                switch (this.State)
                {
                    // Adds a day indicator for regular season and playoffs
                    case LeagueState.Unset:
                        return returnString;

                    case LeagueState.RegularSeason:
                        return returnString += $@"Day{this.DayIndex}";

                    case LeagueState.Playoffs:
                        return returnString += $@"Day{this.CurrentPlayoff.CurrentDay}";

                    case LeagueState.Offseason:
                        return returnString += $@"{this.OffseasonStage}";

                    default:
                        // If state is a null value
                        return returnString;
                }
            }
        }

        public List<Team> SecondConference
        {
            get;
            private set;
        } = new List<Team>();

        public string SecondConferenceName
        {
            get;
            private set;
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

        public LeagueState State
        {
            get;
            private set;
        } = LeagueState.Unset;

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

        public List<Player> UnsignedPlayers { get; private set; } = new List<Player>();
        public int Year { get; private set; } = 1;

        #endregion Properties

        #region Methods

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
        /// Sorts a list of teams by their record
        /// </summary>
        /// <param name="teamList">List of team objects</param>
        public static void SortTeamList(List<Team> teamList)
        {
            teamList.Sort();
            teamList.Reverse();
        }

        /// <summary>
        /// Adds a team to the league through one of the two conferences a league has
        /// </summary>
        /// <param name="team">The team being added</param>
        /// <param name="conference">
        /// Which conference to add team to
        /// 1-First
        /// 2-Second
        /// </param>
        /// <param name="hasEnforcedSpacing">Whether the function enforces conferences to be within 1 size of each other</param>
        public void AddTeam(Team team, int conference = 1, bool hasEnforcedSpacing = true)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team), @"team was passed as null");
            }

            // Throws exception if an exact team object already exists in league
            if (this.DoesTeamExist(team))
            {
                throw new ArgumentException("Team already exists within the league, league can't have multiples of a single team");
            }

            // Throws exception if the league has no additional space to add any teams
            if (this.AllTeams.Count == this._numberOfTeams)
            {
                throw new ArgumentException("League is full, can not add another team");
            }

            // Throws an exception if there is enforced spacing and one conference is guaranteed to become 2 teams greater than the other conference
            if (hasEnforcedSpacing && !this.ConferenceSpaceCheck(conference))
            {
                throw new ArgumentException("Conference is full, can only add to the other conference");
            }
            switch (conference)
            {
                case 1:
                    this.FirstConference.Add(team);
                    break;

                case 2:
                    this.SecondConference.Add(team);
                    break;

                default:
                    throw new ArgumentException("Conference is properly defined");
            }
        }

        public void AdvanceToOffseason()
        {
            this.Year++;
            this.State = LeagueState.Offseason;

            // Sets the offseason stage to the first stage of the offseason
            this.OffseasonStage = OffseasonStage.ProgressionAndRetirement;

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
                if (Retirement.ChooseToRetire(player, player.CurrentTeam, rand))
                {
                    player.Retired = true;
                }
                //Advances a year in the players contract
                //if the contract remaining becomes 0 then the player is a free agent
                if (player.CurrentContract.YearsRemaining > 0)
                {
                    player.CurrentContract.YearsRemaining -= 1;
                }
            }
        }

        public void AdvanceToPlayoffs()
        {
            int x = this.SignedPlayers.Where(y => y.CurrentContract.YearsRemaining == 1).Count();
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
                this.AssignPresidentsTrophyWinner();
                //Turns the state of the league to playoffs
                this.State = LeagueState.Playoffs;
                //Confirms the two conferences are sorted so the playoff teams are correct
                SortTeamList(FirstConference);
                SortTeamList(SecondConference);
                this._leagueHistoryPlayoffs.Add(new Playoff(this.PlayoffRounds, this.Year, FirstConference, SecondConference));
            }
        }

        /// <summary>
        /// Sets league object variables around to prepare for start of new season
        /// Only called for each regular season after the first season that came prepared
        /// </summary>
        public void AdvanceToRegularSeason()
        {
            this.State = LeagueState.RegularSeason;
            this.DayIndex = 0;
            this._leagueHistorySchedules.Add(new LeagueComponents.Schedule(this.FirstConference, this.SecondConference, this.rand));
            this.AddYearlyStats();

            // Makes sure old players are removed from active lineup and new players are placed into lineup
            foreach (Team team in AllTeams)
            {
                team.AutoSetLines();
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

        /// <summary>
        /// Creates random teams to fill out the rest of the leagues teams
        /// </summary>
        public void FillRemainingTeams()
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
                    errorMessage += $"{team.FullName}\n";
                }
            }
            return errorMessage;
        }

        /// <summary>
        /// Function that returns whether the league is at its specified size
        /// </summary>
        /// <returns>Returns boolean of whether league is full of teams</returns>
        public bool IsFull()
        {
            return FirstConference.Count + SecondConference.Count == _numberOfTeams;
        }

        public void SimLeague(int days)
        {
            if (DayIndex + days > LeagueSchedule.Length)
            {
                days = LeagueSchedule.Length - DayIndex;
            }
            for (int i = 0; i < days; i++)
            {
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

        public void SimulateFreeAgencyPhase()
        {
            FreeAgency.SimulateFreeAgencyPeriod(this, rand);
        }

        public void SimulateResignPhase()
        {
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
            State = LeagueState.RegularSeason;
            DayIndex = 0;
            _leagueHistorySchedules.Add(new LeagueComponents.Schedule(FirstConference, SecondConference, rand));
            //Sets the day counter to the first day of the schedule
            //Sets the League State to the regular season state
            _scheduleLength = this.LeagueSchedule.SeasonSchedule.Count;
        }

        public override string ToString()
        {
            return $"{this.Abbreviation} - {this.LeagueName} - Teams:{this.NumberOfTeams}";
        }

        /// <summary>
        /// Adds new seasonal stats to all signed players and teams
        /// </summary>
        private void AddYearlyStats()
        {
            foreach (Team team in AllTeams)
            {
                team.SeasonTeamStats.Add(new Stats.TeamStats(Year, false));
            }
            foreach (Player player in SignedPlayers)
            {
                player.AddStats(this.Year, player.CurrentTeam.TeamID, false);
            }
        }

        /// <summary>
        /// Adds the presidents trophy designation to the stats of the best regular season team
        /// </summary>
        private void AssignPresidentsTrophyWinner()
        {
            // Gets the top ranked team by order of points and sets them as having won a championship for that season
            Team winningTeam = this.AllTeams.OrderByDescending(t => t.CurrentRegularSeasonStats.Points).First();
            winningTeam.CurrentRegularSeasonStats.Champion = true;
        }

        /// <summary>
        /// Checks if a team can be added to a certain conference.
        /// Used primarily for odd sized league logic
        /// </summary>
        /// <param name="conference">
        /// 1 - First Conference
        /// 2 - Second conference
        /// </param>
        /// <returns>Whether the conference that is attempting to add a team can take another team</returns>
        private bool ConferenceSpaceCheck(int conference)
        {
            int selectedConferenceSize;
            if (conference == 1)
            {
                selectedConferenceSize = this.FirstConference.Count;
            }
            else if (conference == 2)
            {
                selectedConferenceSize = this.SecondConference.Count;
            }
            else
            {
                // Error, not specified conference
                throw new ArgumentException("Invalid conference selection");
            }

            // An even league size will ensure both conferences have the exact same amount of teams
            if (this._numberOfTeams % 2 == 0)
            {
                int maxTeams = this._numberOfTeams / 2;
                return selectedConferenceSize != maxTeams;
            }
            else
            {
                // If the amount of teams is odd, one conference will have an additional team
                int maxTeams = (this._numberOfTeams + 1) / 2;
                return selectedConferenceSize != maxTeams;
            }
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
        /// Generates the order of the draft based on standings from the previous season
        /// Non playoff teams are ordered worst to best
        /// Playoff teams are ordered by round placement from worst to best with regular season tiebreakers for teams ending in same rounds
        /// </summary>
        /// <returns>An ordered array from worst to best of all the teams in the league for drafting</returns>
        private Team[] GenerateDraftOrder()
        {
            Team[] DraftOrder = new Team[AllTeams.Count()];
            //Playoff teams in order for draft selection
            Team[] orderedPlayoffTeams = CurrentPlayoff.DraftOrderedPlayoffTeams();
            //All non playoff teams
            Team[] nonPlayoffTeams = AllTeams.Except(orderedPlayoffTeams.ToList()).ToArray();
            //Sort by regular season standing in ascending order
            Array.Sort(nonPlayoffTeams);
            //Combine 2 arrays together into draft order
            Array.Copy(nonPlayoffTeams, 0, DraftOrder, 0, nonPlayoffTeams.Count());
            Array.Copy(orderedPlayoffTeams, 0, DraftOrder, nonPlayoffTeams.Count(), orderedPlayoffTeams.Count());
            return DraftOrder;
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

        #endregion Methods
    }
}