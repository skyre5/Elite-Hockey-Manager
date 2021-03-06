﻿using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes.Stats
{
    [Serializable]
    public class TeamStats
    {
        #region Constructors

        public TeamStats(int year, bool playoff = false)
        {
            Year = year;
            Playoff = playoff;
        }

        #endregion Constructors

        #region Events

        public event EventHandler TeamStatsUpdated;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the season resulted in a championship
        /// Presidents trophy for regular season championship
        /// Stanley cup trophy for playoff championship
        /// </summary>
        public bool Champion
        {
            get;
            set;
        }

        /// <summary>
        /// Total goals team lets up
        /// </summary>
        public int GoalsAgainst
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Total goals team scores
        /// </summary>
        public int GoalsFor
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Games lost in regulation
        /// </summary>
        public int Losses
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Games lost in overtime, count for 1 point
        /// </summary>
        public int OvertimeLosses
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Games won in overtime, also gets added to wins property
        /// </summary>
        public int OvertimeWins
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Property to hold whether they are playoff team stats or regular season stats
        /// If true playoffs
        /// If false regular season
        /// </summary>
        public bool Playoff
        {
            get;
            private set;
        } = false;

        /// <summary>
        /// Property for how many points the team has. 2 points for each win and 1 point for every overtime loss
        /// </summary>
        public int Points
        {
            get
            {
                return (Wins * 2) + OvertimeLosses;
            }
        }

        /// <summary>
        /// Total number of powerplay goals team has scored
        /// </summary>
        public int PowerplayGoals
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Total number of powerplay goals allowed by team
        /// </summary>
        public int PowerplayGoalsAgainst
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Total amount of penalties taken by team
        /// </summary>
        public int PowerplaysAgainst
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Total number of powerplays team has received
        /// </summary>
        public int PowerplaysFor
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Games lost in shootout, count for 1 point
        /// </summary>
        public int ShootoutLosses
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Games won in shootout, counts for wins but not overtime property
        /// </summary>
        public int ShootoutWins
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Total number of shots team has allowed
        /// </summary>
        public int ShotsAgainst
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Total amount of shots team has taken
        /// </summary>
        public int ShotsFor
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Wins on the season, 2 points per win
        /// </summary>
        public int Wins
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Year of the sim the stats are being taken for
        /// </summary>
        public int Year
        {
            get;
            private set;
        } = 1;

        #endregion Properties

        #region Methods

        public void InsertGameStats(Game game, Side side)
        {
            if (!game.Finished)
            {
                throw new ArgumentException("Game must be finished to enter stats");
            }
            //Sets the win stats for class
            SetWinStats(game, side);
            if (side == Side.Home)
            {
                TakeHomeStats(game);
            }
            else
            {
                TakeAwayStats(game);
            }
            //Triggers event when the teams stats have changed
            //Will trigger the standings on the home page to update
            //TeamStatsUpdated(this, null);
        }

        /// <summary>
        /// Gets the string of the teams record
        /// </summary>
        /// <returns>string of the teams record Wins-Regulation Losses-Overtime Losses</returns>
        public string Record()
        {
            int regulationLosses = Losses - OvertimeLosses;
            return $"({Wins}-{regulationLosses}-{OvertimeLosses})";
        }

        /// <summary>
        /// Takes stats from game class when the parent team is the away team
        /// </summary>
        /// <param name="game">Game to be processed</param>
        public void TakeAwayStats(Game game)
        {
            this.GoalsFor += game.AwayScore;
            this.GoalsAgainst += game.HomeScore;

            this.ShotsFor += game.AwayShots;
            this.ShotsAgainst += game.HomeShots;

            this.PowerplaysFor += game.AwayPowerplays;
            this.PowerplayGoals += game.AwayPowerplayGoals;
            this.PowerplaysAgainst += game.HomePowerplays;
            this.PowerplayGoalsAgainst += game.HomePowerplayGoals;
        }

        /// <summary>
        /// Takes stats from game class when the parent team is the home team
        /// </summary>
        /// <param name="game">Game to be processed</param>
        public void TakeHomeStats(Game game)
        {
            this.GoalsFor += game.HomeScore;
            this.GoalsAgainst += game.AwayScore;

            this.ShotsFor += game.HomeShots;
            this.ShotsAgainst += game.AwayShots;

            this.PowerplaysFor += game.HomePowerplays;
            this.PowerplayGoals += game.HomePowerplayGoals;
            this.PowerplaysAgainst += game.AwayPowerplays;
            this.PowerplayGoalsAgainst += game.AwayPowerplayGoals;
        }

        /// <summary>
        /// Takes game data and sets wins and losses properties based on game results
        /// </summary>
        /// <param name="game">Game to be processed</param>
        /// <param name="side">Enum for whether the team parent class was home or away</param>
        private void SetWinStats(Game game, Side side)
        {
            if (game.Winner == side)
            {
                this.Wins++;
                if (game.Overtime)
                    this.OvertimeWins++;
            }
            else
            {
                this.Losses++;
                if (game.Overtime) this.OvertimeLosses++;
            }
        }

        #endregion Methods
    }
}