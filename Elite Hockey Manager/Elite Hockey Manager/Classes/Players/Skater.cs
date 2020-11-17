using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public abstract class Skater : Player
    {
        protected List<SkaterStats> _stats = new List<SkaterStats>();
        protected SkaterAttributes _attributes;
        public override BaseAttributes Attributes
        {
            get
            {
                return _attributes;
            }
        }
        public SkaterAttributes SkaterAttributes
        {
            get
            {
                return (SkaterAttributes)_attributes;
            }
        }
        public SkaterStats Stats
        {
            get
            {
                //If there are no stats on list add a new invalid skaterstats object
                if (_stats.Count == 0)
                {
                    Console.WriteLine("Unset skater stats added\n" + new System.Diagnostics.StackTrace().ToString());
                    _stats.Add(new SkaterStats(-1, -1));
                }
                return _stats.Last();
            }
        }
        public List<SkaterStats> StatsList
        {
            get
            {
                return _stats;
            }
        }
        public Skater(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age)
        {
            _attributes = attributes;
        }
        public Skater(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract)
        {
            _attributes = attributes;
        }
        public Skater(string first, string last, int age) : base(first, last, age)
        {
            _attributes = new SkaterAttributes();
        }
        public Skater(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
            _attributes = new SkaterAttributes();
        }
        public override void AddStats(int year, int teamID, bool playoffs)
        {
            _stats.Add(new SkaterStats(year, teamID, playoffs));
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
    }
}
