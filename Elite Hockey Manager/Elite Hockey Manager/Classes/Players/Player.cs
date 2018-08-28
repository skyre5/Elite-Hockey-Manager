using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

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
    public abstract class Player : ISerializable
    {

        protected string _firstName;
        protected string _lastName;
        protected int _age;
        //Incrementing int that will hold all players that play in the league
        private static int idCount = 0;
        //Set in constructor after incrementing the id count
        private int _playerID;


        public abstract int PlayerStatusID
        {
            get;
        }

        private List<Stats> _careerStats = new List<Stats>();
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

        public Contract CurrentContract
        {
            get
            {
                if (_careerContracts.Count == 0)
                {
                    return null;
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
        public abstract int Overall
        {
            get;
        }
        public abstract string Position
        {
            get;
        }
        public abstract Attributes Attributes
        {
            get;
            //set;
        }
        private void IncrementYear()
        {
            _age++;
        }
        public override string ToString()
        {
            return String.Format("{0,-2}: {1,-20}: Ovr:{2,-5}", this.Position, this.FullName, this.Overall);
        }
        public abstract void GenerateStats(int playerStatus);
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("First", this._firstName);
            info.AddValue("Last", this._lastName);
            info.AddValue("Age", this._age);
            info.AddValue("PlayerID", this._playerID);
            info.AddValue("Contracts", this._careerContracts);
        }
        public Player(SerializationInfo info, StreamingContext context)
        {
            this._firstName = (string)info.GetValue("First", typeof(string));
            this._lastName = (string)info.GetValue("Last", typeof(string));
            this._age = (int)info.GetValue("Age", typeof(int));
            this._playerID = (int)info.GetValue("PlayerID", typeof(int));
            //For versioning for past players made before contracts added to player
            try
            {
                this._careerContracts = (List<Contract>)info.GetValue("Contracts", typeof(List<Contract>));
            }
            catch
            {
                this._careerContracts = new List<Contract>();
                //If no contract is found it gives a default contract of 1 year and 1m
                this._careerContracts.Add(new Players.PlayerComponents.Contract());
            }
        }
        public void AddContract(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException("Null contract object can not be added");
            }
            _careerContracts.Add(contract);
        }
    }
}
