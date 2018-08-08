using NUnit.Framework;
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
    }
}