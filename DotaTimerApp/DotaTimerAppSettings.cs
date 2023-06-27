using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaTimerApp
{
    internal class DotaTimerAppSettings
    {
        public int _tTSVolume;

        public bool _lotusTTSReminders;
        public bool _wisdomRuneTTSReminders;
        public bool _roshanTTSReminders;
        public bool _tormentorTTSReminders;

        public bool _lotusSpawnTTSNotification;
        public bool _wisdowRuneSpawnTTSNotification;
        public bool _tormentorSpawnTTSNotification;

        public string _roshanEarlyReminder;
        public string _wisdomRuneEarlyReminder;

        public bool _neutralTierChangeTTSNotification;

        public DotaTimerAppSettings()
        {
            SetDefaults();
        }
        public void SetDefaults()
        {
            ToggleTTS(true);

            _lotusTTSReminders = false;
            _wisdomRuneTTSReminders = true;
            _roshanTTSReminders = true;
            _tormentorTTSReminders = false;

            _lotusSpawnTTSNotification = true;
            _wisdowRuneSpawnTTSNotification = true;
            _tormentorSpawnTTSNotification = true;

            _neutralTierChangeTTSNotification = true;

            _roshanEarlyReminder = "00:02:00";
            _wisdomRuneEarlyReminder = "00:01:00";
        }
        public void ToggleTTS(bool b)
        {
            if (b) { _tTSVolume = 0; }
            else { _tTSVolume = 100; }
        }
        public void SetAllLotusTTS(bool b)
        {
            _lotusTTSReminders = b;
            _lotusSpawnTTSNotification = b;
        }

        public void SetAllWisdom(bool b)
        {
            _wisdomRuneTTSReminders = b;
            _wisdowRuneSpawnTTSNotification= b;
        }

        public void SetAllRoshanReminders(bool b)
        {
            _roshanTTSReminders = b;
        }

        public void SetAllTormentorReminders(bool b)
        {
            _tormentorTTSReminders = b;
            _tormentorSpawnTTSNotification = b;        
        }

    }
}
