using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class LeftWinger : WingerBase
    {
        public LeftWinger(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {

        }
        public LeftWinger(string first, string last, int age) : base(first, last, age)
        {
        }

    }

    public class RightWinger : WingerBase
    {
        public RightWinger(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {

        }
        public RightWinger(string first, string last, int age) : base(first, last, age)
        {
        }

    }
}
