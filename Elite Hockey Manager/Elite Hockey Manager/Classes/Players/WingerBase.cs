using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public abstract class WingerBase : Forward
    {
        #region Constructors

        public WingerBase(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public WingerBase(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        public WingerBase(string first, string last, int age) : base(first, last, age)
        {
        }

        public WingerBase(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        public WingerBase(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion Constructors

        #region Properties

        public override int Overall
        {
            get
            {
                return _attributes.WingerOverall();
            }
        }

        #endregion Properties
    }
}