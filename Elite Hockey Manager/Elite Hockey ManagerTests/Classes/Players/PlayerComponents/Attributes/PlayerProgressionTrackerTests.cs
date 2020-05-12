using NUnit.Framework;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes.Tests
{
    [TestFixture()]
    public class PlayerProgressionTrackerTests
    {
        [Test()]
        public void PlayerProgressionTrackerTest()
        {
            //Sets default goalie attributes with a clutchness rating of 22 and a goalie unique rating of 77
            GoalieAttributes testGoalieAttributes = new GoalieAttributes();
            testGoalieAttributes.Clutchness = 22;
            testGoalieAttributes.Low = 77;
            PlayerProgressionTracker testTracker = new PlayerProgressionTracker(1, 85, testGoalieAttributes);
            //Tests whether the ProgressionTracker can reach goalie unique stats
            Assert.AreEqual(77, testTracker.AttributeTrackerDictionary["Low"].Item2[0]);
            //Tests whether the ProgressionTracker can reach base shared attributes
            Assert.AreEqual(22, testTracker.AttributeTrackerDictionary["Clutchness"].Item2[0]);
        }

        [Test()]
        public void UpdatePlayerAttributesTest()
        {
            SkaterAttributes testSkaterAttributes = new SkaterAttributes();
            testSkaterAttributes.SlapShot = 80;
            PlayerProgressionTracker testTracker = new PlayerProgressionTracker(1, 80, testSkaterAttributes);
            testSkaterAttributes.SlapShot = 90;
            testTracker.UpdatePlayerAttributes(83,testSkaterAttributes);
            Tuple<int, List<int>> slapshotTuple = testTracker.AttributeTrackerDictionary["SlapShot"];
            //Tests that the base attribute from the initialization does not get changed
            Assert.AreEqual(80, slapshotTuple.Item1);
            //Tests that the history of the attribute was updated with the new slapshot value
            Assert.AreEqual(new List<int>() { 90 }, slapshotTuple.Item2);
            //Tests that the new given overall of the player was updated into the list as well as holding the initial overall
            Assert.AreEqual(new List<int>() { 80, 83 }, testTracker.OverallTrackerList);
        }
    }
}