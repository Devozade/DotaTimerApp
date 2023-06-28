using System.Diagnostics;
using System.Timers;

namespace StopWatchWithTimerLogic
{
    public class StopwatchLogic
    {
        private Stopwatch dotaStopwatch;
        private System.Timers.Timer dotaTimer;
        private TimeSpan currentTime;

        public StopwatchLogic()
        {
            dotaStopwatch = new Stopwatch();
            dotaTimer = new System.Timers.Timer(1000);
            dotaTimer.Elapsed += TimerElapsed;
        }

        public void Start()
        {
            dotaStopwatch.Start();
            dotaTimer.Start();
        }

        public void Pause()
        {
            dotaStopwatch.Stop();
            dotaTimer.Stop();
        }

        public TimeSpan GetCurrentTime()
        {
            return currentTime;
        }

        public TimeSpan GetCurrentTimeToNearestSecond()
        {
            TimeSpan trimmedTime = new TimeSpan(currentTime.Days, currentTime.Hours, currentTime.Minutes, currentTime.Seconds);

            return trimmedTime;
        }
        public void Reset()
        {
            dotaTimer.Stop();
            dotaStopwatch.Reset();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (dotaStopwatch.Elapsed.Seconds % 1 == 0)
            {
                currentTime = dotaStopwatch.Elapsed;
                OnEventOccured();
            }
        }

        public event EventHandler DotaStopwatchSecondElapsed;

        protected virtual void OnEventOccured()
        {

            DotaStopwatchSecondElapsed?.Invoke(this, EventArgs.Empty);

        }

        public bool IsRunning()
        {
            return dotaStopwatch.IsRunning;
        }

    }
}
