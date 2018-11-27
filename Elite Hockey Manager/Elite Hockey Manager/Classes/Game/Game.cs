using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Elite_Hockey_Manager.Classes.Game.GameEvent;

namespace Elite_Hockey_Manager.Classes.Game
{
    public struct PlayersOnIce
    {
        public Player[] homePlayers;
        public Player[] awayPlayers;
    }
    [Serializable]
    public class Game : ISerializable
    {
        private List<Event> _gameEvents = new List<Event>();
        /// <summary>
        /// Period of the game 
        /// 1-3 Periods played 20 minutes
        /// 4+ Overtime periods 20 minutes unless regular season in which 5 minute single overtime then shootout
        /// </summary>
        private int period = 1;
        //1200 Seconds in a period (300 in regular season OT)
        private int secondsElapsed = 0;
        //Home and away scores
        private int homeGoals = 0;
        private int awayGoals = 0;
        //Home and away shot totals
        private int homeShots = 0;
        private int awayShots = 0;
        //Home and away hit totals
        private int homeHits = 0;
        private int awayHits = 0;
        //Home and away faceoff wins
        private int homeFaceoffWins = 0;
        private int awayFaceoffWins = 0;
        /// <summary>
        /// Public constructor for Game class in a dormant, yet to be played state
        /// </summary>
        /// <param name="homeTeam">Home team object of game to be played</param>
        /// <param name="awayTeam">Away team object of game to be played</param>
        /// <param name="game">Game number within the season or playoff series game #</param>
        public Team HomeTeam
        {
            get;
            protected set;
        }
        public Team AwayTeam
        {
            get;
            protected set;
        }
        public int GameNumber
        {
            get;
            protected set;
        }
        public string Title
        {
            get
            {
                return String.Format("{0} @ {1}", AwayTeam.TeamName, HomeTeam.TeamName);
            }
        }
        /// <summary>
        /// Boolean variable on whether the game has been finished yet
        /// </summary>
        public bool Finished
        {
            get;
            private set;
        } = false;
        public List<Event> GameEvents
        {
            get
            {
                return _gameEvents;
            }
        }

        public Game(Team homeTeam, Team awayTeam, int game = 1)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            GameNumber = game;
        }
        public void PlayGame()
        {
            //Completes the entire game
        }
        protected Game(SerializationInfo info, StreamingContext context)
        {
            this.HomeTeam = (Team)info.GetValue("HomeTeam", typeof(Team));
            this.AwayTeam = (Team)info.GetValue("AwayTeam", typeof(Team));
            this.GameNumber = (int)info.GetValue("GameNumber", typeof(int));
            this.Finished = (bool)info.GetValue("Finished", typeof(bool));

            this.homeGoals = (int)info.GetValue("HomeGoals", typeof(int));
            this.awayGoals = (int)info.GetValue("AwayGoals", typeof(int));

            this.homeShots = (int)info.GetValue("HomeShots", typeof(int));
            this.awayShots = (int)info.GetValue("AwayShots", typeof(int));

            this.homeHits = (int)info.GetValue("HomeHits", typeof(int));
            this.awayHits = (int)info.GetValue("AwayHits", typeof(int));

            this.homeFaceoffWins = (int)info.GetValue("HomeFaceoff", typeof(int));
            this.awayFaceoffWins = (int)info.GetValue("AwayFaceoff", typeof(int));

            this._gameEvents = (List<Event>)info.GetValue("GameEvents", typeof(List<Event>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("HomeTeam", this.HomeTeam);
            info.AddValue("AwayTeam", this.AwayTeam);
            info.AddValue("GameNumber", this.GameNumber);
            info.AddValue("Finished", this.Finished);

            info.AddValue("HomeGoals", this.homeGoals);
            info.AddValue("AwayGoals", this.awayGoals);

            info.AddValue("HomeShots", this.homeShots);
            info.AddValue("AwayShots", this.awayShots);

            info.AddValue("HomeHits", this.homeHits);
            info.AddValue("AwayHits", this.awayHits);

            info.AddValue("HomeFaceoff", this.homeFaceoffWins);
            info.AddValue("AwayFaceoff", this.awayFaceoffWins);

            info.AddValue("GameEvents", this._gameEvents);
        }
    }
}
