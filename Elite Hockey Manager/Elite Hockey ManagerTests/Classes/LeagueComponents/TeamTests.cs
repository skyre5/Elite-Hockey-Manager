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
    public class TeamTests
    {
        [Test()]
        public void EqualsTest()
        {
            Team t1 = new Team("Test", "Test");
        }
    }
}