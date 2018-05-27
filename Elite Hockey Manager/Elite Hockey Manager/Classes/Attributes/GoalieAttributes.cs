using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class GoalieAttributes : Attributes
    {
        private int _high = DefaultRating;
        private int _low = DefaultRating;
        private int _speed = DefaultRating;
        private int _reboundControl = DefaultRating;

        public GoalieAttributes(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._high = (int)info.GetValue("High", typeof(int));
            this._low = (int)info.GetValue("Low", typeof(int));
            this._speed = (int)info.GetValue("Speed", typeof(int));
            this._reboundControl = (int)info.GetValue("ReboundControl", typeof(int));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("High", this._high);
            info.AddValue("Low", this._low);
            info.AddValue("Speed", this._speed);
            info.AddValue("ReboundControl", this._reboundControl);
        }
        public GoalieAttributes()
        {
        }

        public int High
        {
            get
            {
                return _high;
            }
            set
            {
                CheckRating(ref _high, value);
            }
        }
        public int Low
        {
            get
            {
                return _low;
            }
            set
            {
                CheckRating(ref _low, value);
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                CheckRating(ref _speed, value);
            }
        }
        public int ReboundControl
        {
            get
            {
                return _reboundControl;
            }
            set
            {
                CheckRating(ref _reboundControl, value);
            }
        }

        public int GoalieOverall()
        {
            //90% of rating is from average of high, low, speed, and rebound control
            double baseTotal = (((double)(High + Low + Speed + ReboundControl)) / 4);
            baseTotal *= 0.90;
            //Takes goalies clutch rating as 10% of goalies rating
            double clutchTotal = ((double)(Clutchness)) / 10;
            //Rounds up addition of base and total and rounds up into int
            int overall = (int)Math.Ceiling(baseTotal + clutchTotal);
            return overall;
        }
    }
}
