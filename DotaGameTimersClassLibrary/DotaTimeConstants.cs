namespace DotaGameTimersClassLibrary
{
    public class DotaTimeConstants
    {
        //constants all need to be in hh:mm:ss

        //lotus
        public const string LotusSpawnSeedTime = "00:03:00";
        public const string LotusRespawnTime = "00:03:00";

        //wisdom
        public const string WisdomRuneSpawnSeedTime = "00:07:00";
        public const string WisdomRuneRespawnTime = "00:07:00";

        //Roshan Constants
        public const string RoshanRespawnMinMinutes = "00:08:00";
        public const string RoshanRespawnMaxMinutes = "00:11:00";
        public const string AegisExpiryTimer = "00:05:00";

        //Tormentor constants
        public const string TormentorSpawnSeed = "00:20:00";
        public const string TormentorRespawnTime = "00:10:00";

        //neutral tier constants
        private const string NeutralTier0Time = "00:00:00";

        public const string NeutralTier1Time = "00:07:00";
        public const string NeutralTier2Time = "00:17:00";
        public const string NeutralTier3Time = "00:27:00";
        public const string NeutralTier4Time = "00:36:40";
        public const string NeutralTier5Time = "01:00:00";

        public static readonly string[] NeutralTierTimeArray = { NeutralTier0Time, NeutralTier1Time, NeutralTier2Time, NeutralTier3Time, NeutralTier4Time, NeutralTier5Time };
    }
}
