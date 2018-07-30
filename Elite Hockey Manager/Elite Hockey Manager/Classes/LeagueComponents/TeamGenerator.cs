using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes;
using System.Reflection;
using System.IO;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public static class TeamGenerator
    {
        public static int Status
        {
            get;
            private set;
        } = 0;

        public static List<string> CityNames;
        public static List<string> TeamNames;
        private static Random rand = new Random();

        static TeamGenerator()
        {
            Initialize();
        }
        public static void Initialize()
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string cityPath = new Uri(basePath + @"\Files\cityNames.txt").LocalPath;
            CityNames = SaveLoadUtils.ReadFromFile(cityPath);
            string teamPath = new Uri(basePath + @"\Files\teamNames.txt").LocalPath;
            TeamNames = SaveLoadUtils.ReadFromFile(teamPath);
            if (CityNames == null || TeamNames == null || CityNames.Count == 0 || TeamNames.Count == 0)
            {
                //There was an error in loading the team names
                //Displays status to parent using static class
                Status = -1;
            }
            else
            {
                Status = 0;
            }
        }
        public static Tuple<string, string> GetFullTeamName()
        {
            if (CityNames == null || TeamNames == null)
            {
                Status = -1;
                return null;
            }
            if (CityNames.Count == 0 || TeamNames.Count == 0)
            {
                TeamGenerator.Initialize();
                return GetFullTeamName();
            }
            if (Status == -1)
            {
                //Returns null when the team generator wasn't properly initialized
                return null;
            }
            Tuple<string, string> LocationAndName;
            int cityIndex = rand.Next(CityNames.Count);
            int nameIndex = rand.Next(TeamNames.Count);

            string city = CityNames[cityIndex];
            string name = TeamNames[nameIndex];

            //Removes the city and team name from the pool so no duplicates can occur in either
            CityNames.RemoveAt(cityIndex);
            TeamNames.RemoveAt(nameIndex);

            LocationAndName = new Tuple<string, string>(city, name);
            //Returns the tuple with Location in first index and name in second index
            return LocationAndName;

        }
    }
}
