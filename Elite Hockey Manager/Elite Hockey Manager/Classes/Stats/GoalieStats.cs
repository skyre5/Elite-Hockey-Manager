using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class GoalieStats : PlayerStats
    {
        private int _gamesStarted = 0;

        private int _wins = 0;
        private int _losses = 0;
        private int _shutouts = 0;

        private int _shotsFaced = 0;
        private int _goalsAllowed = 0;

        private int _breakawayShots = 0;
        private int _breakawayGoalsAllowed = 0;

        private int _powerplayShots = 0;
        private int _powerplayGoalsAllowed = 0;

        private int _shorthandedShots = 0;
        private int _shorthandedGoalsAllowed = 0;

        public GoalieStats(int year, int teamID) : base(year, teamID)
        {
        }
        public void AddGameStarted()
        {
            _gamesPlayed++;
            _gamesStarted++;
        }
        public void AddReliefStart()
        {
            _gamesPlayed++;
        }
        public void AddWin()
        {
            _wins++;
        }
        public void AddLoss()
        {
            _losses++;
        }
        public void AddBreakaway(bool scored)
        {
            _breakawayShots++;
            if (scored)
            {
                _breakawayGoalsAllowed++;
            }
        }
        public void AddShorthanded(bool scored)
        {
            _shorthandedShots++;
            if (scored)
            {
                _shorthandedGoalsAllowed++;
            }
        }
        public void AddPowerplay(bool scored)
        {
            _powerplayShots++;
            if (scored)
            {
                _powerplayGoalsAllowed++;
            }
        }
        public int GamesStarted
        {
            get
            {
                return _gamesStarted;
            }
        }
        public int Wins
        {
            get
            {
                return _wins;
            }
        }
        public int Losses
        {
            get
            {
                return _losses;
            }
        }
        public int Shutouts
        {
            get
            {
                return _shutouts;
            }
            set
            {
                _shutouts = value;
            }
        }
        public int ShotsFaced
        {
            get
            {
                return _shotsFaced;
            }
            set
            {
                _shotsFaced = value;
            }
        }
        public int GoalsAllowed
        {
            get
            {
                return _goalsAllowed;
            }
            set
            {
                _goalsAllowed = value;
            }
        }
        public int BreakawayShots
        {
            get
            {
                return _breakawayShots;
            }
        }
        public int BreakawayGoalsAllowed
        {
            get
            {
                return _breakawayGoalsAllowed;
            }
        }
        public int PowerplayShots
        {
            get
            {
                return _powerplayShots;
            }
        }
        public int PowerplayGoalsAllowed
        {
            get
            {
                return _powerplayGoalsAllowed;
            }
        }
        public int ShorthandedShots
        {
            get
            {
                return _shorthandedShots;
            }
        }
        public int ShorthandedGoalsAllowed
        {
            get
            {
                return _shorthandedGoalsAllowed;
            }
        }
        public double SavePercentage
        {
            get
            {
                if (this._shotsFaced > 0)
                {
                    return ((double)this._shotsFaced / (double)(this._shotsFaced + this._goalsAllowed));
                }
                else
                {
                    return 0;
                }
            }
        }
        public double PowerplaySavePercentage
        {
            get
            {
                if (this._powerplayShots > 0)
                {
                    return ((double)this._powerplayShots / (double)(this._powerplayShots + this._powerplayGoalsAllowed));
                }
                else
                {
                    return 0;
                }
            }
        }
        public double ShorthandedSavePercentage
        {
            get
            {
                if (this._shorthandedShots > 0)
                {
                    return ((double)this._shorthandedShots / (double)(this._shorthandedShots + this._shorthandedGoalsAllowed));
                }
                else
                {
                    return 0;
                }
            }
        }
        public double BreakawaySavePercentage
        {
            get
            {
                if (this._breakawayShots > 0)
                {
                    return ((double)this._breakawayShots / (double)(this._breakawayShots + this._breakawayGoalsAllowed));
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
