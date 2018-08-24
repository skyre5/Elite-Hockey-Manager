using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes
{

    public abstract class Forward : Skater
    {
        public ForwardPlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = ForwardPlayerStatus.Unset;
        public Forward(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }
        public Forward(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }
        public Forward(string first, string last, int age) : base(first, last, age)
        {
        }
        public Forward(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }
        public Forward(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        protected override void GenerateInitialContract()
        {
            //If other contracts are found doesn't generate one
            if (_careerContracts.Count == 0)
            {

            }
        }
        public override int PlayerStatusID
        {
            get
            {
                return (int)PlayerStatus;
            }
        }
        public override void GenerateStats(int playerStatus)
        {
            ForwardPlayerStatus status = (ForwardPlayerStatus)playerStatus;
            _attributes.GenerateForwardStatRanges(status, _age);
            
        }
    }
}
