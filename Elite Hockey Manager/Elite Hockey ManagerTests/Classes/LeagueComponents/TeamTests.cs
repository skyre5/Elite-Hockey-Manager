using NUnit.Framework;
using Elite_Hockey_Manager.Classes;
using System;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
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
    }
}