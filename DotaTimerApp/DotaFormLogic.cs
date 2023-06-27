using DotaTimerApp;
namespace DotaTimerApp
{
    partial class DotaFormLogic
    {
        static public StopwatchLogic dotaTimerCurrent;
        static public ImportantDotaTimes dotaTimes = new();
        static public DotaTimerAppForm MainForm { get ; set; }

        public static void Initialize()
        {
            dotaTimerCurrent = new StopwatchLogic();
            dotaTimerCurrent.DotaStopwatchSecondElapsed += DotaStopwatchSecondElapsed;
        }
        private static void DotaStopwatchSecondElapsed(object sender, EventArgs e)
        {
            TimeSpan elapsedTimeSeconds = dotaTimerCurrent.GetCurrentTimeToNearestSecond();
        }

        static public void StartButton()
        {
            dotaTimerCurrent.Start();            

            if (dotaTimerCurrent.GetCurrentTime() != TimeSpan.Zero)
            {
                TextToSpeechLogic.SaySomething("Game timer resumed.");
                return;
            }

            TextToSpeechLogic.SaySomething("Game timer started.");
        }

        static public void StopButton()
        {
            dotaTimerCurrent.Pause();

            TextToSpeechLogic.SaySomething("Game paused");
        }

        static public void ResetButton()
        {
            dotaTimerCurrent.Reset();
            dotaTimes.ResetAll();

            TextToSpeechLogic.SaySomething("Tracker Reset");
        }
        static public void RoshanDiedButton()
        {
            TextToSpeechLogic.SaySomething("R I P Roshan");
        }
        private void CheckButtonAuthorisation()
        {
            ThreadInvokeHelper.InvokeOnUIThread(MainForm, ButtonChecks);
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
                dotaTimes.AegisExpired();
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

            string neutralImage = $"neutralToken{neutralTier}";

            ThreadInvokeHelper.updateImage(this, neutralItemPicture, neutralImage);

            TextToSpeechLogic.SaySomething($"Neutral item tier {neutralTier} started");
        }
        private void CheckReminders(TimeSpan elapsedTime)
        {
            bool[] remindersNeedChecking = dotaTimes.CheckReminders(elapsedTime);
            string[] eventCollection = new string[remindersNeedChecking.Count()];

            eventCollection[0] = $"Roshan potentially respawning in {dotaTimes._roshanReminderEarlyMinutes} minutes.";
            eventCollection[1] = $"Roshan definitely respawning in {dotaTimes._roshanReminderEarlyMinutes} minutes.";
            eventCollection[2] = $"Wisdom runes spawning in {dotaTimes._wisdomRuneReminderEarlyMinutes} minute.";

            for (int b = 0; b < remindersNeedChecking.Length; b++)
            {
                if (remindersNeedChecking[b])
                {
                    TextToSpeechLogic.SaySomething(eventCollection[b]);
                }
            }
        }
        private void aegisCarrierDiedButton()
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

        private void RadiantTormentorButton()
        {
            dotaTimes.KillTormentor(dotaTimerCurrent.GetCurrentTimeToNearestSecond(), false);

            ThreadInvokeHelper.DisableButton(this, radiantTormentorDeadButton);

            TextToSpeechLogic.SaySomething("Radiant Tormentor Killed");
        }

        private void DireTormentorButton()
        {
            dotaTimes.KillTormentor(dotaTimerCurrent.GetCurrentTimeToNearestSecond(), true);

            ThreadInvokeHelper.DisableButton(this, direTormentorDeadButton);

            TextToSpeechLogic.SaySomething("Dire Tormentor Killed");

        }
    }
}
