using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
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
            this._attributes = new GoalieAttributes();
        }
        public Goalie(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._attributes = (GoalieAttributes)info.GetValue("Attributes", typeof(GoalieAttributes));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Attributes", this._attributes);
        }


        public override string Position
        {
            get
            {
                return "G";
            }
        }
        public override Attributes Attributes
        {
            get
            {
                return _attributes;
            }
        }
    }
}
