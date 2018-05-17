using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class Goalie : Player
    {
        private int _high;
        private int _low;
        private int _breakaway;
        private int _poise;

        private int _fatigue = 100;

        private int _goalieStats;

        public Goalie(string first, string last, int age, int high, int low, int breakaway, int poise) : base(first, last, age)
        {
            _high = high;
            _low = low;
            _breakaway = breakaway;
            _poise = poise;
        }

        public override int GetOverall()
        {
            int total = this._high + this._low + this._breakaway;
            return total / 3;
        }
        public int High
        {
            get
            {
                return _high;
            }
            set
            {
                if (CheckRating(value))
                {
                    _high = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
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
                if (CheckRating(value))
                {
                    _low = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int Breakaway
        {
            get
            {
                return _breakaway;
            }
            set
            {
                if (CheckRating(value))
                {
                    _breakaway = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int Poise
        {
            get
            {
                return _poise;
            }
            set
            {
                if (CheckRating(value))
                {
                    _poise = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
