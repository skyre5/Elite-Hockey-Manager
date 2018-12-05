using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class PlayerStats
    {
        protected int _year;
        protected int _team;
        protected int _gamesPlayed = 0;
        public int GamesPlayed
        {
            get
            {
                return _gamesPlayed;
            }
            set
            {
                _gamesPlayed = value;
            }
        }
        public PlayerStats(int year, int teamID)
        {
            _year = year;
            _team = teamID;
        }
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
    }
}
