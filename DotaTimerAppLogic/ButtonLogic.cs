using System.Security.Cryptography.X509Certificates;

namespace DotaTimerAppLogic
{
    public class ButtonLogic
    {
        private bool StartEnabled;
        private bool PauseEnabled;
        private bool ResetEnabled;

        private bool RoshanEnabled;
        private bool AegisEnabled;

        private bool RadiantTormentorEnabled;
        private bool DireTormentorEnabled;

        public ButtonLogic()
        {
            Defaults();
        }
        public void Defaults()
        {
            StartEnabled = true;
            PauseEnabled = false;
            ResetEnabled = false;

            RoshanEnabled = false;
            AegisEnabled = false;

            RadiantTormentorEnabled = false;
            DireTormentorEnabled = false;
        }

        public void TimerStarted()
        {
            StartEnabled = false;
            PauseEnabled = true;
            ResetEnabled = true;

            RoshanEnabled = true;
        }

        public void TimerResumed(bool rosh, bool aegis, bool radTormentor, bool dirTormentor)
        {
            StartEnabled = false;
            PauseEnabled = true;
            ResetEnabled = true;

            if (rosh) { RoshanEnabled = true; };
            if (aegis) { AegisEnabled = true; };
            if (radTormentor) { RadiantTormentorEnabled = true; };
            if (dirTormentor) { DireTormentorEnabled = true; };
        }

        public void TimerPaused()
        {
            StartEnabled = true;
            PauseEnabled = false;
            ResetEnabled = false;

            RoshanEnabled = false;
            AegisEnabled = false;

            RadiantTormentorEnabled = false;
            DireTormentorEnabled = false;
            
        }
        public void RoshDied()
        {
            RoshanEnabled = false;
            AegisEnabled = true;
        }
        public void AegisDied()
        {
            AegisEnabled = false;
        }
        public void AegisExpired()
        {
            AegisDied();
        }
        public void RoshPotentiallyRespawned()
        {
            RoshanEnabled = true;
        }
        public void RadantTormentorRespawned()
        {
            RadiantTormentorEnabled = true;
        }
        public void RadiantTormentorDied()
        {
            RadiantTormentorEnabled = false;
        }
        public void DireTormentorRespawned()
        {
            DireTormentorEnabled = true;
        }

        public void DireTormentorDied()
        {
            DireTormentorEnabled = false;
        }

        public List<(string, bool)> UpdateAllButtons()
        {
            List<(string, bool)> buttonStates = new List<(string, bool)>
            {
                ("StartEnabled", StartEnabled),
                ("PauseEnabled", PauseEnabled),
                ("ResetEnabled", ResetEnabled),
                ("RoshanEnabled", RoshanEnabled),
                ("AegisEnabled", AegisEnabled),
                ("RadiantTormentorEnabled", RadiantTormentorEnabled),
                ("DireTormentorEnabled", DireTormentorEnabled)
            };

            return buttonStates;            
        }
    }
}
