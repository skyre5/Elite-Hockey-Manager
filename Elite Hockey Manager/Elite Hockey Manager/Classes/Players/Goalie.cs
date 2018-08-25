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
        public GoaliePlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = GoaliePlayerStatus.Unset;
        private GoalieAttributes _attributes;
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
        public Goalie(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._attributes = (GoalieAttributes)info.GetValue("Attributes", typeof(GoalieAttributes));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Attributes", this._attributes);
        }

        public override void GenerateStats(int playerStatus)
        {
            GoaliePlayerStatus status = (GoaliePlayerStatus)playerStatus;
            _attributes.GenerateGoalieStatRanges(status, _age);
        }

        public override string Position
        {
            get
            {
                return "G";
            }
        }
        public override Attributes Attributes
        {
            get
            {
                return _attributes;
            }
        }
        protected override void GenerateInitialContract()
        {
            //if (CurrentContract)
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
        protected override void GenerateYoungContract()
        {
            int years = YearsForEntryContract();
            double amount = 0;
            switch (PlayerStatus)
            {
                case GoaliePlayerStatus.Generational:
                    amount = 2.5;
                    break;
                case GoaliePlayerStatus.Elite:
                    amount = 2;
                    break;
                case GoaliePlayerStatus.Starter:
                    amount = 1.5;
                    break;
                case GoaliePlayerStatus.LowStarter:
                    amount = 1;
                    break;
                case GoaliePlayerStatus.Backup:
                    amount = .5;
                    break;
                case GoaliePlayerStatus.Role:
                case GoaliePlayerStatus.Unset:
                    amount = 0;
                    break;
            }
            Contract contract = new Contract(1, years, amount);
            _careerContracts.Add(contract);
        }
    }
}
