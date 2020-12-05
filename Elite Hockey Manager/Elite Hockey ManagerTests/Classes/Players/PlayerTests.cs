using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;
using NUnit.Framework;
using System.Collections.Generic;

namespace Elite_Hockey_Manager.Classes.Tests
{
    using Elite_Hockey_Manager.Classes.LeagueComponents;
    using Elite_Hockey_Manager.Classes.Players;

    [TestFixture()]
    public class PlayerTests
    {
        #region Methods

        [Test()]
        public void AgePlayerAndProgressTest()
        {
            Center testC = (Center)PlayerGenerator.GenerateForward(1, 1, 18);
            testC.InitializePlayerProgressionTracker(1);
            testC.AgePlayerAndProgress();
            Assert.AreEqual(19, 19);
            testC.AgePlayerAndProgress();
            PlayerProgressionTracker tracker = testC.ProgressionTracker;
            List<int> history = tracker.GetAttributeHistory(SkaterAttributeNames.WristShot.ToString());
            Assert.AreEqual(history.Count, 3);
        }

        #endregion Methods
    }
}