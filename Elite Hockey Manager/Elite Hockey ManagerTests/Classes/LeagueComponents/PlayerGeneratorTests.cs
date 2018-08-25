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
    public class PlayerGeneratorTests
    {
        [Test()]
        public void CreateRandomLeftWingTest()
        {
            LeftWinger test = PlayerGenerator.CreateRandomLeftWing();
            Assert.IsInstanceOf<LeftWinger>(test);
        }
    }
}