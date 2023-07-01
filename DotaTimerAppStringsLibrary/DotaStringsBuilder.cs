using System.Text;

namespace DotaTimerAppStringsLibrary
{
    public static class DotaStringsBuilder
    {
        public static string RoshIntToNumberString(int number)
        {
            return AppendString(TimerAppStrings._roshanNumber, number.ToString());                       
        }

        public static string RoshanLastDeathToString(TimeSpan timeStamp)
        {
            return AppendString(TimerAppStrings._roshanLastDeath, timeStamp.ToString("mm\\:ss"));
        }

        public static string RoshanLastDeathToStringDefault()
        {
            return AppendString(TimerAppStrings._roshanLastDeath, TimerAppStrings._null);
        }
        public static string RoshIntToDropsString(int roshNum)
        {
            string dropsString;

            string[] roshanDrops = TimerAppStrings._roshDrops;


            switch (roshNum)
            {
                case 1:
                    dropsString = roshanDrops[0];
                    break;
                case 2:
                    dropsString = roshanDrops[1];
                    break;
                case >= 3:
                    dropsString = roshanDrops[2];
                    break;
                default:
                    dropsString = roshanDrops[0];
                    break;
            }

            return AppendString(TimerAppStrings._roshanDrops, dropsString);
        }
        public static string RoshRespawnsToString(TimeSpan minTime, TimeSpan maxTime)
        {
            string partialString;
            string timeConvertMin = minTime.ToString("mm\\:ss");
            string timeConvertMax = $"- { maxTime.ToString("mm\\:ss") }";

            partialString = AppendString(TimerAppStrings._roshanNextSpawns, timeConvertMin);
            partialString = AppendString(partialString, timeConvertMax);

            return partialString;
        }
        public static string RoshRespawnsDefault()
        {            
            string timeNA = TimerAppStrings._null;

            return AppendString(TimerAppStrings._roshanNextSpawns, timeNA);
        }
        public static string AegisTimer(TimeSpan remaining)
        {
            return AppendString(TimerAppStrings._aegisTimer, remaining.ToString("mm\\:ss"));
        }
        public static string AegisTimerDefault()
        {
            return AppendString(TimerAppStrings._aegisTimer, TimerAppStrings._null);
        }
        public static string AegisInPlay(bool b)
        {
            string boolResult;
            if (b == true)
            {
                boolResult = "Yes";
            }
            else
            {
                boolResult = "No";
            }

            return AppendString(TimerAppStrings._aegisInPlay, boolResult);
        }
        public static string RadiantTormentorTimer(TimeSpan remaining)
        {
            string partial = AppendString(TimerAppStrings._radiant, TimerAppStrings._tormentorSpawn);

            return AppendString(partial, remaining.ToString("mm\\:ss"));
        }
        public static string DireTormentorTimer(TimeSpan remaining)
        {
            string partial = AppendString(TimerAppStrings._dire, TimerAppStrings._tormentorSpawn);

            return AppendString(partial, remaining.ToString("mm\\:ss"));
        }
        public static string RadiantTormentorAlive()
        {
            string partial = AppendString(TimerAppStrings._radiant, TimerAppStrings._tormentorSpawn);

            return AppendString(partial, TimerAppStrings._null);
        }
        public static string DireTormentorAlive()
        {
            string partial = AppendString(TimerAppStrings._dire, TimerAppStrings._tormentorSpawn);

            return AppendString(partial, TimerAppStrings._null);
        }

        public static string LotusSpawn(TimeSpan remaining)
        {
            return AppendString(TimerAppStrings._lotusSpawn, remaining.ToString("mm\\:ss"));
        }
        public static string WisdomSpawn(TimeSpan remaining)
        {
            return AppendString(TimerAppStrings._wisdomSpawn, remaining.ToString("mm\\:ss"));
        }

        public static string NeutralTier(int tier, TimeSpan nextTierStamp)
        {
            string partial;
            string intString = tier.ToString();
            switch (tier)
            {
                case 1:
                    partial = AppendString(TimerAppStrings._neutralsCurrentTier, intString);
                    break;
                case 2:
                    partial = AppendString(TimerAppStrings._neutralsCurrentTier, intString);
                    break;
                case 3:
                    partial = AppendString(TimerAppStrings._neutralsCurrentTier, intString);
                    break;
                case 4:
                    partial = AppendString(TimerAppStrings._neutralsCurrentTier, intString);
                    break;
                case 5:
                    partial = AppendString(TimerAppStrings._neutralsCurrentTier, intString);
                    return partial;
                default:
                    partial = TimerAppStrings._neutralsTooEarly;
                    break;
            }

            string timeConvert = nextTierStamp.ToString("mm\\:ss");
            string nextTier = AppendString(TimerAppStrings._neutralsNextTierAt, timeConvert);

            partial = AppendString(partial, nextTier);
            
            return partial;
        }

        public static string MainTimerString(TimeSpan currentTime)
        {
            return currentTime.ToString(@"hh\:mm\:ss");        
        }
        public static string MainTimerStringDefault()
        {
            return TimeSpan.Zero.ToString(@"hh\:mm\:ss");
        }

        private static string AppendString(string first, string second)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(first);
            sb.Append(" ");
            sb.Append(second);
            return sb.ToString();
        }
    }
}
