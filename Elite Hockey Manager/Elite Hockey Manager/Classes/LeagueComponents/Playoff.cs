using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    [Serializable]
    public class Playoff : ISerializable
    {
        public int CurrentRound
        {
            get
            {
                return _currentRound;
            }
        }

        public int CurrentDay
        {
            get
            {
                return _currentDay;
            }
        }

        //Returns a shallow copy of the teams in the playoffs for the first conference
        public List<Team> FirstConferencePlayoffTeams
        {
            get
            {
                return new List<Team>(_firstConference);
            }
        }

        //Returns a shallow copy of the teams in the playoffs for the first conference
        public List<Team> SecondConferencePlayoffTeams
        {
            get
            {
                return new List<Team>(_secondConference);
            }
        }

        public bool FinishedSimming
        {
            get;
            private set;
        } = false;

        public Team Champion
        {
            get;
            private set;
        }

        public readonly PlayoffRounds PlayoffRounds;
        public readonly int PlayoffYear;
        public PlayoffSeries[][] playoffSeriesArray;

        //Holds the initial playoff participants
        private List<Team> _firstConference, _secondConference;

        //Tracks the remaining teams left in the playoffs
        private List<Team> firstConferenceRemainingTeams, secondConferenceRemainingTeams;

        private int _currentRound = 1;
        private int _currentDay = 1;
        private Random rand = new Random();

        public Playoff(PlayoffRounds rounds, int year, List<Team> first, List<Team> second)
        {
            PlayoffRounds = rounds;
            PlayoffYear = year;
            _firstConference = first.Take(PlayoffRounds.GetTotalPlayoffTeams() / 2).ToList();
            _secondConference = second.Take(PlayoffRounds.GetTotalPlayoffTeams() / 2).ToList();
            firstConferenceRemainingTeams = new List<Team>(_firstConference);
            secondConferenceRemainingTeams = new List<Team>(_secondConference);
            //Adds new TeamStats to each playoff team
            AddPlayoffStats();
            //Builds the playoffSeriesArray jagged array sizes
            DefinePlayoffSeriesArray();
            //Creates playoff matchups so highest ranked seeds go against lowest seeds and so on for both sides
            CreatePlayoffMatchups();
        }

        /// <summary>
        /// Gets the games from the current playoff round and day in the series
        /// </summary>
        /// <returns>Returns a list of all the games that are taking place at the current round and day</returns>
        public List<Game> GetCurrentPlayoffGames()
        {
            List<Game> daySchedule = new List<Game>();
            foreach (PlayoffSeries series in playoffSeriesArray[CurrentRound - 1])
            {
                if (series.GetGameByIndex(_currentDay - 1) != null)
                {
                    daySchedule.Add(series.GetGameByIndex(_currentDay - 1));
                }
            }
            return daySchedule;
        }

        public void SimPlayoffsDoWork(object sender, DoWorkEventArgs e)
        {
            //If the playoffs is already done being simmed then
            if (FinishedSimming)
            {
                return;
            }
            BackgroundWorker worker = (BackgroundWorker)sender;
            int gamesSimmedCount = 0;
            int argumentValue = (int)e.Argument;
            if (argumentValue == -1)
            {
                while (!FinishedSimming)
                {
                    gamesSimmedCount += SimDayOfPlayoffs();
                    worker.ReportProgress(gamesSimmedCount);
                }
            }
            //Else the argument value is the amount of games to be simmed, or to the end of the current round
            else
            {
                int startingRound = _currentRound;
                for (int i = 0; i < argumentValue; i++)
                {
                    //If advanced to the next round or the playoffs is finished simming, break out of for loop
                    if (_currentRound != startingRound || FinishedSimming)
                    {
                        break;
                    }
                    gamesSimmedCount += SimDayOfPlayoffs();
                    worker.ReportProgress(gamesSimmedCount);
                }
            }
        }

        public List<Player> GetAllPlayoffPlayers()
        {
            List<Player> playoffPlayers = new List<Player>();
            for (int i = 0; i < _firstConference.Count; i++)
            {
                playoffPlayers.AddRange(_firstConference[i].Roster);
                playoffPlayers.AddRange(_secondConference[i].Roster);
            }
            return playoffPlayers;
        }

        /// <summary>
        /// Can only be called after the playoffs are done being simmed
        /// Returns the playoff teams in order of where they finished in the playoffs
        /// Used to determine draft order
        /// </summary>
        /// <returns>An ascending ordered list of the playoff teams</returns>
        public Team[] DraftOrderedPlayoffTeams()
        {
            if (!FinishedSimming)
            {
                throw new ArgumentException("Playoffs are not done being simmed, draft order can not be generated");
            }
            Team[] orderedTeams = new Team[_firstConference.Count + _secondConference.Count];
            int counter = 0;
            foreach (PlayoffSeries[] round in playoffSeriesArray)
            {
                //If the round is the finals
                if (round.Count() == 1)
                {
                    //Loser gets 2nd to last place, winner gets last place in the array
                    orderedTeams[counter++] = round[0].Loser;
                    orderedTeams[counter] = round[0].Winner;
                    continue;
                }
                Team[] losingRoundTeams = new Team[round.Count()];
                for (int i = 0; i < round.Count(); i++)
                {
                    losingRoundTeams[i] = round[i].Loser;
                }
                //Sorts the losing teams by there regular season record
                Array.Sort(losingRoundTeams);
                Array.Copy(losingRoundTeams, 0, orderedTeams, counter, losingRoundTeams.Count());
                counter += losingRoundTeams.Count();
            }
            return orderedTeams;
        }

        private int SimDayOfPlayoffs()
        {
            bool isGamesOnCurrentDay = false;
            int currentDayIndex = _currentDay - 1;
            int gamesSimmedCount = 0;
            foreach (PlayoffSeries series in playoffSeriesArray[_currentRound - 1])
            {
                Game game = series.GetGameByIndex(currentDayIndex);
                if (game != null)
                {
                    isGamesOnCurrentDay = true;
                    if (!game.Finished)
                    {
                        game.PlayGame();
                        gamesSimmedCount++;
                    }
                }
            }
            //If all the series are done in less than 7 or the existing game 7s have been simmed
            if (!isGamesOnCurrentDay || currentDayIndex == 6)
            {
                AdvanceToNextRound();
            }
            else
            {
                _currentDay++;
            }
            return gamesSimmedCount;
        }

        private void AdvanceToNextRound()
        {
            if (_currentRound == (int)PlayoffRounds)
            {
                //The final series of the playoffs will always be of size 1 in the array
                PlayoffSeries finalSeries = playoffSeriesArray.Last()[0];
                FinishedSimming = true;
                Champion = finalSeries.Winner;
            }
            //If there are still more rounds to be played
            else
            {
                RemoveLosingTeamsFromRemainingTeamsLists();
                _currentRound++;
                _currentDay = 1;
                //Creates the next set of series given the updated CurrentRound and CurrentDay
                CreatePlayoffMatchups();
            }
        }

        private void RemoveLosingTeamsFromRemainingTeamsLists()
        {
            firstConferenceRemainingTeams.Clear();
            secondConferenceRemainingTeams.Clear();
            PlayoffSeries selectedSeries;
            int seriesLength = playoffSeriesArray[_currentRound - 1].Length;
            for (int i = 0; i < seriesLength; i++)
            {
                selectedSeries = playoffSeriesArray[_currentRound - 1][i];
                if (i < (seriesLength / 2))
                {
                    firstConferenceRemainingTeams.Add(selectedSeries.Winner);
                }
                else
                {
                    secondConferenceRemainingTeams.Add(selectedSeries.Winner);
                }
            }
        }

        /// <summary>
        /// Defines the size of a jagged array for both x andividual y sizes
        /// </summary>
        private void DefinePlayoffSeriesArray()
        {
            playoffSeriesArray = new PlayoffSeries[(int)PlayoffRounds][];
            for (int i = 0; i < playoffSeriesArray.Count(); i++)
            {
                playoffSeriesArray[i] = new PlayoffSeries[PlayoffRounds.GetTotalPlayoffTeams() / (int)Math.Pow(2, i + 1)];
            }
        }

        private void CreatePlayoffMatchups()
        {
            //If the finals round is being created
            if (_currentRound == (int)PlayoffRounds)
            {
                if (firstConferenceRemainingTeams.Count != 1 || secondConferenceRemainingTeams.Count != 1)
                {
                    throw new ArgumentException("Playoffs have reached the final round without a single team left from each side");
                }
                else
                {
                    Team finalFirstTeam = firstConferenceRemainingTeams[0];
                    int finalFirstTeamSeed = GetSeed(_firstConference, finalFirstTeam);
                    Team finalSecondTeam = secondConferenceRemainingTeams[0];
                    int finalSecondTeamSeed = GetSeed(_secondConference, finalSecondTeam);
                    //If the first conference team is high seeded than the second conference team, give first conference home ice advantage
                    if (finalFirstTeam.CompareTo(finalSecondTeam) > 0)
                    {
                        playoffSeriesArray[_currentRound - 1][0] =
                            new PlayoffSeries(finalFirstTeam, finalFirstTeamSeed, finalSecondTeam, finalSecondTeamSeed, _currentRound, rand);
                    }
                    //If second conference team is higher seeded, give second conference home ice
                    else
                    {
                        playoffSeriesArray[_currentRound - 1][0] =
                            new PlayoffSeries(finalSecondTeam, finalSecondTeamSeed, finalFirstTeam, finalFirstTeamSeed, _currentRound, rand);
                    }
                }
            }
            else
            {
                BuildPlayoffSeriesForConference(_firstConference, firstConferenceRemainingTeams, 0);
                //Starting index for the second conference will be the starting point of the second half of the array which is the count of one sides remaining teams
                BuildPlayoffSeriesForConference(_secondConference, secondConferenceRemainingTeams, secondConferenceRemainingTeams.Count / 2);
            }
        }

        /// <summary>
        /// Builds playoff series for a conference based on the number of teams remaining in the playoffs
        /// </summary>
        /// <param name="fullConference">Initial list of all teams from this conference in the playoffs, used to get seeds</param>
        /// <param name="remainingConferenceTeams">The remaining teams of this conference still in the playoffs, all picked out and put into playoff series objects</param>
        /// <param name="startingIndex">Index at which to start adding the playoff series to the playoffSeriesArray, first conference always starts at 0 and second conference takes up 2nd half of array. always an even size</param>
        private void BuildPlayoffSeriesForConference(List<Team> fullConference, List<Team> remainingConferenceTeams, int startingIndex)
        {
            League.SortTeamList(remainingConferenceTeams);
            for (int i = 0; i < remainingConferenceTeams.Count / 2; i++)
            {
                Team highTeam = remainingConferenceTeams[i];
                int highSeed = GetSeed(fullConference, highTeam);
                Team lowTeam = remainingConferenceTeams[remainingConferenceTeams.Count - 1 - i];
                int lowSeed = GetSeed(fullConference, lowTeam);
                playoffSeriesArray[_currentRound - 1][i + startingIndex] =
                    new PlayoffSeries(highTeam, highSeed, lowTeam, lowSeed, _currentRound, rand);
            }
        }

        /// <summary>
        /// Gets the seed of the playoff team based on their standings at the end of the regular season
        /// </summary>
        /// <param name="initialPlayoffTeamList">Sorted list of all the teams that qualified for the playoffs in this conference </param>
        /// <param name="selectedTeam">Team to search the initialPlayoffTeamList for exact seed entering playoffs</param>
        /// <returns>The seed number of the team for the playoffs</returns>
        private int GetSeed(List<Team> initialPlayoffTeamList, Team selectedTeam)
        {
            return initialPlayoffTeamList.FindIndex(team => team == selectedTeam) + 1;
        }

        /// <summary>
        /// Adds new playoff version of TeamStats object to seasonStats list in Team object
        /// </summary>
        private void AddPlayoffStats()
        {
            //Sizes of both lists will always be the same
            for (int i = 0; i < _firstConference.Count; i++)
            {
                //Adds a new TeamStats object to internal team list denoting this years playoffs
                _firstConference[i].AddPlayoffsStatsToTeamAndPlayers();
                _secondConference[i].AddPlayoffsStatsToTeamAndPlayers();
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        protected Playoff(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class PlayoffSeries : ISerializable
    {
        public int HighWins
        {
            get
            {
                return _highWins;
            }
        }

        public int LowWins
        {
            get
            {
                return _lowWins;
            }
        }

        /// <summary>
        /// Returns the winning team in the series, returns null if neither team has clinched the series victory
        /// </summary>
        public Team Winner
        {
            get
            {
                //If either team has reached 4 wins, they have won the series
                if (_highWins == 4)
                {
                    return HighSeedTeam;
                }
                else if (_lowWins == 4)
                {
                    return LowSeedTeam;
                }
                else
                {
                    return null;
                }
            }
        }

        //The losing team in the series, if series is unfinished returns null
        public Team Loser
        {
            get
            {
                if (!SeriesFinished)
                {
                    return null;
                }
                if (_highWins == 4)
                {
                    return LowSeedTeam;
                }
                else
                {
                    return HighSeedTeam;
                }
            }
        }

        /// <summary>
        /// Boolean that shows if the series is finished and a winner is determined
        /// </summary>
        public bool SeriesFinished
        {
            get
            {
                //If the winner is null then neither team has reached 4 wins and won
                return Winner != null;
            }
        }

        public readonly Team HighSeedTeam, LowSeedTeam;
        public readonly int HighSeed, LowSeed;
        public readonly int Round;

        private int _highWins = 0, _lowWins = 0;
        private Game[] seriesGames = new Game[7];
        private Random rand;

        ///////////
        ///////////
        ///////////
        ///////////
        ///////////

        public PlayoffSeries(Team highSeedTeam, int highSeed, Team lowSeedTeam, int lowSeed, int playoffRound, Random leagueRand)
        {
            HighSeedTeam = highSeedTeam;
            HighSeed = highSeed;
            LowSeedTeam = lowSeedTeam;
            LowSeed = lowSeed;
            Round = playoffRound;
            rand = leagueRand;
            //Creates the series matches
            CreateGamesSchedule();
        }

        /// <summary>
        /// Gets the game of the series based on the zero based day index
        /// </summary>
        /// <param name="dayIndex">Zero based game index</param>
        /// <returns></returns>
        public Game GetGameByIndex(int dayIndex)
        {
            return seriesGames[dayIndex];
        }

        /// <summary>
        /// Creates the 7 game series with the correct home ice being given to each side
        /// </summary>
        private void CreateGamesSchedule()
        {
            //Games 1,2 played with high seed home
            //games 3,4 low seed home
            //game 5 high seed, 6 low seed, final game 7 to high seed team home
            seriesGames[0] = new Game(HighSeedTeam, LowSeedTeam, rand, 1);
            seriesGames[1] = new Game(HighSeedTeam, LowSeedTeam, rand, 2);
            seriesGames[2] = new Game(LowSeedTeam, HighSeedTeam, rand, 3);
            seriesGames[3] = new Game(LowSeedTeam, HighSeedTeam, rand, 4);
            seriesGames[4] = new Game(HighSeedTeam, LowSeedTeam, rand, 5);
            seriesGames[5] = new Game(LowSeedTeam, HighSeedTeam, rand, 6);
            seriesGames[6] = new Game(HighSeedTeam, LowSeedTeam, rand, 7);
            SetGameFinishedEvents();
        }

        private void SetGameFinishedEvents()
        {
            for (int i = 0; i < 7; i++)
            {
                seriesGames[i].GameFinished += InputGameResults;
            }
        }

        /// <summary>
        /// Clears the remaining game in the series so the containing class knows there are no games to be played
        /// </summary>
        /// <param name="seriesFinishedGameIndex">Game index of game that ended the series 1-7</param>
        private void ClearRemainingGames(int seriesFinishedGameIndex)
        {
            //Index is offset by 1 to get to zero base but 1 is added because you dont want to turn the game you just finished null
            for (int i = seriesFinishedGameIndex - 1 + 1; i <= 6; i++)
            {
                seriesGames[i] = null;
            }
        }

        private void InputGameResults(object obj, EventArgs e)
        {
            Game game = (Game)obj;
            Team winningTeam;
            switch (game.Winner)
            {
                case (Side.Home):
                    winningTeam = game.HomeTeam;
                    break;

                case (Side.Away):
                    winningTeam = game.AwayTeam;
                    break;

                default:
                    throw new ArgumentException();
            }
            if (winningTeam == HighSeedTeam)
            {
                _highWins++;
            }
            else
            {
                _lowWins++;
            }
            //If the series is finished, make the rest of the games in the series null, if the series ended in 7, function call is unnecessary
            if (SeriesFinished && game.GameNumber != 7)
            {
                ClearRemainingGames(game.GameNumber);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        protected PlayoffSeries(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}