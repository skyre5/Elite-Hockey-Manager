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
        public Skater[] homeForwards;
        public Skater[] awayForwards;
        public Skater[] homeDefenders;
        public Skater[] awayDefenders;
        //Home true, away false
        public Skater[] GetAllPlayers(bool side)
        {
            Skater[] allPlayers = new Skater[5];
            if (side)
            {
                return CombineArrays(homeForwards, homeDefenders);
            }
            else
            {
                return CombineArrays(awayForwards, awayDefenders);
            }
        }
        private Skater[] CombineArrays(Skater[] forwards, Skater[] defenders)
        {
            Skater[] combinedArrays = new Skater[5];
            Array.Copy(forwards, combinedArrays, forwards.Length);
            Array.Copy(defenders, 0, combinedArrays, 3, 2);
            return combinedArrays;
        }
    }
    [Serializable]
    public class Game : ISerializable
    {
        public const bool HOMESCORINGCHANCE = true;
        public const bool AWAYSCORINGCHANCE = false;
        private Random rand = new Random();
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
        private PlayersOnIce _playersOnIce = new PlayersOnIce();
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
        private void ScoringChance()
        {
            //Gets players for each team for this scoring chance
            SetPlayers();
            bool scoringChanceSide = Faceoff();
            Skater[] skatersOnIce = GetSkatersOnIce(scoringChanceSide);
            Skater[] skatersForPlay = GetSkatersForPlay(skatersOnIce);
            //0 or 1
            int chosenDefenderNum = rand.Next(0, 2);
            Skater chosenDefender = GetChosenDefender(scoringChanceSide);
        }
        private void SetPlayers()
        {
            _playersOnIce.homeForwards = GetForwardLine(HomeTeam);
            _playersOnIce.awayForwards = GetForwardLine(AwayTeam);
            _playersOnIce.homeDefenders = GetDefensiveLine(HomeTeam);
            _playersOnIce.awayDefenders = GetDefensiveLine(AwayTeam);
        }
        private bool Faceoff()
        {
            //Gets both centers off line and has faceoff
            Skater homeCenter = _playersOnIce.homeForwards[1];
            Skater awayCenter = _playersOnIce.awayForwards[1];
            int homeFaceoff = homeCenter.SkaterAttributes.Faceoff;
            int awayFaceoff = awayCenter.SkaterAttributes.Faceoff;
            int sumFaceoff = homeFaceoff + awayFaceoff;
            int choice = rand.Next(1, sumFaceoff + 1);
            //If the random number is less than home, home wins faceoff and gets scoring chance
            if (choice <= homeFaceoff)
            {
                //Adds faceoff wins and loss to both centers
                homeCenter.Stats.FaceoffWins++;
                awayCenter.Stats.FaceoffLosses++;
                //Sets in game faceoff tracker
                this.homeFaceoffWins++;
                //Returns constant for home getting scoring chance
                return HOMESCORINGCHANCE;
            }
            //Else random number is larger, away team wins faceoff
            else
            {
                homeCenter.Stats.FaceoffLosses++;
                awayCenter.Stats.FaceoffWins++;
                this.awayFaceoffWins++;
                //Returns constant for away getting scoring chance
                return AWAYSCORINGCHANCE;
            }
        }
        private Skater[] GetSkatersOnIce(bool scoringChanceSide)
        {
            return _playersOnIce.GetAllPlayers(scoringChanceSide);
        }
        private Skater GetChosenDefender(bool scoringChanceSide)
        {
            int chosenDenderNum = rand.Next(0, 2);
            //If home is side defending
            if (scoringChanceSide == AWAYSCORINGCHANCE)
            {
                return _playersOnIce.homeDefenders[chosenDenderNum];
            }
            //If away is defending
            else
            {
                return _playersOnIce.awayDefenders[chosenDenderNum];
            }
        }
        private Skater[] GetSkatersForPlay(Skater[] skaters)
        {
            Skater[] playersForPlay = new Skater[3];
            //0-4 for all 5 indexes
            playersForPlay[0] = skaters[rand.Next(0, 5)];
            playersForPlay[1] = skaters[rand.Next(0, 5)];
            playersForPlay[2] = skaters[rand.Next(0, 5)];
            //If the first assist is the same player as the play taker, set to null
            if (playersForPlay[1] == playersForPlay[0])
            {
                playersForPlay[1] = null;
            }
            //If second assist is same as play taker or first assist, set to null
            if (playersForPlay[2] == playersForPlay[0] || playersForPlay[2] == playersForPlay[1])
            {
                playersForPlay[2] = null;
            }
            if (playersForPlay[1] == null && playersForPlay[2] != null)
            {
                playersForPlay[1] = playersForPlay[2];
                playersForPlay[2] = null;
            }
            return playersForPlay;
        }
        private Skater[] GetForwardLine(Team team)
        {
            int line = ChooseForwardLineNumber();
            return team.GetForwardLine(line);
        }
        private Skater[] GetDefensiveLine(Team team)
        {
            int line = ChooseDefenseLineNumber();
            return team.GetDefensiveLine(line);
        }
        private int ChooseForwardLineNumber()
        {
            //Chances that each line will be chosen to play a particular event
            //% out of 100 each line is played
            int[] lineChances = new int[] {
                35, //1st line
                30, //2nd line
                25, //3rd line
                10  //4th line
            };
            int choice = rand.Next(1, 101);
            int counter = 0;
            for (int i = 0; i <= 3; i++)
            {
                counter += lineChances[i];
                if (choice <= counter)
                {
                    return i + 1;
                }
            }
            Console.WriteLine("Error in Game.ChooseForwardLineNumber function: Does not return a line number in for loop.");
            return 4;
            
        }
        private int ChooseDefenseLineNumber()
        {
            //Chances that each line will be chosen to play a particular event
            //% out of 100 each line is played
            int[] lineChances = new int[] {
                42, //1st line
                35, //2nd line
                23 };
            int choice = rand.Next(1, 101);
            int counter = 0;
            for (int i = 0; i <= 2; i++)
            {
                counter += lineChances[i];
                if (choice <= counter)
                {
                    return i + 1;
                }
            }
            Console.WriteLine("Error in Game.ChooseDefenseLineNumber function: Does not return a line number in for loop.");
            return 4;

        }
        private int ChoosePlayerNumber()
        {
            int[] weights = new int[] { 25, 25, 25, 13, 12 };
            int choice = rand.Next(1, 101);
            int count = 0;
            for (int i = 0; i <= 4; i++)
            {
                count += weights[i];
                if (choice < count)
                {
                    return i;
                }
            }
            Console.WriteLine("Game.ChoosePrimaryPlayerNumber error, passed through for statement");
            return 0;
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
