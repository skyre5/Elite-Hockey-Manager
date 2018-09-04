using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public abstract class WingerBase : Forward
    {

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
        public WingerBase(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }

        public override int Overall
        {
            get
            {
                return _attributes.WingerOverall();
            }
        }
    }
}
