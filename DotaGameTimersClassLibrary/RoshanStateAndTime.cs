using TimeSpanTools;

namespace DotaGameTimersClassLibrary
{
    public class RoshanStateTimes
    {
        private int _currentRoshanNumber;
        private TimeSpan _lastRoshanDeathTimeStamp;
        private bool _isAegisInPlay;
        private TimeSpan _aegisExpiryTimeStamp;
        private TimeSpan _earliestRoshanSpawnTimeStamp;
        private TimeSpan _latestRoshanSpawnTimeStamp;
        private bool _canRoshanBeAliveNow;
        private bool _IsRoshanAlive;

        public RoshanStateTimes()
        {
            SetDefaults();
        }
        private void SetDefaults()
        {
            _currentRoshanNumber = 1;
            _isAegisInPlay = false;
            _canRoshanBeAliveNow = true;
            _IsRoshanAlive = true;

            TimeSpan zero = TimeSpan.Zero;

            _lastRoshanDeathTimeStamp = zero;
            _aegisExpiryTimeStamp = zero;
            _earliestRoshanSpawnTimeStamp = zero;
            _latestRoshanSpawnTimeStamp = zero;
        }
        public int GetRoshNumber()
        {
            return _currentRoshanNumber;
        }
        public void SetKilled(TimeSpan currentTime)
        {
            UpdateKilledStatus(currentTime);
            SetRespawns(currentTime);
            SetAegisExpiry(currentTime);
            SetAegisInPlay();
        }
        private void SetAegisInPlay()
        {
            _isAegisInPlay = true;        
        }
        private void UpdateKilledStatus(TimeSpan currentTime)
        {
            _currentRoshanNumber++;
            _lastRoshanDeathTimeStamp = currentTime;
            _canRoshanBeAliveNow = false;
            _IsRoshanAlive = false;

        }
        private TimeSpan[] SetRespawns(TimeSpan currentTime)
        {
            TimeSpan[] roshanSpawns = new TimeSpan[2];

            TimeSpan roshanEarlyRespawnIncrease = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.RoshanRespawnMinMinutes);
            TimeSpan roshanLateRespawnIncrease = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.RoshanRespawnMaxMinutes);

            roshanSpawns[0] = TimeSpanCalcs.IncrementTime(currentTime, roshanEarlyRespawnIncrease);
            roshanSpawns[1] = TimeSpanCalcs.IncrementTime(currentTime, roshanLateRespawnIncrease);

            _earliestRoshanSpawnTimeStamp = roshanSpawns[0];
            _latestRoshanSpawnTimeStamp = roshanSpawns[1];

            return roshanSpawns;
        }
        public TimeSpan[] GetRespawnsRemaining(TimeSpan currentTime)
        {
            TimeSpan[] roshanRemaining = new TimeSpan[2];

            roshanRemaining[0] = TimeSpanCalcs.TimeRemainingUntil(currentTime, _earliestRoshanSpawnTimeStamp);

            roshanRemaining[1] = TimeSpanCalcs.TimeRemainingUntil(currentTime, _latestRoshanSpawnTimeStamp);

            UpdateRoshanFlags(roshanRemaining);

            return roshanRemaining;
        }
        public TimeSpan[] GetRespawns()
        {
            TimeSpan[] roshanSpawns = new TimeSpan[2];

            roshanSpawns[0] = _earliestRoshanSpawnTimeStamp;
            roshanSpawns[1] = _latestRoshanSpawnTimeStamp;

            return roshanSpawns;
        }
        public TimeSpan GetLastDeath()
        {
            return _lastRoshanDeathTimeStamp;
        }

        private void UpdateRoshanFlags(TimeSpan[] roshanRemaining)
        {
            if (roshanRemaining[0] == TimeSpan.Zero)
            {
                _canRoshanBeAliveNow = true;
            }
            if (roshanRemaining[1] == TimeSpan.Zero)
            {
                _IsRoshanAlive = true;
            }
        }

        private void SetAegisExpiry(TimeSpan currentTime)
        {
            TimeSpan roshanEarlyRespawnIncrease = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.AegisExpiryTimer);

            _aegisExpiryTimeStamp = TimeSpanCalcs.IncrementTime(currentTime, roshanEarlyRespawnIncrease);
        }

        public TimeSpan GetAegisRemaining(TimeSpan currentTime)
        {
            TimeSpan aegisremains = TimeSpanCalcs.TimeRemainingUntil(currentTime, _aegisExpiryTimeStamp);
            UpdateAegisFlag(aegisremains, currentTime);
            return aegisremains;
        }

        public TimeSpan GetAegisExpiryTimeStamp()
        {
            return _aegisExpiryTimeStamp;
        }

        private void UpdateAegisFlag(TimeSpan aegisRemaining, TimeSpan currentTime)
        {
            if (TimeSpanCalcs.HasTimeStampElapsed(currentTime, aegisRemaining))
            {
                _isAegisInPlay = false;
            }
            else
            {
                _isAegisInPlay = true;
            }
        }
        public bool IsAegisInPlay()
        {
            return _isAegisInPlay;
        }
        public bool[] IsRoshanAlive()
        {
            bool[] isAlive = new bool[2];
            isAlive[0] = _canRoshanBeAliveNow;
            isAlive[1] = _IsRoshanAlive;
            
            return isAlive;
        }

        public void ResetAll()
        {
            SetDefaults();
        }
    }
}
