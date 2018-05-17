using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Forward : Skater
    {
        public Forward(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }
        public Forward(string first, string last, int age) : base(first, last, age)
        {
        }

    }
}
