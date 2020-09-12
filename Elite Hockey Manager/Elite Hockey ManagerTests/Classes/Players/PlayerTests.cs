﻿using NUnit.Framework;
using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes;

namespace Elite_Hockey_Manager.Classes.Tests
{
    [TestFixture()]
    public class PlayerTests
    {
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
    }
}