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
    }
}