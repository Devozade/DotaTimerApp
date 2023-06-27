using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotaGameTimersClassLibrary;
using DotaConst = DotaGameTimersClassLibrary.DotaTimeConstants;
using TimeSpanTools;

namespace DotaGameTimersTests
{
    [TestClass]
    public class MiscStateTimesTests
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
        public void ResetTest()
        {
            TimeSpan testTime = TimeSpanCalcs.StringToTimespan(DotaConst.LotusSpawnSeedTime);
            MiscStateTimes classInstance = new();

            classInstance.GetLotusRemaining(testTime);

            classInstance.ResetAll();

            TimeSpan testTS = classInstance.GetNextLotusSpawns();

            Assert.AreEqual(TimeSpanCalcs.StringToTimespan(DotaConst.LotusSpawnSeedTime), testTS);
        }
        [TestMethod]
        public void GetFirstLotusTest()
        {            
            MiscStateTimes classInstance = new();                      

            TimeSpan testTS = classInstance.GetNextLotusSpawns();

            Assert.AreEqual(TimeSpanCalcs.StringToTimespan(DotaConst.LotusSpawnSeedTime), testTS);
        }        
        [TestMethod]
        public void IncrementLotusTest()
        {
            TimeSpan testTime = TimeSpanCalcs.StringToTimespan(DotaConst.LotusRespawnTime);
            MiscStateTimes classInstance = new();

            classInstance.GetLotusRemaining(testTime);

            TimeSpan testTS = classInstance.GetNextLotusSpawns();

            TimeSpan expectedTime = TimeSpanCalcs.IncrementTime(DotaConst.LotusSpawnSeedTime, DotaConst.LotusRespawnTime);

            Assert.AreEqual(expectedTime, testTS);
        }
        [TestMethod]
        public void GetFirstWisdomTest()
        {
            MiscStateTimes classInstance = new();

            TimeSpan testTS = classInstance.GetNextWisdomSpawns();

            TimeSpan expectedTime = TimeSpanCalcs.StringToTimespan(DotaConst.WisdomRuneSpawnSeedTime);

            Assert.AreEqual(expectedTime, testTS);
        }

        [TestMethod]
        public void IncrementWisdomTest()
        {
            TimeSpan testTime = TimeSpanCalcs.StringToTimespan(DotaConst.WisdomRuneSpawnSeedTime);
            MiscStateTimes classInstance = new();

            classInstance.GetWisdomRemaining(testTime);

            TimeSpan testTS = classInstance.GetNextWisdomSpawns();

            TimeSpan expectedTime = TimeSpanCalcs.IncrementTime(DotaConst.WisdomRuneSpawnSeedTime, DotaConst.WisdomRuneRespawnTime);

            Assert.AreEqual(expectedTime, testTS);
        }
        [TestMethod]
        public void RemainingLotusTest()
        {
            TimeSpan testTime = TimeSpan.FromMinutes(2);
            MiscStateTimes classInstance = new();

            TimeSpan testTS = classInstance.GetLotusRemaining(testTime);

            TimeSpan ExpectedTime = TimeSpanCalcs.StringToTimespan(DotaConst.LotusSpawnSeedTime) - testTime;

            Assert.AreEqual(ExpectedTime, testTS);
        }
        [TestMethod]
        public void RemainingWisdomTest()
        {
            TimeSpan testTime = TimeSpan.FromMinutes(4);
            MiscStateTimes classInstance = new();

            TimeSpan testTS = classInstance.GetWisdomRemaining(testTime);

            TimeSpan expectedTime = TimeSpanCalcs.StringToTimespan(DotaConst.WisdomRuneSpawnSeedTime) - testTime;

            Assert.AreEqual(expectedTime, testTS);
        }        

    }
}
