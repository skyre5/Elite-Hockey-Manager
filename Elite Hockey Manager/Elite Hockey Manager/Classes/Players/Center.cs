using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class Center : Forward
    {
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
        public Center(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
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
    }
}
