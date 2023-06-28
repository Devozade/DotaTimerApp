using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStrings = DotaTimerAppStringsLibrary.DotaTimerAppStrings;

namespace DotaTimerAppLogic
{
    internal class StringLogic
    {
        private string _roshanNumberLabel;
        private string _roshanLastDeathTimestampLabel;
        private string _roshanPossibleSpawnTimeStampLabel;
        private string _roshanDropsLabel;

        private string _aegisInPlayLabel;
        private string _aegisTimerLabel;

        private string _radiantTormentorLabel;
        private string _direTormentorLabel;

        private string _nextLotusSpawnLabel;
        private string _nextWisdowRuneSpawnLabel;

        private string _currentNeutralTierLabel;

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
        }
        private void RoshanDefaults()
        {
            _roshanNumberLabel = DotaStrings.RoshIntToNumberString(1);
            _roshanLastDeathTimestampLabel = DotaStrings.RoshanLastDeath(TimeSpan.Zero);
            _roshanPossibleSpawnTimeStampLabel = DotaStrings.RoshRespawnsNull();
            _roshanDropsLabel = DotaStrings.RoshIntToDropsString(1);
        }

        private void AegisDefaults()
        {
            _aegisInPlayLabel = DotaStrings.AegisInPlay(false);
            //_aegisTimerLabel = DotaStrings.BuildTimeStampStringNA();
        }

        private void TormentorDefaults()
        {
            //_radiantTormentorLabel = DotaStrings.;
            //_direTormentorLabel = ;
        }

        private void MiscSpawnsDefaults()
        {
            //_nextLotusSpawnLabel;
            //_nextWisdowRuneSpawnLabel;
        }

        private void NeutralTierDefault()
        {
            //_currentNeutralTierLabel;
        }

        internal void UpdateMainTimer(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        internal void UpdateTimerStrings(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }
    }
}
