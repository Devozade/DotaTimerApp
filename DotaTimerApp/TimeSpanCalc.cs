namespace DotaTimerApp
{
    internal class TimeSpanCalc
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

    }
}
