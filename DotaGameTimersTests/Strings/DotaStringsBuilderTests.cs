using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotaTimerAppStringsLibrary;
using DotaGameTimersClassLibrary;

namespace DotaGameTimersTests.Strings
{
    [TestClass]
    public class DotaStringsBuilderTests
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
        [TestMethod]
        public void RoshIntToNumberTest()
        {
            int testRoshNum = 3;

            string result = DotaStringsBuilder.RoshIntToNumberString(3);

            string expected = "Current Roshan #: 3";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RoshanLastDeathToStringTest()
        {
            TimeSpan inputTime = TimeSpan.FromMinutes(5);

            string result = DotaStringsBuilder.RoshanLastDeathToString(inputTime);

            string expected = "Last Death: 05:00";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RoshanLastDeathToStringDefaultTest()
        {
            string result = DotaStringsBuilder.RoshanLastDeathToStringDefault();

            string expected = "Last Death: N/A";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RoshIntToDropsStringOneTest()
        {
            string result = DotaStringsBuilder.RoshIntToDropsString(1);

            string expected = "Drops: Aegis";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RoshIntToDropsStringTwoTest()
        {
            string result = DotaStringsBuilder.RoshIntToDropsString(2);

            string expected = "Drops: Aegis && Cheese";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RoshIntToDropsStringThreeTest()
        {
            string result = DotaStringsBuilder.RoshIntToDropsString(3);

            string expected = "Drops: Aegis, Cheese && Radiant Aghs/Dire Refresher";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RoshIntToDropsStringMoreThanThreeTest()
        {
            string result = DotaStringsBuilder.RoshIntToDropsString(5);

            string expected = "Drops: Aegis, Cheese && Radiant Aghs/Dire Refresher";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RoshRespawnsToStringTest()
        {
            string result = DotaStringsBuilder.RoshRespawnsToString(TimeSpan.FromMinutes(9), TimeSpan.FromMinutes(12));

            string expected = "Next Spawn Interval: 09:00 - 12:00";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RoshRespawnsDefaultTest()
        {
            string result = DotaStringsBuilder.RoshRespawnsDefault();

            string expected = "Next Spawn Interval: N/A";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void AegisTimerTest()
        {
            string result = DotaStringsBuilder.AegisTimer(TimeSpan.FromMinutes(3));

            string expected = "Current Aegis Timer: 03:00";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void AegisTimerDefaultTest()
        {
            string result = DotaStringsBuilder.AegisTimerDefault();

            string expected = "Current Aegis Timer: N/A";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void AegisInPlayTest()
        {
            bool input = true;

            string result = DotaStringsBuilder.AegisInPlay(input);

            string expected = "Aegis in Play: Yes";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RadiantTormentorTimerTest()
        {
            string result = DotaStringsBuilder.RadiantTormentorTimer(TimeSpan.FromMinutes(3));

            string expected = "Radiant Tormentor Spawn: 03:00";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DireTormentorTimerTest()
        {
            string result = DotaStringsBuilder.DireTormentorTimer(TimeSpan.FromMinutes(3));

            string expected = "Dire Tormentor Spawn: 03:00";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void LotusSpawnTest()
        {
            string result = DotaStringsBuilder.LotusSpawn(TimeSpan.FromMinutes(2));

            string expected = "Next Lotus Spawn: 02:00";

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void WisdomSpawnTest()
        {
            string result = DotaStringsBuilder.WisdomSpawn(TimeSpan.FromMinutes(5));

            string expected = "Next Wisdom Rune Spawn: 05:00";

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void NeutralTierZeroTest()
        {
            string result = DotaStringsBuilder.NeutralTier(0, TimeSpan.FromMinutes(7));

            string expected = "Too early for Neutral drops. Next tier starts at 07:00";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void NeutralTierTest()
        {
            string result = DotaStringsBuilder.NeutralTier(1, TimeSpan.FromMinutes(14));

            string expected = "Current Neutral Item Tier: 1 Next tier starts at 14:00";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void MainTimerStringTest()
        {
            TimeSpan testTime = TimeSpan.FromMinutes(5) + TimeSpan.FromSeconds(15);

            string result = DotaStringsBuilder.MainTimerString(testTime);

            string expected = "00:05:15";

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void MainTimerStringDefaultTest()
        {      
            string result = DotaStringsBuilder.MainTimerStringDefault();

            string expected = "00:00:00";

            Assert.AreEqual(expected, result);
        }
    }
}
