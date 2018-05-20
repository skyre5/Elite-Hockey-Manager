using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public static class PlayerGenerator
    {
        private static List<string> firstNames;
        private static List<string> lastNames;
        private static Random rand = new Random();

        public static Center CreateRandomCenter()
        {
            CheckNames();

        }
        private static void CheckNames()
        {
            if (firstNames == null || lastNames == null)
            {
                throw new MissingMemberException("Error: First or last names were not set");
            }
        }
        public static void SetFirstNames()
        {

        }
        public static void SetLastNames()
        {

        }
    }
}
