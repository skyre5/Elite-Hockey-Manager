using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
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
        public LeftDefensemen(string first, string last, int age) : base(first, last, age)
        {
        }

    }
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
        public RightDefensemen(string first, string last, int age) : base(first, last, age)
        {
        }
    }
}
