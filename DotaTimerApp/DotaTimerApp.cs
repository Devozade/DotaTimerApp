using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DotaTimerApp
{
    public partial class DotaTimerAppForm : Form
    {
        private StopwatchLogic dotaTimerCurrent;
        private ImportantDotaTimes dotaTimes = new();

        public DotaTimerAppForm()
        {
            InitializeComponent();

            dotaTimerCurrent = new StopwatchLogic();

            dotaTimerCurrent.DotaStopwatchSecondElapsed += StopwatchLogic_DotaStopwatchSecondElapsed;

            InitialiseDefaultLabels();
            CheckButtonAuthorisation();
        }
        private void StopwatchLogic_DotaStopwatchSecondElapsed(object sender, EventArgs e)
        {
            TimeSpan elapsedTimeSeconds = dotaTimerCurrent.GetCurrentTimeToNearestSecond();

            UpdateTimeLabel(elapsedTimeSeconds);
            CheckButtonAuthorisation();
            CheckCountdownLabels(elapsedTimeSeconds);
            //CheckReminders(elapsedTimeSeconds);
        }
        private void startTimerButton_Click(object sender, EventArgs e)
        {
            dotaTimerCurrent.Start();
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething("Game timer started.");

        }

        private void stopTimerButton_Click(object sender, EventArgs e)
        {
            dotaTimerCurrent.Pause();
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething("Game paused");
        }

        private void resetTimerButton_Click(object sender, EventArgs e)
        {
            dotaTimerCurrent.Reset();
            UpdateTimeLabel(TimeSpan.Zero);
            dotaTimes.ResetAll();
            InitialiseDefaultLabels();
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething("Tracker Reset");
        }

        private void InitialiseDefaultLabels()
        {
            roshanNumberLabel.Text = "Current Roshan #: 1";
            aegisInPlayLabel.Text = "Aegis in Play: No";
            roshanLastDeathTimestampLabel.Text = "Last Death: N/A";
            roshanDropsLabel.Text = "Drops: Aegis";
            aegisTimerLabel.Text = "Current Aegis Timer: N/A";
            roshanNextPossibleSpawnTimestampLabel.Text = "Next Spawn Interval: N/A";
            radiantTormentorLabel.Text = "Tormentor Spawn: 20:00";
            direTormentorLabel.Text = "Tormentor Spawn: 20:00";
            nextLotusSpawnLabel.Text = "Next Lotus Spawn: 3:00";
            nextWisdowRuneSpawn.Text = "Next Wisdow Rune Spawn: 7:00";
            currentNeutralTierLabel.Text = "Too early for Neutral drops. Next tier starts at 7:00";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = dotaTimerCurrent.GetCurrentTime();
            UpdateTimeLabel(elapsedTime);
        }

        private void UpdateTimeLabel(TimeSpan elapsedTime)
        {
            ThreadInvokeHelper.SetText(this, elapsedTimeLabel, elapsedTime.ToString(@"hh\:mm\:ss"));
        }

        private void roshanDiedButton_Click(object sender, EventArgs e)
        {
            (int roshanNumber, bool isAegisInPlay, TimeSpan lastRoshanDeath, String roshanDrops) = dotaTimes.RoshanDied(dotaTimerCurrent.GetCurrentTimeToNearestSecond());

            ThreadInvokeHelper.SetText(this, roshanNumberLabel, $"Current Roshan #: {roshanNumber.ToString()}");
            ThreadInvokeHelper.SetText(this, aegisInPlayLabel, $"Aegis in Play: Yes");
            ThreadInvokeHelper.SetText(this, roshanLastDeathTimestampLabel, $"Last Death: {lastRoshanDeath.ToString("mm\\:ss")}");
            ThreadInvokeHelper.SetText(this, roshanDropsLabel, $"Drops: {roshanDrops}");
            ThreadInvokeHelper.SetText(this, aegisTimerLabel, $"Current Aegis Timer: 5:00");
            (string earlyTime, string lateTime) = dotaTimes.GetRoshanSpawnIntervals(dotaTimerCurrent.GetCurrentTimeToNearestSecond());

            ThreadInvokeHelper.SetText(this, roshanNextPossibleSpawnTimestampLabel, $"Next Spawn Interval: " + earlyTime + "-" + lateTime);
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething("R I P Roshan");
        }
        private void CheckButtonAuthorisation()
        {
            ThreadInvokeHelper.InvokeOnUIThread(this, ButtonChecks);
        }
        public void ButtonChecks()
        {
            bool isTimerRunning = dotaTimerCurrent.IsRunning();
            bool roshanAlive = dotaTimes.IsRoshanAlive(dotaTimerCurrent.GetCurrentTimeToNearestSecond());
            bool aegisInPlay = dotaTimes._isAegisInPlay;
            bool radiantTormentorUp = dotaTimes.IsTormentorUp(false);
            bool direTormentorUp = dotaTimes.IsTormentorUp(true);

            if (!isTimerRunning)
            {
                roshanDiedButton.Enabled = false;
                aegisCarrierDiedButton.Enabled = false;
                direTormentorDeadButton.Enabled = false;
                radiantTormentorDeadButton.Enabled = false;
                stopTimerButton.Enabled = false;
                startTimerButton.Enabled = true;
                return;
            }
            else
            {
                startTimerButton.Enabled = false;
                stopTimerButton.Enabled = true;
            }

            if (roshanAlive)
            {
                roshanDiedButton.Enabled = true;
            }
            else
            {
                roshanDiedButton.Enabled = false;
            }
            if (aegisInPlay)
            {
                aegisCarrierDiedButton.Enabled = true;
            }
            else
            {
                aegisCarrierDiedButton.Enabled = false;
            }
            if (radiantTormentorUp)
            {
                radiantTormentorDeadButton.Enabled = true;
            }
            if (direTormentorUp)
            {
                direTormentorDeadButton.Enabled = true;
            }
        }


        private void CheckCountdownLabels(TimeSpan elapsedTime)
        {
            Thread secondCheckThread = new Thread(() => LabelsThread(elapsedTime));
            secondCheckThread.Name = "SecondsCheck";
            secondCheckThread.IsBackground = true;
            secondCheckThread.Start();
        }

        private void LabelsThread(TimeSpan elapsedTime)
        {
            CheckAegisTimer(elapsedTime);
            CheckTormentorTimers(elapsedTime);
            CheckFixedSpawns(elapsedTime);
            CheckNeutralTier(elapsedTime);
        }

        private void CheckAegisTimer(TimeSpan elapsedTime)
        {
            TimeSpan aegisTimeLeft = dotaTimes.CheckAegisTimer(elapsedTime);
            string aegisTimeLeftText;

            if (aegisTimeLeft == TimeSpan.Zero)
            {
                aegisTimeLeftText = "Current Aegis Timer: N/A";
                ThreadInvokeHelper.SetText(this, aegisTimerLabel, aegisTimeLeftText);
                return;
            }

            aegisTimeLeftText = $"Current Aegis Timer: {aegisTimeLeft.ToString("mm\\:ss")}";

            ThreadInvokeHelper.SetText(this, aegisTimerLabel, aegisTimeLeftText);
        }

        private void CheckTormentorTimers(TimeSpan elapsedTime)
        {
            TimeSpan currentTime = elapsedTime;

            string radiantTimeLeft = (dotaTimes.NextTormentorSpawn(currentTime, false) - currentTime).ToString("mm\\:ss");
            string direTimeLeft = (dotaTimes.NextTormentorSpawn(currentTime, true) - currentTime).ToString("mm\\:ss");

            string radiantLabel = $"Tormentor Spawn: {radiantTimeLeft}";
            string direLabel = $"Tormentor Spawn: {direTimeLeft}";

            ThreadInvokeHelper.SetText(this, radiantTormentorLabel, radiantLabel);
            ThreadInvokeHelper.SetText(this, direTormentorLabel, direLabel);

        }

        private void CheckFixedSpawns(TimeSpan elapsedTime)
        {
            TimeSpan currentTime = elapsedTime;
            TimeSpan[] spawnTimers = dotaTimes.CheckAndUpdateFixedSpawns(currentTime);

            string lotusTimeLeft = spawnTimers[0].ToString("mm\\:ss");
            string wisdomTimeLeft = spawnTimers[1].ToString("mm\\:ss");

            string lotusLabel = $"Next Lotus Spawn: {lotusTimeLeft}";
            string wisdomLabel = $"Next Wisdow Rune Spawn: {wisdomTimeLeft}";

            ThreadInvokeHelper.SetText(this, nextLotusSpawnLabel, lotusLabel);
            ThreadInvokeHelper.SetText(this, nextWisdowRuneSpawn, wisdomLabel);
        }

        private void CheckNeutralTier(TimeSpan elapsedTime)
        {
            TimeSpan currentTime = elapsedTime;

            int neutralTier = dotaTimes.CheckNeutralTier(currentTime);

            string neutralTierLabel = dotaTimes.ReturnNeutralTierText(neutralTier);

            if (currentNeutralTierLabel.Text == neutralTierLabel)
            {
                return;
            }

            ThreadInvokeHelper.SetText(this, currentNeutralTierLabel, neutralTierLabel);

            TextToSpeechLogic.SaySomething($"Neutral item tier {neutralTier} started");
        }

        // WIP -
        private void CheckReminders(TimeSpan elapsedTime)
        {
            bool[] remindersNeedChecking = dotaTimes.CheckReminders(elapsedTime);
            string event1 = $"Roshan potentially respawning in {dotaTimes._roshanReminderEarlyMinutes} minutes.";
            string event2 = $"Wisdom runes spawning in {dotaTimes._wisdomRuneReminderEarlyMinutes} minute.";

            foreach (bool b in remindersNeedChecking)
            {
                if (b)
                {

                    //TextToSpeechLogic.SaySomething("b");
                }
            }

        }

        private void aegisCarrierDiedButton_Click(object sender, EventArgs e)
        {
            aegisCarrierDied();
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething("Aegis carrier died");
        }

        private void aegisCarrierDied()
        {
            dotaTimes.AegisCarrierDied();
            ThreadInvokeHelper.SetText(this, aegisInPlayLabel, "Aegis in Play: No");
            ThreadInvokeHelper.SetText(this, aegisTimerLabel, "Current Aegis Timer: N/A");
        }

        private void radiantTormentorDeadButton_Click(object sender, EventArgs e)
        {
            dotaTimes.KillTormentor(dotaTimerCurrent.GetCurrentTimeToNearestSecond(), false);

            ThreadInvokeHelper.DisableButton(this, radiantTormentorDeadButton);

            TextToSpeechLogic.SaySomething("Radiant Tormentor Killed");
        }

        private void direTormentorDeadButton_Click(object sender, EventArgs e)
        {
            dotaTimes.KillTormentor(dotaTimerCurrent.GetCurrentTimeToNearestSecond(), true);

            ThreadInvokeHelper.DisableButton(this, direTormentorDeadButton);

            TextToSpeechLogic.SaySomething("Dire Tormentor Killed");
        }
    }
}