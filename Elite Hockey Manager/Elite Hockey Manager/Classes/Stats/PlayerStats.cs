using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class PlayerStats
    {
        public int Year
        {
            get
            {
                return _year;
            }
        }
        /// <summary>
        /// Team id of current set of stats
        /// </summary>
        public int Team
        {
            get
            {
                return _team;
            }
        }
        public int GamesPlayed
        {
            get;
            set;
        } = 0;
        public bool Playoff
        {
            get;
            private set;
        }
        protected int _year;
        protected int _team;

        public PlayerStats(int year, int teamID, bool playoff = false)
        {
            _year = year;
            _team = teamID;
            Playoff = playoff;
        }


    }
}
