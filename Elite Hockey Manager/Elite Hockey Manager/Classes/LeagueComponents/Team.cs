using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class Team : ISerializable, IEquatable<Team>
    {
        private int _year = 1;
        private string _location;
        private string _teamName;
        private string _logoPath = null;
        private int _teamID = -1;
        private static int idCount = 0;
        public int Year
        {
            get
            {
                return _year;
            }
        }
        public List<Player> Roster
        {
            get;
            private set;
        } = new List<Player>();

        private Forward[,] _forwards = new Forward[4, 3];
        private Defender[,] _defenders = new Defender[3, 2];
        private Goalie[] _goalies = new Goalie[2];
        public Team(string location, string name)
        {
            Location = location;
            TeamName = name;
            idCount++;
            _teamID = idCount;
        }
        public Team(string location, string name, string imagePath)
        {
            Location = location;
            TeamName = name;
            LogoPath = imagePath;
            idCount++;
            _teamID = idCount;
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
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", _location, _teamName);
            }
        }
        public int TeamID
        {
            get
            {
                return _teamID;
            }
        }
        public Forward[,] Forwards
        {
            get
            {
                return _forwards;
            }
        }
        public Defender[,] Defenders
        {
            get
            {
                return _defenders;
            }
        }
        public Goalie[] Goalies
        {
            get
            {
                return _goalies;
            }
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
            return GetRow(_forwards, line - 1);
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
            return GetRow(_defenders, line - 1);
        }
        /// <summary>
        /// Gets the starter or backup goalie for a game
        /// </summary>
        /// <returns>Returns the goalie that will be playing a game</returns>
        public Goalie GetGoalie()
        {
            //If the starting goalies fatigue is greater than 10, returns backup
            if (_goalies[0].Attributes.Fatigue >= 10)
            {
                return _goalies[1];
            }
            //Returns starter
            return _goalies[0];
        }
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
            for (int i = 0;i < rowLength; i++)
            {
                line[i] = players[row, i];
            }
            return line;
        }
        public void AddNewSkater(Skater skater)
        {
            skater.StatsList.Add(new SkaterStats(_year, this.TeamID));
            Roster.Add(skater);
        }
        public void AddNewGoalie(Goalie goalie)
        {
            goalie.StatsList.Add(new GoalieStats(_year, this.TeamID));
            Roster.Add(goalie);
        }
        public override string ToString()
        {
            return FullName;
        }
        public override int GetHashCode()
        {
            return _teamID.GetHashCode() ^ FullName.GetHashCode();
        }
        public bool Equals(Team other)
        {
            return int.Equals(this.GetHashCode(), other.GetHashCode());
            //return int.Equals(_teamID, other.TeamID) && String.Equals(FullName, other.FullName);
        }
        public int GetPositionCount<T>()
        {
            return Roster.Where(player => player is T).Count();
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
        public void AutoSetLines()
        {
            AutoSetForwardLines();
            AutoSetDefenseLines();
            AutoSetGoalies();
        }
        /// <summary>
        /// Sets the 4 forward lines sorted by overall and with no injured forwards
        /// Will sign new role players if unable to meet required amount
        /// </summary>
        public void AutoSetForwardLines()
        {
            List<Player> leftWings = GetPlayersOfType<LeftWinger>();
            CheckForInjury(leftWings, 0, 5, 4, PlayerGenerator.GenerateForward);
            List<Player> rightWings = GetPlayersOfType<RightWinger>();
            CheckForInjury(rightWings, 1, 5, 4, PlayerGenerator.GenerateForward);
            List<Player> centers = GetPlayersOfType<Center>();
            CheckForInjury(centers, 2, 5, 4, PlayerGenerator.GenerateForward);
            for (int i = 0; i <= 3; i++)
            {
                _forwards[i, 0] = (Forward)leftWings[i];
                _forwards[i, 1] = (Forward)centers[i];
                _forwards[i, 2] = (Forward)rightWings[i];
            }
        }
        /// <summary>
        /// Sets the 3 defensive lines sorted by overall and with no injured defenders
        /// Will sign new role players if unable to meet required amount
        /// </summary>
        public void AutoSetDefenseLines()
        {
            List<Player> leftDefenders = GetPlayersOfType<LeftDefensemen>();
            CheckForInjury(leftDefenders, 0, 4, 3, PlayerGenerator.GenerateDefender);
            List<Player> rightDefenders = GetPlayersOfType<RightDefensemen>();
            CheckForInjury(rightDefenders, 1, 4, 3, PlayerGenerator.GenerateDefender);
            for (int i = 0; i <= 2; i++)
            {
                _defenders[i, 0] = (Defender)leftDefenders[i];
                _defenders[i, 1] = (Defender)rightDefenders[i];
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
                goalies.Add(PlayerGenerator.GenerateGoalie(3));
            }
            _goalies[0] = (Goalie)goalies[0];
            _goalies[1] = (Goalie)goalies[1];
        }
        /// <summary>
        /// Checks to make sure there are a sufficient amount of players to fill out the forward and defensive lines
        /// </summary>
        /// <param name="players">A List of players of players of a speciific position</param>
        /// <param name="position">Int variable to go into GenerateForward or GenerateDefender functions</param>
        /// <param name="quality">int variable to go into GenerateForward or GenerateDefender function</param>
        /// <param name="amountRequired">Amount of players needed for that position. 4 for forwards, 3 for defenders</param>
        /// <param name="createPlayerFunc">Function to create player that takes a position and quality variable</param>
        private void CheckForInjury(List<Player> players, int position, int quality, int amountRequired, Func<int, int, Player> createPlayerFunc)
        {
            while (players.Count < amountRequired)
            {
                players.Add(createPlayerFunc(position, quality));
            }
        }
        protected Team(SerializationInfo info, StreamingContext context)
        {
            this._teamName = (string)info.GetValue("TeamName", typeof(string));
            this._location = (string)info.GetValue("Location", typeof(string));
            this._logoPath = (string)info.GetValue("Logo", typeof(string));
            try
            {
                this._teamID = (int)info.GetValue("ID", typeof(int));
            }
            catch
            {
                //For previous versions that didn't save teamID
                this._teamID = -1;
            }
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TeamName", this._teamName);
            info.AddValue("Location", this._location);
            info.AddValue("Logo", this._logoPath);
            info.AddValue("ID", this._teamID);
        }
    }
}
