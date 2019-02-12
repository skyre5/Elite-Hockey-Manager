using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.GameComponents;

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
    }
    public class ScheduleCounter
    {
        public int homeGamesScheduled;
        public int awayGamesScheduled;
    }
    public class Schedule
    {
        private Random rand;
        private List<Team> _firstConference;
        private List<Team> _secondConference;
        private List<TeamPair> _teamsList = new List<TeamPair>();
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
        private void GenerateRegularSeason()
        {
            int gamesScheduled = 0;
            List<Game> daySchedule;
            while (gamesScheduled < _scheduleSize)
            {
                daySchedule = new List<Game>();
                List<TeamPair> homeTeams = GetHomeTeams();
                List<TeamPair> awayTeams = GetAwayTeams(homeTeams);
                for (int i = 0; i < homeTeams.Count; i++)
                {
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
            List<TeamPair> awayTeams = _teamsList.Except(homeTeams).Where(x => x.counter.awayGamesScheduled < 41).ToList();
            while (awayTeams.Count < homeTeams.Count)
            {
                TeamPair transferTeam = homeTeams.Last();
                awayTeams.Add(transferTeam);
                homeTeams.Remove(transferTeam);
            }
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
