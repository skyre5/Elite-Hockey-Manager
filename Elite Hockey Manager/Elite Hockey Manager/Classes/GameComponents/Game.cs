namespace Elite_Hockey_Manager.Classes.GameComponents
{
    using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Elite_Hockey_Manager.Classes.Players;

    /// <summary>
    /// enum for the separate shot types, each shot type will be weighted on different attribute values
    /// </summary>
    public enum ShotType
    {
        /// <summary>
        /// Wrist shot weighted on wrist shot attribute
        /// </summary>
        WristShot,

        /// <summary>
        /// Slap shot weighted on slap shot attribute
        /// </summary>
        SlapShot,

        /// <summary>
        /// Backhand shot weighted on both wrist shot and deking attributes
        /// </summary>
        Backhand,

        /// <summary>
        /// The breakaway.
        /// </summary>
        Breakaway
    }

    /// <summary>
    /// The players on ice.
    /// </summary>
    public struct PlayersOnIce
    {
        #region Fields

        /// <summary>
        /// Holds defenders on away team who are on the ice
        /// </summary>
        public Skater[] AwayDefenders;

        /// <summary>
        /// Holds forwards on away team who are on the ice
        /// </summary>
        public Skater[] AwayForwards;

        /// <summary>
        /// Holds goalie on the away team who is on the ice
        /// </summary>
        public Goalie AwayGoalie;

        /// <summary>
        /// Holds defenders on home team who are on the ice
        /// </summary>
        public Skater[] HomeDefenders;

        /// <summary>
        /// Holds forwards on home team who are on the ice
        /// </summary>
        public Skater[] HomeForwards;

        /// <summary>
        /// Holds goalie on the home team who is on the ice
        /// </summary>
        public Goalie HomeGoalie;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Function that gets all the skaters on the ice from both teams
        /// </summary>
        /// <returns>Skater array made up of home and away skaters</returns>
        public Skater[] GetAllSkatersFromBothSides()
        {
            return this.CombineArrays(this.GetAllSkatersFromSide(true), this.GetAllSkatersFromSide(false));
        }

        /// <summary>
        /// Gets all the skaters on the ice from one of the teams
        /// </summary>
        /// <param name="side">
        /// True is Home
        /// False is away
        /// </param>
        /// <returns>Skater array of all the skaters on the home or away team</returns>
        public Skater[] GetAllSkatersFromSide(bool side)
        {
            if (side)
            {
                return this.CombineArrays(this.HomeForwards, this.HomeDefenders);
            }

            return this.CombineArrays(this.AwayForwards, this.AwayDefenders);
        }

        /// <summary>
        /// Combines two arrays of Skater type into one single array
        /// </summary>
        /// <param name="array1">First Skater array</param>
        /// <param name="array2">Second Skater array</param>
        /// <returns>Single skater array of the two combined input arrays</returns>
        private Skater[] CombineArrays(Skater[] array1, Skater[] array2)
        {
            Skater[] combinedArrays = new Skater[array1.Length + array2.Length];
            Array.Copy(array1, combinedArrays, array1.Length);
            Array.Copy(array2, 0, combinedArrays, array1.Length, array2.Length);
            return combinedArrays;
        }

        #endregion Methods
    }

    /// <summary>
    /// Game object that simulates and stores the information of a game between two teams
    /// </summary>
    [Serializable]
    public class Game
    {
        #region Fields

        /// <summary>
        /// Away scoring chances within the game are false
        /// </summary>
        private const bool AwayScoringChance = false;

        /// <summary>
        /// Home scoring chances within the game are true
        /// </summary>
        private const bool HomeScoringChance = true;

        /// <summary>
        /// Sets the max time for overtime to be at 20 time units
        /// </summary>
        private const int MaxTimeOvertime = 20;

        /// <summary>
        /// Sets the max time for regulation to be at 80 times units
        /// </summary>
        private const int MaxTimeRegulation = 80;

        /// <summary>
        /// Amount of face-off wins for the away team
        /// </summary>
        private int awayFaceoffWins;

        /// <summary>
        /// Away hits
        /// </summary>
        private int awayHits;

        /// <summary>
        /// List of Events that will summarize all events of the game
        /// </summary>
        private List<Event> gameEvents = new List<Event>();

        /// <summary>
        /// Amount of home faceoff wins
        /// </summary>
        private int homeFaceoffWins;

        // Hits are not implemented yet
        /// <summary>
        /// Home hits
        /// </summary>
        private int homeHits;

        /// <summary>
        /// Period of the game
        /// 1-3 Periods played 20 minutes
        /// 4+ Overtime periods 20 minutes unless regular season in which 5 minute single overtime then shootout
        /// </summary>
        private int period = 1;

        /// <summary>
        /// Players on the ice for a certain play, holds each teams skaters and goalie
        /// </summary>
        private PlayersOnIce playersOnIce;

        /// <summary>
        /// Random object passed to class in constructor to avoid similar game results when simulating multiple games
        /// </summary>
        private Random rand;

        /// <summary>
        /// Boolean to keep track of whether the starting goalies have been chosen
        /// Starting goalies are chosen at the time of running the game, not when the constructor is ran and the object is created
        /// </summary>
        private bool startingGoaliesChosen;

        /// <summary>
        /// Current time interval, each time interval represents 15 seconds
        /// </summary>
        private int timeIntervals;

        /// <summary>
        /// Holds the winner of the game, useful for looking at previously played games from outside this class
        /// </summary>
        private Side winner;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// Public constructor for Game class in a dormant, yet to be played state
        /// </summary>
        /// <param name="homeTeam">
        /// Home team object of game to be played
        /// </param>
        /// <param name="awayTeam">
        /// Away team object of game to be played
        /// </param>
        /// <param name="random">
        /// The random.
        /// </param>
        /// <param name="game">
        /// Game number within the season or playoff series game #
        /// </param>
        public Game(Team homeTeam, Team awayTeam, Random random, int game = 1)
        {
            // Ensures both teams have valid forward, defense, and goalie lines
            homeTeam.ValidateLines();
            awayTeam.ValidateLines();

            // Sets team to properties
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.GameNumber = game;

            this.rand = random;
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// EventHandler for when a game is concluded simulating
        /// </summary>
        public event EventHandler GameFinished;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets the away faceoff wins
        /// </summary>
        public int AwayFaceoffWins => this.awayFaceoffWins;

        /// <summary>
        /// Gets the away powerplay goals
        /// </summary>
        public int AwayPowerplayGoals
        {
            get;
            private set;
        }
            = 0;

        /// <summary>
        /// Gets the away powerplay chances
        /// </summary>
        public int AwayPowerplays
        {
            get;
            private set;
        }
            = 0;

        /// <summary>
        /// Gets the away score.
        /// </summary>
        public int AwayScore
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the away shots.
        /// </summary>
        public int AwayShots => this.AwayShotsArray.Sum();

        /// <summary>
        /// Gets array of shots that the away team took in each period and overtime
        /// </summary>
        public int[] AwayShotsArray
        {
            get;
            private set;
        }
        = { 0, 0, 0, 0 };

        /// <summary>
        /// Gets or sets the away team.
        /// </summary>
        public Team AwayTeam
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets a value indicating whether finished.
        /// </summary>
        public bool Finished
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the game events.
        /// </summary>
        public List<Event> GameEvents => this.gameEvents;

        /// <summary>
        /// Gets or sets the game number.
        /// </summary>
        public int GameNumber
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the amount of home faceoff wins
        /// </summary>
        public int HomeFaceoffWins => this.homeFaceoffWins;

        /// <summary>
        /// Gets the amount of home powerplay goals
        /// </summary>
        public int HomePowerplayGoals
        {
            get;
            private set;
        }
        = 0;

        /// <summary>
        /// Gets the amount of home powerplay opportunities
        /// </summary>
        public int HomePowerplays
        {
            get;
            private set;
        }
        = 0;

        /// <summary>
        /// Gets the home score.
        /// </summary>
        public int HomeScore
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount of home shots
        /// </summary>
        public int HomeShots => this.HomeShotsArray.Sum();

        /// <summary>
        /// Gets the amount of home shots in the three periods or overtime
        /// </summary>
        public int[] HomeShotsArray
        {
            get;
            private set;
        }
            = { 0, 0, 0, 0 };

        /// <summary>
        /// Gets or sets the home team.
        /// </summary>
        public Team HomeTeam
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets a value indicating whether it is overtime
        /// </summary>
        public bool Overtime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the period that the game is currently in
        /// </summary>
        public int Period => this.period;

        /// <summary>
        /// Gets the players on the ice currently in a PlayersOnIce struct
        /// </summary>
        public PlayersOnIce PlayersOnIce => this.playersOnIce;

        /// <summary>
        /// Gets the current time interval. Each interval is 15 seconds
        /// </summary>
        public int TimeInterval => this.timeIntervals;

        /// <summary>
        /// Gets the title of the game which has the away team's name @ the home team's name
        /// </summary>
        public string Title => $@"{AwayTeam.TeamName} @ {HomeTeam.TeamName}";

        /// <summary>
        /// Gets the winner of the game
        /// </summary>
        public Side Winner => this.winner;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Increments the game by an interval of time or a certain amount of intervals
        /// </summary>
        /// <param name="intervals">Amount of intervals to advance the game</param>
        public void IncrementTime(int intervals = 1)
        {
            // If the game is finished the function has no need to run and returns
            if (this.Finished)
            {
                Console.WriteLine(@"Game is already finished");
                return;
            }

            if (intervals < 1)
            {
                return;
            }

            for (int i = 0; i < intervals; i++)
            {
                // If end of 1st or 2nd period is reached
                if (this.period < 3 && this.timeIntervals == MaxTimeRegulation)
                {
                    this.period++;
                    this.timeIntervals = 0;
                    break;
                }

                // If end of 3rd period is reached
                if (this.period == 3 && this.timeIntervals == MaxTimeRegulation)
                {
                    if (this.HomeScore != this.AwayScore)
                    {
                        this.Finished = true;
                        this.winner = this.HomeScore > this.AwayScore ? Side.Home : Side.Away;
                        this.InputStats();
                        return;
                    }

                    this.period++;
                    break;
                }

                // If its overtime and a team has scored
                if (this.period == 4 && this.HomeScore != this.AwayScore)
                {
                    this.Overtime = true;
                    this.Finished = true;
                    this.winner = this.HomeScore > this.AwayScore ? Side.Home : Side.Away;
                    this.InputStats();
                    return;
                }

                // If it has reached the end of overtime
                if (this.period == 4 && this.timeIntervals == MaxTimeOvertime)
                {
                    this.Overtime = true;
                    this.Finished = true;
                    this.InputStats();
                    this.winner = (Side)this.rand.Next(0, 2);
                    if (this.winner == Side.Home)
                    {
                        this.HomeScore++;
                    }
                    else
                    {
                        this.AwayScore++;
                    }

                    return;
                }

                this.ScoringChance();
            }
        }

        /// <summary>
        /// Plays the entire game from the point the game state was until it is completed
        /// </summary>
        public void PlayGame()
        {
            this.SetStartingGoalies();
            if (this.Finished)
            {
                Console.WriteLine(@"Game is already finished");
                return;
            }

            // 1st period - 3rd period -always played
            while (this.Period <= 4 && !this.Finished)
            {
                this.PlayPeriod();
            }
        }

        /// <summary>
        /// Simulates 1 period of the game. if a period was already in progress finishes current period only
        /// </summary>
        public void PlayPeriod()
        {
            if (this.Finished)
            {
                Console.WriteLine(@"Game is already finished");
                return;
            }

            if (this.period <= 3)
            {
                while (this.timeIntervals < MaxTimeRegulation)
                {
                    this.ScoringChance();
                }

                if (this.period < 3)
                {
                    this.period++;
                    this.timeIntervals = 0;
                }
                else if (this.period == 3)
                {
                    if (this.HomeScore != this.AwayScore)
                    {
                        this.Finished = true;
                        this.winner = this.HomeScore > this.AwayScore ? Side.Home : Side.Away;
                        this.InputStats();
                    }
                    else
                    {
                        this.period++;
                        this.timeIntervals = 0;
                        return;
                    }
                }
            }

            if (this.period == 4)
            {
                this.Overtime = true;
                while (this.timeIntervals <= MaxTimeOvertime && this.HomeScore == this.AwayScore)
                {
                    this.ScoringChance();
                }

                if (this.timeIntervals >= MaxTimeOvertime)
                {
                    this.Finished = true;
                    this.winner = (Side)this.rand.Next(0, 2);
                    if (this.winner == Side.Home)
                    {
                        this.HomeScore++;
                    }
                    else
                    {
                        this.AwayScore++;
                    }

                    this.InputStats();
                }
                else if (this.HomeScore != this.AwayScore)
                {
                    this.Finished = true;
                    this.winner = this.HomeScore > this.AwayScore ? Side.Home : Side.Away;
                    this.InputStats();
                }
            }
        }

        /// <summary>
        /// Function that gets the two starting goalies for each team
        /// Called at the start of the simulating for each game
        /// </summary>
        public void SetStartingGoalies()
        {
            if (!this.startingGoaliesChosen)
            {
                this.playersOnIce.HomeGoalie = this.HomeTeam.GetGamesStartingGoalie();
                this.playersOnIce.AwayGoalie = this.AwayTeam.GetGamesStartingGoalie();
                this.startingGoaliesChosen = true;
            }
        }

        /// <summary>
        /// Simulates a backhand scoring opportunity
        /// Weighted off the skaters wrist shot and deking against the goalies high and speed attributes
        /// </summary>
        /// <param name="shotTaker">Skater that is taking the shot</param>
        /// <param name="goalie">Goalie that is facing the shot</param>
        /// <returns>Whether the shot opportunity scored a goal</returns>
        private bool Backhand(Skater shotTaker, Goalie goalie)
        {
            int backhand = (shotTaker.SkaterAttributes.WristShot + shotTaker.SkaterAttributes.Deking) / 2;
            int sumOffense = (int)Math.Pow(backhand, 1.3);
            int sumGoalie = goalie.GoalieAttributes.High + goalie.GoalieAttributes.Speed;
            sumGoalie *= 10;
            int choice = this.rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Simulates a breakaway scoring opportunity
        /// Weighted off the skaters deking speed and wrist shot against the goalies speed and low attribute
        /// </summary>
        /// <param name="shotTaker">Skater taking the shot</param>
        /// <param name="goalie">Goalie facing the shot</param>
        /// <returns>Whether the scoring opportunity scored a goal</returns>
        private bool Breakaway(Skater shotTaker, Goalie goalie)
        {
            int breakaway = shotTaker.SkaterAttributes.Deking + (shotTaker.SkaterAttributes.Speed / 10) + (shotTaker.SkaterAttributes.WristShot / 10);
            int sumOffense = (int)Math.Pow(breakaway, 1.5);
            int sumGoalie = goalie.GoalieAttributes.Speed + goalie.GoalieAttributes.Low;
            sumGoalie *= 10;
            int choice = this.rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Chooses the line that will be taking a certain play
        /// Weighted to favor the higher lines more (Higher means lower number)
        /// </summary>
        /// <returns>
        /// Returns the line that will be chosen 1-3
        /// </returns>
        private int ChooseDefenseLineNumber()
        {
            // Chances that each line will be chosen to play a particular event
            // % out of 100 each line is played
            int[] lineChances = { 42, 35, 23 };
            int choice = this.rand.Next(1, 101);
            int counter = 0;
            for (int i = 0; i <= 2; i++)
            {
                counter += lineChances[i];
                if (choice <= counter)
                {
                    return i + 1;
                }
            }

            Console.WriteLine(@"Error in Game.ChooseDefenseLineNumber function: Does not return a line number in for loop.");
            return 4;
        }

        /// <summary>
        /// Chooses one of the four forward lines
        /// Weighted towards higher lines
        /// </summary>
        /// <returns>The forward line chosen 1-4</returns>
        private int ChooseForwardLineNumber()
        {
            // Chances that each line will be chosen to play a particular event
            // % out of 100 each line is played
            int[] lineChances = { 35, 30, 25, 10 };
            int choice = this.rand.Next(1, 101);
            int counter = 0;
            for (int i = 0; i <= 3; i++)
            {
                counter += lineChances[i];
                if (choice <= counter)
                {
                    return i + 1;
                }
            }

            Console.WriteLine(@"Error in Game.ChooseForwardLineNumber function: Does not return a line number in for loop.");
            return 4;
        }

        /// <summary>
        /// Chooses a player on the ice that will be given a opportunity
        /// Weighted towards forwards
        /// </summary>
        /// <returns>Returns skater chosen 0-4</returns>
        private int ChooseSkaterOnIce()
        {
            int[] weights = { 25, 25, 25, 13, 12 };
            int choice = this.rand.Next(1, 101);
            int count = 0;
            for (int i = 0; i <= 4; i++)
            {
                count += weights[i];
                if (choice < count)
                {
                    return i;
                }
            }

            Console.WriteLine(@"Game.ChoosePrimaryPlayerNumber error, passed through for statement");
            return 0;
        }

        /// <summary>
        /// Decides who wins a faceoff based on centers on the ice
        /// </summary>
        /// <returns>Winner of faceoff. Home - True, Away - False</returns>
        private bool Faceoff()
        {
            // Gets both centers off line and has faceoff
            Skater homeCenter = this.playersOnIce.HomeForwards[1];
            Skater awayCenter = this.playersOnIce.AwayForwards[1];
            int homeFaceoff = homeCenter.SkaterAttributes.Faceoff;
            int awayFaceoff = awayCenter.SkaterAttributes.Faceoff;
            int sumFaceoff = homeFaceoff + awayFaceoff;
            int choice = this.rand.Next(1, sumFaceoff + 1);

            // If the random number is less than home, home wins faceoff and gets scoring chance
            if (choice <= homeFaceoff)
            {
                // Player stat entry
                // Adds faceoff wins and loss to both centers
                homeCenter.Stats.FaceoffWins++;
                awayCenter.Stats.FaceoffLosses++;

                // Sets in game faceoff tracker
                this.homeFaceoffWins++;

                // Returns constant for home getting scoring chance
                return HomeScoringChance;
            }

            // Else random number is larger, away team wins faceoff

            // Player stat entry
            homeCenter.Stats.FaceoffLosses++;
            awayCenter.Stats.FaceoffWins++;
            this.awayFaceoffWins++;

            // Returns constant for away getting scoring chance
            return AwayScoringChance;
        }

        /// <summary>
        /// Gets defenders from either team based on the side that the current chance is taking place for
        /// </summary>
        /// <param name="scoringChanceSide">True for home, false for away</param>
        /// <returns>Skater array of the defenders involved in play</returns>
        private Skater[] GetChosenDefenders(bool scoringChanceSide)
        {
            if (scoringChanceSide == AwayScoringChance)
            {
                return this.playersOnIce.HomeDefenders;
            }

            // If away is defending
            return this.playersOnIce.AwayDefenders;
        }

        /// <summary>
        /// Determines whether the offensive team gets a shot opportunity on a single play
        /// Weighted off the skaters of the offensive team and the skaters on the defensive team
        /// </summary>
        /// <param name="offensiveSkaters">Offensive skaters trying to get a shot</param>
        /// <param name="defenders">Defensive players trying to stop a shot</param>
        /// <returns>Whether a shot is taken and gets to the goalie</returns>
        private bool GetShotTaken(Skater[] offensiveSkaters, Skater[] defenders)
        {
            int offensiveSumTotal = 0;
            int defensiveSumTotal = 0;

            // Max of 200 per each player, 600 total max
            // Shot taken about 1/4 opportunities, 1/3 for better stats
            foreach (Skater skater in offensiveSkaters)
            {
                if (skater == null)
                {
                    offensiveSumTotal += 150;
                }
                else
                {
                    // 150 max
                    offensiveSumTotal += (int)(skater.SkaterAttributes.Speed * 1.5);

                    // 100 max
                    offensiveSumTotal += skater.SkaterAttributes.Awareness;

                    // 50 max
                    offensiveSumTotal += skater.SkaterAttributes.Checking / 2;
                }
            }

            // 2 defenders
            foreach (Skater defender in defenders)
            {
                // Max 100 for each
                defensiveSumTotal += defender.SkaterAttributes.Speed;
                defensiveSumTotal += defender.SkaterAttributes.Awareness;
                defensiveSumTotal += defender.SkaterAttributes.Checking;
            }

            // Max of forwards should be 900
            // Max of defenders is 600
            // 600 x 4.5 = 2700
            // a 900/3600 chance gets a 1/4 shot opportunity in perfect circumstances
            defensiveSumTotal = (int)(defensiveSumTotal * 4.5);
            int choice = this.rand.Next(1, defensiveSumTotal + offensiveSumTotal + 1);

            // If the chosen random number is less than the offensive total, return true for shot taken
            return choice <= offensiveSumTotal;
        }

        /// <summary>
        /// TODO Design better function it isn't given a blind amount of weights and is expected to know how data is presented
        /// Gets the type of shot that is taken if a scoring opportunity is taken
        /// </summary>
        /// <param name="weights">Weights for each shot type ordered by their enum definition</param>
        /// <returns>Type of shot taken</returns>
        private ShotType GetShotType(int[] weights)
        {
            if (weights.Length > 4)
            {
                Console.WriteLine(@"Game.GetShotType was passed to with more than 4 weights, should only pass 4");
            }

            int choice = this.rand.Next(1, 101);
            int total = 0;
            for (int i = 0; i <= 3; i++)
            {
                total += weights[i];
                if (choice <= total)
                {
                    return (ShotType)i;
                }
            }

            return ShotType.WristShot;
        }

        /// <summary>
        /// Chooses 1-3 players on a team to take part in a scoring chance
        /// </summary>
        /// <param name="skaters">Offensive players for the team with a scoring chance</param>
        /// <returns>Skater list of players that will take an offensive chance</returns>
        private Skater[] GetSkatersForPlay(Skater[] skaters)
        {
            Skater[] playersForPlay = new Skater[3];

            // 0-4 for all 5 indexes
            playersForPlay[0] = skaters[this.rand.Next(0, 5)];
            playersForPlay[1] = skaters[this.rand.Next(0, 5)];
            playersForPlay[2] = skaters[this.rand.Next(0, 5)];

            // If the first assist is the same player as the play taker, set to null
            if (playersForPlay[1] == playersForPlay[0])
            {
                playersForPlay[1] = null;
            }

            // If second assist is same as play taker or first assist, set to null
            if (playersForPlay[2] == playersForPlay[0] || playersForPlay[2] == playersForPlay[1])
            {
                playersForPlay[2] = null;
            }

            // If the first assist position is null and there is a player in the second position,
            // Places the player in the first assist position and removes them from the 2nd
            if (playersForPlay[1] == null && playersForPlay[2] != null)
            {
                playersForPlay[1] = playersForPlay[2];
                playersForPlay[2] = null;
            }

            return playersForPlay;
        }

        /// <summary>
        /// Gets the players on teams defensive line based on weighting for each of the 3 lines
        /// </summary>
        /// <param name="team">The team that the defenders belong to</param>
        /// <returns>Defenders on that line</returns>
        private Skater[] GetWeightedDefensiveLine(Team team)
        {
            int line = this.ChooseDefenseLineNumber();
            return team.GetDefensiveLine(line);
        }

        /// <summary>
        /// Gets the players on teams forward line based on weighting for each of the 4 lines
        /// </summary>
        /// <param name="team">The team that the forwards belong to</param>
        /// <returns>Forwards on that line</returns>
        private Skater[] GetWeightedForwardLine(Team team)
        {
            int line = this.ChooseForwardLineNumber();
            return team.GetForwardLine(line);
        }

        /// <summary>
        /// Function called at end of game to add a game played to forwards, defenders, and starting goalie
        /// </summary>
        [SuppressMessage("ReSharper", "CoVariantArrayConversion", Justification = "CoVariance in this case is with data that will never cause Conversion errors")]
        private void InputGamesPlayedStats()
        {
            // Helper function that takes a 2d player array and adds games played for each player
            void AddGamesPlayToSkatersArray(Skater[,] players)
            {
                for (int x = 0; x < players.GetLength(0); x++)
                {
                    for (int y = 0; y < players.GetLength(1); y++)
                    {
                        players[x, y].Stats.GamesPlayed++;
                    }
                }
            }

            // Player stat entry
            AddGamesPlayToSkatersArray(this.HomeTeam.Forwards);
            AddGamesPlayToSkatersArray(this.AwayTeam.Forwards);

            AddGamesPlayToSkatersArray(this.HomeTeam.Defenders);
            AddGamesPlayToSkatersArray(this.AwayTeam.Defenders);

            // Adds games started to both starting goalies
            this.playersOnIce.HomeGoalie.Stats.AddGameStarted();
            this.playersOnIce.AwayGoalie.Stats.AddGameStarted();
        }

        /// <summary>
        /// Inputs all the stats for the game when it is finished
        /// </summary>
        private void InputStats()
        {
            // If any events are tied to game finishing, passes the current game object to that event
            this.GameFinished?.Invoke(this, null);

            this.InputGamesPlayedStats();

            // Inputs all the stats from the game into the season wide TeamStats within Team class
            this.HomeTeam.CurrentSeasonStats.InsertGameStats(this, Side.Home);
            this.AwayTeam.CurrentSeasonStats.InsertGameStats(this, Side.Away);
            if (this.Winner == Side.Home)
            {
                // If the losing team scored no goals, winning goal is given a shutout
                if (this.AwayScore == 0)
                {
                    this.playersOnIce.HomeGoalie.Stats.Shutouts++;

                    // Starting goalie gains a fatigue of 2 if they get a shutout
                    this.playersOnIce.HomeGoalie.Attributes.Fatigue += 2;
                }

                // Winning goaltender
                // When home wins, home goalie given win and away goalie given loss
                this.playersOnIce.HomeGoalie.Stats.Wins++;

                // Winning goalie gains a fatigue of 3 for winning a game
                this.playersOnIce.HomeGoalie.Attributes.Fatigue += 3;

                // Losing goaltender
                this.playersOnIce.AwayGoalie.Stats.Losses++;

                // Losing goalie gains 5 fatigue for losing
                this.playersOnIce.AwayGoalie.Attributes.Fatigue += 5;
            }
            else
            {
                // If away team gets a shoutout
                if (this.HomeScore == 0)
                {
                    this.playersOnIce.AwayGoalie.Stats.Shutouts++;
                    this.playersOnIce.AwayGoalie.Attributes.Fatigue += 2;
                }

                // Winning goaltender
                this.playersOnIce.AwayGoalie.Stats.Wins++;
                this.playersOnIce.AwayGoalie.Attributes.Fatigue += 3;

                // Losing Goaltender
                this.playersOnIce.HomeGoalie.Stats.Losses++;
                this.playersOnIce.HomeGoalie.Attributes.Fatigue += 5;
            }
        }

        /// <summary>
        /// Game event simulation that takes place during one individual time increment
        /// </summary>
        private void ScoringChance()
        {
            this.timeIntervals++;

            // Gets players for each team for this scoring chance
            this.SetPlayersForScoringChance();
            this.SetTimeOnIceStats();
            bool scoringChanceSide = this.Faceoff();
            Skater[] skatersOnIce = this.playersOnIce.GetAllSkatersFromSide(scoringChanceSide);
            Skater[] skatersForPlay = this.GetSkatersForPlay(skatersOnIce);

            // 0 or 1
            Skater[] defenders = this.GetChosenDefenders(scoringChanceSide);
            bool shotOpportunity = this.GetShotTaken(skatersForPlay, defenders);
            if (shotOpportunity)
            {
                Goalie goalie;
                goalie = scoringChanceSide == HomeScoringChance ? this.playersOnIce.AwayGoalie : this.playersOnIce.HomeGoalie;

                this.TakeShot(skatersForPlay, goalie, scoringChanceSide);
            }
        }

        /// <summary>
        /// Sets the players into the playersOnIce object based on a weighted random chance towards the higher lines
        /// </summary>
        private void SetPlayersForScoringChance()
        {
            this.playersOnIce.HomeForwards = this.GetWeightedForwardLine(this.HomeTeam);
            this.playersOnIce.AwayForwards = this.GetWeightedForwardLine(this.AwayTeam);
            this.playersOnIce.HomeDefenders = this.GetWeightedDefensiveLine(this.HomeTeam);
            this.playersOnIce.AwayDefenders = this.GetWeightedDefensiveLine(this.AwayTeam);
        }

        /// <summary>
        /// Sets the plus minus of all skaters on the ice when a goal is scored
        /// Scoring team gets a +, conceding team gets a -
        /// </summary>
        /// <param name="scoringSide">True is home, False is away</param>
        private void SetPlusMinusStats(bool scoringSide)
        {
            foreach (Skater skater in this.playersOnIce.GetAllSkatersFromSide(scoringSide))
            {
                // Player stat entry
                skater.Stats.PlusMinus++;
            }

            foreach (Skater skater in this.playersOnIce.GetAllSkatersFromSide(!scoringSide))
            {
                // Player stat entry
                skater.Stats.PlusMinus--;
            }
        }

        /// <summary>
        /// Adds a time increment to player stats every time they are on the ice for a scoring chance
        /// </summary>
        private void SetTimeOnIceStats()
        {
            foreach (Skater skater in this.playersOnIce.GetAllSkatersFromBothSides())
            {
                // Player stat entry
                skater.Stats.TimeOnIce++;
            }
        }

        /// <summary>
        /// Simulates a slapshot scoring opportunity
        /// Weighted off the skaters slapshot attribute and goalies low and rebound control attributes
        /// </summary>
        /// <param name="shotTaker">Skater taking the shot</param>
        /// <param name="goalie">Goalie facing the shot</param>
        /// <returns>Whether the scoring opportunity scored a goal</returns>
        private bool SlapShot(Skater shotTaker, Goalie goalie)
        {
            // Less likely to score slapshot than wristshot
            int sumOffense = (int)Math.Pow(shotTaker.SkaterAttributes.SlapShot, 1.3);
            int sumGoalie = goalie.GoalieAttributes.Low + goalie.GoalieAttributes.ReboundControl;
            sumGoalie *= 10;
            int choice = this.rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Takes a shot from one of the players on the team for the offensive team of this play
        /// Results in either a goal or a save based on the goalies stats and the stats of the player and his potential assisting players
        /// </summary>
        /// <param name="offensiveSkaters">Offensive players</param>
        /// <param name="goalie">Goalie for the defending team</param>
        /// <param name="scoringChanceSide">True home</param>
        private void TakeShot(Skater[] offensiveSkaters, Goalie goalie, bool scoringChanceSide)
        {
            // If Shot taker is a forward, else a defender
            // Weights are on WristShot, SlapShot, BackHand, Breakaway
            int[] weights = offensiveSkaters[0] is Forward ? new[] { 40, 25, 20, 10 } : new[] { 30, 50, 15, 5 };

            ShotType shotType = this.GetShotType(weights);
            bool goalScored;
            switch (shotType)
            {
                case ShotType.WristShot:
                    goalScored = this.WristShot(offensiveSkaters[0], goalie);
                    break;

                case ShotType.SlapShot:
                    goalScored = this.SlapShot(offensiveSkaters[0], goalie);
                    break;

                case ShotType.Backhand:
                    goalScored = this.Backhand(offensiveSkaters[0], goalie);
                    break;

                case ShotType.Breakaway:
                    goalScored = this.Breakaway(offensiveSkaters[0], goalie);
                    break;

                default:
                    goalScored = this.WristShot(offensiveSkaters[0], goalie);
                    break;
            }

            Side side = scoringChanceSide == HomeScoringChance ? Side.Home : Side.Away;
            if (side == Side.Home)
            {
                this.HomeShotsArray[this.period - 1]++;
            }
            else
            {
                this.AwayShotsArray[this.period - 1]++;
            }

            this.gameEvents.Add(new ShotEvent(offensiveSkaters[0], this.period, this.timeIntervals, side, shotType));

            // Player stat entry
            offensiveSkaters[0].Stats.Shots++;
            goalie.Stats.ShotsFaced++;

            if (goalScored)
            {
                this.gameEvents.Add(
                    new GoalEvent(
                        offensiveSkaters[0],
                        this.period,
                        this.timeIntervals,
                        side,
                        GoalType.EvenStrength,
                        shotType,
                        offensiveSkaters[1],
                        offensiveSkaters[2]));
                this.SetPlusMinusStats(scoringChanceSide);

                // Player stat Entry
                goalie.Stats.GoalsAllowed++;
                offensiveSkaters[0].Stats.Goals++;

                // If there were assisting players on the play
                if (offensiveSkaters[1] != null)
                {
                    offensiveSkaters[1].Stats.Assists++;
                }

                if (offensiveSkaters[2] != null)
                {
                    offensiveSkaters[2].Stats.Assists++;
                }

                if (side == Side.Home)
                {
                    this.HomeScore++;
                }
                else
                {
                    this.AwayScore++;
                }
            }
        }

        /// <summary>
        /// Simulates a wrist shot scoring opportunity
        /// Weighted off the skaters slapshot attribute and goalies low and rebound control attributes
        /// </summary>
        /// <param name="shotTaker">Skater taking the shot</param>
        /// <param name="goalie">Goalie facing the shot</param>
        /// <returns>Whether the scoring opportunity scored a goal</returns>
        private bool WristShot(Skater shotTaker, Goalie goalie)
        {
            int sumOffense = (int)Math.Pow(shotTaker.SkaterAttributes.WristShot, 1.5);
            int sumGoalie = goalie.GoalieAttributes.High + goalie.GoalieAttributes.Low;
            sumGoalie *= 10;
            int choice = this.rand.Next(1, sumOffense + sumGoalie + 1);
            if (choice <= sumOffense)
            {
                return true;
            }

            return false;
        }

        #endregion Methods
    }
}