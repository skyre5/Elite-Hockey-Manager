using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class Center : Forward
    {
        public Center(string first, string last, int age) : base(first, last, age)
        {
        }
        public Center(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }
        public Center(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override int Overall
        {
            get
            {
                return Attributes.CenterRating();
            }
        }

        public override string Position
        {
            get
            {
                return "C";
            }
        }
    }
}
