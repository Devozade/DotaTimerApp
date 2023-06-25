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
        private TimeSpan _aegisexpirytime;

        private readonly int _roshanRespawnMinMinutes = 8;
        private readonly int _roshanRespawnMaxMinutes = 11;
        private readonly int _TormentorInitialSpawnMinutes = 20;
        private readonly int _TormentorRespawnMinutes = 10;

        private readonly int _lotusRespawnIntervalMinutes = 3;
        private readonly int _wisdomRuneRespawnMinutes = 7;

        private readonly int _aegisExpiryTimerMinutes = 5;

        public int _roshanReminderEarlyMinutes = 2;
        public int _wisdomRuneReminderEarlyMinutes = 1;

        //always make sure these are in hh:mm:ss
        private readonly string _neutralTier1 = "00:07:00";
        private readonly string _neutralTier2 = "00:17:00";
        private readonly string _neutralTier3 = "00:27:00";
        private readonly string _neutralTier4 = "00:36:40";
        private readonly string _neutralTier5 = "00:60:00";

        public ImportantDotaTimes()
        {
            Initialize();
        }
        private void Initialize()
        {
            _lastRoshanDeath = TimeSpan.Zero;
            _lastRadiantTormentor = TimeSpan.Zero;
            _lastDireTormentor = TimeSpan.Zero;
            _currentRoshan = 1;
            _isAegisInPlay = false;
            _earliestRoshanSpawn = TimeSpan.Zero;
            _latestRoshanSpawn = TimeSpan.Zero;
            _isRadiantTormentorUp = false;
            _isDireTormentorUp = false;
            _nextLotusSpawn = TimeSpan.FromMinutes(_lotusRespawnIntervalMinutes);
            _nextWisdomRuneSpawn = TimeSpan.FromMinutes(_wisdomRuneRespawnMinutes);
            _currentNeutralTier = 0;
        }
        public (int, bool, TimeSpan, string, string, string) RoshanDied(TimeSpan currentTime)
        {
            _currentRoshan++;
            _isAegisInPlay = true;
            _lastRoshanDeath = currentTime;
            _aegisexpirytime = TimeSpanCalc.IncrementTime(currentTime, _aegisExpiryTimerMinutes);

            string roshanDrops = CheckRoshanDrops();
            (string earlyTime, string lateTime) = GetRoshanSpawnIntervals(currentTime);

            return (_currentRoshan, _isAegisInPlay, _lastRoshanDeath, roshanDrops, earlyTime, lateTime);
        }

        private string CheckRoshanDrops()
        {
            return _currentRoshan switch
            {
                1 => "Aegis",
                2 => "Aegis && Cheese",
                _ => "Aegis, Cheese && Aghs Radiant/Dire Refresher",
            };
        }
        public (string, string) GetRoshanSpawnIntervals(TimeSpan currentTime)
        {
            TimeSpan roshanDiedTime = currentTime;

            TimeSpan earliestSpawn = TimeSpanCalc.IncrementTime(roshanDiedTime, _roshanRespawnMinMinutes);

            TimeSpan latestSpawn = TimeSpanCalc.IncrementTime(roshanDiedTime, _roshanRespawnMaxMinutes);

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
            _isRoshanAlive = currentTime > _earliestRoshanSpawn;
            return _isRoshanAlive;
        }
        public void AegisCarrierDied()
        {
            _isAegisInPlay = false;
        }
        public TimeSpan NextTormentorSpawn(TimeSpan currentTime, bool team)
        {
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

            return TimeSpanCalc.IncrementTime(teamCalculated, _TormentorRespawnMinutes);
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
            return !team ? _isRadiantTormentorUp : _isDireTormentorUp;
        }

        public TimeSpan[] CheckAndUpdateFixedSpawns(TimeSpan currentTime)
        {

            TimeSpan[] returnedTimes = { TimeSpanCalc.TimeRemainingUntil(currentTime, _nextLotusSpawn), TimeSpanCalc.TimeRemainingUntil(currentTime, _nextWisdomRuneSpawn) };

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

            return 0;
        }
        public string ReturnNeutralTierText(int tier)
        {
            if (tier == 0)
            {
                return $"Too early for Neutral drops. Next tier starts at 7:00";
            }

            TimeSpan nextTierTime;

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
                return $"Current Neutral Item Tier: {tier}. Next tier starts at {timeStampText}";
            }           
        }

        public TimeSpan CheckAegisTimer(TimeSpan currentTime)
        {
            if (!_isAegisInPlay)
            {
                return TimeSpan.Zero;
            }

            TimeSpan timeDifference = TimeSpanCalc.TimeRemainingUntil(currentTime, _aegisexpirytime);

            if (timeDifference == TimeSpan.Zero)
            {
                _isAegisInPlay = false;
            }

            return timeDifference;
        }
        public bool[] CheckReminders(TimeSpan currentTime)
        {
            var listOfEvents = new List<(TimeSpan, int)>()
            {
                (_earliestRoshanSpawn, _roshanReminderEarlyMinutes),
                (_latestRoshanSpawn, _roshanReminderEarlyMinutes),
                (_nextWisdomRuneSpawn, _wisdomRuneReminderEarlyMinutes)
            };

            bool[] reminders = new bool[listOfEvents.Count];

            for(int i = 0; i < listOfEvents.Count; i++)
            {
                (TimeSpan nextEvent, int earlyReminder) = listOfEvents[i];

                TimeSpan timeToCheckFor = TimeSpanCalc.DecreaseTime(nextEvent, earlyReminder);

                if (TimeSpanCalc.TimeRemainingUntil(currentTime, timeToCheckFor) == TimeSpan.Zero)
                {
                    reminders[i] = true;
                }            
            }

            return reminders;
        }

        public void AegisExpired()
        {
            _isAegisInPlay = false;
        }
    }
}
