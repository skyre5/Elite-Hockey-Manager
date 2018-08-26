using NUnit.Framework;
using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elite_Hockey_Manager.Classes.LeagueComponents;
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
        public void LeagueOutOfRangeSizeTest(int leagueSize)
        {
            League testLeague;
            Assert.Throws<ArgumentException>(() => testLeague = new League("Test", "Test", leagueSize));
        }

        [Test()]
        public void AddTeamTest()
        {
            League testLeague = new League("Test", "TST", 31);
            Team testTeam = new Team("test", "test");
            Team testTeam2 = new Team("test2", "test");
            testLeague.AddTeam(testTeam, 1);
            //Tests that adding a team to conference 1 adds a single team
            Assert.AreEqual(1, testLeague.FirstConference.Count);
            testLeague.AddTeam(testTeam2, 2);
            //Tests that adding a team to conference 2 adds a single team
            Assert.AreEqual(1, testLeague.SecondConference.Count);
        }

        [Test()]
        public void AddTeamTestNullCheck()
        {
            Team testTeam = null;
            League testLeague = new League("test", "test", 6);
            Assert.Throws<ArgumentNullException>(() => testLeague.AddTeam(testTeam));
        }

        [Test()]
        public void AddTeamCheckForExistingTeamCheck()
        {
            League testLeague = new League("Test", "TST", 31);
            Team testTeam = new Team("test", "test");
            testLeague.AddTeam(testTeam, 2);
            //Tests that you can't add the same team twice to a league
            Assert.Throws<ArgumentException>(() => testLeague.AddTeam(testTeam, 2));
        }

        [TestCase(6)]
        [TestCase(7)]
        public void AddTeamFullTest(int leagueSize)
        {
            League testLeague = new League("Test", "TST", leagueSize);
            testLeague.FillRemainingTeams();
            Team testTeam = new Team("test", "test");
            Assert.Throws<ArgumentException>(() => testLeague.AddTeam(testTeam, 1));
        }
        [Test()]
        public void AddTeamUnevenCoferenceFullTest()
        {
            League testLeague = new League("test", "TST", 7);
            for (int i = 0; i <= 3; i++)
            {
                testLeague.AddTeam(TeamGenerator.GetTeam(), 1);
            }
            testLeague.AddTeam(TeamGenerator.GetTeam(), 2);
            Assert.Throws<ArgumentException>(() => testLeague.AddTeam(TeamGenerator.GetTeam(), 1));
        }

        [Test()]
        public void FillLeagueWithPlayersTest()
        {
            League testLeague = new League("Test", "Test", 32);
            testLeague.FillRemainingTeams();
            testLeague.FillLeagueWithPlayers();
            foreach (Team team in testLeague.AllTeams)
            {
                if (!team.ValidMinimumTeamSize())
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

    }
}