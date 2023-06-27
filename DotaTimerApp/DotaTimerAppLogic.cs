using DotaStrings = DotaTimerApp.DotaTimerAppStrings;


//MASSIVE REWRITE IN PROGRESS
namespace DotaTimerApp
{
    internal class DotaTimerAppLogic
    {
        private StopwatchLogic dotaTimerCurrent;
        private ImportantDotaTimes dotaTimes = new();

        public DotaTimerAppLogic()
        {
            dotaTimerCurrent = new StopwatchLogic();
            dotaTimerCurrent.DotaStopwatchSecondElapsed += StopwatchLogic_DotaStopwatchSecondElapsed;
        }
        private void StopwatchLogic_DotaStopwatchSecondElapsed(object sender, EventArgs e)
        {
            TimeSpan elapsedTimeSeconds = dotaTimerCurrent.GetCurrentTimeToNearestSecond();

            UpdateTimeLabel(elapsedTimeSeconds);
            CheckButtonAuthorisation();
            CheckCountdownLabels(elapsedTimeSeconds);
            CheckReminders(elapsedTimeSeconds);
        }

        public void TimerStart()
        {
            dotaTimerCurrent.Start();
            TimerStartTTS();
        }

        private void TimerStartTTS()
        {
            if (dotaTimerCurrent.GetCurrentTime() != TimeSpan.Zero)
            {
                TextToSpeechLogic.SaySomething(DotaStrings._tTSTimerResumed);
                return;
            }

            TextToSpeechLogic.SaySomething(DotaStrings._tTSTimerStarted);
        }

        public void TimerStop()
        {
            dotaTimerCurrent.Pause();
            CheckButtonAuthorisation();
            TextToSpeechLogic.SaySomething(DotaStrings._tTSTimerPaused);
        }

        public void TimerReset()
        {
            dotaTimerCurrent.Reset();
            UpdateTimeLabel(TimeSpan.Zero);
            dotaTimes.ResetAll();
            InitialiseDefaults();
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething(DotaStrings._tTSTimerReset);
        }
        private void InitialiseDefaults()
        {
            InitialiseDefaultLabels();
            ResetNeutralImage();
        }

        private void InitialiseDefaultLabels()
        {
            //roshanNumberLabel.Text = "Current Roshan #: 1";
            //aegisInPlayLabel.Text = "Aegis in Play: No";
            //roshanLastDeathTimestampLabel.Text = "Last Death: N/A";
            //roshanDropsLabel.Text = "Drops: Aegis";
            //aegisTimerLabel.Text = "Current Aegis Timer: N/A";
            //roshanNextPossibleSpawnTimestampLabel.Text = "Next Spawn Interval: N/A";
            //radiantTormentorLabel.Text = "Tormentor Spawn: 20:00";
            //direTormentorLabel.Text = "Tormentor Spawn: 20:00";
            //nextLotusSpawnLabel.Text = "Next Lotus Spawn: 3:00";
            //nextWisdowRuneSpawn.Text = "Next Wisdow Rune Spawn: 7:00";
            //currentNeutralTierLabel.Text = "Too early for Neutral drops. Next tier starts at 7:00";
        }
        private void ResetNeutralImage()
        {
            //neutralItemPicture.Image = null;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = dotaTimerCurrent.GetCurrentTime();
            UpdateTimeLabel(elapsedTime);
        }
        private void UpdateTimeLabel(TimeSpan elapsedTime)
        {
            //ThreadInvokeHelper.SetText(this, elapsedTimeLabel, elapsedTime.ToString(@"hh\:mm\:ss"));
        }
        private void roshanDiedButton_Click(object sender, EventArgs e)
        {
            (int roshanNumber, bool isAegisInPlay, TimeSpan lastRoshanDeath, String roshanDrops, string earlyTime, string lateTime) = dotaTimes.RoshanDied(dotaTimerCurrent.GetCurrentTimeToNearestSecond());

            //ThreadInvokeHelper.SetText(this, roshanNumberLabel, $"Current Roshan #: {roshanNumber.ToString()}");
            //ThreadInvokeHelper.SetText(this, aegisInPlayLabel, $"Aegis in Play: Yes");
            //ThreadInvokeHelper.SetText(this, roshanLastDeathTimestampLabel, $"Last Death: {lastRoshanDeath.ToString("mm\\:ss")}");
            //ThreadInvokeHelper.SetText(this, roshanDropsLabel, $"Drops: {roshanDrops}");
            //ThreadInvokeHelper.SetText(this, aegisTimerLabel, $"Current Aegis Timer: 5:00");
            //ThreadInvokeHelper.SetText(this, roshanNextPossibleSpawnTimestampLabel, $"Next Spawn Interval: " + earlyTime + "-" + lateTime);
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething("R I P Roshan");
        }
        private void CheckButtonAuthorisation()
        {
            //ThreadInvokeHelper.InvokeOnUIThread(this, ButtonChecks);
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
                //roshanDiedButton.Enabled = false;
                //aegisCarrierDiedButton.Enabled = false;
                //direTormentorDeadButton.Enabled = false;
                //radiantTormentorDeadButton.Enabled = false;
                //stopTimerButton.Enabled = false;
                //startTimerButton.Enabled = true;
                return;
            }
            else
            {
                //startTimerButton.Enabled = false;
                //stopTimerButton.Enabled = true;
            }

            if (roshanAlive)
            {
                //roshanDiedButton.Enabled = true;
            }
            else
            {
                //roshanDiedButton.Enabled = false;
            }
            if (aegisInPlay)
            {
                //aegisCarrierDiedButton.Enabled = true;
            }
            else
            {
                //aegisCarrierDiedButton.Enabled = false;
            }
            if (radiantTormentorUp)
            {
                //radiantTormentorDeadButton.Enabled = true;
            }
            if (direTormentorUp)
            {
                //direTormentorDeadButton.Enabled = true;
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
        //need to clean this up - also not properly setting string to N/A on expiry
        private void CheckAegisTimer(TimeSpan elapsedTime)
        {
            TimeSpan aegisTimeLeft = dotaTimes.CheckAegisTimer(elapsedTime);
            string aegisTimeLeftText;

            if (aegisTimeLeft == TimeSpan.Zero)
            {
                aegisTimeLeftText = "Current Aegis Timer: N/A";
                dotaTimes.AegisExpired();
                //ThreadInvokeHelper.SetText(this, aegisTimerLabel, aegisTimeLeftText);
                return;
            }

            aegisTimeLeftText = $"Current Aegis Timer: {aegisTimeLeft.ToString("mm\\:ss")}";

            //ThreadInvokeHelper.SetText(this, aegisTimerLabel, aegisTimeLeftText);
        }

        private void CheckTormentorTimers(TimeSpan elapsedTime)
        {
            TimeSpan currentTime = elapsedTime;

            string radiantTimeLeft = (dotaTimes.NextTormentorSpawn(currentTime, false) - currentTime).ToString("mm\\:ss");
            string direTimeLeft = (dotaTimes.NextTormentorSpawn(currentTime, true) - currentTime).ToString("mm\\:ss");

            string radiantLabel = $"Tormentor Spawn: {radiantTimeLeft}";
            string direLabel = $"Tormentor Spawn: {direTimeLeft}";

            //ThreadInvokeHelper.SetText(this, radiantTormentorLabel, radiantLabel);
            //ThreadInvokeHelper.SetText(this, direTormentorLabel, direLabel);

        }

        private void CheckFixedSpawns(TimeSpan elapsedTime)
        {
            TimeSpan currentTime = elapsedTime;
            TimeSpan[] spawnTimers = dotaTimes.CheckAndUpdateFixedSpawns(currentTime);

            string lotusTimeLeft = spawnTimers[0].ToString("mm\\:ss");
            string wisdomTimeLeft = spawnTimers[1].ToString("mm\\:ss");

            string lotusLabel = $"Next Lotus Spawn: {lotusTimeLeft}";
            string wisdomLabel = $"Next Wisdow Rune Spawn: {wisdomTimeLeft}";

            //ThreadInvokeHelper.SetText(this, nextLotusSpawnLabel, lotusLabel);
            //ThreadInvokeHelper.SetText(this, nextWisdowRuneSpawn, wisdomLabel);
        }

        private void CheckNeutralTier(TimeSpan elapsedTime)
        {
            TimeSpan currentTime = elapsedTime;

            int neutralTier = dotaTimes.CheckNeutralTier(currentTime);

            string neutralTierLabel = dotaTimes.ReturnNeutralTierText(neutralTier);

            //if (currentNeutralTierLabel.Text == neutralTierLabel)
            //{
            //    return;
            //}

            //ThreadInvokeHelper.SetText(this, currentNeutralTierLabel, neutralTierLabel);

            string neutralImage = $"neutralToken{neutralTier}";
            
            //ThreadInvokeHelper.updateImage(this, neutralItemPicture, neutralImage);

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

        private void aegisCarrierDiedButton_Click(object sender, EventArgs e)
        {
            aegisCarrierDied();
            CheckButtonAuthorisation();

            TextToSpeechLogic.SaySomething("Aegis carrier died");
        }

        private void aegisCarrierDied()
        {
            dotaTimes.AegisCarrierDied();
            //ThreadInvokeHelper.SetText(this, aegisInPlayLabel, "Aegis in Play: No");
            //ThreadInvokeHelper.SetText(this, aegisTimerLabel, "Current Aegis Timer: N/A");
        }

        private void radiantTormentorDeadButton_Click(object sender, EventArgs e)
        {
            dotaTimes.KillTormentor(dotaTimerCurrent.GetCurrentTimeToNearestSecond(), false);

            //ThreadInvokeHelper.DisableButton(this, radiantTormentorDeadButton);

            TextToSpeechLogic.SaySomething("Radiant Tormentor Killed");
        }

        private void direTormentorDeadButton_Click(object sender, EventArgs e)
        {
            dotaTimes.KillTormentor(dotaTimerCurrent.GetCurrentTimeToNearestSecond(), true);

            //ThreadInvokeHelper.DisableButton(this, direTormentorDeadButton);

            TextToSpeechLogic.SaySomething("Dire Tormentor Killed");
        }

    }
}
