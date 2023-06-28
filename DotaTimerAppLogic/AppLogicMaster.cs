using StopWatchWithTimerLogic;
using DotaGameTimersClassLibrary;

namespace DotaTimerAppLogic
{
    internal class AppLogicMaster
    {
        private StopwatchLogic _dotaTimerCurrent;

        private RoshanStateAndTimes _roshanState = new();
        private TormentorsStateAndTimes _tormentorstate = new();
        private MiscStateAndTimes _miscState = new();
        private NeutralItemStateAndTimes _neutralItemState = new();

        private ButtonEnableDisableLogic _buttonstates = new();
        private StringLogic _stringStates = new();
        private NeutralImageLogic _neutralImageLogic = new();        

        public AppLogicMaster()
        {
            _dotaTimerCurrent = new StopwatchLogic();
            _dotaTimerCurrent.DotaStopwatchSecondElapsed += StopwatchLogic_DotaStopwatchSecondElapsed;
        }
        private void StopwatchLogic_DotaStopwatchSecondElapsed(object sender, EventArgs e)
        {
            _stringStates.UpdateMainTimer(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());
            _stringStates.UpdateTimerStrings(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());
        }

        public void TimerStart()
        {
            _dotaTimerCurrent.Start();
        }

        public void TimerPause()
        {
            _dotaTimerCurrent.Pause();
        }

        public void TimerReset()
        {
            _dotaTimerCurrent.Reset();
        }

        public void RoshanDied()
        {
            _roshanState.SetKilled(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());

        }
        public void AegisCarrierDied()
        {
            _roshanState.AegisCarrierDead();
        }
        public void RadiantTormentorDied()
        {
            _tormentorstate.KillRadiantTormentor(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());
        }
        public void DireTormentorDied()
        {
            _tormentorstate.KillDireTormentor(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());
        }

    }
}
