using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class LeftDefensemen : Defender
    {
        public override string Position
        {
            get
            {
                return "LD";
            }
        }

        public LeftDefensemen(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public LeftDefensemen(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        public LeftDefensemen(string first, string last, int age) : base(first, last, age)
        {
        }

        public LeftDefensemen(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        protected LeftDefensemen(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class RightDefensemen : Defender
    {
        public override string Position
        {
            get
            {
                return "RD";
            }
        }

        public RightDefensemen(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public RightDefensemen(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        public RightDefensemen(string first, string last, int age) : base(first, last, age)
        {
        }

        public RightDefensemen(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        protected RightDefensemen(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}