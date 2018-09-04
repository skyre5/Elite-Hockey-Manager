using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    enum SkaterStatNames : int
    {
        WristShot,
        SlapShot,
        Awareness,
        Checking,
        Deking,
        Speed,
        //Not included in guaranteed stat
        Faceoff
    }
    [Serializable]
    public class SkaterAttributes : Attributes
    {
        //Shooting stats
        private int _wristShot = DefaultRating;
        private int _slapShot = DefaultRating;
        //Defense stats
        private int _awareness = DefaultRating;
        private int _checking = DefaultRating;

        private int _deking = DefaultRating;
        private int _speed = DefaultRating;
        //Mainly set for centers
        private int _faceoff = DefaultRating;
        public SkaterAttributes()
        {

        }
        public new Tuple<string, int>[] GetStatNames()
        {
            Tuple<string, int>[] parentNames = base.GetStatNames();
            Tuple<string, int>[] newNames = {
                Tuple.Create("WristShot", this._wristShot),
                Tuple.Create("SlapShot", this._slapShot),
                Tuple.Create("Awareness", this._awareness),
                Tuple.Create("Checking", this._checking),
                Tuple.Create("Deking", this._deking),
                Tuple.Create("Speed", this._speed),
                Tuple.Create("Faceoff", this._faceoff)
            };
            Tuple<string, int>[] statNames = newNames.Concat(parentNames).ToArray();
            return statNames;
        }
        protected override void GenerateStats(int age, int lower, int upper, int guarantee)
        {
            ModifyBoundsToAge(age, ref lower, ref upper, ref guarantee);
            Random rand = new Random();
            //Base attribute stats ranging from lower bound to 100
            _clutchness = rand.Next(lower, 101);
            _consistency = rand.Next(lower, 101);

            _wristShot = rand.Next(lower, upper + 1);
            _slapShot = rand.Next(lower, upper + 1);
            _awareness = rand.Next(lower, upper + 1);
            _checking = rand.Next(lower, upper + 1);
            _deking = rand.Next(lower, upper + 1);
            _speed = rand.Next(lower, upper + 1);
            _faceoff = rand.Next(lower, upper + 1);
            GuaranteedStatChoice(guarantee);
        }

        protected override void GuaranteedStatChoice(int rating)
        {
            Random rand = new Random();
            //0-5
            //Does not include faceoff(6)
            int choice = rand.Next(0, 7);
            switch (choice)
            {
                case (int)SkaterStatNames.WristShot:
                    GuaranteedStatSet(ref _wristShot, rating);
                    break;
                case (int)SkaterStatNames.SlapShot:
                    GuaranteedStatSet(ref _slapShot, rating);
                    break;
                case (int)SkaterStatNames.Awareness:
                    GuaranteedStatSet(ref _awareness, rating);
                    break;
                case (int)SkaterStatNames.Checking:
                    GuaranteedStatSet(ref _checking, rating);
                    break;
                case (int)SkaterStatNames.Deking:
                    GuaranteedStatSet(ref _deking, rating);
                    break;
                case (int)SkaterStatNames.Speed:
                    GuaranteedStatSet(ref _speed, rating);
                    break;
            }
        }
        protected SkaterAttributes(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._wristShot = (int)info.GetValue("WristShot", typeof(int));
            this._slapShot = (int)info.GetValue("SlapShot", typeof(int));
            this._awareness = (int)info.GetValue("Awareness", typeof(int));
            this._checking = (int)info.GetValue("Checking", typeof(int));
            this._deking = (int)info.GetValue("Deking", typeof(int));
            this._speed = (int)info.GetValue("Speed", typeof(int));
            this._faceoff = (int)info.GetValue("Faceoff", typeof(int));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("WristShot", this._wristShot);
            info.AddValue("SlapShot", this._slapShot);
            info.AddValue("Awareness", this._awareness);
            info.AddValue("Checking", this._checking);
            info.AddValue("Deking", this._deking);
            info.AddValue("Speed", this._speed);
            info.AddValue("Faceoff", this._faceoff);
        }
        public int WristShot
        {
            get
            {
                return _wristShot;
            }
            set
            {
                CheckRating(ref _wristShot, value);
            }
        }
        public int SlapShot
        {
            get
            {
                return _slapShot;
            }
            set
            {
                CheckRating(ref _slapShot, value);
            }
        }
        public int Deking
        {
            get
            {
                return _deking;
            }
            set
            {
                CheckRating(ref _deking, value);
            }
        }
        public int Faceoff
        {
            get
            {
                return _faceoff;
            }
            set
            {
                CheckRating(ref _faceoff, value);
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
        public int Awareness
        {
            get
            {
                return _awareness;
            }
            set
            {
                CheckRating(ref _awareness, value);
            }
        }
        public int Checking
        {
            get
            {
                return _checking;
            }
            set
            {
                CheckRating(ref _checking, value);
            }
        }
        /// <summary>
        /// Average of wrist shot and slap shot skill
        /// </summary>
        public int Shooting
        {
            get
            {
                return (_wristShot + _slapShot) / 2;
            }
        }
        /// <summary>
        /// Average of awareness and checking skill
        /// </summary>
        public int Defense
        {
            get
            {
                return (_awareness + _checking) / 2;
            }
        }
        public int CenterRating()
        {
            //Takes the 4 attributes (A weighted version of the 6 main attributes) and weighs them as 90% of overall
            double baseTotal = (((double)(Shooting + Defense + Deking + Speed))/4);
            baseTotal *= 0.9;
            //Takes the faceoff as 10% of the players overall
            double faceoffTotal = ((double)(Faceoff)) / 10;
            //Adds the together and rounds it up back into an integer
            int overall = (int)Math.Ceiling(baseTotal + faceoffTotal);
            return overall;
        }
        public int WingerOverall()
        {
            //Takes 80 percent of the overall as the average of the shooting deking and speed attributes
            double baseTotal = (((double)(Shooting + Deking + Speed)) / 3);
            baseTotal *= 0.8;
            //Takes the defense as 20% of the player overall
            //Slightly less than the other 3 categories values
            double defenseTotal = ((double)(Defense)) / 5;
            //Rounds up the addition of the two parts and rounds it up
            int overall = (int)Math.Ceiling(baseTotal + defenseTotal);
            return overall;
        }
        public int DefenseRating()
        {
            //Takes 85 percent of the overall as the average of the shooting defense and speed
            double baseTotal = (((double)(Shooting + Defense + Speed)) / 3);
            baseTotal *= 0.85;
            //Takes the deking as 15% of the player overall
            //Slightly less than the other 3 categories values
            double defenseTotal = ((double)(Deking)) * 0.15;
            //Rounds up the addition of the two parts and rounds it up
            int overall = (int)Math.Ceiling(baseTotal + defenseTotal);
            return overall;
        }
        public void GenerateForwardStatRanges(ForwardPlayerStatus playerStatus, int age = 27)
        {
            int lowerBound, upperBound, guaranteedStat;
            switch (playerStatus)
            {
                case ForwardPlayerStatus.Unset:
                    lowerBound = 50;
                    upperBound = 55;
                    guaranteedStat = 53;
                    break;
                case ForwardPlayerStatus.Generational:
                    lowerBound = 80;
                    upperBound = 100;
                    guaranteedStat = 95;
                    break;
                case ForwardPlayerStatus.Superstar:
                    lowerBound = 75;
                    upperBound = 95;
                    guaranteedStat = 90;
                    break;
                case ForwardPlayerStatus.FirstLine:
                    lowerBound = 75;
                    upperBound = 90;
                    guaranteedStat = 85;
                    break;
                case ForwardPlayerStatus.TopSix:
                    lowerBound = 70;
                    upperBound = 85;
                    guaranteedStat = 82;
                    break;
                case ForwardPlayerStatus.TopNine:
                    lowerBound = 65;
                    upperBound = 80;
                    guaranteedStat = 75;
                    break;
                case ForwardPlayerStatus.BottomSix:
                    lowerBound = 60;
                    upperBound = 78;
                    guaranteedStat = 72;
                    break;
                case ForwardPlayerStatus.RolePlayer:
                    lowerBound = 55;
                    upperBound = 75;
                    guaranteedStat = 65;
                    break;
                default:
                    lowerBound = 50;
                    upperBound = 50;
                    guaranteedStat = 50;
                    break;
            }
            GenerateStats(age, lowerBound, upperBound, guaranteedStat);
        }
        public void GenerateDefenseStatRanges(DefensePlayerStatus playerStatus, int age = 27)
        {
            int lowerBound, upperBound, guaranteedStat;
            switch (playerStatus)
            {
                case DefensePlayerStatus.Unset:
                    lowerBound = 50;
                    upperBound = 55;
                    guaranteedStat = 53;
                    break;
                case DefensePlayerStatus.Generational:
                    lowerBound = 80;
                    upperBound = 100;
                    guaranteedStat = 95;
                    break;
                case DefensePlayerStatus.Superstar:
                    lowerBound = 75;
                    upperBound = 95;
                    guaranteedStat = 90;
                    break;
                case DefensePlayerStatus.FirstPairing:
                    lowerBound = 75;
                    upperBound = 90;
                    guaranteedStat = 85;
                    break;
                case DefensePlayerStatus.SecondPairing:
                    lowerBound = 70;
                    upperBound = 85;
                    guaranteedStat = 82;
                    break;
                case DefensePlayerStatus.BottomPairing:
                    lowerBound = 65;
                    upperBound = 80;
                    guaranteedStat = 75;
                    break;
                case DefensePlayerStatus.Role:
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
