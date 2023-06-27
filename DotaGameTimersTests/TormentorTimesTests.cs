using DotaGameTimersClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using TimeSpanTools;
using DotaConst = DotaGameTimersClassLibrary.DotaTimeConstants;

namespace DotaGameTimersTests
{
    [TestClass]
    public class TormentorTimesTests
    {
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Executes once for the test class. (Optional)
        }

        [TestInitialize]
        public void Setup()
        {

        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
        }

        [TestCleanup]
        public void TearDown()
        {
            // Runs after each test. (Optional)
        }

        [TestMethod]
        public void ResetDefaultsTest()
        {
            TormentorsStateAndTime tormentorInstance = new();
            TimeSpan killTime = TimeSpan.FromMinutes(1);

            tormentorInstance.KillDireTormentor(killTime);
            tormentorInstance.ResetAll();

            TimeSpan[] deathTimes = tormentorInstance.GetLastDeaths();

            Assert.AreEqual(TimeSpan.Zero, deathTimes[0]);
        }

        [TestMethod]
        public void IntitialSpawnTest()
        {
            TormentorsStateAndTime tormentorInstance = new();

            TimeSpan[] spawnTimes = tormentorInstance.GetRespawns();

            TimeSpan expectedTime = TimeSpanCalcs.StringToTimespan(DotaConst.TormentorSpawnSeed);

            Assert.AreEqual(expectedTime, spawnTimes[0]);
            Assert.AreEqual(expectedTime, spawnTimes[1]);
        }
        [TestMethod]
        public void TormentorsAreUpTest()
        {
            TormentorsStateAndTime tormentorInstance = new();

            bool[] statuses = tormentorInstance.AreTormentorsUp();

            Assert.IsFalse(statuses[0]);
        }
        [TestMethod]
        public void KillRadiantTormentorSpawnTimeTest()
        {
            TormentorsStateAndTime tormentorInstance = new();
            tormentorInstance.KillRadiantTormentor(TimeSpan.FromMinutes(2));

            TimeSpan expectedResult = TimeSpan.FromMinutes(2) + TimeSpanCalcs.StringToTimespan(DotaConst.TormentorRespawnTime);

            TimeSpan[] spawns = tormentorInstance.GetRespawns();

            Assert.AreEqual(expectedResult, spawns[0]);
        }
        [TestMethod]
        public void KillDireTormentorSpawnTimeTest()
        {
            TormentorsStateAndTime tormentorInstance = new();
            tormentorInstance.KillDireTormentor(TimeSpan.FromMinutes(2));

            TimeSpan expectedResult = TimeSpan.FromMinutes(2) + TimeSpanCalcs.StringToTimespan(DotaConst.TormentorRespawnTime);

            TimeSpan[] spawns = tormentorInstance.GetRespawns();

            Assert.AreEqual(expectedResult, spawns[1]);
        }
        [TestMethod]
        public void RadiantTormentorRespawnRemainingSeedTest()
        {
            TormentorsStateAndTime tormentorInstance = new();
            tormentorInstance.KillRadiantTormentor(TimeSpan.FromMinutes(22));

            TimeSpan testTime = TimeSpan.FromMinutes(24);
            TimeSpan expectedTime = TimeSpan.FromMinutes(8);

            TimeSpan[] remaining = tormentorInstance.GetRespawnsRemaining(testTime);

            Assert.AreEqual(expectedTime, remaining[0]);
        }
        [TestMethod]
        public void DireTormentorRespawnRemainingSeedTest()
        {
            TormentorsStateAndTime tormentorInstance = new();
            tormentorInstance.KillDireTormentor(TimeSpan.FromMinutes(24));

            TimeSpan testTime = TimeSpan.FromMinutes(28);
            TimeSpan expectedTime = TimeSpan.FromMinutes(6);

            TimeSpan[] remaining = tormentorInstance.GetRespawnsRemaining(testTime);

            Assert.AreEqual(expectedTime, remaining[1]);
        }
        [TestMethod]
        public void GetTormentorDeathTimeStampTest()
        {
            TormentorsStateAndTime tormentorInstance = new();
            TimeSpan testTime = TimeSpan.FromMinutes(5);

            tormentorInstance.KillRadiantTormentor(testTime);

            TimeSpan[] results = tormentorInstance.GetLastDeaths();

            Assert.AreEqual(testTime, results[0]);
        }

        [TestMethod]
        public void CheckDireTormentorRespawnEvent()
        {
            TormentorsStateAndTime tormentorInstance = new();
            TimeSpan deathTime = TimeSpan.FromMinutes(22);

            tormentorInstance.KillRadiantTormentor(deathTime);

            TimeSpan respawnTime = deathTime + TimeSpanCalcs.StringToTimespan(DotaConst.TormentorRespawnTime);
            tormentorInstance.GetRespawnsRemaining(respawnTime);

            bool[] statuses = tormentorInstance.AreTormentorsUp();

            Assert.IsTrue(statuses[0]);

        }
        [TestMethod]
        public void CheckRadiantTormentorRespawnEvent()
        {
            TormentorsStateAndTime tormentorInstance = new();
            TimeSpan deathTime = TimeSpan.FromMinutes(28);

            tormentorInstance.KillDireTormentor(deathTime);

            TimeSpan respawnTime = deathTime + TimeSpanCalcs.StringToTimespan(DotaConst.TormentorRespawnTime);
            tormentorInstance.GetRespawnsRemaining(respawnTime);

            bool[] statuses = tormentorInstance.AreTormentorsUp();

            Assert.IsTrue(statuses[1]);
        }

    }
}
