namespace DotaTimerApp
{
    partial class DotaTimerAppForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DotaTimerAppForm));
            startTimerButton = new Button();
            gameTimer = new System.Windows.Forms.Timer(components);
            elapsedTimeLabel = new Label();
            stopTimerButton = new Button();
            resetTimerButton = new Button();
            roshanDiedButton = new Button();
            roshanNumberLabel = new Label();
            roshanLastDeathTimestampLabel = new Label();
            roshanNextPossibleSpawnTimestampLabel = new Label();
            aegisCarrierDiedButton = new Button();
            aegisInPlayLabel = new Label();
            aegisTimerLabel = new Label();
            radiantTormentorDeadButton = new Button();
            direTormentorDeadButton = new Button();
            radiantTormentorLabel = new Label();
            direTormentorLabel = new Label();
            currentNeutralTierLabel = new Label();
            nextLotusSpawnLabel = new Label();
            nextWisdowRuneSpawn = new Label();
            roshanDropsLabel = new Label();
            SuspendLayout();
            // 
            // startTimerButton
            // 
            startTimerButton.Location = new Point(12, 84);
            startTimerButton.Name = "startTimerButton";
            startTimerButton.Size = new Size(142, 28);
            startTimerButton.TabIndex = 0;
            startTimerButton.Text = "Start";
            startTimerButton.UseVisualStyleBackColor = true;
            startTimerButton.Click += startTimerButton_Click;
            // 
            // elapsedTimeLabel
            // 
            elapsedTimeLabel.AutoSize = true;
            elapsedTimeLabel.Font = new Font("Segoe UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
            elapsedTimeLabel.Location = new Point(94, 9);
            elapsedTimeLabel.Name = "elapsedTimeLabel";
            elapsedTimeLabel.Size = new Size(181, 59);
            elapsedTimeLabel.TabIndex = 1;
            elapsedTimeLabel.Text = "00:00:00";
            // 
            // stopTimerButton
            // 
            stopTimerButton.Location = new Point(179, 84);
            stopTimerButton.Name = "stopTimerButton";
            stopTimerButton.Size = new Size(142, 28);
            stopTimerButton.TabIndex = 2;
            stopTimerButton.Text = "Pause";
            stopTimerButton.UseVisualStyleBackColor = true;
            stopTimerButton.Click += stopTimerButton_Click;
            // 
            // resetTimerButton
            // 
            resetTimerButton.Location = new Point(94, 118);
            resetTimerButton.Name = "resetTimerButton";
            resetTimerButton.Size = new Size(142, 28);
            resetTimerButton.TabIndex = 3;
            resetTimerButton.Text = "Reset";
            resetTimerButton.UseVisualStyleBackColor = true;
            resetTimerButton.Click += resetTimerButton_Click;
            // 
            // roshanDiedButton
            // 
            roshanDiedButton.Location = new Point(12, 152);
            roshanDiedButton.Name = "roshanDiedButton";
            roshanDiedButton.Size = new Size(142, 60);
            roshanDiedButton.TabIndex = 4;
            roshanDiedButton.Text = "Roshan Death";
            roshanDiedButton.UseVisualStyleBackColor = true;
            roshanDiedButton.Click += roshanDiedButton_Click;
            // 
            // roshanNumberLabel
            // 
            roshanNumberLabel.AutoSize = true;
            roshanNumberLabel.Location = new Point(160, 152);
            roshanNumberLabel.Name = "roshanNumberLabel";
            roshanNumberLabel.Size = new Size(0, 15);
            roshanNumberLabel.TabIndex = 5;
            // 
            // roshanLastDeathTimestampLabel
            // 
            roshanLastDeathTimestampLabel.AutoSize = true;
            roshanLastDeathTimestampLabel.Location = new Point(160, 167);
            roshanLastDeathTimestampLabel.Name = "roshanLastDeathTimestampLabel";
            roshanLastDeathTimestampLabel.Size = new Size(0, 15);
            roshanLastDeathTimestampLabel.TabIndex = 6;
            // 
            // roshanNextPossibleSpawnTimestampLabel
            // 
            roshanNextPossibleSpawnTimestampLabel.AutoSize = true;
            roshanNextPossibleSpawnTimestampLabel.Location = new Point(160, 182);
            roshanNextPossibleSpawnTimestampLabel.Name = "roshanNextPossibleSpawnTimestampLabel";
            roshanNextPossibleSpawnTimestampLabel.Size = new Size(0, 15);
            roshanNextPossibleSpawnTimestampLabel.TabIndex = 7;
            // 
            // aegisCarrierDiedButton
            // 
            aegisCarrierDiedButton.Location = new Point(12, 218);
            aegisCarrierDiedButton.Name = "aegisCarrierDiedButton";
            aegisCarrierDiedButton.Size = new Size(142, 30);
            aegisCarrierDiedButton.TabIndex = 8;
            aegisCarrierDiedButton.Text = "Aegis Carrier Died";
            aegisCarrierDiedButton.UseVisualStyleBackColor = true;
            aegisCarrierDiedButton.Click += aegisCarrierDiedButton_Click;
            // 
            // aegisInPlayLabel
            // 
            aegisInPlayLabel.AutoSize = true;
            aegisInPlayLabel.Location = new Point(160, 218);
            aegisInPlayLabel.Name = "aegisInPlayLabel";
            aegisInPlayLabel.Size = new Size(0, 15);
            aegisInPlayLabel.TabIndex = 9;
            // 
            // aegisTimerLabel
            // 
            aegisTimerLabel.AutoSize = true;
            aegisTimerLabel.Location = new Point(160, 233);
            aegisTimerLabel.Name = "aegisTimerLabel";
            aegisTimerLabel.Size = new Size(0, 15);
            aegisTimerLabel.TabIndex = 10;
            // 
            // radiantTormentorDeadButton
            // 
            radiantTormentorDeadButton.Location = new Point(12, 254);
            radiantTormentorDeadButton.Name = "radiantTormentorDeadButton";
            radiantTormentorDeadButton.Size = new Size(142, 42);
            radiantTormentorDeadButton.TabIndex = 11;
            radiantTormentorDeadButton.Text = "Radiant Tormentor Dead";
            radiantTormentorDeadButton.UseVisualStyleBackColor = true;
            radiantTormentorDeadButton.Click += radiantTormentorDeadButton_Click;
            // 
            // direTormentorDeadButton
            // 
            direTormentorDeadButton.Location = new Point(179, 254);
            direTormentorDeadButton.Name = "direTormentorDeadButton";
            direTormentorDeadButton.Size = new Size(142, 42);
            direTormentorDeadButton.TabIndex = 12;
            direTormentorDeadButton.Text = "Dire Tormentor Dead";
            direTormentorDeadButton.UseVisualStyleBackColor = true;
            direTormentorDeadButton.Click += direTormentorDeadButton_Click;
            // 
            // radiantTormentorLabel
            // 
            radiantTormentorLabel.AutoSize = true;
            radiantTormentorLabel.Location = new Point(12, 299);
            radiantTormentorLabel.Name = "radiantTormentorLabel";
            radiantTormentorLabel.Size = new Size(0, 15);
            radiantTormentorLabel.TabIndex = 13;
            // 
            // direTormentorLabel
            // 
            direTormentorLabel.AutoSize = true;
            direTormentorLabel.Location = new Point(179, 299);
            direTormentorLabel.Name = "direTormentorLabel";
            direTormentorLabel.Size = new Size(0, 15);
            direTormentorLabel.TabIndex = 14;
            // 
            // currentNeutralTierLabel
            // 
            currentNeutralTierLabel.AutoSize = true;
            currentNeutralTierLabel.Location = new Point(12, 426);
            currentNeutralTierLabel.Name = "currentNeutralTierLabel";
            currentNeutralTierLabel.Size = new Size(150, 15);
            currentNeutralTierLabel.TabIndex = 15;
            currentNeutralTierLabel.Text = "Current Neutral Item Tier: 1";
            // 
            // nextLotusSpawnLabel
            // 
            nextLotusSpawnLabel.AutoSize = true;
            nextLotusSpawnLabel.Location = new Point(12, 397);
            nextLotusSpawnLabel.Name = "nextLotusSpawnLabel";
            nextLotusSpawnLabel.Size = new Size(129, 15);
            nextLotusSpawnLabel.TabIndex = 16;
            nextLotusSpawnLabel.Text = "Next Lotus Spawn: 3:00";
            // 
            // nextWisdowRuneSpawn
            // 
            nextWisdowRuneSpawn.AutoSize = true;
            nextWisdowRuneSpawn.Location = new Point(12, 370);
            nextWisdowRuneSpawn.Name = "nextWisdowRuneSpawn";
            nextWisdowRuneSpawn.Size = new Size(172, 15);
            nextWisdowRuneSpawn.TabIndex = 17;
            nextWisdowRuneSpawn.Text = "Next Wisdow Rune Spawn: 7:00";
            // 
            // roshanDropsLabel
            // 
            roshanDropsLabel.AutoSize = true;
            roshanDropsLabel.Location = new Point(160, 197);
            roshanDropsLabel.Name = "roshanDropsLabel";
            roshanDropsLabel.Size = new Size(0, 15);
            roshanDropsLabel.TabIndex = 18;
            // 
            // DotaTimerAppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 450);
            Controls.Add(roshanDropsLabel);
            Controls.Add(nextWisdowRuneSpawn);
            Controls.Add(nextLotusSpawnLabel);
            Controls.Add(currentNeutralTierLabel);
            Controls.Add(direTormentorLabel);
            Controls.Add(radiantTormentorLabel);
            Controls.Add(direTormentorDeadButton);
            Controls.Add(radiantTormentorDeadButton);
            Controls.Add(aegisTimerLabel);
            Controls.Add(aegisInPlayLabel);
            Controls.Add(aegisCarrierDiedButton);
            Controls.Add(roshanNextPossibleSpawnTimestampLabel);
            Controls.Add(roshanLastDeathTimestampLabel);
            Controls.Add(roshanNumberLabel);
            Controls.Add(roshanDiedButton);
            Controls.Add(resetTimerButton);
            Controls.Add(stopTimerButton);
            Controls.Add(elapsedTimeLabel);
            Controls.Add(startTimerButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DotaTimerAppForm";
            Text = "Dota Game Timer App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startTimerButton;
        public System.Windows.Forms.Timer gameTimer;
        private Label elapsedTimeLabel;
        private Button stopTimerButton;
        private Button resetTimerButton;
        private Button roshanDiedButton;
        private Label roshanNumberLabel;
        private Label roshanLastDeathTimestampLabel;
        private Label roshanNextPossibleSpawnTimestampLabel;
        private Button aegisCarrierDiedButton;
        private Label aegisInPlayLabel;
        private Label aegisTimerLabel;
        private Button radiantTormentorDeadButton;
        private Button direTormentorDeadButton;
        private Label radiantTormentorLabel;
        private Label direTormentorLabel;
        private Label currentNeutralTierLabel;
        private Label nextLotusSpawnLabel;
        private Label nextWisdowRuneSpawn;
        private Label roshanDropsLabel;
    }
}