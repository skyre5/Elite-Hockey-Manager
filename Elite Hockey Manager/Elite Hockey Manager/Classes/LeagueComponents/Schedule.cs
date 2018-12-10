using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.GameComponents;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public class Schedule
    {
        private List<Team> _firstConference;
        private List<Team> _secondConference;
        private List<Team> _allTeams;
        private List<KeyValuePair<Team, Tuple<int, int>>> _teamsList;
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
        public Schedule(List<Team> firstConference, List<Team> secondConference)
        {
            _firstConference = firstConference;
            _secondConference = secondConference;
            _allTeams = _firstConference.Concat(_secondConference).ToList();
            //Each team has 41 home games which accounts for every game of the season in an 82 game schedule
            int scheduleSize = _allTeams.Count * 41;
            SetTeamsList();
            SetMaxGamesInADay();
            GenerateRegularSeason();
        }
        private void GenerateRegularSeason()
        {
            List<KeyValuePair<Team, Tuple<int, int>>> homeTeams = (List<KeyValuePair<Team, Tuple<int, int>>>)_teamsList.Take(_maxGamesPerDay);
        }
        private void SetTeamsList()
        {
            foreach (Team team in _allTeams)
            {
                _teamsList.Add(new KeyValuePair<Team, Tuple<int, int>>(team, new Tuple<int, int>(0, 0)));
            }
        }
        private void SetMaxGamesInADay()
        {
            //Half of the number of the teams in the league, rounds down
            int teamsCount = (_allTeams.Count / 2);
            if (teamsCount > 10) teamsCount = 10;
            _maxGamesPerDay = teamsCount;
        }
    }
}
