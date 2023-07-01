using StopWatchWithTimerLogic;
using DotaGameTimersClassLibrary;
using System.Drawing;

namespace DotaTimerAppLogic
{
    public class AppLogicMaster
    {
        private StopwatchLogic _dotaTimerCurrent;

        private RoshanStateAndTimes _roshanState = new();
        private TormentorsStateAndTimes _tormentorstate = new();
        private MiscStateAndTimes _miscState = new();
        private NeutralItemStateAndTimes _neutralItemState = new();

        private ButtonLogic _buttonstates = new();
        private StringLogic _stringStates = new();
        private DotaTimerImages.NeutralImage _neutralImage = new();

        public event EventHandler? UpdateTextLabels;
        public event EventHandler? UpdateButtons;
        public event EventHandler? GetImages;
        public event EventHandler? UpdateNeutralImage;

        public AppLogicMaster()
        {
            _dotaTimerCurrent = new StopwatchLogic();            
            _dotaTimerCurrent.DotaStopwatchSecondElapsed += StopwatchLogic_DotaStopwatchSecondElapsed;

            _roshanState.MinSpawnReached += RoshMinSpawnReached;
            _roshanState.MaxSpawnReached += RoshMaxSpawnReached;
            _roshanState.AegisExpired += AegisExpired;

            _tormentorstate.RadiantTormentorSpawned += RadiantTormentorSpawnTrigger;
            _tormentorstate.DireTormentorSpawned += DireTormentorSpawnTrigger;

            _neutralItemState.NextNeutralTier += NeutralTierTrigger;

            GetImages?.Invoke(this, EventArgs.Empty);

        }

        private void AegisExpired(object? sender, EventArgs e)
        {
            _stringStates.AegisDefaults();
            _buttonstates.AegisExpired();
        }

        private void RoshMaxSpawnReached(object? sender, EventArgs e)
        {
            //nothing yet
        }

        private void RoshMinSpawnReached(object? sender, EventArgs e)
        {
            _buttonstates.RoshPotentiallyRespawned();
        }

        private async void StopwatchLogic_DotaStopwatchSecondElapsed(object? sender, EventArgs e)
        {
            _stringStates.UpdateMainTimer(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());
            UpdateSubTimersChecks();
            UpdateFixedTimers();

            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
            UpdateNeutralImage?.Invoke(this, EventArgs.Empty);
        }

        public List<(string, bool)> GetButtons()
        {
            List<(string, bool)> buttonstates = new List<(string, bool)>();
                
            buttonstates = _buttonstates.UpdateAllButtons();

            return buttonstates;
        }

        public List<(string, string)> GetTextLabels()
        {
            List<(string, string)> labelsText = new List<(string, string)>();

            labelsText = _stringStates.UpdateAllLabels();

            return labelsText;
        }
        private void UpdateSubTimersChecks()
        {
            TimeSpan currentTime = _dotaTimerCurrent.GetCurrentTimeToNearestSecond();
            
            if (_roshanState.IsAegisInPlay())
            {
                UpdateAegisTimer(currentTime);
            }

            bool[] tormentorsState = _tormentorstate.AreTormentorsUp();

            if (tormentorsState[0])
            {
                UpdateRadiantTormentorTimer(currentTime);
            }

            if (tormentorsState[1])
            {
                UpdateDireTormentorTimer(currentTime);
            }
        }
        private void UpdateAegisTimer(TimeSpan currentTime)
        {
            _stringStates.UpdateAegisTimer(_roshanState.GetAegisRemaining(currentTime));
        }
        private void UpdateRadiantTormentorTimer(TimeSpan currentTime)
        {
            TimeSpan[] timeLeft = _tormentorstate.GetRespawnsRemaining(currentTime);
            _stringStates.UpdateRadiantTormentorSpawn(timeLeft[0]);
        }
        private void UpdateDireTormentorTimer(TimeSpan currentTime)
        {
            TimeSpan[] timeLeft = _tormentorstate.GetRespawnsRemaining(currentTime);
            _stringStates.UpdateDireTormentorSpawn(timeLeft[1]);
        }
        private void RadiantTormentorSpawnTrigger(object? sender, EventArgs e)
        {
            _stringStates.RadiantTormentorAlive();
        }
        private void DireTormentorSpawnTrigger(object? sender, EventArgs e)
        {
            _stringStates.DireTormentorAlive();
        }
        private void UpdateFixedTimers()
        {
            TimeSpan currentTime = _dotaTimerCurrent.GetCurrentTimeToNearestSecond();

            _stringStates.UpdateLotusSpawn(_miscState.GetLotusRemaining(currentTime));
            _stringStates.UpdateWisdomRuneSpawn(_miscState.GetWisdomRemaining(currentTime));

            int[] neutralTiers= _neutralItemState.GetCurrentAndNextTier();

            _stringStates.UpdateNeutralTier(neutralTiers[0], _neutralItemState.GetNextTierTime());
        }
        private void LotusSpawnTrigger(object? sender, EventArgs e)
        {

        }
        private void WisdomSpawnTrigger(object? sender, EventArgs e)
        {

        }
        private void NeutralTierTrigger(object? sender, EventArgs e)
        {
            int[] tier = _neutralItemState.GetCurrentAndNextTier();
            TimeSpan nextTier = _neutralItemState.GetNextTierTime();
            _stringStates.UpdateNeutralTier(tier[0], nextTier);
        }
        public void TimerStart()
        {
            if (_dotaTimerCurrent.GetCurrentTime() != TimeSpan.Zero)
            {
                _dotaTimerCurrent.Start();
                bool[] tormentorState = _tormentorstate.AreTormentorsUp();
                bool[] roshanState = _roshanState.IsRoshanAlive();

                _buttonstates.TimerResumed(roshanState[0] , _roshanState.IsAegisInPlay(), tormentorState[0], tormentorState[1]);
                UpdateTextLabels?.Invoke(this, EventArgs.Empty);
                UpdateButtons?.Invoke(this, EventArgs.Empty);
                return;
            }

            _dotaTimerCurrent.Start();
            _buttonstates.TimerStarted();
            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
        }

        public void TimerPause()
        {
            _dotaTimerCurrent.Pause();
            _buttonstates.TimerPaused();
            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
        }

        public void TimerReset()
        {
            _dotaTimerCurrent.Reset();
            _stringStates.ResetDefaults();
            _buttonstates.Defaults();
            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
        }

        public void RoshanDied()
        {
            TimeSpan currentTime = _dotaTimerCurrent.GetCurrentTimeToNearestSecond();
            _roshanState.SetKilled(currentTime);
            _stringStates.UpdateRoshanDeathStamp(_roshanState.GetLastDeath());

            int roshNum = _roshanState.GetRoshNumber();
            _stringStates.IncrementRoshanAndDrops(roshNum);

            TimeSpan[] roshSpawns = _roshanState.GetRespawns();
            _stringStates.UpdateRoshanPossibleSpawns(roshSpawns[0], roshSpawns[1]);

            RoshDiedSetAegis(currentTime);

            _buttonstates.RoshDied();
            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
        }
        public void RoshDiedSetAegis(TimeSpan currentTime)
        {
            _stringStates.UpdateAegisinPlay(_roshanState.IsAegisInPlay());

            _stringStates.UpdateAegisTimer(_roshanState.GetAegisRemaining(currentTime));
        }
        public void AegisCarrierDied()
        {
            _roshanState.AegisCarrierDead();
            _stringStates.AegisDefaults();
            _buttonstates.AegisExpired();
            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
        }
        public void RadiantTormentorDied()
        {            
            _tormentorstate.KillRadiantTormentor(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());
            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
        }
        public void DireTormentorDied()
        {
            _tormentorstate.KillDireTormentor(_dotaTimerCurrent.GetCurrentTimeToNearestSecond());
            UpdateTextLabels?.Invoke(this, EventArgs.Empty);
            UpdateButtons?.Invoke(this, EventArgs.Empty);
        }

    }
}
