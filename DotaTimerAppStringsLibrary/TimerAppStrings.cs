using System.Text;

namespace DotaTimerAppStringsLibrary
{
    internal class TimerAppStrings
    {

        //TTS generic
        internal static string _tTSTimerStarted = "Game timer started.";
        internal static string _tTSTimerResumed = "Game timer resumed.";
        internal static string _tTSTimerPaused = "Game timer paused";
        internal static string _tTSTimerReset = "Game Timer Reset";

        //GENERICS
        internal static string _radiant = "Radiant";
        internal static string _dire = "Dire";
        internal static string _null = "N/A";

        //ROSHAN
        internal static string _roshanNumber = "Current Roshan #:";
        internal static string _roshanLastDeath = "Last Death:";
        internal static string _roshanDrops = "Drops:";

        internal static string _roshDropsOne = "Aegis";
        internal static string _roshDropsTwo = "Aegis && Cheese";
        internal static string _roshDropsThreePlus = "Aegis, Cheese && Radiant Aghs/Dire Refresher";

        internal static string[] _roshDrops = { _roshDropsOne, _roshDropsTwo, _roshDropsThreePlus };

        internal static string _roshanNextSpawns = "Next Spawn Interval:";

        //AEGIS
        internal static string _aegisTimer = "Current Aegis Timer:";
        internal static string _aegisInPlay = "Aegis in Play:";

        //ROSHAN TTS AEGIS
        internal static string _tTSRoshanDied = "R I P Roshan";
        internal static string _tTSAegisDied = "Aegis carrier dead";

        internal static string _tTSRoshanMinReminder = "Roshan potentially respawning in";
        internal static string _tTSRoshanMaxReminder = "Roshan definitely respawning in";

        //TORMENTOR
        internal static string _tormentorSpawn = "Tormentor Spawn:";
        internal static string _tormentorDied = "Tormentor Killed";

        //LOTUS
        internal static string _lotusSpawn = "Next Lotus Spawn:";
        internal static string _tTSlotusReminder = "Lotuses spawning in";

        //WISDOM
        internal static string _wisdomSpawn = "Next Wisdom Rune Spawn:";
        internal static string _tTSWisdomReminder = "Wisdom runes spawning in";


        //NEUTRALITEMS
        internal static string _neutralsTooEarly = "Too early for Neutral drops.";
        internal static string _neutralsCurrentTier = "Current Neutral Item Tier:";
        internal static string _neutralsNextTierAt = "Next tier starts at";

        internal static string _tTSNeutralTierChange = "Entering next neutral tier.";           
                
    }
}
