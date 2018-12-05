using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Elite_Hockey_Manager.Classes.Game.GameEvent;

namespace Elite_Hockey_Manager.Classes.Game
{
    public enum ShotType { Wristshot, Slapshot, Backhand, Breakaway };
    public struct PlayersOnIce
    {
        public Skater[] homeForwards;
        public Skater[] awayForwards;
        public Skater[] homeDefenders;
        public Skater[] awayDefenders;
        public Goalie homeGoalie;
        public Goalie awayGoalie;
        //Home true, away false
        public Skater[] GetAllSkatersFromSide(bool side)
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
        public Skater[] GetAllSkatersFromBothSides()
        {
            return CombineArrays(GetAllSkatersFromSide(true), GetAllSkatersFromSide(false));
        }
        private Skater[] CombineArrays(Skater[] array1, Skater[] array2)
        {
            Skater[] combinedArrays = new Skater[array1.Length + array2.Length];
            Array.Copy(array1, combinedArrays, array1.Length);
            Array.Copy(array2, 0, combinedArrays, array1.Length, array2.Length);
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
        private int timeIntervals = 0;
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
            _playersOnIce.homeGoalie = homeTeam.GetGoalie();
            _playersOnIce.awayGoalie = awayTeam.GetGoalie();
        }
        public void PlayGame()
        {
            //Completes the entire game
        }
        private void ScoringChance()
        {
            //Gets players for each team for this scoring chance
            SetPlayers();
            SetTimeOnIceStats();
            bool scoringChanceSide = Faceoff();
            Skater[] skatersOnIce = GetSkatersOnIce(scoringChanceSide);
            Skater[] skatersForPlay = GetSkatersForPlay(skatersOnIce);
            //0 or 1
            Skater[] defenders = GetChosenDefenders(scoringChanceSide);
            bool shotOpportunity = GetShotTaken(skatersForPlay, defenders);
            if (shotOpportunity)
            {
                Goalie goalie;
                if (scoringChanceSide == HOMESCORINGCHANCE)
                {
                    goalie = _playersOnIce.awayGoalie;
                }
                else
                {
                    goalie = _playersOnIce.homeGoalie;
                }
                TakeShot(skatersForPlay, defenders, goalie, scoringChanceSide);
            }
        }
        private void SetTimeOnIceStats()
        {
            foreach (Skater skater in _playersOnIce.GetAllSkatersFromBothSides())
            {
                skater.Stats.TimeOnIce++;
            }
        }
        private void SetPlusMinusStats(bool scoringSide)
        {
            foreach (Skater skater in _playersOnIce.GetAllSkatersFromSide(scoringSide))
            {
                skater.Stats.PlusMinus++;
            }
            foreach (Skater skater in _playersOnIce.GetAllSkatersFromSide(!scoringSide))
            {
                skater.Stats.PlusMinus--;
            }
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
        private bool GetShotTaken(Skater[] offensiveSkaters, Skater[] defenders)
        {
            int offensiveSumTotal = 0;
            int defensiveSumTotal = 0;
            //Max of 200 per each player, 600 total max
            //Shot taken about 1/4 opportunites, 1/3 for better stats
            foreach (Skater skater in offensiveSkaters)
            {
                if (skater == null) {
                    offensiveSumTotal += 150;
                }
                //150 max
                offensiveSumTotal += (int)(skater.SkaterAttributes.Speed * 1.5);
                //100 max
                offensiveSumTotal += skater.SkaterAttributes.Awareness;
                //50 max
                offensiveSumTotal += (skater.SkaterAttributes.Checking / 2);
            }
            //2 defenders
            foreach (Skater defender in defenders)
            {
                //Max 100 for each
                defensiveSumTotal += defender.SkaterAttributes.Speed;
                defensiveSumTotal += defender.SkaterAttributes.Awareness;
                defensiveSumTotal += defender.SkaterAttributes.Checking;
            }
            //Max of forwards should be 900
            //Max of defenders is 600
            //600 x 4.5 = 2700
            //a 900/3600 chance gets a 1/4 shot opportunity in perfect circumstances
            defensiveSumTotal = (int)(defensiveSumTotal * 4.5);
            int choice = rand.Next(1, defensiveSumTotal + offensiveSumTotal + 1);
            //If the chosen random number is less than the offensive total, return true for shot taken
            return choice <= offensiveSumTotal ? true : false;
        }
        private void TakeShot(Skater[] offensiveSkaters, Skater[] defenders, Goalie goalie, bool scoringChanceSide)
        {
            int[] weights;
            //If shot taker is forward
            if (offensiveSkaters[0] is Forward)
            {
                //45% wristshot, 25% slapshot, 20% backhand, 10% breakaway
                weights = new int[] { 40, 25, 20, 10 };
            }
            //Else if defender
            else
            {
                //30% wristshot, 50% slapshot, 15% backhand, 5% breakawy
                weights = new int[] { 30, 50, 15, 5 };
            }
            ShotType shotType = GetShotType(weights);
            bool goalScored;
            switch (shotType)
            {
                case (ShotType.Wristshot):
                    goalScored = WristShot(offensiveSkaters[0], goalie);
                    break;
                case (ShotType.Slapshot):
                    goalScored = SlapShot(offensiveSkaters[0], goalie);
                    break;
                case (ShotType.Backhand):
                    goalScored = Backhand(offensiveSkaters[0], goalie);
                    break;
                case (ShotType.Breakaway):
                    goalScored = Breakaway(offensiveSkaters[0], goalie);
                    break;
                default:
                    goalScored = WristShot(offensiveSkaters[0], goalie);
                    break;
            }
            Side side = scoringChanceSide == HOMESCORINGCHANCE ? Side.Home : Side.Away;
            if (side == Side.Home)
            {
                homeShots++;
            }
            else
            {
                awayShots++;
            }
            _gameEvents.Add(new ShotEvent(offensiveSkaters[0], period, timeIntervals, side, shotType));
            goalie.Stats.ShotsFaced++;
            if (goalScored)
            {
                _gameEvents.Add(new GoalEvent(offensiveSkaters[0], period, timeIntervals, side, GoalType.EvenStrength, _playersOnIce, shotType, offensiveSkaters[1], offensiveSkaters[2]));
                SetPlusMinusStats(scoringChanceSide);
                goalie.Stats.GoalsAllowed++;
                if (side == Side.Home)
                {
                    homeGoals++;
                }
                else
                {
                    awayGoals++;
                }
            }
            
        }
        private bool WristShot(Skater shotTaker, Goalie goalie)
        {
            int sumOffense = (int)Math.Pow(shotTaker.SkaterAttributes.WristShot, 1.5);
            int sumGoalie = goalie.GoalieAttributes.High + goalie.GoalieAttributes.Low;
            sumGoalie *= 10;
            int choice = rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }
            return false;
        }
        private bool SlapShot(Skater shotTaker, Goalie goalie)
        {
            //Less likely to score slapshot than wristshot
            int sumOffense = (int)Math.Pow(shotTaker.SkaterAttributes.SlapShot, 1.3);
            int sumGoalie = goalie.GoalieAttributes.Low + goalie.GoalieAttributes.ReboundControl;
            sumGoalie *= 10;
            int choice = rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }
            return false;
        }
        private bool Backhand(Skater shotTaker, Goalie goalie)
        {
            int backhand = (shotTaker.SkaterAttributes.WristShot + shotTaker.SkaterAttributes.Deking) / 2;
            int sumOffense = (int)Math.Pow(backhand, 1.3);
            int sumGoalie = goalie.GoalieAttributes.High + goalie.GoalieAttributes.Speed;
            sumGoalie *= 10;
            int choice = rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }
            return false;
        }
        private bool Breakaway(Skater shotTaker, Goalie goalie)
        {
            int breakaway = shotTaker.SkaterAttributes.Deking + (shotTaker.SkaterAttributes.Speed / 10) + (shotTaker.SkaterAttributes.WristShot / 10);
            int sumOffense = (int)Math.Pow(breakaway, 1.5);
            int sumGoalie = goalie.GoalieAttributes.Speed + goalie.GoalieAttributes.Low;
            sumGoalie *= 10;
            int choice = rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }
            return false;
        }
        private ShotType GetShotType(int[] weights)
        {
            int choice = rand.Next(1, 101);
            int total = 0;
            for (int i = 0; i <= 3; i++)
            {
                total += weights[i];
                if (choice <= total)
                {
                    return (ShotType)i;
                }
            }
            return ShotType.Wristshot;
        }
        private Skater[] GetSkatersOnIce(bool scoringChanceSide)
        {
            return _playersOnIce.GetAllSkatersFromSide(scoringChanceSide);
        }
        private Skater[] GetChosenDefenders(bool scoringChanceSide)
        {
            if (scoringChanceSide == AWAYSCORINGCHANCE)
            {
                return _playersOnIce.homeDefenders;
            }
            //If away is defending
            else
            {
                return _playersOnIce.awayDefenders;
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
