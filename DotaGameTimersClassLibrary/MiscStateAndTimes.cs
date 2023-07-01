using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSpanTools;

namespace DotaGameTimersClassLibrary
{
    public class MiscStateAndTimes
    {
        private TimeSpan _nextWisdomRuneSpawn;
        private TimeSpan _nextLotusSpawn;

        public event EventHandler? LotusSpawned;
        public event EventHandler? WisdomRuneSpawned;

        public MiscStateAndTimes()
        {
            SetDefaults();
        }
        private void SetDefaults()
        {
            _nextLotusSpawn = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.LotusSpawnSeedTime);
            _nextWisdomRuneSpawn = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.WisdomRuneSpawnSeedTime);
        }
        public void ResetAll()
        {
            SetDefaults();
        }

        public TimeSpan GetWisdomRemaining(TimeSpan currentTime)
        {
            TimeSpan wisdomRemains = TimeSpanCalcs.TimeRemainingUntil(currentTime, _nextWisdomRuneSpawn);
            UpdateWisdomSpawn(currentTime);
            return wisdomRemains;
        }

        private void UpdateWisdomSpawn(TimeSpan currentTime)
        {
            if (TimeSpanCalcs.HasTimeStampElapsed(currentTime, _nextWisdomRuneSpawn))
            {
                _nextWisdomRuneSpawn = _nextWisdomRuneSpawn + TimeSpanCalcs.StringToTimespan(DotaTimeConstants.WisdomRuneRespawnTime);
                WisdomRuneSpawned?.Invoke(this, EventArgs.Empty);
            }
        }

        public TimeSpan GetNextWisdomSpawns()
        {
            return _nextWisdomRuneSpawn;
        }
        public TimeSpan GetLotusRemaining(TimeSpan currentTime)
        {
            TimeSpan lotusRemains = TimeSpanCalcs.TimeRemainingUntil(currentTime, _nextLotusSpawn);
            UpdateLotusSpawn(currentTime);
            return lotusRemains;
        }
        private void UpdateLotusSpawn(TimeSpan currentTime)
        {
            if (TimeSpanCalcs.HasTimeStampElapsed(currentTime, _nextLotusSpawn))
            {
                _nextLotusSpawn = _nextLotusSpawn + TimeSpanCalcs.StringToTimespan(DotaTimeConstants.LotusRespawnTime);
                LotusSpawned?.Invoke(this, EventArgs.Empty);
            }       
        }

        public TimeSpan GetNextLotusSpawns()
        {
            return _nextLotusSpawn;
        }

    }
}
