using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public static class TeamGenerator
    {
        #region Fields

        public static List<string> CityNames;

        public static List<string> TeamNames;

        private static Random rand = new Random();

        #endregion Fields

        #region Constructors

        static TeamGenerator()
        {
            Initialize();
        }

        #endregion Constructors

        #region Properties

        public static int Status
        {
            get;
            private set;
        } = 0;

        #endregion Properties

        #region Methods

        public static void FillDefenders(Team team)
        {
            for (int position = 0; position <= 1; position++)
            {
                for (int line = 1; line <= 4; line++)
                {
                    Defender defender = PlayerGenerator.GenerateDefender(position, line);
                    team.AddNewSkater(defender);
                    defender.AddStats(1, team.TeamID, false);
                }
            }
        }

        public static void FillForwards(Team team)
        {
            for (int position = 0; position <= 2; position++)
            {
                for (int line = 1; line <= 5; line++)
                {
                    Skater skater = PlayerGenerator.GenerateForward(position, line);
                    team.AddNewSkater(skater);
                    skater.AddStats(1, team.TeamID, false);
                }
            }
        }

        public static void FillGoalies(Team team)
        {
            for (int line = 0; line <= 2; line++)
            {
                Goalie goalie = PlayerGenerator.GenerateGoalie(line);
                team.AddNewGoalie(goalie);
                goalie.AddStats(1, team.TeamID, false);
            }
        }

        public static void FillTeam(Team team)
        {
            FillForwards(team);
            FillDefenders(team);
            FillGoalies(team);
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

        public static Team GetTeam()
        {
            Tuple<string, string> teamName = GetFullTeamName();
            if (teamName == null)
            {
                return null;
            }
            Team team = new Team(teamName.Item1, teamName.Item2);
            return team;
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

        #endregion Methods
    }
}