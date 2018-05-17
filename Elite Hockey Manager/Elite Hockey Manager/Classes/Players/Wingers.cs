using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class LeftWinger : Forward
    {
        public LeftWinger(string first, string last, int age) : base(first, last, age)
        {
        }

    }

    public class RightWinger : Forward
    {
        public RightWinger(string first, string last, int age) : base(first, last, age)
        {
        }

    }
}
