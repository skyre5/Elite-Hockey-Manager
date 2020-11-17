using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class Goalie : Player
    {

        private List<GoalieStats> _stats = new List<GoalieStats>();
        private GoalieAttributes _attributes;
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
        public GoaliePlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = GoaliePlayerStatus.Unset;
        public override int Overall
        {
            get
            {
                return _attributes.GoalieOverall();
            }
        }

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
        protected Goalie(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._attributes = (GoalieAttributes)info.GetValue("Attributes", typeof(GoalieAttributes));
            try
            {
                this.PlayerStatus = (GoaliePlayerStatus)info.GetValue("PlayerStatus", typeof(GoaliePlayerStatus));
            }
            catch
            {
                this.PlayerStatus = GoaliePlayerStatus.Unset;
            }
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Attributes", this._attributes);
            info.AddValue("PlayerStatus", this.PlayerStatus);
            base.GetObjectData(info, context);
        }
        public override void GenerateStats(int playerStatus)
        {
            GoaliePlayerStatus status = (GoaliePlayerStatus)playerStatus;
            PlayerStatus = status;
            _attributes.GenerateGoalieStatRanges(status, _age);
        }

        public override void AddStats(int year, int teamID, bool playoffs)
        {
            _stats.Add(new GoalieStats(year, teamID, playoffs));
        }

        public override string Position
        {
            get
            {
                return "G";
            }
        }
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

        public override int PlayerStatusID
        {
            get
            {
                return (int)PlayerStatus;
            }
        }
    }
}
