using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public static class TeamGenerator
    {
        public static int Status
        {
            get;
            private set;
        } = 0;

        private static List<string> _cityNames;
        private static List<string> _teamNames;
        private static Random rand = new Random();

        static TeamGenerator()
        {
            _cityNames = SaveLoadUtils.ReadFromFile("Files/cityNames.txt");
            _teamNames = SaveLoadUtils.ReadFromFile("Files/teamNames.txt");
            if (_cityNames == null || _teamNames == null)
            {
                //There was an error in loading the team names
                //Displays status to parent using static class
                Status = -1;
            }
        }
        public static Tuple<string, string> GetFullTeamName()
        {
            if (Status == -1)
            {
                //Returns null when the team generator wasn't properly initialized
                return null;
            }
            Tuple<string, string> LocationAndName;
            int cityIndex = rand.Next(_cityNames.Count);
            int nameIndex = rand.Next(_teamNames.Count);

            string city = _cityNames[cityIndex];
            string name = _teamNames[nameIndex];

            //Removes the city and team name from the pool so no duplicates can occur in either
            _cityNames.RemoveAt(cityIndex);
            _teamNames.RemoveAt(nameIndex);

            LocationAndName = new Tuple<string, string>(city, name);
            //Returns the tuple with Location in first index and name in second index
            return LocationAndName;

        }
    }
}
