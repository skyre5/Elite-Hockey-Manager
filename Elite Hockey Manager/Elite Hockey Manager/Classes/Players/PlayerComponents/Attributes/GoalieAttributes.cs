﻿using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;

    internal enum GoalieStatNames : int
    {
        High,
        Low,
        Speed,
        ReboundControl
    }

    [Serializable]
    public class GoalieAttributes : BaseAttributes
    {
        #region Fields

        private int _high = DefaultRating;
        private int _low = DefaultRating;
        private int _reboundControl = DefaultRating;
        private int _speed = DefaultRating;

        #endregion Fields

        #region Constructors

        public GoalieAttributes()
        {
        }

        #endregion Constructors

        #region Properties

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

        #endregion Properties

        #region Methods

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

        public override Tuple<string, int>[] GetAttributeNames()
        {
            Tuple<string, int>[] parentNames = base.GetAttributeNames();
            Tuple<string, int>[] newNames = {
                Tuple.Create("High", this._high),
                Tuple.Create("Low", this._low),
                Tuple.Create("Speed", this._speed),
                Tuple.Create("ReboundControl", this._reboundControl)
            };
            Tuple<string, int>[] statNames = newNames.Concat(parentNames).ToArray();
            return statNames;
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

        protected override void GenerateStats(int age, int lower, int upper, int guarantee)
        {
            ModifyBoundsToAge(age, ref lower, ref upper, ref guarantee);
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

        #endregion Methods

        #region Player Progression

        internal override void ProgressPlayer(int age, string position, int playerStatusID)
        {
            if (position == "G")
            {
                ProgressGoalie(age, (GoaliePlayerStatus)playerStatusID);
            }
            else
            {
                throw new ArgumentException("Goalie was not sent to ProgressPlayer in GoalieAttributes");
            }
        }

        protected override void GrowStats(int negativeRange, int upperRange)
        {
            High += GetGrowthValue(negativeRange, upperRange);
            Low += GetGrowthValue(negativeRange, upperRange);
            Speed += GetGrowthValue(negativeRange, upperRange);
            ReboundControl += GetGrowthValue(negativeRange, upperRange);
        }

        private void ProgressGoalie(int age, GoaliePlayerStatus status)
        {
            switch (status)
            {
                case GoaliePlayerStatus.Generational:
                    ChoosePlayerGrowthPhase(age, 23, 33, 6);
                    break;

                case GoaliePlayerStatus.Elite:
                    ChoosePlayerGrowthPhase(age, 21, 30, 4);
                    break;

                case GoaliePlayerStatus.Starter:
                    ChoosePlayerGrowthPhase(age, 21, 30, 3);
                    break;

                case GoaliePlayerStatus.LowStarter:
                    ChoosePlayerGrowthPhase(age, 21, 28, 3);
                    break;

                case GoaliePlayerStatus.Backup:
                    ChoosePlayerGrowthPhase(age, 20, 32, 2);
                    break;

                case GoaliePlayerStatus.Role:
                    ChoosePlayerGrowthPhase(age, 23, 35, 1);
                    break;

                case GoaliePlayerStatus.Unset:
                default:
                    ChoosePlayerGrowthPhase(age, 18, 29, 1);
                    break;
            }
        }

        #endregion Player Progression
    }
}