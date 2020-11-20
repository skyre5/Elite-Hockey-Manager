namespace Elite_Hockey_Manager.Classes
{
    public class GoalieStats : PlayerStats
    {
        public GoalieStats(int year, int teamID, bool playoff = false) : base(year, teamID, playoff)
        {
        }

        public void AddGameStarted()
        {
            GamesPlayed++;
            GamesStarted++;
        }

        public void AddReliefStart()
        {
            GamesPlayed++;
        }

        public int GamesStarted
        {
            get;
            set;
        } = 0;

        public int Wins
        {
            get;
            set;
        } = 0;

        public int Losses
        {
            get;
            set;
        } = 0;

        public int Shutouts
        {
            get;
            set;
        } = 0;

        public int ShotsFaced
        {
            get;
            set;
        } = 0;

        public int GoalsAllowed
        {
            get;
            set;
        } = 0;

        public double GAA
        {
            get
            {
                //To make sure number isn't being divided by 0 if goalie hasnt played a game
                if (GamesPlayed == 0)
                {
                    return 0;
                }
                else
                {
                    return (double)GoalsAllowed / GamesPlayed;
                }
            }
        }

        public int BreakawayShots
        {
            get;
            set;
        } = 0;

        public int BreakawayGoalsAllowed
        {
            get;
            set;
        } = 0;

        public int PowerplayShots
        {
            get;
            set;
        } = 0;

        public int PowerplayGoalsAllowed
        {
            get;
            set;
        } = 0;

        public int ShorthandedShots
        {
            get;
            set;
        } = 0;

        public int ShorthandedGoalsAllowed
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// SavePercentage gotten by dividing shots faced by shots faced + goals allowed
        /// Returns 0 if no shots have been faced, avoids divide by zero error
        /// </summary>
        public double SavePercentage
        {
            get
            {
                if (this.ShotsFaced > 0)
                {
                    return ((double)this.ShotsFaced / (double)(this.ShotsFaced + this.GoalsAllowed)) * 100;
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
                if (this.PowerplayShots > 0)
                {
                    return ((double)this.PowerplayShots / (double)(this.PowerplayShots + this.PowerplayGoalsAllowed));
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
                if (this.ShorthandedShots > 0)
                {
                    return ((double)this.ShorthandedShots / (double)(this.ShorthandedShots + this.ShorthandedGoalsAllowed));
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
                if (this.BreakawayShots > 0)
                {
                    return ((double)this.BreakawayShots / (double)(this.BreakawayShots + this.BreakawayGoalsAllowed));
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}