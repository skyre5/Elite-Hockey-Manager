using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Defender : Skater
    {

        public Defender(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }
        public Defender(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }
        public Defender(string first, string last, int age) : base(first, last, age)
        {
        }
        public Defender(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }
        public Defender(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }

        public override int Overall
        {
            get
            {
                return _attributes.DefenseRating();
            }
        }
    }
}
