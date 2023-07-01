using DotaTimerAppLogic;
using DotaTimerImages;
using System.Resources;

namespace DotaTimerApp
{
    public partial class DotaTimerAppForm : Form
    {
        private AppLogicMaster appLogic = new AppLogicMaster();

        private NeutralImage neutralImage = new NeutralImage();

        public DotaTimerAppForm()
        {
            InitializeComponent();
            InitialiseDefaults();
            appLogic.UpdateTextLabels += GetTextLabels;
            appLogic.UpdateButtons += GetButtonStatuses;
            appLogic.UpdateNeutralImage += GetNeutralImage;
            GetStaticImages();
            GetNeutralImage(this, EventArgs.Empty);
        }

        private void GetStaticImages()
        {          
            lotusPicture.Image = StaticImages.GetLotusImage();
            wisdomRunePicture.Image = StaticImages.GetWisdomImage();
        }

        private void GetNeutralImage(object? sender, EventArgs e)
        {
            neutralItemPicture.Image = neutralImage.GetNeutralImage();
        }

        private async void GetButtonStatuses(object? sender, EventArgs e)
        {
            List<(Button, string)> buttons = new List<(Button, string)>
                { (startTimerButton, "StartEnabled"),
                (stopTimerButton, "PauseEnabled"),
                (resetTimerButton, "ResetEnabled"),
                (roshanDiedButton, "RoshanEnabled"),
                (aegisCarrierDiedButton, "AegisEnabled"),
                (radiantTormentorDeadButton, "RadiantTormentorEnabled"),
                (direTormentorDeadButton, "DireTormentorEnabled") };

            string[] buttonNames = buttons.Select(tuple => tuple.Item2).ToArray();

            List<(string, bool)> buttonStates = appLogic.GetButtons();

            List<(Button, bool)> matchedButtons = buttons
            .Where(tuple => buttonStates.Any(state => state.Item1 == tuple.Item2))
            .Select(tuple => (tuple.Item1, buttonStates.First(state => state.Item1 == tuple.Item2).Item2))
            .ToList();

            foreach ((Button button, bool status) in matchedButtons)
            {
               ButtonUpdater.UpdateButton(button, status, this);            
            }
        }

        private async void GetTextLabels(object? sender, EventArgs e)
        {
            List<(Label, string)> labels = new List<(Label, string)>
                { (elapsedTimeLabel, "_timer"),
                (roshanNumberLabel, "_roshanNumberLabel"),
                (roshanLastDeathTimestampLabel, "_roshanLastDeathTimestampLabel"),
                (roshanNextPossibleSpawnTimestampLabel, "_roshanPossibleSpawnTimeStampLabel"),
                (aegisInPlayLabel, "_aegisInPlayLabel"),
                (aegisTimerLabel, "_aegisTimerLabel"),
                (radiantTormentorLabel, "_radiantTormentorLabel"),
                (direTormentorLabel, "_direTormentorLabel"),
                (currentNeutralTierLabel, "_currentNeutralTierLabel"),
                (nextLotusSpawnLabel, "_nextLotusSpawnLabel"),
                (nextWisdowRuneSpawn, "_nextWisdowRuneSpawnLabel"),
                (roshanDropsLabel, "_roshanDropsLabel") };

            string[] labelNames = labels.Select(tuple => tuple.Item2).ToArray();

            List<(string, string)> labelsText = appLogic.GetTextLabels();

            List<(Label, string)> matchedLabels = labels
            .Where(tuple => labelsText.Any(state => state.Item1 == tuple.Item2))
            .Select(tuple => (tuple.Item1, labelsText.First(state => state.Item1 == tuple.Item2).Item2))
            .ToList();

            foreach ((Label label, string text) in matchedLabels)
            {
                LabelUpdater.UpdateLabel(label, text, this);
            }

        }

        private void startTimerButton_Click(object sender, EventArgs e)
        {
            appLogic.TimerStart();
        }

        private void stopTimerButton_Click(object sender, EventArgs e)
        {
            appLogic.TimerPause();
        }

        private void resetTimerButton_Click(object sender, EventArgs e)
        {
            appLogic.TimerReset();
        }

        private void InitialiseDefaults()
        {
            InitialiseDefaultLabels();
            CheckButtons();
            CheckLabels();
            CheckNeutralImage();
        }

        private void InitialiseDefaultLabels()
        {
        }

        private void CheckNeutralImage()
        {
            
        }
        private void roshanDiedButton_Click(object sender, EventArgs e)
        {
            appLogic.RoshanDied();
        }
        private void CheckButtons()
        {

            
        }

        private void CheckLabels()
        {
        
        }
        private void aegisCarrierDiedButton_Click(object sender, EventArgs e)
        {
            appLogic.AegisCarrierDied();
        }

        private void radiantTormentorDeadButton_Click(object sender, EventArgs e)
        {
            appLogic.RadiantTormentorDied();
        }

        private void direTormentorDeadButton_Click(object sender, EventArgs e)
        {
            appLogic.DireTormentorDied();
        }
    }
}