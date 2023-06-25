using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using System.Timers;

namespace DotaTimerApp
{
    internal class ImportantDotaTimes
    {
        public TimeSpan _lastRoshanDeath;
        public TimeSpan _lastRadiantTormentor;
        public TimeSpan _lastDireTormentor;
        private int _currentRoshan;
        public bool _isAegisInPlay;
        private TimeSpan _earliestRoshanSpawn;
        public TimeSpan _latestRoshanSpawn;
        private bool _isRadiantTormentorUp;
        private bool _isDireTormentorUp;
        private bool _isRoshanAlive;
        private TimeSpan _nextWisdomRuneSpawn;
        private TimeSpan _nextLotusSpawn;
        private int _currentNeutralTier;

        private int _roshanRespawnMinMinutes = 8;
        private int _roshanRespawnMaxMinutes = 11;
        private int _TormentorInitialSpawnMinutes = 20;
        private int _TormentorRespawnMinutes = 10;

        private int _lotusRespawnIntervalMinutes = 3;
        private int _wisdomRuneRespawnMinutes = 7;

        public int _roshanReminderEarlyMinutes = 2;
        public int _wisdomRuneReminderEarlyMinutes = 1;

        //always make sure these are in hh:mm:ss
        private string _neutralTier1 = "00:07:00";
        private string _neutralTier2 = "00:17:00";
        private string _neutralTier3 = "00:27:00";
        private string _neutralTier4 = "00:36:40";
        private string _neutralTier5 = "00:60:00";

        public ImportantDotaTimes()
        {
            Initialize();
        }
        private void Initialize()
        {
            _lastRoshanDeath = new TimeSpan(0);
            _lastRadiantTormentor = new TimeSpan(0);
            _lastDireTormentor = new TimeSpan(0);
            _currentRoshan = 1;
            _isAegisInPlay = false;
            _earliestRoshanSpawn = TimeSpan.Zero;
            _latestRoshanSpawn = TimeSpan.Zero;
            _isRadiantTormentorUp = false;
            _isDireTormentorUp = false;
            _nextLotusSpawn = TimeSpan.FromMinutes(_lotusRespawnIntervalMinutes);
            _nextWisdomRuneSpawn = TimeSpan.FromMinutes(_wisdomRuneRespawnMinutes);
            _currentNeutralTier = 1;
        }
        public (int, bool, TimeSpan, string) RoshanDied(TimeSpan currentTime)
        {
            _currentRoshan++;
            _isAegisInPlay = true;
            _lastRoshanDeath = currentTime;
            string roshanDrops = CheckRoshanDrops();

            return (_currentRoshan, _isAegisInPlay, _lastRoshanDeath, roshanDrops);
        }

        private string CheckRoshanDrops()
        {
            switch (_currentRoshan)
            {
                case 1:
                    return "Aegis";
                case 2:
                    return "Aegis && Cheese";
                case >= 3:
                    return "Aegis, Cheese && Aghs Radiant/Dire Refresher";
                default:
                    return "Aegis";
            }
        }
        public (string, string) GetRoshanSpawnIntervals(TimeSpan currentTime)
        {
            TimeSpan roshanDiedTime = currentTime;

            var earliestSpawn = roshanDiedTime.Add(TimeSpan.FromMinutes(_roshanRespawnMinMinutes));

            var latestSpawn = roshanDiedTime.Add(TimeSpan.FromMinutes(_roshanRespawnMaxMinutes));

            _earliestRoshanSpawn = earliestSpawn;
            _latestRoshanSpawn = latestSpawn;

            return (earliestSpawn.ToString("mm\\:ss"), latestSpawn.ToString("mm\\:ss"));
        }

        public void ResetAll()
        {
            Initialize();
        }
        public bool IsRoshanAlive(TimeSpan currentTime)
        {
            if (currentTime > _earliestRoshanSpawn)
            {
                _isRoshanAlive = true;
                return true;

            }
            _isRoshanAlive = false;
            return false;
        }
        public void AegisCarrierDied()
        {
            _isAegisInPlay = false;
        }
        public TimeSpan NextTormentorSpawn(TimeSpan currentTime, bool team)
        {
            // team - 0 radiant - 1 dire

            if (currentTime < TimeSpan.FromMinutes(_TormentorInitialSpawnMinutes))
            {
                return TimeSpan.FromMinutes(_TormentorInitialSpawnMinutes);
            }

            TimeSpan teamCalculated;

            if (!team)
            {
                teamCalculated = _lastRadiantTormentor;
            }
            else
            {
                teamCalculated = _lastDireTormentor;
            }

            TimeSpan nextSpawn = teamCalculated + TimeSpan.FromMinutes(_TormentorRespawnMinutes);

            return nextSpawn;

        }

        public void KillTormentor(TimeSpan currentTime, bool team)
        {
            if (!team)
            {
                _isRadiantTormentorUp = false;
                _lastRadiantTormentor = currentTime;
            }
            else
            {
                _isDireTormentorUp = false;
                _lastDireTormentor = currentTime;
            }
        }

        public bool IsTormentorUp(bool team)
        {
            if (!team)
            {
                return _isRadiantTormentorUp;
            }
            else
            {
                return _isDireTormentorUp;
            }
        }

        public TimeSpan[] CheckAndUpdateFixedSpawns(TimeSpan currentTime)
        {

            TimeSpan[] returnedTimes = { TimeRemaining(_nextLotusSpawn, currentTime), TimeRemaining(_nextWisdomRuneSpawn, currentTime) };

            if (returnedTimes[0] == TimeSpan.Zero)
            {
                _nextLotusSpawn += TimeSpan.FromMinutes(_lotusRespawnIntervalMinutes);
            }
            if (returnedTimes[1] == TimeSpan.Zero)
            {
                _nextWisdomRuneSpawn += TimeSpan.FromMinutes(_wisdomRuneRespawnMinutes);
            }

            return returnedTimes;
        }

        public TimeSpan TimeRemaining(TimeSpan checkTime, TimeSpan currentTime)
        {

            return checkTime - currentTime;
        }

        public int CheckNeutralTier(TimeSpan currentTime)
        {
            int tier;

            if (currentTime < TimeSpan.Parse(_neutralTier1))
            {
                tier = 0;
                return tier;
            }

            if (currentTime < TimeSpan.Parse(_neutralTier2))
            {
                tier = 1;
                return tier;
            }

            if (currentTime < TimeSpan.Parse(_neutralTier3))
            {
                tier = 2;
                return tier;
            }
            if (currentTime < TimeSpan.Parse(_neutralTier4))
            {
                tier = 3;
                return tier;
            }
            if (currentTime < TimeSpan.Parse(_neutralTier5))
            {
                tier = 4;
                    return tier;
            }
            if (currentTime > TimeSpan.Parse(_neutralTier5))
            {
                tier = 5;
                return tier;
            }

            tier = 0;
            return tier;
        }
        public string ReturnNeutralTierText(int tier)
        {
            if (tier == 0)
            {
                return $"Too early for Neutral drops. Next tier starts at 7:00";
            }

            TimeSpan nextTierTime = new();

            switch (tier)
            {
                case 1:
                    nextTierTime = TimeSpan.Parse(_neutralTier2);
                    break;
                case 2:
                    nextTierTime = TimeSpan.Parse(_neutralTier3);
                    break;
                case 3:
                    nextTierTime = TimeSpan.Parse(_neutralTier4);
                    break;
                case 4:
                    nextTierTime = TimeSpan.Parse(_neutralTier5);
                    break;
                case 5:
                    nextTierTime = TimeSpan.Zero;
                    break;
                default:
                    nextTierTime = TimeSpan.Parse(_neutralTier1);
                    break;
            }

            string timeStampText = nextTierTime.ToString("mm\\:ss");

            if (nextTierTime == TimeSpan.Zero)
            {
                return "$Current Neutral Item Tier: 5";
            }
            else
            {
                return $"Current Neutral Item Tier: {tier.ToString()}. Next tier starts at {timeStampText}";
            }           
        }

        public TimeSpan CheckAegisTimer(TimeSpan currentTime)
        {
            if (!_isAegisInPlay)
            {
                return TimeSpan.Zero;
            }
            TimeSpan timeDifference = currentTime - (_lastRoshanDeath + TimeSpan.FromMinutes(5));

            if (timeDifference == TimeSpan.Zero)
            {
                _isAegisInPlay = false;
            }

            return timeDifference;
        }
        // to complete
        public bool[] CheckReminders(TimeSpan currentTime)
        {
            TimeSpan[] nextSpawnsToCheckFor = { _earliestRoshanSpawn, _nextLotusSpawn };
            int[] earlyReminderMinutes = { _roshanReminderEarlyMinutes, _wisdomRuneReminderEarlyMinutes };

            TimeSpan[] reminderTimes = new TimeSpan[nextSpawnsToCheckFor.Length];

            for (int i=0; i < nextSpawnsToCheckFor.Length; i++ )
            {
                TimeSpan checkTime = nextSpawnsToCheckFor[i];
                int reminderWindow = earlyReminderMinutes[i];

                TimeSpan triggerTime = checkTime - TimeSpan.FromMinutes(reminderWindow);
                reminderTimes[i] = triggerTime;
            }

            bool[] eventNeedsTriggering = new bool[reminderTimes.Length];

            for (int i = 0; i < reminderTimes.Length; i++)
            {
                if (currentTime == reminderTimes[i])
                {
                    eventNeedsTriggering[i] = true;
                }
            }
            return eventNeedsTriggering;           
        }
    }
}
