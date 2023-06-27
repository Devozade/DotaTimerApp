using TimeSpanTools;

namespace DotaGameTimersClassLibrary
{
    public class TormentorsStateAndTime
    {
        private TimeSpan _lastRadiantDeath;
        private TimeSpan _lastDireDeath;
        private TimeSpan _nextRadiantRespawn;
        private TimeSpan _nextDireRespawn;

        private bool _isRadiantUp;
        private bool _isDireUp;

        public TormentorsStateAndTime()
        {
            SetDefaults();
        }
        private void SetDefaults()
        {
            _isRadiantUp = false;
            _isDireUp = false;
            _nextRadiantRespawn = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.TormentorSpawnSeed);
            _nextDireRespawn = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.TormentorSpawnSeed);

            TimeSpan zero = TimeSpan.Zero;

            _lastRadiantDeath = zero;
            _lastDireDeath = zero;
        }
        public void ResetAll()
        {
            SetDefaults();
        }
        public void KillRadiantTormentor(TimeSpan currentTime)
        {
            _isRadiantUp = false;
            _lastRadiantDeath = currentTime;
            _nextRadiantRespawn = SetRespawn(currentTime);
        }
        public void KillDireTormentor(TimeSpan currentTime)
        {
            _isDireUp = false;
            _lastDireDeath = currentTime;
            _nextDireRespawn = SetRespawn(currentTime);
        }
        private TimeSpan SetRespawn(TimeSpan currentTime)
        {
           return TimeSpanCalcs.IncrementTime(currentTime, TimeSpanCalcs.StringToTimespan(DotaTimeConstants.TormentorRespawnTime));
        }
        public TimeSpan[] GetRespawns()
        {
            TimeSpan[] respawns = new TimeSpan[2];

            respawns[0] = _nextRadiantRespawn;
            respawns[1] = _nextDireRespawn;

            return respawns;
        }

        public TimeSpan[] GetRespawnsRemaining(TimeSpan currentTime)
        {
            TimeSpan[] tormentorRemaining = new TimeSpan[2];

            tormentorRemaining[0] = TimeSpanCalcs.TimeRemainingUntil(currentTime, _nextRadiantRespawn);

            tormentorRemaining[1] = TimeSpanCalcs.TimeRemainingUntil(currentTime, _nextDireRespawn);

            UpdateTormentorFlags(tormentorRemaining);

            return tormentorRemaining;
        }
        public TimeSpan[] GetLastDeaths()
        {
            TimeSpan[] deaths = new TimeSpan[2];
            deaths[0] = _lastRadiantDeath;
            deaths[1] = _lastDireDeath;

            return deaths;
        }
        private void UpdateTormentorFlags(TimeSpan[] tormentorRemaining)
        {
            if (tormentorRemaining[0] == TimeSpan.Zero)
            {
                _isRadiantUp = true;
            }
            if (tormentorRemaining[1] == TimeSpan.Zero)
            {
                _isDireUp = true;
            }
        }
        public bool[] AreTormentorsUp()
        {
            bool[] up = new bool[2];
            up[0] = _isRadiantUp;
            up[1] = _isDireUp;

            return up;
        }
    }      
}
