using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;

    using Newtonsoft.Json.Linq;

    [Serializable]
    public class Goalie : Player
    {
        #region Fields

        private GoalieAttributes _attributes;
        private List<GoalieStats> _stats = new List<GoalieStats>();

        #endregion Fields

        #region Constructors

        public Goalie(string first, string last, int age, GoalieAttributes Attributes) : base(first, last, age)
        {
            _attributes = Attributes;
        }

        public Goalie(string first, string last, int age, Contract contract, GoalieAttributes Attributes) : base(first, last, age, contract)
        {
            _attributes = Attributes;
        }

        public Goalie(string first, string last, int age) : base(first, last, age)
        {
            this._attributes = new GoalieAttributes();
        }

        public Goalie(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
            this._attributes = new GoalieAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Goalie"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public Goalie(JToken token) : base(token)
        {
            this._attributes = new GoalieAttributes();
        }

        #endregion Constructors

        #region Properties

        public override BaseAttributes Attributes
        {
            get
            {
                return _attributes;
            }
        }

        public GoalieAttributes GoalieAttributes
        {
            get
            {
                return (GoalieAttributes)_attributes;
            }
        }

        public override int Overall
        {
            get
            {
                return _attributes.GoalieOverall();
            }
        }

        public GoaliePlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = GoaliePlayerStatus.Unset;

        public override int PlayerStatusId
        {
            get
            {
                return (int)PlayerStatus;
            }
        }

        public override string PositionAbbreviation
        {
            get
            {
                return "G";
            }
        }

        public GoalieStats Stats
        {
            get
            {
                if (_stats.Count == 0)
                {
                    Console.WriteLine("Unset goalie stats added\n" + new System.Diagnostics.StackTrace().ToString());
                    _stats.Add(new GoalieStats(-1, -1));
                }
                return _stats.Last();
            }
        }

        public List<GoalieStats> StatsList
        {
            get
            {
                return _stats;
            }
        }

        #endregion Properties

        #region Methods

        public override void AddStats(int year, int teamID, bool playoffs)
        {
            _stats.Add(new GoalieStats(year, teamID, playoffs));
        }

        public override void GenerateAttributes(int playerStatus)
        {
            GoaliePlayerStatus status = (GoaliePlayerStatus)playerStatus;
            PlayerStatus = status;
            _attributes.GenerateGoalieStatRanges(status, this.Age);
        }

        #endregion Methods
    }
}