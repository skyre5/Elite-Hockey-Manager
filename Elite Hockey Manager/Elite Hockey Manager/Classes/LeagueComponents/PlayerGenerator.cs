﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public static class PlayerGenerator
    {
        public static int status = 0;
        private static List<string> firstNames;
        private static List<string> lastNames;
        private static Random rand = new Random();
        static PlayerGenerator()
        {
            firstNames = ReadFromFile("firstNames.txt");
            lastNames = ReadFromFile("lastNames.txt");
            CheckNames();
        }
        public static Center CreateRandomCenter()
        {
            if (status == -1)
            {
                return null;
            }
            Tuple<string, string> names = GetFirstLastName();
            if (names == null)
            {
                return null;
            }
            int age = GetAge();
            Center player = new Center(names.Item1, names.Item2, age);
            return player;

        }
        public static LeftWinger CreateRandomLeftWing()
        {
            if (status == -1)
            {
                return null;
            }
            Tuple<string, string> names = GetFirstLastName();
            if (names == null)
            {
                return null;
            }
            int age = GetAge();
            LeftWinger player = new LeftWinger(names.Item1, names.Item2, age);
            return player;

        }
        public static RightWinger CreateRandomRightWing()
        {
            if (status == -1)
            {
                return null;
            }
            Tuple<string, string> names = GetFirstLastName();
            if (names == null)
            {
                return null;
            }
            int age = GetAge();
            RightWinger player = new RightWinger(names.Item1, names.Item2, age);
            return player;

        }
        public static LeftDefensemen CreateRandomLeftDefender()
        {
            if (status == -1)
            {
                return null;
            }
            Tuple<string, string> names = GetFirstLastName();
            if (names == null)
            {
                return null;
            }
            int age = GetAge();
            LeftDefensemen player = new LeftDefensemen(names.Item1, names.Item2, age);
            return player;

        }
        public static RightDefensemen CreateRandomRightDefender()
        {
            if (status == -1)
            {
                return null;
            }
            Tuple<string, string> names = GetFirstLastName();
            if (names == null)
            {
                return null;
            }
            int age = GetAge();
            RightDefensemen player = new RightDefensemen(names.Item1, names.Item2, age);
            return player;

        }
        public static Goalie CreateRandomGoalie()
        {
            if (status == -1)
            {
                return null;
            }
            Tuple<string, string> names = GetFirstLastName();
            if (names == null)
            {
                return null;
            }
            int age = GetAge();
            Goalie player = new Goalie(names.Item1, names.Item2, age);
            return player;

        }
        /// <summary>
        /// Weighted age from 18-42 weighted towards around 25
        /// </summary>
        /// <returns></returns>
        public static int GetAge()
        {
            int weight = rand.Next(100);
            //returns 25-32
            if (weight < 50)
            {
                return (25 + rand.Next(8));
            }
            //Returns 18=24
            else if (weight < 75)
            {
                return (18 + rand.Next(7));
            }
            //Returns 33-36
            else if (weight < 90)
            {
                return (33 + rand.Next(4));
            }
            //Returns 36-40
            else
            {
                return (36 + rand.Next(5));
            }
        }
        public static Tuple<string ,string> GetFirstLastName()
        {
            if (status == -1)
            {
                return null;
            }
            Tuple<string, string> names;
            int firstIndex = rand.Next(firstNames.Count);
            int lastIndex = rand.Next(lastNames.Count);
            string first = firstNames[firstIndex];
            string last = lastNames[lastIndex];
            names = new Tuple<string, string>(first, last);
            return names;
        }
        public static List<string> ReadFromFile(string filename)
        {
            List<string> list = new List<string>();

            StreamReader reader = new StreamReader(filename);

            String line;
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }

            reader.Close();

            return list;
        }
        private static void CheckNames()
        {
            if (firstNames == null || lastNames == null)
            {
                status = -1;
                throw new MissingMemberException("Error: First or last names were not set");
            }
            else
            {
                status = 0;
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
