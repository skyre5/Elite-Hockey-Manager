namespace Elite_Hockey_Manager.Classes
{
    using System;

    [Serializable]
    public abstract class PlayerStats
    {
        #region Fields

        protected int _team;

        protected int _year;

        #endregion Fields

        #region Constructors

        public PlayerStats(int year, int teamID, bool playoff = false)
        {
            _year = year;
            _team = teamID;
            Playoff = playoff;
        }

        #endregion Constructors

        #region Properties

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

        public int Year
        {
            get
            {
                return _year;
            }
        }

        #endregion Properties
    }
}