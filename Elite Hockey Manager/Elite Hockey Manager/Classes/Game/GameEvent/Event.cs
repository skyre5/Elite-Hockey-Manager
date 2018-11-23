using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.Game.GameEvent
{
    public abstract class Event
    {
        private Player _player;
        private int _period;
        private int _time;
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
        public Event(Player player, int period, int time)
        {
            Player = player;
            Period = period;
            Time = time;
        }
    }
    public class GoalEvent : Event
    {
        private Player _assister1;
        private Player _assister2;
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
        public GoalEvent(Player player, int period, int time, Player assister1 = null, Player assister2 = null) : base(player, period, time)
        {
            Assister1 = assister1;
            Assister2 = assister2;
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
        public HitEvent(Player player, int period, int time, Player playerHit) : base(player, period, time)
        {
            PlayerHit = playerHit;
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
        public PenaltyEvent(Player player, int period, int time, int minutes, Player playerTakenOn = null) : base(player, period, time)
        {
            Minutes = minutes;
            PlayerTakenOn = playerTakenOn;
        }
    }
    public class ShotEvent : Event
    {
        public ShotEvent(Player player, int period, int time) : base(player, period, time)
        {
        }
    }
}
