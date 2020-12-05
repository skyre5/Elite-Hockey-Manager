using System;

namespace Elite_Hockey_Manager.Classes.GameComponents.GameEvent
{
    using Elite_Hockey_Manager.Classes.Players;

    public enum GoalType : int
    {
        EvenStrength,
        Shorthanded,
        Powerplay
    }

    public enum Side : int
    {
        Home,
        Away
    }

    public static class EnumExtensions
    {
        #region Methods

        public static string GoalTypeToShortenedString(GoalType gt)
        {
            switch (gt)
            {
                case GoalType.EvenStrength:
                    return "ES";

                case GoalType.Powerplay:
                    return "PP";

                case GoalType.Shorthanded:
                    return "SH";

                default:
                    return gt.ToString();
            }
        }

        #endregion Methods
    }

    public abstract class Event
    {
        #region Fields

        private int _period;
        private Player _player;
        private Side _side;
        private int _time;

        #endregion Fields

        #region Constructors

        public Event(Player player, int period, int time, Side side)
        {
            Player = player;
            Period = period;
            Time = time;
            Side = side;
        }

        #endregion Constructors

        #region Properties

        public int Period
        {
            get
            {
                return _period;
            }
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _period = value;
            }
        }

        public Player Player
        {
            get
            {
                return _player;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                _player = value;
            }
        }

        public Side Side
        {
            get
            {
                return _side;
            }
            protected set
            {
                _side = value;
            }
        }

        public int Time
        {
            get
            {
                return _time;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _time = value;
            }
        }

        #endregion Properties
    }

    public class GoalEvent : Event
    {
        #region Fields

        private Player _assister1;
        private Player _assister2;
        private GoalType _goalType;
        private PlayersOnIce _playersOnIce = new PlayersOnIce();
        private ShotType _shotType;

        #endregion Fields

        #region Constructors

        public GoalEvent(Player player, int period, int time, Side side, GoalType goalType, ShotType shotType, Player assister1 = null, Player assister2 = null)
            : base(player, period, time, side)
        {
            Assister1 = assister1;
            Assister2 = assister2;
            ShotType = shotType;
        }

        #endregion Constructors

        #region Properties

        public Player Assister1
        {
            get
            {
                return _assister1;
            }
            protected set
            {
                _assister1 = value;
            }
        }

        public Player Assister2
        {
            get
            {
                return _assister2;
            }
            protected set
            {
                _assister2 = value;
            }
        }

        public GoalType GoalType
        {
            get
            {
                return _goalType;
            }
            protected set
            {
                _goalType = value;
            }
        }

        public ShotType ShotType
        {
            get
            {
                return _shotType;
            }
            protected set
            {
                _shotType = value;
            }
        }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            string returnString =
                $"({Side}) {EnumExtensions.GoalTypeToShortenedString(GoalType)} Goal: {Player.PositionAbbreviation}:{Player.LastName}";
            if (Assister1 != null)
            {
                returnString += $"-{Assister1.PositionAbbreviation}:{Assister1.LastName}";
            }
            if (Assister2 != null)
            {
                returnString += $"-{Assister2.PositionAbbreviation}:{Assister2.LastName}";
            }
            return returnString;
        }

        #endregion Methods
    }

    public class HitEvent : Event
    {
        #region Fields

        private Player _playerHit;

        #endregion Fields

        #region Constructors

        public HitEvent(Player player, int period, int time, Side side, Player playerHit) : base(player, period, time, side)
        {
            PlayerHit = playerHit;
        }

        #endregion Constructors

        #region Properties

        public Player PlayerHit
        {
            get
            {
                return _playerHit;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                _playerHit = null;
            }
        }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"({Side}) {Player.PositionAbbreviation}:{Player.LastName} Hit On {PlayerHit.PositionAbbreviation}:{PlayerHit.LastName}";
        }

        #endregion Methods
    }

    public class PenaltyEvent : Event
    {
        #region Fields

        private int _minutes;
        private Player _playerTakenOn;

        #endregion Fields

        #region Constructors

        public PenaltyEvent(Player player, int period, int time, Side side, int minutes, Player playerTakenOn = null) : base(player, period, time, side)
        {
            Minutes = minutes;
            PlayerTakenOn = playerTakenOn;
        }

        #endregion Constructors

        #region Properties

        public int Minutes
        {
            get
            {
                return _minutes;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _minutes = value;
            }
        }

        public Player PlayerTakenOn
        {
            get
            {
                return _playerTakenOn;
            }
            protected set
            {
                _playerTakenOn = value;
            }
        }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"({Side}) {Minutes} Minute Penalty-{Player.PositionAbbreviation}:{Player.LastName}";
        }

        #endregion Methods
    }

    public class ShotEvent : Event
    {
        #region Fields

        private ShotType _shotType;

        #endregion Fields

        #region Constructors

        public ShotEvent(Player player, int period, int time, Side side, ShotType shotType) : base(player, period, time, side)
        {
            ShotType = shotType;
        }

        #endregion Constructors

        #region Properties

        public ShotType ShotType
        {
            get
            {
                return _shotType;
            }
            protected set
            {
                _shotType = value;
            }
        }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"({Side}) {ShotType} {Player.PositionAbbreviation}:{Player.LastName}";
        }

        #endregion Methods
    }
}