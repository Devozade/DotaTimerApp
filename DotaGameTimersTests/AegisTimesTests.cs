using DotaGameTimersClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSpanTools;
using DotaConst = DotaGameTimersClassLibrary.DotaTimeConstants;

namespace DotaGameTimersTests
{
    [TestClass]
    public class AegisTimesTests
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
        public void AegisInPlayTest()
        {
            RoshanStateAndTimes roshanInstance = new();

            roshanInstance.SetKilled(TimeSpan.FromMinutes(1));

            bool result = roshanInstance.IsAegisInPlay();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AegisExpiryTest()
        {
            RoshanStateAndTimes roshanInstance = new();

            roshanInstance.SetKilled(TimeSpan.FromMinutes(1));

            TimeSpan result = roshanInstance.GetAegisExpiryTimeStamp();

            Assert.AreEqual(result, TimeSpan.FromMinutes(6));
        }
        [TestMethod]
        public void AegisRemainingTest()
        {
            RoshanStateAndTimes roshanInstance = new();

            TimeSpan timeToCheck = TimeSpan.FromMinutes(4);

            roshanInstance.SetKilled(TimeSpan.FromMinutes(2));

            TimeSpan result = roshanInstance.GetAegisRemaining(timeToCheck);

            Assert.AreEqual(result, TimeSpan.FromMinutes(3));
        }
    }
}
