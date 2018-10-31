using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public abstract class Attributes : ISerializable
    {
        public const int DefaultRating = 50;
        //General stats
        protected int _clutchness = DefaultRating;
        protected int _consistency = DefaultRating;

        private int _fatigue = 0;

        private int _injuryLength = 0;
        //0 Healthy
        //1 Slight injury
        //2 Major injury
        //3 Can't play
        private int _injurySeverity = 0;
        public Attributes()
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
            if (rating < 1 || rating > 100)
            {
                Console.WriteLine("Invalid input error");
                //PropertyInfo.SetValue produces unhandleable handling for this exception
                //Common problem online with no solution
                //throw new ArgumentException("Error: Value entered needs to be within the range of (1-100)");
            }
            else
            {
                attribute = rating;
            }
        }
        public Attributes(SerializationInfo info, StreamingContext context)
        {
            this._clutchness = (int)info.GetValue("Clutchness", typeof(int));
            this._consistency = (int)info.GetValue("Consistency", typeof(int));
            this._fatigue = (int)info.GetValue("Fatigue", typeof(int));
            this._injuryLength = (int)info.GetValue("InjuryLength", typeof(int));
            this._injurySeverity = (int)info.GetValue("InjurySeverity", typeof(int));
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Clutchness", this._clutchness);
            info.AddValue("Consistency", this._consistency);
            info.AddValue("Fatigue", this._fatigue);
            info.AddValue("InjuryLength", this._injuryLength);
            info.AddValue("InjurySeverity", this._injurySeverity);
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
                lower -= 10;
                upper -= 10;
                guarantee -= 5;
            }
            else if (age == 19)
            {
                lower -= 7;
                upper -= 7;
                guarantee -= 3;
            }
            else if (age == 20)
            {
                lower -= 5;
                upper -= 3;
            }
            else if (age == 21)
            {
                lower -= 3;
            }
            else if (age >= 36)
            {
                lower -= 1 + (2 * (age - 36));
                upper -= 1 + (age - 36);
                guarantee -= (age - 36);
            }
        }
        public int Fatigue
        {
            get
            {
                return _fatigue;
            }
            set
            {
                CheckRating(ref _fatigue, value);
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
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _clutchness = value;
                }
                //CheckRating(ref _clutchness, value);
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
        public int InjurySeverity
        {
            get
            {
                return _injurySeverity;
            }
            set
            {
                if (value < 0 || value > 3)
                {
                    throw new ArgumentException("Error: Injury severity must be between 0 and 3");
                }
                else
                {
                    _injurySeverity = value;
                }
            }
        }
    }

}
