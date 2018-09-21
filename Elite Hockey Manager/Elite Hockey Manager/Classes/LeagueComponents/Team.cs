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
        private string _location;
        private string _teamName;
        private string _logoPath = null;
        private int _teamID = -1;
        private static int idCount = 0;
        public List<Player> Roster
        {
            get;
            private set;
        } = new List<Player>();

        private Forward[,] forwards = new Forward[4, 3];
        private Defender[,] defenders = new Defender[3, 2];
        private Goalie[] goalies = new Goalie[2];
        private Skater[] scratched = new Skater[3];
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
        public override string ToString()
        {
            return FullName;
        }
        public override int GetHashCode()
        {
            return _teamID.GetHashCode() ^ FullName.GetHashCode();
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TeamName", this._teamName);
            info.AddValue("Location", this._location);
            info.AddValue("Logo", this._logoPath);
            info.AddValue("ID", this._teamID);
        }

        public bool Equals(Team other)
        {
            return int.Equals(_teamID, other.TeamID) && String.Equals(FullName, other.FullName);
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
        public int GetPositionCount<T>()
        {
            return Roster.Where(player => player is T).Count();
        }
        /// <summary>
        /// Returns a list of players of position T
        /// Sorted by overall
        /// </summary>
        /// <typeparam name="T">The type of player E.G Center,Goalie</typeparam>
        /// <returns>Returns list of type Player that is shared by all positions through inheritance</returns>
        public List<Player> GetPlayersOfType<T>()
        {
            //Returns a list of a certain position, sorted by overall
            return Roster.Where(player => player is T)
                .OrderBy(item => item.Overall).ToList();
        }
        public double GetTotalCapSpace()
        {
            double totalCap = 0;
            for (int i = 0; i < Roster.Count; i++)
            {
                totalCap += Roster[i].CurrentContract.ContractAmount;
            }
            return totalCap;
        }
        public double GetCapSpace()
        {
            throw new NotImplementedException();
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
    }
}
