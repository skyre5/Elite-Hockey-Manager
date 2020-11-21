using Elite_Hockey_Manager.Classes.LeagueComponents;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Elite_Hockey_Manager.Classes.Tests
{
    [TestFixture()]
    public class LeagueTests
    {
        #region Methods

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

        [Test()]
        public void GetTeamErrorCountTest()
        {
            League testLeague = new League("Test", "TST", 6);

            //League with six teams should return with 6 team errors
            Assert.AreEqual(testLeague.GetTeamErrorCount(), 6);

            Team testTeam = new Team("Test", "Test");

            //Adds team to league
            testLeague.AddTeam(testTeam);

            Assert.AreEqual(testLeague.GetTeamErrorCount(), 6);

            //Makes team valid
            TeamGenerator.FillTeam(testTeam);

            //League should return 5 errors since the new team is now valid
            Assert.AreEqual(testLeague.GetTeamErrorCount(), 5);

            //Fills the remaining teams and players for the league
            testLeague.FillRemainingTeams();
            testLeague.FillLeagueWithPlayers();
            //League should now return zero errors since all teams and players are valid
            Assert.AreEqual(testLeague.GetTeamErrorCount(), 0);
        }

        [TestCase(5)]
        [TestCase(33)]
        public void LeagueOutOfRangeSizeTest(int leagueSize)
        {
            League testLeague;
            Assert.Throws<ArgumentException>(() => testLeague = new League("Test", "Test", leagueSize));
        }

        #endregion Methods
    }
}