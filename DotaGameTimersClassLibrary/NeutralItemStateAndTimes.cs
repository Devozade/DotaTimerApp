using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TimeSpanTools;

namespace DotaGameTimersClassLibrary
{
    public class NeutralItemStateAndTimes
    {
        private int _currentNeutralTier;
        private int _nextNeutralTier;
        private TimeSpan _nextTierTime;

        public NeutralItemStateAndTimes()
        {
            SetDefaults();        
        }
        public void SetDefaults()
        {
            _currentNeutralTier = 0;
            _nextNeutralTier = 1;
            _nextTierTime = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.NeutralTier1Time);
        }
        public void ResetAll()
        {
            SetDefaults();
        }
        public void IncrementCurrentTier()
        {
            if (_currentNeutralTier < 5)
            {
                _currentNeutralTier++;
            }            
            IncrementNextTier();
        }
        public void IncrementNextTier()
        {
        if (_currentNeutralTier == 5 )
            {
                _nextNeutralTier = 5;
                SetNextTierTimeStamp(5);
                return;
            }
            _nextNeutralTier = _currentNeutralTier + 1;
            SetNextTierTimeStamp(_nextNeutralTier);
        }
        public void SetNextTierTimeStamp(int num)
        {
            string tierTime = DotaTimeConstants.NeutralTierTimeArray[num];

            _nextTierTime = TimeSpanCalcs.StringToTimespan(tierTime);

        }
        public int[] GetCurrentAndNextTier()
        {
            int[] tiers = new int[2];

            tiers[0] = _currentNeutralTier;
            tiers[1] = _nextNeutralTier;

            return tiers;
        }
        public TimeSpan GetNextTierTime()
        {
        return _nextTierTime;
        }
        public TimeSpan TimeRemainingUntilNextTier(TimeSpan currentTime)
        {
            TimeSpan timeLeft = TimeSpanCalcs.TimeRemainingUntil(currentTime, _nextTierTime);

            UpdateTiersFlag(timeLeft);

            return timeLeft;        
        }
        private void UpdateTiersFlag(TimeSpan timeLeft)
        {
            if (timeLeft == TimeSpan.Zero)
            {
                IncrementCurrentTier();
            }
        }
    }
}
