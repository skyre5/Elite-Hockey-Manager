using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class LeftDefensemen : Defender
    {
        #region Constructors

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

        #endregion Constructors

        #region Properties

        public override string Position
        {
            get
            {
                return "LD";
            }
        }

        #endregion Properties
    }

    [Serializable]
    public class RightDefensemen : Defender
    {
        #region Constructors

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

        #endregion Constructors

        #region Properties

        public override string Position
        {
            get
            {
                return "RD";
            }
        }

        #endregion Properties
    }
}