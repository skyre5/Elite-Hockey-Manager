using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using NUnit.Framework;

namespace Elite_Hockey_Manager.Classes.Tests
{
    [TestFixture()]
    public class TeamTests
    {
        [Test()]
        public void EqualsTest()
        {
            Team t1 = new Team("Test", "Test");
        }

        [Test()]
        public void GetPositionCountTest()
        {
            Team testTeam = new Team("Test", "Test");

            Center testCenter = new Center("Test", "Test", 21);
            LeftDefensemen testDefender = new LeftDefensemen("Test", "Test", 22);
            Goalie testGoalie = new Goalie("Test", "Test", 21);

            testTeam.Roster.Add(testCenter);
            testTeam.Roster.Add(testDefender);
            testTeam.Roster.Add(testGoalie);

            Assert.AreEqual(testTeam.GetPositionCount<Center>(), 1);
            Assert.AreEqual(testTeam.GetPositionCount<Skater>(), 2);
            Assert.AreEqual(testTeam.GetPositionCount<Player>(), 3);
        }

        [Test()]
        public void GetTotalCapSpaceTest()
        {
            Team testTeam = new Team("Test", "test");
            Assert.AreEqual(0, testTeam.GetCapSpent());

            Contract testContract = new Contract(1, 1, 5.0, testTeam);
            Center testCenter = new Center("Test", "Test", 21, testContract);
            testTeam.Roster.Add(testCenter);
            Assert.AreEqual(5.0, testTeam.GetCapSpent());
        }

        [TestCase(0, 0, 0, false)]
        [TestCase(11, 6, 2, false)]
        [TestCase(12, 5, 2, false)]
        [TestCase(12, 6, 1, false)]
        [TestCase(12, 6, 2, true)]
        public void ValidMinimumTeamSizeTest(int forwards, int defenders, int goalies, bool pass)
        {
            Team testTeam = new Team("Test", "test");
            //Adding forwards
            for (int i = 0; i < forwards; i++)
            {
                testTeam.Roster.Add(PlayerGenerator.CreateRandomCenter());
            }
            for (int i = 0; i < defenders; i++)
            {
                testTeam.Roster.Add(PlayerGenerator.CreateRandomLeftDefender());
            }
            for (int i = 0; i < goalies; i++)
            {
                testTeam.Roster.Add(PlayerGenerator.CreateRandomGoalie());
            }
            Assert.AreEqual(testTeam.ValidMinimumTeamSize(), pass);
        }

        /// <summary>
        /// Tests that a full team made from the team generator will have correct lines of the right position
        /// </summary>
        [Test()]
        public void AutoSetLinesTestFullTeam()
        {
            Team testTeam = TeamGenerator.GetTeam();
            TeamGenerator.FillTeam(testTeam);
            AutoSetLinesTest(testTeam);
        }

        /// <summary>
        /// Tests that a team with no players will have more players auto-assigned to the team
        /// Also tests that all needed positions are filled and the correct positions
        /// </summary>
        [Test()]
        public void AutoSetLinesTestIncompleteTeam()
        {
            Team testTeam = TeamGenerator.GetTeam();
            AutoSetLinesTest(testTeam);
        }

        private void AutoSetLinesTest(Team testTeam)
        {
            testTeam.AutoSetLines();
            //Checks to make sure no player in the lineup is null
            CheckArrayForNull(testTeam.Forwards, 4, 3);
            CheckArrayForNull(testTeam.Defenders, 3, 2);
            if (testTeam.Goalies[0] == null || testTeam.Goalies[1] == null)
            {
                Assert.Fail();
            }

            //Checks to make sure there are no players playing in the wrong position category
            //Forwards, Defenders, and goalies
            CheckArrayForType<Forward>(testTeam.Forwards, 4, 3);
            CheckArrayForType<Defender>(testTeam.Defenders, 3, 2);
            if (!(testTeam.Goalies[0] is Goalie) || !(testTeam.Goalies[1] is Goalie))
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        /// <summary>
        /// Checks if any player inside the 2d array is null
        /// Fails if null is found
        /// </summary>
        /// <param name="players"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        private void CheckArrayForNull(Player[,] players, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (players[i, j] == null)
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        /// <summary>
        /// Checks 2d array for variable that is not of type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="players"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        private void CheckArrayForType<T>(Player[,] players, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!(players[i, j] is T))
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}