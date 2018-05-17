using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Skater : Player
    {
        public Skater(string first, string last, int age) : base(first, last, age)
        {
        }
    }
}
