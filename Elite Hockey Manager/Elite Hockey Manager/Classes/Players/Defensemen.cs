using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.Players
{
    public class LeftDefensemen : Defender
    {
        public LeftDefensemen(string first, string last, int age) : base(first, last, age)
        {
        }

        public override int GetOverall()
        {
            throw new NotImplementedException();
        }
    }
    public class RightDefensemen : Defender
    {
        public RightDefensemen(string first, string last, int age) : base(first, last, age)
        {
        }

        public override int GetOverall()
        {
            throw new NotImplementedException();
        }
    }
}
