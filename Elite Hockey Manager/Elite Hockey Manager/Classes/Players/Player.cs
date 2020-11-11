using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;

namespace Elite_Hockey_Manager.Classes
{
    public enum ForwardPlayerStatus : int
    {
        Unset,
        Generational,
        Superstar,
        FirstLine,
        TopSix,
        TopNine,
        BottomSix,
        RolePlayer
    }
    public enum DefensePlayerStatus: int
    {
        Unset,
        Generational,
        Superstar,
        FirstPairing,
        SecondPairing,
        BottomPairing,
        Role
    }
    public enum GoaliePlayerStatus: int
    {
        Unset,
        Generational,
        Elite,
        Starter,
        LowStarter,
        Backup,
        Role
    }
    //[Serializable]
    public abstract class Player : ISerializable
    {
        public abstract int PlayerStatusID
        {
            get;
        }
        public int PlayerNumber
        {
            get
            {
                return _playerNumber;
            }
            private set
            {
                if (value < 1 || value > 99)
                {
                    throw new ArgumentException("Number must fall between 1 and 99");
                }
            }
        }
        public Contract CurrentContract
        {
            get
            {
                if (_careerContracts.Count == 0)
                {
                    _careerContracts.Add(new Contract());
                    _careerContracts.Last();
                }
                return _careerContracts.Last();
            }
        }
        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Error: First name entered must contain a valid value");
                }
                else
                {
                    _firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Error: Last name entered must contain a value");
                }
                else
                {
                    _lastName = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 17 || value > 50)
                {
                    throw new ArgumentException("Error: Age set should be within the range of 17 to 50");
                }
                else
                {
                    _age = value;
                }
            }
        }
        public int ID
        {
            get
            {
                return _playerID;
            }
        }
        /// <summary>
        /// Keeps track of if the player is currently retired
        /// If player is retired, then no further additions should be made to this history
        /// </summary>
        public bool Retired { get; set; } = false;
        public abstract int Overall
        {
            get;
        }
        public abstract string Position
        {
            get;
        }
        public abstract BaseAttributes Attributes
        {
            get;
            //set;
        }
        public PlayerProgressionTracker ProgressionTracker { get; private set; }
        //Keeps track of the players current team, if it is null they are a free agent
        public Team CurrentTeam = null;
        //Static random object for use in player number generation
        private static Random rand = new Random();
        //Incrementing int that will hold all players that play in the league
        private static int idCount = 0;
        //Set in constructor after incrementing the id count
        private int _playerID;
        //Random number between 1 and 99
        private int _playerNumber = rand.Next(1, 100);
        protected string _firstName;
        protected string _lastName;
        protected int _age;
        protected List<PlayerStats> _careerStats = new List<PlayerStats>();
        protected List<Contract> _careerContracts = new List<Contract>();
        
        public Player(string first, string last, int age, Contract contract)
        {
            //Input validation done in setters
            FirstName = first;
            LastName = last;
            Age = age;
            //Increments player id
            idCount++;
            _playerID = idCount;

            //Adds initial contract to player
            _careerContracts.Add(contract);
        }

        public Player(string first, string last, int age)
        {
            //Input validation done in setters
            FirstName = first;
            LastName = last;
            Age = age;
            //Increments player id
            idCount++;
            _playerID = idCount;
        }
        /// <summary>
        /// Initializes the player progression tracker when they are created and have been given their base attributes
        /// </summary>
        /// <param name="year">Year in the league for which the players rookie season would take place</param>
        public void InitializePlayerProgressionTracker(int year)
        {
            //Attributes defined in skater for its children subclasses
            //Overall defined in each non abstract child
            this.ProgressionTracker = new PlayerProgressionTracker(year, this.Overall, this.Attributes);
        }
        /// <summary>
        /// Advances the players age by a year and updates their attributes based on age and player status
        /// </summary>
        public void AgePlayerAndProgress()
        {
            Attributes.ProgressPlayer(this._age, this.Position, this.PlayerStatusID);
            this.ProgressionTracker.UpdatePlayerAttributes(this.Overall, this.Attributes);
            Age++;
        }
        /// <summary>
        /// Method to add contract to a player
        /// Contracts are added upon league creation, injury replacement players, draft pick created players, resign, and free agency
        /// </summary>
        /// <param name="contract"></param>
        public void AddContract(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException("Null contract object can not be added");
            }
            _careerContracts.Add(contract);
        }
        public override string ToString()
        {
            return String.Format("{0,-2}:#{2,-2} {1,-20}: Ovr:{3,-5}", this.Position, this.FullName, this.PlayerNumber, this.Overall);
        }
        public abstract void GenerateStats(int playerStatus);
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("First", this._firstName);
            info.AddValue("Last", this._lastName);
            info.AddValue("Age", this._age);
            info.AddValue("PlayerID", this._playerID);
            info.AddValue("Contracts", this._careerContracts);
            info.AddValue("PlayerNumber", this._playerNumber);
            info.AddValue("CurrentTeam", this.CurrentTeam);
        }
        public Player(SerializationInfo info, StreamingContext context)
        {
            this._firstName = (string)info.GetValue("First", typeof(string));
            this._lastName = (string)info.GetValue("Last", typeof(string));
            this._age = (int)info.GetValue("Age", typeof(int));
            this._playerID = (int)info.GetValue("PlayerID", typeof(int));
            this._careerContracts = (List<Contract>)info.GetValue("Contracts", typeof(List<Contract>));
            this._playerNumber = (int)info.GetValue("PlayerNumber", typeof(int));
            this.CurrentTeam = (Team)info.GetValue("CurrentTeam", typeof(Team));
        }
    }
}
