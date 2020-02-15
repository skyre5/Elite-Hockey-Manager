﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays;
using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Classes.GameComponents.GameEvent;


namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    [Serializable]
    public class Playoff : ISerializable
    {
        public readonly PlayoffRounds PlayoffRounds;
        public readonly int PlayoffYear;
        //Holds the initial playoff participants 
        private List<Team> firstConference, secondConference;
        //Tracks the remaining teams left in the playoffs
        private List<Team> firstConferenceRemainingTeams, secondConferenceRemainingTeams;
        private PlayoffSeries[][] playoffSeriesArray;
        private int _currentRound = 1;
        Random rand = new Random();
        public Playoff(PlayoffRounds rounds, int year, List<Team> first, List<Team> second)
        {
            PlayoffRounds = rounds;
            PlayoffYear = year;
            firstConference = first.Take(PlayoffRounds.GetTotalPlayoffTeams() / 2).ToList();
            secondConference = second.Take(PlayoffRounds.GetTotalPlayoffTeams() / 2).ToList();
            firstConferenceRemainingTeams = new List<Team>(firstConference);
            secondConferenceRemainingTeams = new List<Team>(secondConference);
            DefinePlayoffSeriesArray();

        }
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
                    int finalFirstTeamSeed = GetSeed(firstConference, finalFirstTeam);
                    Team finalSecondTeam = secondConferenceRemainingTeams[0];
                    int finalSecondTeamSeed = GetSeed(secondConference, finalSecondTeam);
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
                BuildPlayoffSeriesForConference(firstConference, firstConferenceRemainingTeams, 0);
                //Starting index for the second conference will be the starting point of the second half of the array which is the count of one sides remaining teams
                BuildPlayoffSeriesForConference(secondConference, secondConferenceRemainingTeams, secondConferenceRemainingTeams.Count / 2);
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
        private void InputGameStats(Game game, EventArgs e)
        {
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
