using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes.Game
{
    [Serializable]
    public class Game : ISerializable
    {
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
        public bool Finished
        {
            get;
            private set;
        } = false;
        /// <summary>
        /// Public constructor for Game class in a dormant, yet to be played state
        /// </summary>
        /// <param name="homeTeam">Home team object of game to be played</param>
        /// <param name="awayTeam">Away team object of game to be played</param>
        /// <param name="game">Game number within the season or playoff series game #</param>
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
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("HomeTeam", this.HomeTeam);
            info.AddValue("AwayTeam", this.AwayTeam);
            info.AddValue("GameNumber", this.GameNumber);
        }
    }
}
