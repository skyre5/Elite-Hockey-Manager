using NUnit.Framework;
using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.Tests
{
    [TestFixture()]
    public class LeagueTests
    {
        [Test()]
        public void FillConferenceCorrectCountTest()
        {
            List<Team> testConference = new List<Team>();
            League.FillConference(testConference, 16);
            Assert.AreEqual(testConference.Count, 16);
        }

        [Test()]
        public void FillConferenceNegativeNumberTest()
        {
            List<Team> testConference = new List<Team>();
            Assert.Throws<ArgumentOutOfRangeException>(() => League.FillConference(testConference, -10));
        }
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(32)]
        [TestCase(31)]
        public void FillRemainingTeamsTest(int leagueSize)
        {
            League testLeague = new League("Test", "test", leagueSize);
            testLeague.FillRemainingTeams();
            int testLeagueSize = testLeague.FirstConference.Count + testLeague.SecondConference.Count;
            Assert.AreEqual(testLeagueSize, leagueSize);
        }
        [TestCase(5)]
        [TestCase(33)]
        public void TestLeagueCreationLimits(int leagueSize)
        {
            League testLeague;
            Assert.Throws<ArgumentException>(() => testLeague = new League("Test", "Test", leagueSize));
        }

    }
}