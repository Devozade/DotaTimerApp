using DotaGameTimersClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSpanTools;
using DotaConst = DotaGameTimersClassLibrary.DotaTimeConstants;

namespace DotaGameTimersTests
{
    [TestClass]
    public class NeutralItemTimesTests
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
            NeutralItemStateAndTimes neutralItemsInstance = new();

            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.ResetAll();

            int[] tiers = neutralItemsInstance.GetCurrentAndNextTier();
            int expected = 0;

            Assert.AreEqual(expected, tiers[0]);
        }
        [TestMethod]
        public void IncrementCurrentTierTest()
        {
            NeutralItemStateAndTimes neutralItemsInstance = new();
            neutralItemsInstance.IncrementCurrentTier();

            int[] tiers = neutralItemsInstance.GetCurrentAndNextTier();

            int expected = 1;
            Assert.AreEqual(expected, tiers[0]);
        }
        [TestMethod]
        public void IncrementNextTierTest()
        {
            NeutralItemStateAndTimes neutralItemsInstance = new();
            neutralItemsInstance.IncrementCurrentTier();

            int[] tiers = neutralItemsInstance.GetCurrentAndNextTier();

            int expected = 2;
            Assert.AreEqual(expected, tiers[1]);
        }
        [TestMethod]
        public void IncrementCurrentToFiveCheckNextTest()
        {
            NeutralItemStateAndTimes neutralItemsInstance = new();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();

            int[] tiers = neutralItemsInstance.GetCurrentAndNextTier();

            int expected = 5;
            Assert.AreEqual(expected, tiers[1]);
        }
        [TestMethod]
        public void IncrementCurrentTierMoreThanFiveTest()
        {
            NeutralItemStateAndTimes neutralItemsInstance = new();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();
            neutralItemsInstance.IncrementCurrentTier();

            int[] tiers = neutralItemsInstance.GetCurrentAndNextTier();

            int expected = 5;
            Assert.AreEqual(expected, tiers[0]);
        }

        [TestMethod]
        public void GetNextTierTimeStampTest()
        {
            NeutralItemStateAndTimes neutralItemsInstance = new();
            neutralItemsInstance.IncrementCurrentTier();

            TimeSpan expected = TimeSpanCalcs.StringToTimespan(DotaConst.NeutralTier2Time);

            TimeSpan result = neutralItemsInstance.GetNextTierTime();

            Assert.AreEqual(expected, result);

        }
    }
}
