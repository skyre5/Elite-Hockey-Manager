using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class Center : Forward
    {
        #region Constructors

        public Center(string first, string last, int age) : base(first, last, age)
        {
        }

        public Center(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        public Center(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public Center(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        protected Center(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion Constructors

        #region Properties

        public override int Overall
        {
            get
            {
                return _attributes.CenterRating();
            }
        }

        public override string Position
        {
            get
            {
                return "C";
            }
        }

        #endregion Properties
    }
}