using Elite_Hockey_Manager.Classes.GameComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public class TeamPair
    {
        public Team team;
        public ScheduleCounter counter;

        public TeamPair(Team newTeam)
        {
            team = newTeam;
            counter = new ScheduleCounter();
        }

        public override string ToString()
        {
            return $"{team.TeamName} Home:{counter.homeGamesScheduled} Away:{counter.awayGamesScheduled}";
        }
    }

    public class ScheduleCounter
    {
        public int homeGamesScheduled;
        public int awayGamesScheduled;
    }

    [Serializable]
    public class Schedule
    {
        private Random rand;
        private List<Team> _firstConference;
        private List<Team> _secondConference;
        public List<TeamPair> _teamsList = new List<TeamPair>();
        private int _maxGamesPerDay;
        private int _scheduleSize;
        private List<List<Game>> _seasonSchedule = new List<List<Game>>();

        public List<List<Game>> SeasonSchedule
        {
            get
            {
                return _seasonSchedule;
            }
        }

        public int Length
        {
            get
            {
                return _seasonSchedule.Count;
            }
        }

        public void SimDay(int day)
        {
            if (day < 0 || day >= SeasonSchedule.Count)
            {
                throw new IndexOutOfRangeException("Day must be within the range of season length");
            }
            foreach (Game game in SeasonSchedule[day])
            {
                game.PlayGame();
            }
        }

        public Schedule(List<Team> firstConference, List<Team> secondConference, Random random)
        {
            //Sets random to league-wide random
            rand = random;
            _firstConference = firstConference;
            _secondConference = secondConference;
            //Each team has 41 home games which accounts for every game of the season in an 82 game schedule
            _scheduleSize = (_firstConference.Count + _secondConference.Count) * 41;
            SetTeamsList();
            SetMaxGamesInADay();
            GenerateRegularSeason();
        }

        /// <summary>
        /// Function to return total number of games scheduled for season
        /// </summary>
        /// <returns>Integer of number of games scheduled</returns>
        public int TotalGamesScheduled()
        {
            int totalGames = 0;
            foreach (List<Game> day in _seasonSchedule)
            {
                foreach (Game game in day)
                {
                    totalGames++;
                }
            }
            return totalGames;
        }

        /// <summary>
        /// Gets the total of games that are not finished that are yet to be simmed or partially simmed
        /// </summary>
        /// <returns>Total number of games that need to be simmed</returns>
        public int RemainingGamesToSim(int dayIndex, int duration)
        {
            int totalGames = 0;
            //If simming rest of season with -1 key. Calculation duration of rest of league
            if (duration == -1)
            {
                duration = _seasonSchedule.Count - dayIndex;
            }
            for (int i = 0; i < duration; i++)
            {
                if (dayIndex + i >= _seasonSchedule.Count)
                {
                    break;
                }
                foreach (Game game in _seasonSchedule[dayIndex + i])
                {
                    if (!game.Finished)
                    {
                        totalGames++;
                    }
                }
            }
            return totalGames;
        }

        /// <summary>
        /// Function to determine if there are any games left to sim
        /// </summary>
        /// <returns>Return boolean of if the schedule is done being simmed
        /// True - League is done simming all games in this class
        /// False - League still needs to sim games
        /// </returns>
        public bool IsFinishedSimming()
        {
            for (int i = 0; i < _seasonSchedule.Count; i++)
            {
                foreach (Game game in _seasonSchedule[i])
                {
                    if (!game.Finished)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Function to force the etnire schedule to be simmed, used in case of error simming schedule
        /// </summary>
        public void ForceFinishSimming()
        {
            for (int i = 0; i < _seasonSchedule.Count; i++)
            {
                foreach (Game game in _seasonSchedule[i])
                {
                    if (!game.Finished)
                    {
                        game.PlayGame();
                    }
                }
            }
        }

        private void GenerateRegularSeason()
        {
            int gamesScheduled = 0;
            List<Game> daySchedule;
            while (gamesScheduled < _scheduleSize)
            {
                daySchedule = new List<Game>();
                List<TeamPair> homeTeams = GetHomeTeams();
                //If an odd number sized league ends up with one team having 40 home games and 40 away games
                //Bricks system in infinite loop otherwise
                if (_teamsList.Where(x => x.counter.homeGamesScheduled < 41 || x.counter.awayGamesScheduled < 41).ToList().Count == 1)
                {
                    TeamPair brokenTeam = _teamsList.Where(x => x.counter.homeGamesScheduled < 41 || x.counter.awayGamesScheduled < 41).ToList().Last();
                    while (brokenTeam.counter.awayGamesScheduled < 41)
                    {
                        FixOddTeamLeague(brokenTeam, ref gamesScheduled);
                    }
                }
                List<TeamPair> awayTeams = GetAwayTeams(homeTeams);
                for (int i = 0; i < homeTeams.Count; i++)
                {
                    if (awayTeams.Count == 0)
                    {
                        continue;
                    }
                    TeamPair homeTeam = homeTeams[i];
                    TeamPair awayTeam = ChooseAwayTeam(awayTeams);
                    daySchedule.Add(new Game(homeTeam.team, awayTeam.team, rand, gamesScheduled));
                    gamesScheduled++;
                    homeTeam.counter.homeGamesScheduled++;
                    awayTeam.counter.awayGamesScheduled++;
                }
                _seasonSchedule.Add(daySchedule);
            }
        }

        private void FixOddTeamLeague(TeamPair lastTeam, ref int newGameNumber)
        {
            //home game missing
            while (lastTeam.counter.awayGamesScheduled != 41 && lastTeam.counter.homeGamesScheduled != 41)
            {
                for (int i = 0; i <= _seasonSchedule.Count; i++)
                {
                    for (int j = 0; j < _seasonSchedule[i].Count; j++)
                    {
                        if (_seasonSchedule[i][j].HomeTeam != lastTeam.team && _seasonSchedule[i][j].AwayTeam != lastTeam.team)
                        {
                            Game game = _seasonSchedule[i][j];
                            Team homeTeam = game.HomeTeam;
                            Team awayTeam = game.AwayTeam;
                            int gameNumber = game.GameNumber;
                            _seasonSchedule[i].RemoveAt(j);
                            _seasonSchedule[i].Add(new Game(lastTeam.team, awayTeam, rand, gameNumber));
                            lastTeam.counter.homeGamesScheduled++;
                            _seasonSchedule[i].Add(new Game(homeTeam, lastTeam.team, rand, newGameNumber));
                            newGameNumber++;
                            lastTeam.counter.awayGamesScheduled++;
                            i = _seasonSchedule.Count;
                            break;
                        }
                    }
                }
            }
        }

        private TeamPair ChooseAwayTeam(List<TeamPair> awayTeams)
        {
            //Chooses a random team among the away teams list
            int choice = rand.Next(0, awayTeams.Count);
            TeamPair chosenTeam = awayTeams[choice];
            //Removes chosen away team from the pool
            awayTeams.RemoveAt(choice);
            return chosenTeam;
        }

        private List<TeamPair> GetHomeTeams()
        {
            //Takes only teams where they have played less than 41 home games
            List<TeamPair> homeTeams = _teamsList.Where(x => x.counter.homeGamesScheduled < 41)
                //Sorts by home games the team has played
                .OrderBy(x => x.counter.homeGamesScheduled)
                //Takes the max number of games that can be played in a day
                .Take(_maxGamesPerDay).ToList();
            return homeTeams;
        }

        private List<TeamPair> GetAwayTeams(List<TeamPair> homeTeams)
        {
            List<TeamPair> onlyAwayTeams = _teamsList.Except(homeTeams).ToList();
            List<TeamPair> awayTeams = onlyAwayTeams.Where(x => x.counter.awayGamesScheduled < 41).ToList();
            for (int i = 0; ;)
            {
                if (i == homeTeams.Count)
                {
                    break;
                }
                if (awayTeams.Count >= homeTeams.Count)
                {
                    break;
                }
                if (homeTeams[i].counter.awayGamesScheduled < 41)
                {
                    awayTeams.Add(homeTeams[i]);
                    homeTeams.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            /*while (awayTeams.Count < homeTeams.Count)
            {
                TeamPair transferTeam = homeTeams.Last();
                awayTeams.Add(transferTeam);
                homeTeams.Remove(transferTeam);
            }*/
            return awayTeams;
        }

        private void SetTeamsList()
        {
            List<Team> allTeams = _firstConference.Concat(_secondConference).ToList();
            foreach (Team team in allTeams)
            {
                _teamsList.Add(new TeamPair(team));
            }
        }

        private void SetMaxGamesInADay()
        {
            //Half of the number of the teams in the league, rounds down
            int teamsCount = (_teamsList.Count / 2);
            if (teamsCount > 10) teamsCount = 10;
            _maxGamesPerDay = teamsCount;
        }
    }
}