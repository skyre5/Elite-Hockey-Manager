using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class Goalie : Player
    {
        private GoalieAttributes _attributes;

        public override int Overall
        {
            get
            {
                return _attributes.GoalieOverall();
            }
        }

        public Goalie(string first, string last, int age, GoalieAttributes Attributes) : base(first, last, age)
        {
            _attributes = Attributes;
        }
        
        public Goalie(string first, string last, int age) : base(first, last, age)
        {
            _attributes = new GoalieAttributes();
        }
        
        public GoalieAttributes Attributes
        {
            get
            {
                return _attributes;
            }
        }


        public override string Position
        {
            get
            {
                return "G";
            }
        }
    }
}
