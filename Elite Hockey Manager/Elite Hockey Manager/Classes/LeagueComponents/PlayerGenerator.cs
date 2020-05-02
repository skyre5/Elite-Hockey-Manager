using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.LeagueComponents;

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
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string firstPath = new Uri(basePath + @"\Files\firstNames.txt").LocalPath;
            firstNames = SaveLoadUtils.ReadFromFile(firstPath);
            string lastPath = new Uri(basePath + @"\Files\lastNames.txt").LocalPath;
            lastNames = SaveLoadUtils.ReadFromFile(lastPath);
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

        public static Player[] GenerateDraftPool(int teams, int rounds)
        {
            int playersToCreate = (int)(teams * rounds * 1.5);
            Player[] DraftPool = new Player[playersToCreate];
            //Generates at least 5 high quality prospects with up to an aditional amount cooresponding to half the leagues teams
            int highQualityProspectsCount = rand.Next( ((int)(teams / 2)) + 1) + 5;
            //Generates at least 10 medium quality prospects with an additional amount for half the leagues size
            int mediumQualityProspectsCount = rand.Next(((int)(teams / 2))) + 10;
            //Generates at least 10 low quality prospects with up to an additional amount for the amount of teams
            int lowQualityProspectsCount = rand.Next(((int)(teams))) + 10;
            int depthQualityProspectsCount = rand.Next(((int)(teams)) + 10);
            //Holds the offset for where the creation of new draftable players is in the draft
            int offset = 0;
            for (int i = 0; i < highQualityProspectsCount; i++)
            {
                DraftPool[offset + i] = GenerateDraftPlayerWithQuality(1);
            }
            offset += highQualityProspectsCount;
            for (int i = 0; i < mediumQualityProspectsCount; i++)
            {
                DraftPool[offset + i] = GenerateDraftPlayerWithQuality(2);
            }
            offset += mediumQualityProspectsCount;
            for (int i = 0; i < lowQualityProspectsCount; i++)
            {
                DraftPool[offset + i] = GenerateDraftPlayerWithQuality(3);
            }
            offset += lowQualityProspectsCount;
            for (int i = 0; i < depthQualityProspectsCount; i++)
            {
                DraftPool[offset + i] = GenerateDraftPlayerWithQuality(4);
            }
            offset += depthQualityProspectsCount;
            for (int i = offset; i < playersToCreate; i++)
            {
                DraftPool[i] = GenerateDraftPlayerWithQuality(5);
            }
            return DraftPool;

        }
        public static Player GenerateDraftPlayerWithQuality(int quality)
        {
            Player generatedPlayer;
            int playerType = rand.Next(10);
            //60% of created players are forwards
            if (playerType <= 5)
            {
                //Generates random number between 0 and 2, each cooresponds to the forward positions left wing-center-right wing
                int forwardPosition = rand.Next(3);
                //5 qualities exist for forward, all draft players are 18
                generatedPlayer = GenerateForward(forwardPosition, quality, 18);
            }
            //30% of created players are defenders
            else if (playerType <= 8)
            {
                //Defense only has 4 qualities, if a higher quality is entered, set it to max 
                if (quality > 4)
                {
                    quality = 4;
                }
                int defensePosition = rand.Next(2);
                generatedPlayer = GenerateDefender(defensePosition, quality, 18);
            }
            //10% are goalies
            else if (playerType == 9)
            {
                //Only 3 quality types for goalies, if a quality is given higher than 3, set to max
                if (quality > 3)
                {
                    quality = 3;
                }
                generatedPlayer = GenerateGoalie(quality, 18);
            }
            else
            {
                generatedPlayer = GenerateForward(0, 5, 18);
                Console.Error.WriteLine("PlayerGenerator.GenerateDraftPlayerWithQuality falls through else ifs");
            }
            return generatedPlayer;
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
        /// Returns a randomly created left or right defensemen
        /// </summary>
        /// <param name="position">
        /// 0 - Left Defender
        /// 1 - Right Defender
        /// </param>
        /// <returns></returns>
        private static Defender GenerateBaseDefender(int position)
        {
            switch (position)
            {
                //Left Defender
                case 0:
                    return CreateRandomLeftDefender();
                //Right Defender
                case 1:
                    return CreateRandomRightDefender();
                default:
                    throw new ArgumentException("Player position out of ranger within GenerateDefender function");
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
        /// 5-Role Player
        /// </param>
        /// <returns>Returns type of player specificed</returns>
        /// 
        public static Forward GenerateForward(int position, int quality, int age = -1)
        {
            Forward newForward = GenerateBaseForward(position);
            //If the user does pass an age variable, sets the random age to the one given
            //Used for Draft to ensure all players are 18 and give them appropriate stats
            if (age == -1)
            {
                newForward.Age = GetAge();
            }
            else
            {
                newForward.Age = 18;
            }
            switch (quality)
            {
                case 1:
                    WeightedPlayerRatingsGenerator(newForward
                        , 2 //% Generational
                        , 4 //% Superstar
                        , 54//% 1st Line
                        , 35//% Top 6
                        , 6 //% Top 9
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
                        , 10//% Role
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
                        , 65//% Role
                        );
                    break;
                case 5:
                    WeightedPlayerRatingsGenerator(newForward
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 0 //% 1st Line
                        , 0 //% Top 6
                        , 0 //% Top 9
                        , 20//% Bottom 6
                        , 80//% Role
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
                        , 65//% Role
                        );
                    break;
            }
            //Generates base contract for player based on overall
            ContractGenerator.GenerateContract(newForward);
            return newForward;

        }
        /// <summary>
        /// Returns a generated defensemen of a certain quality
        /// </summary>
        /// <param name="position">
        /// 0 - Left Defender
        /// 1 - Right Defender
        /// </param>
        /// <param name="quality">
        /// 1 - 1st Pairing
        /// 2 - 2nd Pairing
        /// 3 - 3rd Pairing
        /// 4 - Role Defender
        /// </param>
        /// <returns></returns>
        public static Defender GenerateDefender(int position, int quality, int age = -1)
        {
            Defender newDefender = GenerateBaseDefender(position);
            if (age == -1)
            {
                age = GetAge();
            }
            else
            {
                newDefender.Age = 18;
            }
            switch (quality)
            {
                case 1:
                    WeightedPlayerRatingsGenerator(newDefender
                        , 5 //% Generational
                        , 8 //% Superstar
                        , 50//% First Pairing
                        , 37//% Second Pairing
                        );
                    break;
                case 2:
                    WeightedPlayerRatingsGenerator(newDefender
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 5 //% First Pairing
                        , 75//% Second Pairing
                        , 20//% Bottom Pairing
                        );
                    break;
                case 3:
                    WeightedPlayerRatingsGenerator(newDefender
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 0 //% First Pairing
                        , 20//% Second Pairing
                        , 70//% Bottom Pairing
                        , 10//% Role Defender
                        );
                    break;
                case 4:
                    WeightedPlayerRatingsGenerator(newDefender
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 0 //% First Pairing
                        , 0 //% Second Pairing
                        , 20//% Bottom Pairing
                        , 80//% Role Defender
                        );
                    break;
                default:
                    WeightedPlayerRatingsGenerator(newDefender
                        , 0 //% Generational
                        , 0 //% Superstar
                        , 0 //% First Pairing
                        , 0 //% Second Pairing
                        , 25//% Bottom Pairing
                        , 75//% Role Defender
                        );
                    break;

            }
            //Generates base contract for player based on overall
            ContractGenerator.GenerateContract(newDefender);
            //Sets faceoff to 50 for defenders since they don't use it
            newDefender.SkaterAttributes.Faceoff = 50;
            return newDefender;

        }
        /// <summary>
        /// Returns a randomly generated goalie of a certain quality
        /// </summary>
        /// <param name="quality">
        /// 1 - Starter
        /// 2 - Backup
        /// 3 - Role
        /// </param>
        /// <returns></returns>
        public static Goalie GenerateGoalie(int quality, int age = -1)
        {
            Goalie newGoalie = CreateRandomGoalie();
            if (age == -1)
            {
                age = GetAge();
            }
            else
            {
                newGoalie.Age = 18;
            }
            switch (quality)
            {
                case 1:
                    WeightedPlayerRatingsGenerator(newGoalie
                        , 3 //% Generational
                        , 7 //% Elite
                        , 70//% Starter
                        , 10//% LowStarter
                        , 10//% Backup
                        );
                    break;
                case 2:
                    WeightedPlayerRatingsGenerator(newGoalie
                        , 0 //% Generational
                        , 0 //% Elite
                        , 5 //% Starter
                        , 20//% LowStarter
                        , 60//% Backup
                        , 15//% Role
                        );
                    break;
                case 3:
                    WeightedPlayerRatingsGenerator(newGoalie
                        , 0 //% Generational
                        , 0 //% Elite
                        , 0 //% Starter
                        , 0 //% LowStarter
                        , 20//% Backup
                        , 80//% Role
                        );
                    break;
                default:
                    WeightedPlayerRatingsGenerator(newGoalie
                        , 0 //% Generational
                        , 0 //% Elite
                        , 0 //% Starter
                        , 0 //% LowStarter
                        , 20//% Backup
                        , 80//% Role
                        );
                    break;
            }
            //Generates base contract for player based on overall
            ContractGenerator.GenerateContract(newGoalie);
            return newGoalie;
        }
        private static void WeightedPlayerRatingsGenerator(Player player, params int[] weights)
        {
            int decidingNumber = rand.Next(1, 101);
            int total = 0;
            for (int i = 0; i < weights.Count(); i++)
            {
                total += weights[i];
                if (decidingNumber <= total)
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
