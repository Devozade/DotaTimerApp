using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TimeSpanTools
{
    public class TimeSpanCalcs
    {
        public static TimeSpan TimeRemainingUntil(TimeSpan currentTime, TimeSpan timeToCheckAgainst)
        {
            TimeSpan difference = timeToCheckAgainst - currentTime;
            return difference;
        }

        public static TimeSpan TimeSince(TimeSpan currentTime, TimeSpan timeToCheckAgainst)
        {
            TimeSpan difference = currentTime - timeToCheckAgainst;

            return difference;
             
        }

        public static TimeSpan IncrementTime(TimeSpan currentTimeSpan, int timeToAddMinutes)
        {
            TimeSpan newTime = currentTimeSpan + TimeSpan.FromMinutes(timeToAddMinutes);

            return newTime;
        }
        public static TimeSpan IncrementTime(TimeSpan currentTimeSpan, TimeSpan timeToAddMinutes)
        {
            TimeSpan newTime = currentTimeSpan + timeToAddMinutes;

            return newTime;
        }
        public static TimeSpan IncrementTime(string timeStampStart, string timeStampToAdd)
        {
            return TimeSpan.Parse(timeStampStart) + TimeSpan.Parse(timeStampToAdd);
        }
        public static TimeSpan DecreaseTime(TimeSpan currentTimeSpan, int timeToSubtractMinutes)
        {
            TimeSpan newTime = currentTimeSpan - TimeSpan.FromMinutes(timeToSubtractMinutes);

            return newTime;
        }

        public static TimeSpan DecreaseTime(TimeSpan currentTimeSpan, TimeSpan timeToSubtractMinutes)
        {
            TimeSpan newTime = currentTimeSpan - timeToSubtractMinutes;

            return newTime;
        }

        public static TimeSpan StringToTimespan(string timeString)
        {
         return TimeSpan.Parse(timeString);
        }
        public static bool HasTimeStampElapsed(TimeSpan currentTime, TimeSpan timeToCheck)
        {
            if (currentTime >= timeToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsZero(TimeSpan input)
        {
            if (input == TimeSpan.Zero)
            {
                return true;
            }
            return false;        
        }
        public static double TimeStampToMinutes(string timeString)
        {
            TimeSpan tempTime = TimeSpan.Parse(timeString);

            return tempTime.TotalMinutes;

        }

    }
}
