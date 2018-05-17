using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class Center : Forward
    {
        public Center(string first, string last, int age) : base(first, last, age)
        {
        }
        public Center(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }
        public override int Overall
        {
            get
            {
                return this._attributes.CenterRating();
            }
        }
    }
}
