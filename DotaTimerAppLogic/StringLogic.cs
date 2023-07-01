using DotaStrings = DotaTimerAppStringsLibrary.DotaStringsBuilder;
using DotaGameTimersClassLibrary;
using TimeSpanTools;

namespace DotaTimerAppLogic
{
    internal class StringLogic
    {

        private string? _timer;
        private string? _roshanNumberLabel;
        private string? _roshanLastDeathTimestampLabel;
        private string? _roshanPossibleSpawnTimeStampLabel;
        private string? _roshanDropsLabel;

        private string? _aegisInPlayLabel;
        private string? _aegisTimerLabel;

        private string? _radiantTormentorLabel;
        private string? _direTormentorLabel;

        private string? _nextLotusSpawnLabel;
        private string? _nextWisdowRuneSpawnLabel;

        private string? _currentNeutralTierLabel;

        public StringLogic()
        {
            ResetDefaults();
        }
        public void ResetDefaults()
        {
            RoshanDefaults();
            AegisDefaults();
            TormentorDefaults();
            MiscSpawnsDefaults();
            NeutralTierDefault();
            MainTimerDefault();
        }
        private void RoshanDefaults()
        {
            _roshanNumberLabel = DotaStrings.RoshIntToNumberString(1);
            _roshanLastDeathTimestampLabel = DotaStrings.RoshanLastDeathToStringDefault();
            _roshanPossibleSpawnTimeStampLabel = DotaStrings.RoshRespawnsDefault();
            _roshanDropsLabel = DotaStrings.RoshIntToDropsString(1);
        }

        internal void AegisDefaults()
        {
            _aegisInPlayLabel = DotaStrings.AegisInPlay(false);
            _aegisTimerLabel = DotaStrings.AegisTimerDefault();
        }

        internal void TormentorDefaults()
        {
            TimeSpan tormentorSeedToStamp = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.TormentorSpawnSeed);

            _radiantTormentorLabel = DotaStrings.RadiantTormentorTimer(tormentorSeedToStamp);
            _direTormentorLabel = DotaStrings.DireTormentorTimer(tormentorSeedToStamp);
        }

        internal void RadiantTormentorAlive()
        {
            _radiantTormentorLabel = DotaStrings.RadiantTormentorAlive();
        }
        internal void DireTormentorAlive()
        {
            _direTormentorLabel = DotaStrings.DireTormentorAlive();
        }
        private void MiscSpawnsDefaults()
        {
            TimeSpan lotusSeedToStamp = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.LotusSpawnSeedTime);
            _nextLotusSpawnLabel = DotaStrings.LotusSpawn(lotusSeedToStamp);

            TimeSpan wisdomSeedToStamp = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.WisdomRuneSpawnSeedTime);
            _nextLotusSpawnLabel = DotaStrings.LotusSpawn(wisdomSeedToStamp);
        }

        private void NeutralTierDefault()
        {
            TimeSpan neutralTier1Stamp = TimeSpanCalcs.StringToTimespan(DotaTimeConstants.NeutralTierTimeArray[1]);
            _currentNeutralTierLabel = DotaStrings.NeutralTier(0, neutralTier1Stamp);
        }

        private void MainTimerDefault()
        {
            _timer = DotaStrings.MainTimerStringDefault();
        }

        internal void UpdateMainTimer(TimeSpan timeSpan)
        {
            _timer = DotaStrings.MainTimerString(timeSpan);
        }
        internal void UpdateAegisTimer(TimeSpan timeLeft)
        {            
            _aegisTimerLabel = DotaStrings.AegisTimer(timeLeft);
        }

        internal void UpdateAegisinPlay(bool b)
        {
            _aegisInPlayLabel = DotaStrings.AegisInPlay(b);
        }
        internal void UpdateRoshanDeathStamp(TimeSpan timeStamp)
        {
            _roshanLastDeathTimestampLabel = DotaStrings.RoshanLastDeathToString(timeStamp);
            
        }
        internal void UpdateRoshanPossibleSpawns(TimeSpan min, TimeSpan max)
        {
            _roshanPossibleSpawnTimeStampLabel = DotaStrings.RoshRespawnsToString(min, max);
        }
        internal void IncrementRoshanAndDrops(int num)
        {
            _roshanNumberLabel = DotaStrings.RoshIntToNumberString(num);
            _roshanDropsLabel = DotaStrings.RoshIntToDropsString(num);
        }

        internal void UpdateRadiantTormentorSpawn(TimeSpan timeLeft)
        {
            _radiantTormentorLabel = DotaStrings.RadiantTormentorTimer(timeLeft);        
        }
        internal void UpdateDireTormentorSpawn(TimeSpan timeLeft)
        {
            _radiantTormentorLabel = DotaStrings.DireTormentorTimer(timeLeft);
        }
        internal void UpdateWisdomRuneSpawn(TimeSpan timeLeft)
        {
            _nextWisdowRuneSpawnLabel = DotaStrings.WisdomSpawn(timeLeft);
        }
        internal void UpdateLotusSpawn(TimeSpan timeLeft)
        {
            _nextLotusSpawnLabel = DotaStrings.WisdomSpawn(timeLeft);
        }

        internal void UpdateNeutralTier(int num, TimeSpan nextTier)
        {
            _currentNeutralTierLabel = DotaStrings.NeutralTier(num, nextTier);
        }

        public List<(string, string)> UpdateAllLabels()
        {
            List<(string, string?)> labelsText = new List<(string, string?)>
            {
                ("_timer", _timer),
                ("_roshanNumberLabel", _roshanNumberLabel),
                ("_roshanLastDeathTimestampLabel", _roshanLastDeathTimestampLabel),
                ("_roshanPossibleSpawnTimeStampLabel", _roshanPossibleSpawnTimeStampLabel),
                ("_aegisInPlayLabel", _aegisInPlayLabel),
                ("_aegisTimerLabel", _aegisTimerLabel),
                ("_radiantTormentorLabel", _radiantTormentorLabel),
                ("_direTormentorLabel", _direTormentorLabel),
                ("_currentNeutralTierLabel", _currentNeutralTierLabel),
                ("_nextLotusSpawnLabel", _nextLotusSpawnLabel),
                ("_nextWisdowRuneSpawnLabel", _nextWisdowRuneSpawnLabel),
                ("_roshanDropsLabel", _roshanDropsLabel)
            };

            return labelsText;
        }
    }
}
