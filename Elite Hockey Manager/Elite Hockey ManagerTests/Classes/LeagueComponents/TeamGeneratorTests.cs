﻿using NUnit.Framework;
using Elite_Hockey_Manager.Classes.LeagueComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.Tests
{
    [TestFixture()]
    public class TeamGeneratorTests
    {
        [Test()]
        public void ConstructTeamGeneratorTest()
        {
            Assert.IsNotNull(TeamGenerator.CityNames);
            Assert.IsNotNull(TeamGenerator.TeamNames);
        }
        [Test()]
        public void GetFullTeamNameTest()
        {
            Tuple<string, string> names = TeamGenerator.GetFullTeamName();
            Assert.IsNotNull(names);
            Assert.IsNotEmpty(names.Item1);
            Assert.IsNotNull(names.Item1);
            Assert.IsNotEmpty(names.Item2);
            Assert.IsNotNull(names.Item2);
        }
        [Test()]
        public void TeamGeneratorStatusTest()
        {
            TeamGenerator.CityNames = null;
            TeamGenerator.TeamNames = null;
            Assert.IsNull(TeamGenerator.GetFullTeamName());
            Assert.AreEqual(-1, TeamGenerator.Status);
            TeamGenerator.Initialize();
        }

        [Test()]
        public void FillForwardsTest()
        {
            Team testTeam = new Team("test", "test");
            TeamGenerator.FillForwards(testTeam);

            int centers = testTeam.Roster.OfType<Center>().Count();
            Assert.GreaterOrEqual(centers, 4);

            int left = testTeam.Roster.OfType<LeftWinger>().Count();
            Assert.GreaterOrEqual(left, 4);

            int right = testTeam.Roster.OfType<RightWinger>().Count();
            Assert.GreaterOrEqual(right, 4);
        }

        [Test()]
        public void FillDefendersTest()
        {
            Team testTeam = new Team("test", "test");
            TeamGenerator.FillDefenders(testTeam);

            int left = testTeam.Roster.OfType<LeftDefensemen>().Count();
            Assert.GreaterOrEqual(left, 3);

            int right = testTeam.Roster.OfType<RightDefensemen>().Count();
            Assert.GreaterOrEqual(right, 3);
        }

        [Test()]
        public void FillGoaliesTest()
        {
            Team testTeam = new Team("test", "test");
            TeamGenerator.FillGoalies(testTeam);

            int goalies = testTeam.Roster.OfType<Goalie>().Count();
            Assert.GreaterOrEqual(goalies, 2);
        }
    }
}