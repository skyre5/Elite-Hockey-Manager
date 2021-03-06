﻿using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;

    public enum SkaterAttributeNames : int
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
    public class SkaterAttributes : BaseAttributes
    {
        #region Fields

        //Defense stats
        private int _awareness = DefaultRating;

        private int _checking = DefaultRating;

        private int _deking = DefaultRating;

        //Mainly set for centers
        private int _faceoff = DefaultRating;

        private int _slapShot = DefaultRating;

        private int _speed = DefaultRating;

        //Shooting stats
        private int _wristShot = DefaultRating;

        #endregion Fields

        #region Constructors

        public SkaterAttributes()
        {
        }

        #endregion Constructors

        #region Properties

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
        /// Average of awareness and checking skill
        /// </summary>
        public int Defense
        {
            get
            {
                return (_awareness + _checking) / 2;
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

        #endregion Properties

        #region Methods

        public int CenterRating()
        {
            //Takes the 4 attributes (A weighted version of the 6 main attributes) and weighs them as 90% of overall
            double baseTotal = (((double)(Shooting + Defense + Deking + Speed)) / 4);
            baseTotal *= 0.9;
            //Takes the faceoff as 10% of the players overall
            double faceoffTotal = ((double)(Faceoff)) / 10;
            //Adds the together and rounds it up back into an integer
            int overall = (int)Math.Ceiling(baseTotal + faceoffTotal);
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

        public override Tuple<string, int>[] GetAttributeNames()
        {
            Tuple<string, int>[] parentNames = base.GetAttributeNames();
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

        protected override void GenerateStats(int age, int lower, int upper, int guarantee)
        {
            ModifyBoundsToAge(age, ref lower, ref upper, ref guarantee);
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
                case (int)SkaterAttributeNames.WristShot:
                    GuaranteedStatSet(ref _wristShot, rating);
                    break;

                case (int)SkaterAttributeNames.SlapShot:
                    GuaranteedStatSet(ref _slapShot, rating);
                    break;

                case (int)SkaterAttributeNames.Awareness:
                    GuaranteedStatSet(ref _awareness, rating);
                    break;

                case (int)SkaterAttributeNames.Checking:
                    GuaranteedStatSet(ref _checking, rating);
                    break;

                case (int)SkaterAttributeNames.Deking:
                    GuaranteedStatSet(ref _deking, rating);
                    break;

                case (int)SkaterAttributeNames.Speed:
                    GuaranteedStatSet(ref _speed, rating);
                    break;
            }
        }

        #endregion Methods

        #region Player Progression

        internal override void ProgressPlayer(int age, string position, int playerStatusID)
        {
            if (position == "LD" || position == "RD")
            {
                ProgressDefender(age, (DefensePlayerStatus)playerStatusID);
            }
            else if (position == "LW" || position == "C" || position == "RW")
            {
                ProgressForward(age, (ForwardPlayerStatus)playerStatusID);
            }
            else
            {
                throw new ArgumentException("Invalid position sent to SkaterAttributes.ProgressPlayer");
            }
        }

        protected override void GrowStats(int negativeRange, int upperRange)
        {
            WristShot += this.GetGrowthValue(negativeRange, upperRange);
            SlapShot += this.GetGrowthValue(negativeRange, upperRange);
            Awareness += this.GetGrowthValue(negativeRange, upperRange);
            Checking += this.GetGrowthValue(negativeRange, upperRange);
            Deking += this.GetGrowthValue(negativeRange, upperRange);
            Speed += this.GetGrowthValue(negativeRange, upperRange);
            Faceoff += this.GetGrowthValue(negativeRange, upperRange);
        }

        /// <summary>
        /// Sets player growth based on how old player is and defender player status
        /// </summary>
        /// <param name="age">Age of the player</param>
        /// <param name="status">Players status ranging from Generational to Role and unset</param>
        private void ProgressDefender(int age, DefensePlayerStatus status)
        {
            switch (status)
            {
                case DefensePlayerStatus.Generational:
                    ChoosePlayerGrowthPhase(age, 23, 34, 7);
                    break;

                case DefensePlayerStatus.Superstar:
                    ChoosePlayerGrowthPhase(age, 21, 31, 5);
                    break;

                case DefensePlayerStatus.FirstPairing:
                    ChoosePlayerGrowthPhase(age, 21, 30, 4);
                    break;

                case DefensePlayerStatus.SecondPairing:
                    ChoosePlayerGrowthPhase(age, 21, 30, 3);
                    break;

                case DefensePlayerStatus.BottomPairing:
                    ChoosePlayerGrowthPhase(age, 21, 34, 2);
                    break;

                case DefensePlayerStatus.Role:
                    ChoosePlayerGrowthPhase(age, 22, 30, 2);
                    break;

                case DefensePlayerStatus.Unset:
                default:
                    ChoosePlayerGrowthPhase(age, 18, 35, 2);
                    break;
            }
        }

        /// <summary>
        /// Sets player growth based on how old player is and forward player status
        /// </summary>
        /// <param name="age"></param>
        /// <param name="status"></param>
        private void ProgressForward(int age, ForwardPlayerStatus status)
        {
            switch (status)
            {
                case ForwardPlayerStatus.Generational:
                    ChoosePlayerGrowthPhase(age, 23, 34, 7);
                    break;

                case ForwardPlayerStatus.Superstar:
                    ChoosePlayerGrowthPhase(age, 21, 32, 5);
                    break;

                case ForwardPlayerStatus.FirstLine:
                    ChoosePlayerGrowthPhase(age, 21, 31, 4);
                    break;

                case ForwardPlayerStatus.TopSix:
                    ChoosePlayerGrowthPhase(age, 21, 30, 3);
                    break;

                case ForwardPlayerStatus.TopNine:
                    ChoosePlayerGrowthPhase(age, 21, 28, 3);
                    break;

                case ForwardPlayerStatus.BottomSix:
                    ChoosePlayerGrowthPhase(age, 22, 30, 2);
                    break;

                case ForwardPlayerStatus.RolePlayer:
                    ChoosePlayerGrowthPhase(age, 20, 32, 2);
                    break;

                case ForwardPlayerStatus.Unset:
                default:
                    ChoosePlayerGrowthPhase(age, 18, 35, 1);
                    break;
            }
        }

        #endregion Player Progression
    }
}