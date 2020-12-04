using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Utility;

    using Newtonsoft.Json.Linq;

    public enum DefensePlayerStatus : int
    {
        Unset,
        Generational,
        Superstar,
        FirstPairing,
        SecondPairing,
        BottomPairing,
        Role
    }

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

    public enum GoaliePlayerStatus : int
    {
        Unset,
        Generational,
        Elite,
        Starter,
        LowStarter,
        Backup,
        Role
    }

    [Serializable]
    public abstract class Player
    {
        #region Fields

        //Keeps track of the players current team, if it is null they are a free agent
        public Team CurrentTeam = null;

        protected int _age;

        protected string _firstName;

        protected string _lastName;

        //Incrementing int that will hold all players that play in the league
        private static int idCount = 0;

        //Static random object for use in player number generation
        private static Random rand = new Random();

        //Set in constructor after incrementing the id count
        private int _playerID;

        //Random number between 1 and 99
        private int _playerNumber = rand.Next(1, 100);

        #endregion Fields

        #region Constructors

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
            CareerContracts.Add(contract);
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

        public Player(SerializationInfo info, StreamingContext context)
        {
            this._firstName = (string)info.GetValue("First", typeof(string));
            this._lastName = (string)info.GetValue("Last", typeof(string));
            this._age = (int)info.GetValue("Age", typeof(int));
            this._playerID = (int)info.GetValue("PlayerID", typeof(int));
            this.CareerContracts = (List<Contract>)info.GetValue("Contracts", typeof(List<Contract>));
            this._playerNumber = (int)info.GetValue("PlayerNumber", typeof(int));
            this.CurrentTeam = (Team)info.GetValue("CurrentTeam", typeof(Team));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="playerToken">
        /// The player token containing information gathered from online
        /// </param>
        protected Player(JToken playerToken)
        {
            // Tries to import the available player information on the token
            this.FirstName = Import.TrySelectToken(playerToken, "firstName");
            this.LastName = Import.TrySelectToken(playerToken, "lastName");
            this.Age = int.Parse(Import.TrySelectToken(playerToken, "currentAge"));

            // this.PlayerNumber = int.Parse(Import.TrySelectToken(playerToken, "primaryNumber"));
            idCount++;
            this._playerID = idCount;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the players age
        /// </summary>
        public int Age
        {
            get => this._age;
            set
            {
                // Age should not be given below 18 and above 50 is too high for it to be set
                if (value < 17 || value > 50)
                {
                    throw new ArgumentException("Error: Age set should be within the range of 17 to 50");
                }

                this._age = value;
            }
        }

        /// <summary>
        /// Gets the players BaseAttribute class
        /// </summary>
        public abstract BaseAttributes Attributes
        {
            get;
        }

        /// <summary>
        /// Gets the players history of contracts in their career in order of signing
        /// </summary>
        public List<Contract> CareerContracts { get; } = new List<Contract>();

        /// <summary>
        /// Gets the players latest contract
        /// In the instance of a player not having any contracts then it will create one(should not happen)
        /// </summary>
        public Contract CurrentContract
        {
            get
            {
                if (this.CareerContracts.Count == 0)
                {
                    // Gives player a default contract with the lowest available value and 1 year
                    this.CareerContracts.Add(new Contract());
                }

                return this.CareerContracts.Last();
            }
        }

        /// <summary>
        /// Gets or sets the players first name
        /// </summary>
        public string FirstName
        {
            get => this._firstName;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Error: First name entered must contain a valid value");
                }
                else
                {
                    this._firstName = value;
                }
            }
        }

        /// <summary>
        /// Gets the players full name
        /// </summary>
        public string FullName => $"{this._firstName} {this._lastName}";

        /// <summary>
        /// Gets the players unique id
        /// </summary>
        public int Id => this._playerID;

        /// <summary>
        /// Gets or sets the players last name
        /// </summary>
        public string LastName
        {
            get => this._lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Error: Last name entered must contain a value");
                }
                else
                {
                    this._lastName = value;
                }
            }
        }

        /// <summary>
        /// Gets the overall of the player based on their attributes and position
        /// </summary>
        public abstract int Overall
        {
            get;
        }

        /// <summary>
        /// Gets or sets the player's jersey number
        /// </summary>
        public int PlayerNumber
        {
            get => this._playerNumber;
            set
            {
                if (value < 1 || value > 99)
                {
                    throw new ArgumentException("Number must fall between 1 and 99");
                }

                this._playerNumber = value;
            }
        }

        /// <summary>
        /// Gets the players PlayerStatusID which holds a value for how their talent level
        /// Separate PlayerStatusID meanings between Forwards, Defenders, and Goalies
        /// </summary>
        public abstract int PlayerStatusId
        {
            get;
        }

        /// <summary>
        /// Gets the players position abbreviation
        /// </summary>
        public abstract string PositionAbbreviation
        {
            get;
        }

        /// <summary>
        /// Gets the player's progression tracker which holds a history of their overall and attribute values throughout their career
        /// </summary>
        public PlayerProgressionTracker ProgressionTracker { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is retired and not playing
        /// Default value of false
        /// </summary>
        public bool Retired { get; set; } = false;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Method to add contract to a player
        /// Contracts are added upon league creation, injury replacement players, draft pick created players, resign, and free agency
        /// </summary>
        /// <param name="contract">Pre-filled contract object</param>
        public void AddContract(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException(nameof(contract), @"Null contract object can not be added");
            }

            // Adds the contract to their contract history
            this.CareerContracts.Add(contract);
        }

        /// <summary>
        /// Adds a new year of stats to the players stats history
        /// </summary>
        /// <param name="year">Year of the new stats object</param>
        /// <param name="teamId">The team the player is playing for during the new stats season</param>
        /// <param name="playoffs">Whether the new stats season represents a new playoff season</param>
        public abstract void AddStats(int year, int teamId, bool playoffs);

        /// <summary>
        /// Advances the players age by a year and updates their attributes based on age and player status
        /// </summary>
        public void AgePlayerAndProgress()
        {
            // Changes a players attributes based on age and talent level
            this.Attributes.ProgressPlayer(this._age, this.PositionAbbreviation, this.PlayerStatusId);

            // Stores the changes in the players ProgressionTracker
            this.ProgressionTracker.UpdatePlayerAttributes(this.Overall, this.Attributes);

            // Advances the players age by a year
            this.Age++;
        }

        /// <summary>
        /// Generates a player's base attributes based on talent level
        /// Player's playerStatusID is set by passed PlayerStatus showing talent level
        /// </summary>
        /// <param name="playerStatus">The playerStatus value of the player being set. The talent level they are at their position</param>
        public abstract void GenerateAttributes(int playerStatus);

        /// <summary>
        /// Initializes the player progression tracker when they are created and have been given their base attributes
        /// </summary>
        /// <param name="year">Year in the league for which the players rookie season would take place</param>
        public void InitializePlayerProgressionTracker(int year)
        {
            // Attributes defined in skater for its children subclasses
            // Overall defined in each non abstract child
            this.ProgressionTracker = new PlayerProgressionTracker(year, this.Overall, this.Attributes);
        }

        /// <summary>
        /// Returns formatted string should the players position abbreviation, number, name, and overall
        /// </summary>
        /// <returns>formatted display string</returns>
        public override string ToString()
        {
            return string.Format("{0,-2}:#{2,-2} {1,-20}: Ovr:{3,-5}", this.PositionAbbreviation, this.FullName, this.PlayerNumber, this.Overall);
        }

        #endregion Methods
    }
}