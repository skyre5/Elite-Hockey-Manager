using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Attributes : ISerializable
    {
        public const int DefaultRating = 50;
        //General stats
        private int _clutchness = DefaultRating;
        private int _consistency = DefaultRating;

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
        public Tuple<string, int>[] GetStatNames()
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
                throw new ArgumentException("Error: Value entered needs to be within the range of (1-100)");
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
