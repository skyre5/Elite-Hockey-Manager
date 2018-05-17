using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class GoalieAttributes : Attributes
    {
        private int _high = 50;
        private int _low = 50;
        private int _speed = 50;
        private int _reboundControl = 50;

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
