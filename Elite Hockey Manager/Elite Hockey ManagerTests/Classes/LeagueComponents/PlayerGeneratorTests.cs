using NUnit.Framework;
using System.Linq;

namespace Elite_Hockey_Manager.Classes.Tests
{
    using Elite_Hockey_Manager.Classes.LeagueComponents;

    [TestFixture()]
    public class PlayerGeneratorTests
    {
        #region Methods

        [Test()]
        public void CreateRandomLeftWingTest()
        {
            LeftWinger test = PlayerGenerator.CreateRandomLeftWing();
            Assert.IsInstanceOf<LeftWinger>(test);
        }

        [Test()]
        public void GenerateDraftPoolTest()
        {
            Player[] testDraftPool = PlayerGenerator.GenerateDraftPool(30, 7);
            //Ensures there are enough players for all the draft picks to be available to choose players
            Assert.IsTrue(testDraftPool.Count() > 210);
        }

        #endregion Methods
    }
}