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
        private int _team;

        public Stats(int year, int teamID)
        {
            _year = year;
            _team = teamID;
        }
        public int Year
        {
            get;
        }
        /// <summary>
        /// Team id of current set of stats
        /// </summary>
        public int Team
        {
            get;
        }
    }
}
