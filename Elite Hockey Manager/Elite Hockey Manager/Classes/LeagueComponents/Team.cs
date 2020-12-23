using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Classes.Stats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;
    using Elite_Hockey_Manager.Classes.Utility;

    using Newtonsoft.Json.Linq;

    [Serializable]
    public class Team : IEquatable<Team>, IComparable<Team>
    {
        #region Fields

        private static int idCount = 0;
        private string _abbreviation;
        private string _location;
        private string _logoPath = null;
        private int _teamID = -1;
        private string _teamName;
        private int _year = 1;

        #endregion Fields

        #region Constructors

        public Team(string location, string name)
        {
            Location = location;
            TeamName = name;
            //Abbreviation is first letter of team location and teamname
            Abbreviation = String.Concat(location[0], _teamName[0]);
            idCount++;
            _teamID = idCount;
            //Adds the initial season TeamStats to the team class
            SeasonTeamStats.Add(new TeamStats(1));
            SetTeamStatsEvent();
        }

        public Team(string location, string name, string imagePath)
        {
            Location = location;
            TeamName = name;

            // Abbreviation is first letter of team location and team name
            Abbreviation = String.Concat(location[0], _teamName[0]);
            LogoPath = imagePath;
            idCount++;
            _teamID = idCount;
            //Adds the initial season TeamStats to the team class
            SeasonTeamStats.Add(new TeamStats(1));
            SetTeamStatsEvent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="team">
        /// JToken json object from online API call for an NHL team
        /// </param>
        public Team(JToken team)
        {
            this.Location = Import.TrySelectToken(team, "locationName");
            this.TeamName = Import.TrySelectToken(team, "teamName");
            this.Abbreviation = Import.TrySelectToken(team, "abbreviation");
            this._teamID = int.Parse(Import.TrySelectToken(team, "id"));
            this.SeasonTeamStats.Add(new TeamStats(1));
            this.SetTeamStatsEvent();
        }

        #endregion Constructors

        #region Events

        [field: NonSerialized]
        public event EventHandler TeamStatsUpdated;

        #endregion Events

        #region Properties

        public string Abbreviation
        {
            get
            {
                return _abbreviation;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 3)
                {
                    throw new ArgumentException("Abbreviation must be 1 to 3 characters");
                }
                else
                {
                    _abbreviation = value.Trim();
                }
            }
        }

        public TeamStats CurrentRegularSeasonStats
        {
            get
            {
                if (SeasonTeamStats.Last().Playoff)
                {
                    //Gets the second to last teamStats of the list
                    return SeasonTeamStats[SeasonTeamStats.Count - 2];
                }
                else
                {
                    return SeasonTeamStats.Last();
                }
            }
        }

        /// <summary>
        /// Gets the latest seasonal stats from the SeasonTeamStats list
        /// </summary>
        public TeamStats CurrentSeasonStats
        {
            get
            {
                return SeasonTeamStats.Last();
            }
        }

        public Defender[,] Defenders { get; } = new Defender[3, 2];

        public Forward[,] Forwards { get; } = new Forward[4, 3];

        public string FullName
        {
            get
            {
                return $"{_location} {_teamName}";
            }
        }

        public Goalie[] Goalies { get; } = new Goalie[2];

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("location must contain characters");
                }
                else
                {
                    _location = value.Trim();
                }
            }
        }

        public Image Logo
        {
            get
            {
                //If no logoPath is set, returns null
                if (_logoPath == null)
                {
                    return null;
                }
                //Throws an error if the logoPath exists and no image can be found
                try
                {
                    Image image = Image.FromFile(_logoPath);
                    return image;
                }
                catch
                {
                    return null;
                }
            }
        }

        public string LogoPath
        {
            get
            {
                return _logoPath;
            }
            set
            {
                _logoPath = value;
            }
        }

        /// <summary>
        /// Roster should only used to view teams players, no adding or removing of players should be done directly from list
        /// </summary>
        public List<Player> Roster
        {
            get;
            private set;
        } = new List<Player>();

        /// <summary>
        /// List of all season stats through game history
        /// </summary>
        public List<TeamStats> SeasonTeamStats { get; private set; } = new List<TeamStats>();

        public int TeamID
        {
            get
            {
                return _teamID;
            }
        }

        public string TeamName
        {
            get
            {
                return _teamName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name must contain characters");
                }
                else
                {
                    _teamName = value.Trim();
                }
            }
        }

        public string TeamNameWithRecord
        {
            get
            {
                return TeamName + CurrentSeasonStats.Record();
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Helper function to get a row of a 2d array based on row
        /// </summary>
        /// <param name="players">A 2d array of players</param>
        /// <param name="row">Row of players array</param>
        /// <returns>Returns 1d array of players from that row</returns>
        public static Skater[] GetRow(Skater[,] players, int row)
        {
            //If the row specificed is greater than the number of rows in the array, throw exception
            if (row > players.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("Row entered does not fit into size of given 2d array");
            }
            //Gets the size of the 2nd dimension of the 2d array
            int rowLength = players.GetLength(1);
            Skater[] line = new Skater[rowLength];
            for (int i = 0; i < rowLength; i++)
            {
                line[i] = players[row, i];
            }
            return line;
        }

        public void AddNewGoalieAndContract(Goalie goalie)
        {
            //goalie.StatsList.Add(new GoalieStats(_year, this.TeamID));
            //Adds a link to this Team object to the player that will link to the current team they play for
            goalie.CurrentTeam = this;
            ContractGenerator.GenerateContract(goalie, this, Year);
            Roster.Add(goalie);
        }

        public void AddNewPlayerAndContract(Player pickedPlayer)
        {
            if (pickedPlayer is Goalie)
            {
                this.AddNewGoalieAndContract((Goalie)pickedPlayer);
            }
            else if (pickedPlayer is Skater)
            {
                this.AddNewSkaterAndContract((Skater)pickedPlayer);
            }
        }

        public void AddNewSkaterAndContract(Skater skater)
        {
            //skater.StatsList.Add(new SkaterStats(_year, this.TeamID));
            //Adds a link to this Team object to the player that will link to the current team they play for
            skater.CurrentTeam = this;
            ContractGenerator.GenerateContract(skater, this, Year);
            Roster.Add(skater);
        }

        /// <summary>
        /// Adds new teamstats object to this Team class for the playoffs for the current year
        /// Adds new playerstats object to each playoff player for the current year
        /// </summary>
        public void AddPlayoffsStatsToTeamAndPlayers()
        {
            //
            SeasonTeamStats.Add(new TeamStats(Year, true));
            foreach (Player player in Roster)
            {
                if (player is Skater)
                {
                    Skater skater = (Skater)player;
                    skater.AddStats(this._year, this._teamID, true);
                }
                if (player is Goalie)
                {
                    Goalie goalie = (Goalie)player;
                    goalie.AddStats(this._year, this._teamID, true);
                }
            }
        }

        /// <summary>
        /// Advances the teams internal year to the next one
        /// </summary>
        public void AdvanceYear()
        {
            this._year++;
        }

        /// <summary>
        /// Sets the 3 defensive lines sorted by overall and with no injured defenders
        /// Will sign new role players if unable to meet required amount
        /// </summary>
        public void AutoSetDefenseLines()
        {
            List<Player> leftDefenders = GetPlayersOfType<LeftDefender>();
            CheckForInjury(leftDefenders, 0, 4, 3, PlayerGenerator.GenerateDefender);
            List<Player> rightDefenders = GetPlayersOfType<RightDefender>();
            CheckForInjury(rightDefenders, 1, 4, 3, PlayerGenerator.GenerateDefender);
            for (int i = 0; i <= 2; i++)
            {
                Defenders[i, 0] = (Defender)leftDefenders[i];
                Defenders[i, 1] = (Defender)rightDefenders[i];
            }
        }

        /// <summary>
        /// Sets the 4 forward lines sorted by overall and with no injured forwards
        /// Will sign new role players if unable to meet required amount
        /// </summary>
        public void AutoSetForwardLines()
        {
            List<Player> leftWings = GetPlayersOfType<LeftWinger>();
            CheckForInjury(leftWings, 0, 5, 4, PlayerGenerator.GenerateForward);
            List<Player> centers = GetPlayersOfType<Center>();
            CheckForInjury(centers, 1, 5, 4, PlayerGenerator.GenerateForward);
            List<Player> rightWings = GetPlayersOfType<RightWinger>();
            CheckForInjury(rightWings, 2, 5, 4, PlayerGenerator.GenerateForward);
            for (int i = 0; i <= 3; i++)
            {
                Forwards[i, 0] = (Forward)leftWings[i];
                Forwards[i, 1] = (Forward)centers[i];
                Forwards[i, 2] = (Forward)rightWings[i];
            }
        }

        /// <summary>
        /// Sets the 2 goalies sorted by overall with no injured goalies
        /// Will sign new role players if unable to meet required amount
        /// </summary>
        public void AutoSetGoalies()
        {
            List<Player> goalies = GetPlayersOfType<Goalie>();
            while (goalies.Count < 2)
            {
                Goalie emergencyCreateGoalie = PlayerGenerator.GenerateGoalie(3);
                this.AddNewGoalieAndContract(emergencyCreateGoalie);
                goalies.Add(emergencyCreateGoalie);
                //Sets the players progression tracker for when a goalie must be created
                //only occurs in this function as well as the one in CheckForInjury
                emergencyCreateGoalie.InitializePlayerProgressionTracker(_year);
            }
            Goalies[0] = (Goalie)goalies[0];
            Goalies[1] = (Goalie)goalies[1];
        }

        public void AutoSetLines()
        {
            AutoSetForwardLines();
            AutoSetDefenseLines();
            AutoSetGoalies();
        }

        /// <summary>
        /// Comparator for teams. Compares by points, then goals for, then alphabetically
        /// </summary>
        /// <param name="other">Team being compared to</param>
        /// <returns></returns>
        public int CompareTo(Team other)
        {
            //Any context of sorting teams will be done by regular season stats, if the context that this is used is in the playoffs will ensure regular seasons stats are used
            TeamStats t1 = this.CurrentRegularSeasonStats;
            TeamStats t2 = other.CurrentRegularSeasonStats;
            if (t1.Points == t2.Points)
            {
                if (t1.GoalsFor == t2.GoalsFor)
                {
                    //If both teams have same amount of points and goalsFor, compare alphabetically
                    return this.TeamName.CompareTo(other.TeamName);
                }
                //If points are the same, compare by goalsFor
                return t1.GoalsFor.CompareTo(t2.GoalsFor);
            }
            //If points are different, sort by points
            return t1.Points.CompareTo(t2.Points);
        }

        public bool Equals(Team other)
        {
            return int.Equals(this.GetHashCode(), other.GetHashCode());
            //return int.Equals(_teamID, other.TeamID) && String.Equals(FullName, other.FullName);
        }

        /// <summary>
        /// Gets the all time stats for the team
        /// </summary>
        /// <returns>AllTimeTeamStats object is returned with all the stats from this team</returns>
        public AllTimeTeamStats GetAllTimeTeamStats()
        {
            AllTimeTeamStats allTimeTeamStats = new AllTimeTeamStats();
            foreach (TeamStats stats in SeasonTeamStats)
            {
                allTimeTeamStats.AddSeasonalStats(stats);
            }

            return allTimeTeamStats;
        }

        public double GetCapSpent()
        {
            double totalCap = 0;
            for (int i = 0; i < Roster.Count; i++)
            {
                totalCap += Roster[i].CurrentContract.ContractAmount;
            }
            return totalCap;
        }

        /// <summary>
        /// Gets an array of size 2 for a specific defensive line
        /// </summary>
        /// <param name="line">Line 1-3 representing 1st, 2nd, 3rd pairing</param>
        /// <returns>Returns array of 2 defenders for cooresponding defensive pairing</returns>
        public Skater[] GetDefensiveLine(int line)
        {
            if (line < 1 || line > 3)
            {
                throw new ArgumentException("Invalid line number(1-3)");
            }
            return GetRow(Defenders, line - 1);
        }

        /// <summary>
        /// Gets an array of size 3 for a specific forward line
        /// </summary>
        /// <param name="line">Line 1-4 for forward lines</param>
        /// <returns>Returns array of cooresponding line of forwards</returns>
        public Skater[] GetForwardLine(int line)
        {
            if (line < 1 || line > 4)
            {
                throw new ArgumentOutOfRangeException("Invalid line number(1-4)");
            }
            return GetRow(Forwards, line - 1);
        }

        /// <summary>
        /// Gets the starter or backup goalie for a game
        /// </summary>
        /// <returns>Returns the goalie that will be playing a game</returns>
        public Goalie GetGamesStartingGoalie()
        {
            //If the starting goalies fatigue is greater than 10, returns backup
            if (Goalies[0].Attributes.Fatigue >= 10)
            {
                //If backup goaltender plays, reduce starters fatigue by 10
                Goalies[0].Attributes.Fatigue -= 10;
                return Goalies[1];
            }
            //Returns starter
            return Goalies[0];
        }

        public override int GetHashCode()
        {
            return _teamID.GetHashCode() ^ FullName.GetHashCode();
        }

        /// <summary>
        /// Returns a list of players of position T
        /// Sorted by overall
        /// Non-injured players
        /// </summary>
        /// <typeparam name="T">The type of player E.G Center,Goalie</typeparam>
        /// <returns>Returns list of type Player that is shared by all positions through inheritance</returns>
        public List<Player> GetPlayersOfType<T>()
        {
            //Returns a list of a certain position, sorted by overall
            return Roster.Where(player => player is T && !player.Attributes.Injured)
                .OrderByDescending(item => item.Overall).ToList();
        }

        public int GetPositionCount<T>()
        {
            return Roster.Where(player => player is T).Count();
        }

        public override string ToString()
        {
            return FullName;
        }

        public void ValidateLines()
        {
            //If any forward spots are null, auto set forward lines
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (Forwards[i, j] == null)
                    {
                        AutoSetForwardLines();
                        break;
                    }
                }
            }
            //If the defenders array contains any null values, defensive lines are set
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    if (Defenders[i, j] == null)
                    {
                        AutoSetDefenseLines();
                        break;
                    }
                }
            }
            //If the goalies array contains a null value, set goalie lines
            if (Goalies.Contains(null))
            {
                AutoSetGoalies();
            }
        }

        /// <summary>
        /// Boolean function that returns whether the team has a valid number or greater of forwards(12), defenders(6), and goalies(2)
        /// </summary>
        /// <returns>
        /// True - Team has valid number of players at all positions
        /// False - Team has an issue at one of the categories
        /// </returns>
        public bool ValidMinimumTeamSize()
        {
            if (Roster.OfType<Forward>().Count() < 12)
            {
                return false;
            }
            if (Roster.OfType<Defender>().Count() < 6)
            {
                return false;
            }
            if (Roster.OfType<Goalie>().Count() < 2)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks to make sure there are a sufficient amount of players to fill out the forward and defensive lines
        /// </summary>
        /// <param name="players">A List of players of players of a speciific position</param>
        /// <param name="position">Int variable to go into GenerateForward or GenerateDefender functions</param>
        /// <param name="quality">int variable to go into GenerateForward or GenerateDefender function</param>
        /// <param name="amountRequired">Amount of players needed for that position. 4 for forwards, 3 for defenders</param>
        /// <param name="createPlayerFunc">Function to create player that takes a position and quality variable</param>
        private void CheckForInjury(List<Player> players, int position, int quality, int amountRequired, Func<int, int, int, Player> createPlayerFunc)
        {
            while (players.Count < amountRequired)
            {
                Player emergencyCreatePlayer = createPlayerFunc(position, quality, -1);
                players.Add(emergencyCreatePlayer);
                this.AddNewSkaterAndContract((Skater)emergencyCreatePlayer);
                emergencyCreatePlayer.AddStats(this._year, this._teamID, false);
                //Adds a players progression tracker when abruptely created mid season for emergency purposes
                //Only occurs in this function and AutoSetGoalies function
                emergencyCreatePlayer.InitializePlayerProgressionTracker(_year);
            }
        }

        private void SetTeamStatsEvent()
        {
            this.CurrentSeasonStats.TeamStatsUpdated += TriggerTeamStatsEvent;
        }

        private void TriggerTeamStatsEvent(object sender, EventArgs e)
        {
            TeamStatsUpdated?.Invoke(this, null);
        }

        #endregion Methods
    }
}