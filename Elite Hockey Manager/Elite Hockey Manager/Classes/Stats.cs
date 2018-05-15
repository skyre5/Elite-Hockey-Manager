using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Stats
    {
        private int _year;

        public Stats(int year)
        {
            _year = year;
        }
    }
}
