using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Newtonsoft.Json.Linq;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftDefensemen"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public LeftDefensemen(JToken token) : base(token)
        {
        }

        protected LeftDefensemen(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion Constructors

        #region Properties

        public override string PositionAbbreviation
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

        /// <summary>
        /// Initializes a new instance of the <see cref="RightDefensemen"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public RightDefensemen(JToken token) : base(token)
        {
        }

        protected RightDefensemen(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion Constructors

        #region Properties

        public override string PositionAbbreviation
        {
            get
            {
                return "RD";
            }
        }

        #endregion Properties
    }
}