using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    enum GoalieStatNames : int
    {
        High,
        Low,
        Speed,
        ReboundControl
    }
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
        public new Tuple<string, int>[] GetStatNames()
        {
            Tuple<string, int>[] parentNames = base.GetStatNames();
            Tuple<string, int>[] newNames = {
                Tuple.Create("High", this._high),
                Tuple.Create("Low", this._low),
                Tuple.Create("Speed", this._speed),
                Tuple.Create("ReboundControl", this._reboundControl)
            };
            Tuple<string, int>[] statNames = newNames.Concat(parentNames).ToArray();
            return statNames;
        }

        protected override void GenerateStats(int age, int lower, int upper, int guarantee)
        {
            ModifyBoundsToAge(age, ref lower, ref upper, ref guarantee);
            Random rand = new Random();
            _high = rand.Next(lower, upper + 1);
            _low = rand.Next(lower, upper + 1);
            _speed = rand.Next(lower, upper + 1);
            _reboundControl = rand.Next(lower, upper + 1);
            GuaranteedStatChoice(guarantee);
        }

        protected override void GuaranteedStatChoice(int rating)
        {
            Random rand = new Random();
            //0-3
            int choice = rand.Next(0, 4);
            switch (choice)
            {
                case (int)GoalieStatNames.High:
                    GuaranteedStatSet(ref _high, rating);
                    break;
                case (int)GoalieStatNames.Low:
                    GuaranteedStatSet(ref _low, rating);
                    break;
                case (int)GoalieStatNames.Speed:
                    GuaranteedStatSet(ref _speed, rating);
                    break;
                case (int)GoalieStatNames.ReboundControl:
                    GuaranteedStatSet(ref _reboundControl, rating);
                    break;
            }
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
        public void GenerateGoalieStatRanges(GoaliePlayerStatus playerStatus, int age = 27)
        {
            int lowerBound, upperBound, guaranteedStat;
            switch (playerStatus)
            {
                case GoaliePlayerStatus.Unset:
                    lowerBound = 50;
                    upperBound = 55;
                    guaranteedStat = 53;
                    break;
                case GoaliePlayerStatus.Generational:
                    lowerBound = 80;
                    upperBound = 100;
                    guaranteedStat = 95;
                    break;
                case GoaliePlayerStatus.Elite:
                    lowerBound = 75;
                    upperBound = 95;
                    guaranteedStat = 90;
                    break;
                case GoaliePlayerStatus.Starter:
                    lowerBound = 75;
                    upperBound = 90;
                    guaranteedStat = 85;
                    break;
                case GoaliePlayerStatus.LowStarter:
                    lowerBound = 70;
                    upperBound = 85;
                    guaranteedStat = 82;
                    break;
                case GoaliePlayerStatus.Backup:
                    lowerBound = 65;
                    upperBound = 80;
                    guaranteedStat = 75;
                    break;
                case GoaliePlayerStatus.Role:
                    lowerBound = 60;
                    upperBound = 78;
                    guaranteedStat = 72;
                    break;
                default:
                    lowerBound = 50;
                    upperBound = 50;
                    guaranteedStat = 50;
                    break;
            }
            GenerateStats(age, lowerBound, upperBound, guaranteedStat);
        }
    }
}
