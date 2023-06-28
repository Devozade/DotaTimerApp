using System.Text;

namespace DotaTimerAppStringsLibrary
{
    public class DotaTimerAppStrings
    {
        //TTS generic
        public static string _tTSTimerStarted = "Game timer started.";
        public static string _tTSTimerResumed = "Game timer resumed.";
        public static string _tTSTimerPaused = "Game timer paused";
        public static string _tTSTimerReset = "Game Timer Reset";

        //GENERICS
        public static string _radiant = "Radiant";
        public static string _dire = "Dire";
        public static string _null = "N/A";

        //ROSHAN
        private static string _roshanNumber = "Current Roshan #:";
        private static string _roshanLastDeath = "Last Death:";
        private static string _roshanDrops = "Drops:";

        private static string _roshDropsOne = "Aegis";
        private static string _roshDropsTwo = "Aegis && Cheese";
        private static string _roshDropsThreePlus = "Aegis, Cheese && Aghs Radiant/Dire Refresher";

        private static string[] _roshDrops = { _roshDropsOne, _roshDropsTwo, _roshDropsThreePlus };

        private static string _roshanNextSpawns = "Next Spawn Interval:";

        //AEGIS
        private static string _aegisTimer = "Current Aegis Timer:";
        private static string _aegisInPlay = "Aegis in Play:";

        //ROSHAN TTS AEGIS
        public static string _tTSRoshanDied = "R I P Roshan";
        public static string _tTSAegisDied = "Aegis carrier dead";

        private static string _tTSRoshanMinReminder = "Roshan potentially respawning in";
        private static string _tTSRoshanMaxReminder = "Roshan definitely respawning in";

        //TORMENTOR
        private static string _tormentorSpawn = "Tormentor Spawn:";
        private static string _tormentorDied = "Tormentor Killed";

        //LOTUS
        private static string _lotusSpawn = "Next Lotus Spawn:";
        private static string _tTSlotusReminder = "Lotuses spawning in";

        //WISDOM
        private static string _wisdomSpawn = "Next Wisdom Rune Spawn";
        private static string _tTSWisdomReminder = "Wisdom runes spawning in";


        //NEUTRALITEMS
        private static string _neutralsTooEarly = "Too early for Neutral drops.";
        private static string _neutralsNextTierAt = "Next tier starts at";

        public static string _tTSNeutralTierChange = "Entering next neutral tier.";
        
        
        
        private static string BuildTimeStampString(string baseString, TimeSpan timeStamp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(baseString);
            sb.Append(" ");
            sb.Append(timeStamp.ToString("mm\\:ss"));                      

            return sb.ToString();
        }

        private static string BuildTimeStampStringNA(string baseString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(baseString);
            sb.Append(" ");
            sb.Append(_null);

            return sb.ToString();
        }
        public static string RoshIntToDropsString(int roshNum)
        {
            string dropsString;

            switch (roshNum)
            {
                case 1:
                    dropsString = _roshDrops[0];
                    break;
                case 2:
                    dropsString = _roshDrops[1];
                    break;
                case >= 3:
                    dropsString = _roshDrops[2];
                    break;
                default:
                    dropsString = _roshDrops[0];
                    break;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(_roshanDrops);
            sb.Append(" ");
            sb.Append(dropsString);
            return sb.ToString();
        }

        public static string RoshIntToNumberString(int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_roshanNumber);
            sb.Append(" ");
            sb.Append(number);

            return sb.ToString();
        }

        public static string RoshRespawnsToString(TimeSpan minTime, TimeSpan maxTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_roshanNextSpawns);
            sb.Append(" ");
            sb.Append(minTime.ToString("mm\\:ss"));
            sb.Append(" - ");
            sb.Append(maxTime.ToString("mm\\:ss"));

            return sb.ToString();
        }
        public static string RoshRespawnsNull()
        {
            return BuildTimeStampStringNA(_roshanNextSpawns);
        }

        public static string RoshanLastDeath(TimeSpan timeStamp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_roshanLastDeath);
            sb.Append(" ");
            if(timeStamp == TimeSpan.Zero)
            {
                sb.Append("_null");
                return sb.ToString();
            }
            sb.Append(timeStamp.ToString("mm\\:ss"));

            return sb.ToString();
        }

        public static string AppendStringsWhiteSpaced(string stringA, string stringB)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(stringA);
            sb.Append(" ");
            sb.Append(stringB);

            return sb.ToString();
        }

        public static string BuildTTSReminder(string stringA, TimeSpan time)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(stringA);
            sb.Append(" ");
            sb.Append(time.ToString("mm\\:ss"));
            sb.Append(" ");
            sb.Append("minutes.");

            return sb.ToString();
        }

        public static string AegisInPlay(bool b)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_aegisInPlay);
            sb.Append(" ");
            if (b) { sb.Append("Yes"); }
            else { sb.Append("No"); }
            return sb.ToString();

        }
    }
}
