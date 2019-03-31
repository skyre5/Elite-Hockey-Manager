using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.GameComponents;

namespace Elite_Hockey_Manager.Classes.GameComponents.GameEvent
{
    public enum GoalType : int
    {
        EvenStrength,
        Shorthanded,
        Powerplay
    }
    public static class EnumExtensions
    {
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
    }
    public enum Side : int
    {
        Home, 
        Away
    }
    public abstract class Event
    {
        private Player _player;
        private int _period;
        private int _time;
        private Side _side;
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
        public Side Side {
            get
            {
                return _side;
            }
            protected set
            {
                _side = value;
            }
        }
        public Event(Player player, int period, int time, Side side)
        {
            Player = player;
            Period = period;
            Time = time;
            Side = side;
        }
    }
    public class GoalEvent : Event
    {
        private Player _assister1;
        private Player _assister2;
        private GoalType _goalType;
        private ShotType _shotType;
        private PlayersOnIce _playersOnIce = new PlayersOnIce();
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

        public GoalEvent(Player player, int period, int time, Side side, GoalType goalType, ShotType shotType, Player assister1 = null, Player assister2 = null)
            : base(player, period, time, side)
        {
            Assister1 = assister1;
            Assister2 = assister2;
            ShotType = shotType;
        }

        public override string ToString()
        {
            string returnString = String.Format("({0}) {1} Goal: {2}:{3}", Side, EnumExtensions.GoalTypeToShortenedString(GoalType), Player.Position, Player.LastName);
            if (Assister1 != null)
            {
                returnString += String.Format("-{0}:{1}", Assister1.Position, Assister1.LastName);
            }
            if (Assister2 != null)
            {
                returnString += String.Format("-{0}:{1}", Assister2.Position, Assister2.LastName);
            }
            return returnString;
        }
    }
    public class HitEvent : Event
    {
        private Player _playerHit;
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
        public HitEvent(Player player, int period, int time, Side side, Player playerHit) : base(player, period, time, side)
        {
            PlayerHit = playerHit;
        }
        public override string ToString()
        {
            return String.Format("({0}) {1}:{2} Hit On {3}:{4}", Side, Player.Position, Player.LastName, PlayerHit.Position, PlayerHit.LastName);
        }
    }
    public class PenaltyEvent : Event
    {
        private int _minutes;
        private Player _playerTakenOn;
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
        public PenaltyEvent(Player player, int period, int time, Side side, int minutes, Player playerTakenOn = null) : base(player, period, time, side)
        {
            Minutes = minutes;
            PlayerTakenOn = playerTakenOn;
        }
        public override string ToString()
        {
            return String.Format("({0}) {1} Minute Penalty-{2}:{3}", Side, Minutes, Player.Position, Player.LastName);
        }
    }
    public class ShotEvent : Event
    {
        private ShotType _shotType;
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
        public ShotEvent(Player player, int period, int time, Side side, ShotType shotType) : base(player, period, time, side)
        {
            ShotType = shotType;
        }
        public override string ToString()
        {
            return String.Format("({0}) {1} {2}:{3}", Side, ShotType, Player.Position, Player.LastName);
        }
    }
}
