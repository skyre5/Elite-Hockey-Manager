using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Skater : Player
    {
        protected SkaterAttributes _attributes;
        public Skater(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age)
        {
            _attributes = attributes;
        }
        public Skater(string first, string last, int age) : base(first, last, age)
        {
            _attributes = new SkaterAttributes();
        }

        public Skater(SerializationInfo info, StreamingContext context): base(info, context)
        {
            this._attributes = (SkaterAttributes)info.GetValue("Attributes", typeof(SkaterAttributes));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Attributes", this._attributes);
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
