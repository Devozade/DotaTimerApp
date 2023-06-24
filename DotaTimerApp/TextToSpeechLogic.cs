using System.Speech.Synthesis;

namespace DotaTimerApp
{
    internal class TextToSpeechLogic
    {
        public static void SaySomething(string whatToSay)
        {
            Thread speechThread = new Thread(() => ParseTextToSpeech(whatToSay));
            speechThread.Name = "TTSRun";
            speechThread.IsBackground = true;
            speechThread.Start();
        }
        private static void ParseTextToSpeech(string whatToSay)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Speak(whatToSay);
            }
        }
    }
}
