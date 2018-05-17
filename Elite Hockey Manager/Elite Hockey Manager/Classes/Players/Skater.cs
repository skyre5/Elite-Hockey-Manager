using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Skater : Player
    {
        private SkaterAttributes _attributes;
        public Skater(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age)
        {
            _attributes = attributes;
        }
        public Skater(string first, string last, int age) : base(first, last, age)
        {
            _attributes = new SkaterAttributes();
        }
        public SkaterAttributes Attributes
        {
            get;
        }
    }
}
