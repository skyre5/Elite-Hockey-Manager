using NUnit.Framework;
using Elite_Hockey_Manager.Classes;
using System;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using Elite_Hockey_Manager.Classes.LeagueComponents;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.AreEqual(0, testTeam.GetTotalCapSpace());

            Contract testContract = new Contract(1, 1, 5.0);
            Center testCenter = new Center("Test", "Test", 21, testContract);
            testTeam.Roster.Add(testCenter);
            Assert.AreEqual(5.0, testTeam.GetTotalCapSpace());
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
    }
}