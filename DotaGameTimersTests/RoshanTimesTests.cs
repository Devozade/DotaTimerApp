using DotaGameTimersClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSpanTools;
using DotaConst = DotaGameTimersClassLibrary.DotaTimeConstants;

namespace DotaGameTimersTests
{
    [TestClass]
    public class RoshanTimesTests
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
            RoshanStateAndTimes roshanInstance = new();

            roshanInstance.SetKilled(TimeSpan.FromMinutes(1));
            roshanInstance.ResetAll();

            int testResult = roshanInstance.GetRoshNumber();

            Assert.AreEqual(testResult, 1);
        }
        [TestMethod]
        public void RoshanDeadStatusTest()
        {
            RoshanStateAndTimes roshanInstance = new();
            roshanInstance.SetKilled(TimeSpan.FromMinutes(1));

            bool[] roshanStatus = roshanInstance.IsRoshanAlive();

            Assert.IsFalse(roshanStatus[0]);
        }
        [TestMethod]
        public void RoshanMinRespawnTest()
        {
            RoshanStateAndTimes roshanInstance = new();

            roshanInstance.SetKilled(TimeSpan.FromMinutes(1));

            TimeSpan[] roshRespawns = roshanInstance.GetRespawns();

            Assert.AreEqual(TimeSpan.FromMinutes(9), roshRespawns[0]);

        }
        [TestMethod]
        public void RoshanMaxRespawnTest()
        {
            RoshanStateAndTimes roshanInstance = new();

            roshanInstance.SetKilled(TimeSpan.FromMinutes(1));

            TimeSpan[] roshRespawns = roshanInstance.GetRespawns();

            Assert.AreEqual(TimeSpan.FromMinutes(12), roshRespawns[1]);
        } 

        [TestMethod]
        public void RoshanDeathTimeStampTest()
        {
            RoshanStateAndTimes roshanInstance = new();

            TimeSpan deathTime = TimeSpan.FromMinutes(2);
            roshanInstance.SetKilled(deathTime);

            TimeSpan result = roshanInstance.GetLastDeath();

            Assert.AreEqual(deathTime, result);
        }
        [TestMethod]
        public void RoshanMinRespawnRemainingTest()
        {
            TimeSpan deathTime = TimeSpan.FromMinutes(2);
            TimeSpan checkTime = TimeSpan.FromMinutes(4);
            TimeSpan expectedResult = TimeSpan.FromMinutes(6);

            RoshanStateAndTimes roshanInstance = new();
            roshanInstance.SetKilled(deathTime);

            TimeSpan[] spawnsRemaining = roshanInstance.GetRespawnsRemaining(checkTime);

            Assert.AreEqual(expectedResult, spawnsRemaining[0]);
        }
        [TestMethod]
        public void RoshanMaxRespawnRemainingTest()
        {
            TimeSpan deathTime = TimeSpan.FromMinutes(2);
            TimeSpan checkTime = TimeSpan.FromMinutes(5);
            TimeSpan expectedResult = TimeSpan.FromMinutes(8);

            RoshanStateAndTimes roshanInstance = new();
            roshanInstance.SetKilled(deathTime);

            TimeSpan[] spawnsRemaining = roshanInstance.GetRespawnsRemaining(checkTime);

            Assert.AreEqual(expectedResult, spawnsRemaining[1]);
        }
        [TestMethod]
        public void RoshanEarlyRespawnElapsedCanBeAliveTest()
        {
            TimeSpan deathTime = TimeSpan.FromMinutes(3);
            TimeSpan checkTime = deathTime + TimeSpanCalcs.StringToTimespan(DotaConst.RoshanRespawnMinMinutes);                     

            RoshanStateAndTimes roshanInstance = new();
            roshanInstance.SetKilled(deathTime);
            roshanInstance.GetRespawnsRemaining(checkTime);

            bool[] aliveStates = roshanInstance.IsRoshanAlive();

            Assert.IsTrue(aliveStates[0]);
        }
        public void RoshanEarlyRespawnElapsedIsAliveTest()
        {
            TimeSpan deathTime = TimeSpan.FromMinutes(3);
            TimeSpan checkTime = deathTime + TimeSpanCalcs.StringToTimespan(DotaConst.RoshanRespawnMinMinutes);

            RoshanStateAndTimes roshanInstance = new();
            roshanInstance.SetKilled(deathTime);
            roshanInstance.GetRespawnsRemaining(checkTime);

            bool[] aliveStates = roshanInstance.IsRoshanAlive();

            Assert.IsFalse(aliveStates[1]);
        }
        [TestMethod]
        public void RoshanLateRespawnElapsedIsAliveTest()
        {
            TimeSpan deathTime = TimeSpan.FromMinutes(3);
            TimeSpan checkTime = deathTime + TimeSpanCalcs.StringToTimespan(DotaConst.RoshanRespawnMaxMinutes);

            RoshanStateAndTimes roshanInstance = new();
            roshanInstance.SetKilled(deathTime);
            roshanInstance.GetRespawnsRemaining(checkTime);

            bool[] aliveStates = roshanInstance.IsRoshanAlive();

            Assert.IsTrue(aliveStates[1]);
        }
        [TestMethod]
        public void RoshanLateRespawnElapsedCanBeAliveTest()
        {
            TimeSpan deathTime = TimeSpan.FromMinutes(3);
            TimeSpan checkTime = deathTime + TimeSpanCalcs.StringToTimespan(DotaConst.RoshanRespawnMaxMinutes);

            RoshanStateAndTimes roshanInstance = new();
            roshanInstance.SetKilled(deathTime);
            roshanInstance.GetRespawnsRemaining(checkTime);

            bool[] aliveStates = roshanInstance.IsRoshanAlive();

            Assert.IsFalse(aliveStates[0]);
        }



    }
}
