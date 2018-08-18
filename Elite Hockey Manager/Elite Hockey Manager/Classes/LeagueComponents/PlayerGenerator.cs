using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public static class PlayerGenerator
    {
        public static int Status
        {
            get
            {
                return _status;
            }
        }
        private static int _status = 0;
        private static List<string> firstNames;
        private static List<string> lastNames;
        private static Random rand = new Random();
        static PlayerGenerator()
        {
            firstNames = ReadFromFile("Files/firstNames.txt");
            lastNames = ReadFromFile("Files/lastNames.txt");
            CheckNames();
        }
        public static Center CreateRandomCenter()
        {
            if (_status == -1)
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
            if (_status == -1)
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
            if (_status == -1)
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
            if (_status == -1)
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
            if (_status == -1)
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
            if (_status == -1)
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
        private static Forward GenerateBaseForward(int position)
        {
            switch (position)
            {
                //Left Winger
                case 0:
                    return CreateRandomLeftWing();
                //Center
                case 1:
                    return CreateRandomCenter();
                //Right Winger
                case 2:
                    return CreateRandomRightWing();
                //Error
                default:
                    throw new ArgumentException("Player position out of ranger within GenerateForward function");
            }
        }
        /// <summary>
        /// Generates a forward of a specificed type with a quality given by the player.
        /// Used primariliy in team generation for initial rosters
        /// </summary>
        /// <param name="position">
        /// 0 - Left Winger
        /// 1 - Center
        /// 2 - Right Winger
        /// </param>
        /// <param name="quality">
        /// 1-First Line Potential Player
        /// 2-Second Line Potential Player
        /// 3-Third Line Potential Player
        /// 4-Fourth Line Potential Player
        /// </param>
        /// <returns>Returns type of player specificed</returns>
        /// 
        public static Forward GenerateForward(int position, int quality)
        {
            Forward newForward = GenerateBaseForward(position);
            switch (quality)
            {
                case 1:
                    WeightedPlayerRatingsGenerator(newForward
                        , 2 //% Generational
                        , 4 //% Superstar
                        , 54//% 1st Line
                        , 35//% Top 6
                        , 5 //% Top 9
                        );
                    break;
                case 2:
                    WeightedPlayerRatingsGenerator(newForward
                        , 0 //% Generational
                        , 2 //% Superstar
                        , 4 //% 1st Line
                        , 64//% top 6
                        , 25//% Top 9
                        , 5 //% Bottom 6
                        );
                    break;
                case 3:
                    WeightedPlayerRatingsGenerator(newForward
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 0 //% 1st Line
                        , 10//% Top 6
                        , 50//% Top 9
                        , 30//% Bottom 6
                            //10% Role
                        );
                    break;
                case 4:
                    WeightedPlayerRatingsGenerator(newForward
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 0 //% 1st Line
                        , 0 //% Top 6
                        , 5 //% Top 9
                        , 30//% Bottom 6
                            //65% Role
                        );
                    break;
                default:
                    WeightedPlayerRatingsGenerator(newForward
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 0 //% 1st Line
                        , 0 //% Top 6
                        , 5 //% Top 9
                        , 30//% Bottom 6
                            //65% Role
                        );
                    break;

            }
            return newForward;

        }
        /// <summary>
        /// Weighted randomization of good a player is gonna be into certain classes
        /// </summary>
        /// <param name="player">Player that is getting player stats altered and player rating added to player</param>
        /// <param name="genWeight">Generational Player %</param>
        /// <param name="starWeight">Superstar Player %</param>
        /// <param name="firstWeight">First Line Player %</param>
        /// <param name="topSixWeight">Top Six Player(2nd line) %</param>
        /// <param name="topNineWeight">Top Nine Player(2nd/3rd line) %</param>
        /// <param name="bottomSixWeight">Bottom Six Player(3rd/4th line)</param>
        private static void WeightedPlayerRatingsGenerator(Player player, int genWeight = 0, int starWeight = 0, int firstWeight = 0, int topSixWeight = 0, int topNineWeight = 0, int bottomSixWeight = 0)
        {
            int[] playerWeights = new int[] { genWeight, starWeight, firstWeight, topSixWeight, topNineWeight, bottomSixWeight };
            Random rand = new Random();
            int decidingNumber = rand.Next(1, 101);
            int total = 0;
            for (int i = 0; i < playerWeights.Count(); i++)
            {
                total += playerWeights[i];
                if (decidingNumber < total)
                {
                    player.GenerateStats(i + 1);
                    break;
                }
            }

        }
        /// <summary>
        /// Weighted age from 18-40 weighted towards around 25
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
        public static Tuple<string, string> GetFirstLastName()
        {
            if (_status == -1)
            {
                throw new IOException("Player names not loaded correctly");
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
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (reader != null)
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }

                reader.Close();

                return list;
            }
            else
            {
                return null;
            }
        }
        private static void CheckNames()
        {
            if (firstNames == null || lastNames == null)
            {
                _status = -1;
            }
            else
            {
                _status = 0;
            }
        }
    }
}
