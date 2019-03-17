using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class SkaterStats : PlayerStats
    {
        int _gamesPlayed = 0;
        //Assuming game takes place in 15 second increments
        private int _timeOnIce = 0;

        int _goals = 0;
        int _assists = 0;

        int _plusMinus = 0;
        int _penaltyMinutes = 0;

        int _powerplayGoals = 0;
        int _powerplayAssists = 0;

        int _shorthandedGoals = 0;
        int _shortHandedAssists = 0;

        int _faceoffWins = 0;
        int _faceoffLosses = 0;
        public SkaterStats(int year, int teamID) : base(year, teamID)
        {
        }
        /// <summary>
        /// Adds a game played to the players stats, will get added upon the start of the game
        /// </summary>
        public void AddGamePlayed()
        {
            _gamesPlayed++;
        }
        public void AddShift()
        {
            _timeOnIce++;
        }
        public void ScoreGoal()
        {
            _goals++;
        }
        public void ScorePowerplayGoal()
        {
            _goals++;
            _powerplayGoals++;
        }
        public void ScoreShorthandedGoal()
        {
            _goals++;
            _shorthandedGoals++;
        }
        public void AssistOnGoal()
        {
            _assists++;
        }
        public void AssistPowerplayGoal()
        {
            _assists++;
            _powerplayAssists++;
        }
        public void AssistShorthandedGoal()
        {
            _assists++;
            _powerplayAssists++;
        }

        /// <summary>
        /// Records addition or subtraction of plus/minus to player
        /// </summary>
        /// <param name="plus">
        /// True: Add plus/minus
        /// False: Subtract plus/minus
        /// </param>
        public void RecordPlusMinus(bool plus)
        {
            if (plus)
            {
                _plusMinus++;
            }
            else
            {
                _plusMinus--;
            }
        }
        /// <summary>
        /// Records a faceoff for the centers taking it and records whether they won or lost it
        /// </summary>
        /// <param name="faceoffWon">
        /// True: Faceoff Won
        /// False: Faceoff Lost
        /// </param>
        public void RecordFaceoff(bool faceoffWon)
        {
            if (faceoffWon)
            {
                _faceoffWins++;
            }
            else
            {
                _faceoffLosses++;
            }
        }

        /// <summary>
        /// Adds penalty minutes to player stats
        /// </summary>
        /// <param name="minutes">
        /// Number of penalty minutes to add
        /// Must be between 2 and 10 minutes
        /// </param>
        public void RecordPenalty(int minutes)
        {
            if (minutes < 2 || minutes > 10)
            {
                throw new ArgumentOutOfRangeException("Error: Penalty minutes must be between 2 and 10 minutes");
            }
            else
            {
                _penaltyMinutes += minutes;
            }
        }
        public int TimeOnIce
        {
            get
            {
                return _timeOnIce;
            }
            set
            {
                _timeOnIce = value;
            }
        }
        public int GamesPlayed
        {
            get
            {
                return _gamesPlayed;
            }
        }
        public int Goals
        {
            get;
            set;
        } = 0;
        public int Assists
        {
            get;
            set;
        } = 0;
        public int Shots
        {
            get;
            set;
        } = 0;
        public int PlusMinus
        {
            get
            {
                return _plusMinus;
            }
            set
            {
                _plusMinus = value;
            }
        }
        public int PenaltyMinutes
        {
            get
            {
                return _penaltyMinutes;
            }
        }
        public int PowerplayGoals
        {
            get
            {
                return _powerplayGoals;
            }
        }
        public int PowerplayAssists
        {
            get
            {
                return _powerplayAssists;
            }
        }
        public int ShorthandedGoals
        {
            get
            {
                return _shorthandedGoals;
            }
        }
        public int ShorthandedAssists
        {
            get
            {
                return _shortHandedAssists;
            }
        }
        public int FaceoffWins
        {
            get;
            set;
        } = 0;
        public int FaceoffLosses
        {
            get;
            set;
        } = 0;
        public int Points
        {
            get { return _goals + _assists; }
        }
        public int PowerplayPoints
        {
            get { return _powerplayGoals + _powerplayAssists; }
        }
        public int ShorthandedPoints
        {
            get { return _shorthandedGoals + _shortHandedAssists; }
        }
    }
}
