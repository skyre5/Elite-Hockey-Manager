using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class LeftWinger : WingerBase
    {
        #region Constructors

        public LeftWinger(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public LeftWinger(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        public LeftWinger(string first, string last, int age) : base(first, last, age)
        {
        }

        public LeftWinger(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        protected LeftWinger(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion Constructors

        #region Properties

        public override string Position
        {
            get
            {
                return "LW";
            }
        }

        #endregion Properties
    }

    [Serializable]
    public class RightWinger : WingerBase
    {
        #region Constructors

        public RightWinger(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public RightWinger(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        public RightWinger(string first, string last, int age) : base(first, last, age)
        {
        }

        public RightWinger(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        protected RightWinger(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion Constructors

        #region Properties

        public override string Position
        {
            get
            {
                return "RW";
            }
        }

        #endregion Properties
    }
}