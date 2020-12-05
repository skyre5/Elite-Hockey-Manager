using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Newtonsoft.Json.Linq;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Center"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public Center(JToken token) : base(token)
        {
        }

        #endregion Constructors

        #region Properties

        public override int Overall
        {
            get
            {
                return SkaterAttributes.CenterRating();
            }
        }

        public override string PositionAbbreviation
        {
            get
            {
                return "C";
            }
        }

        #endregion Properties
    }
}