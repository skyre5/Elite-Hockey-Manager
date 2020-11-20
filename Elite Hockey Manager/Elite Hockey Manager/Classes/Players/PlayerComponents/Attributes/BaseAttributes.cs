using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    //[Serializable]
    public abstract class BaseAttributes : ISerializable
    {
        protected static Random rand = new Random();
        public const int DefaultRating = 50;

        //General stats
        protected int _clutchness = DefaultRating;

        protected int _consistency = DefaultRating;

        private int _fatigue = 0;

        private int _injuryLength = 0;

        public BaseAttributes()
        {
        }

        public virtual Tuple<string, int>[] GetAttributeNames()
        {
            Tuple<string, int>[] names = {
                Tuple.Create("Clutchness", this._clutchness),
                Tuple.Create("Consistency", this._consistency)
            };
            return names;
        }

        public static void CheckRating(ref int attribute, int rating)
        {
            if (rating < 1)
            {
                Console.WriteLine("Invalid input error");
                //PropertyInfo.SetValue produces unhandleable handling for this exception
                //Common problem online with no solution
                //throw new ArgumentException("Error: Value entered needs to be within the range of (1-100)");
            }
            else if (rating > 100)
            {
                attribute = 100;
            }
            else
            {
                attribute = rating;
            }
        }

        protected void GuaranteedStatSet(ref int baseStat, int guaranteedRating)
        {
            if (baseStat < guaranteedRating)
            {
                baseStat = guaranteedRating;
            }
            else if (baseStat < 100)
            {
                baseStat++;
            }
        }

        protected abstract void GenerateStats(int age, int lower, int upper, int guarantee);

        protected abstract void GuaranteedStatChoice(int rating);

        protected void ModifyBoundsToAge(int age, ref int lower, ref int upper, ref int guarantee)
        {
            if (age == 18)
            {
                lower -= 25;
                upper -= 5;
                guarantee -= 5;
            }
            else if (age == 19)
            {
                lower -= 18;
                upper -= 5;
                guarantee -= 3;
            }
            else if (age == 20)
            {
                lower -= 10;
                upper -= 3;
            }
            else if (age == 21)
            {
                lower -= 5;
            }
            else if (age >= 36)
            {
                lower -= 1 + (2 * (age - 36));
                upper -= 1 + (age - 36);
                guarantee -= (age - 36);
            }
        }

        /// <summary>
        /// Stat to keep track of goalies fatigue, will gain more fatigue from losing than winning
        /// Will cause the backup goaltender to get games played when the starter has gotten fatigued enough
        /// </summary>
        public int Fatigue
        {
            get
            {
                return _fatigue;
            }
            set
            {
                _fatigue = value;
            }
        }

        public int Clutchness
        {
            get
            {
                return _clutchness;
            }
            set
            {
                //if (value < 1 || value > 100)
                //{
                //    throw new ArgumentOutOfRangeException();
                //}
                //else
                //{
                //    _clutchness = value;
                //}
                CheckRating(ref _clutchness, value);
            }
        }

        public int Consistency
        {
            get
            {
                return _consistency;
            }
            set
            {
                CheckRating(ref _consistency, value);
            }
        }

        public int InjuryLength
        {
            get
            {
                return _injuryLength;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Error: Injury length must be a positive number");
                }
                else
                {
                    _injuryLength = value;
                }
            }
        }

        public bool Injured
        {
            get
            {
                if (InjuryLength > 0)
                {
                    return true;
                }
                return false;
            }
        }

        #region Player Progression

        internal abstract void ProgressPlayer(int _age, string position, int playerStatusID);

        /// <summary>
        /// Updates players attributes based on player status and current age
        /// </summary>
        /// <param name="age">Age player is currently</param>
        /// <param name="growthEndingAge">Age at which massive amounts of growth end</param>
        /// <param name="regressionBeginAge">Age at which player begins to regress</param>
        /// <param name="updateRange">The amount of skill a player can gain in 1 season</param>
        protected void ChoosePlayerGrowthPhase(int age, int growthEndingAge, int regressionBeginAge, int updateRange)
        {
            if (age <= growthEndingAge)
            {
                GrowStats(2, updateRange);
            }
            else if (age < regressionBeginAge)
            {
                GrowStats(2, 3);
            }
            else if (age >= regressionBeginAge)
            {
                GrowStats(1 + (age - regressionBeginAge), 1);
            }
        }

        /// <summary>
        /// Grows each stat within attributes between 2 given values
        /// </summary>
        /// <param name="negativeRange">The maximum value a player could lose</param>
        /// <param name="upperRange">The maximum value a player could gain</param>
        protected abstract void GrowStats(int negativeRange, int upperRange);

        /// <summary>
        /// Internal function to get a random value that a player will use to adjust attributes
        /// </summary>
        /// <param name="losingRange">Max value a player could lose</param>
        /// <param name="growthRange">Max value a player could gain </param>
        /// <returns>A value in between and including -LosingRange and growthRange</returns>
        protected int GetGrowthValue(int losingRange, int growthRange)
        {
            return rand.Next(-losingRange, growthRange + 1);
        }

        #endregion Player Progression

        public BaseAttributes(SerializationInfo info, StreamingContext context)
        {
            this._clutchness = (int)info.GetValue("Clutchness", typeof(int));
            this._consistency = (int)info.GetValue("Consistency", typeof(int));
            this._fatigue = (int)info.GetValue("Fatigue", typeof(int));
            this._injuryLength = (int)info.GetValue("InjuryLength", typeof(int));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Clutchness", this._clutchness);
            info.AddValue("Consistency", this._consistency);
            info.AddValue("Fatigue", this._fatigue);
            info.AddValue("InjuryLength", this._injuryLength);
        }
    }
}