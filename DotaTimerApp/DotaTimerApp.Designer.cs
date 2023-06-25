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
            roshanPanel = new Panel();
            aegisPanel = new Panel();
            neutralItemPicture = new PictureBox();
            lotusPicture = new PictureBox();
            wisdomRunePicture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)neutralItemPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lotusPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wisdomRunePicture).BeginInit();
            SuspendLayout();
            // 
            // startTimerButton
            // 
            startTimerButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            startTimerButton.ForeColor = Color.ForestGreen;
            startTimerButton.Location = new Point(23, 84);
            startTimerButton.Name = "startTimerButton";
            startTimerButton.Size = new Size(142, 28);
            startTimerButton.TabIndex = 0;
            startTimerButton.Text = "Start";
            startTimerButton.UseVisualStyleBackColor = true;
            startTimerButton.Click += startTimerButton_Click;
            // 
            // elapsedTimeLabel
            // 
            elapsedTimeLabel.Anchor = AnchorStyles.Top;
            elapsedTimeLabel.AutoSize = true;
            elapsedTimeLabel.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            elapsedTimeLabel.Location = new Point(140, 9);
            elapsedTimeLabel.Name = "elapsedTimeLabel";
            elapsedTimeLabel.Size = new Size(204, 65);
            elapsedTimeLabel.TabIndex = 1;
            elapsedTimeLabel.Text = "00:00:00";
            // 
            // stopTimerButton
            // 
            stopTimerButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            stopTimerButton.ForeColor = Color.Orange;
            stopTimerButton.Location = new Point(319, 84);
            stopTimerButton.Name = "stopTimerButton";
            stopTimerButton.Size = new Size(142, 28);
            stopTimerButton.TabIndex = 2;
            stopTimerButton.Text = "Pause";
            stopTimerButton.UseVisualStyleBackColor = true;
            stopTimerButton.Click += stopTimerButton_Click;
            // 
            // resetTimerButton
            // 
            resetTimerButton.BackColor = SystemColors.Window;
            resetTimerButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            resetTimerButton.ForeColor = Color.Brown;
            resetTimerButton.Location = new Point(171, 84);
            resetTimerButton.Name = "resetTimerButton";
            resetTimerButton.Size = new Size(142, 28);
            resetTimerButton.TabIndex = 3;
            resetTimerButton.Text = "Reset";
            resetTimerButton.UseVisualStyleBackColor = false;
            resetTimerButton.Click += resetTimerButton_Click;
            // 
            // roshanDiedButton
            // 
            roshanDiedButton.Location = new Point(23, 129);
            roshanDiedButton.Name = "roshanDiedButton";
            roshanDiedButton.Size = new Size(142, 73);
            roshanDiedButton.TabIndex = 4;
            roshanDiedButton.Text = "Roshan Death";
            roshanDiedButton.UseVisualStyleBackColor = true;
            roshanDiedButton.Click += roshanDiedButton_Click;
            // 
            // roshanNumberLabel
            // 
            roshanNumberLabel.AutoSize = true;
            roshanNumberLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            roshanNumberLabel.Location = new Point(174, 138);
            roshanNumberLabel.Name = "roshanNumberLabel";
            roshanNumberLabel.Size = new Size(132, 19);
            roshanNumberLabel.TabIndex = 5;
            roshanNumberLabel.Text = "Current Roshan #: 1";
            // 
            // roshanLastDeathTimestampLabel
            // 
            roshanLastDeathTimestampLabel.AutoSize = true;
            roshanLastDeathTimestampLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            roshanLastDeathTimestampLabel.Location = new Point(319, 138);
            roshanLastDeathTimestampLabel.Name = "roshanLastDeathTimestampLabel";
            roshanLastDeathTimestampLabel.Size = new Size(106, 19);
            roshanLastDeathTimestampLabel.TabIndex = 6;
            roshanLastDeathTimestampLabel.Text = "Last Death: N/A";
            // 
            // roshanNextPossibleSpawnTimestampLabel
            // 
            roshanNextPossibleSpawnTimestampLabel.AutoSize = true;
            roshanNextPossibleSpawnTimestampLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            roshanNextPossibleSpawnTimestampLabel.Location = new Point(174, 176);
            roshanNextPossibleSpawnTimestampLabel.Name = "roshanNextPossibleSpawnTimestampLabel";
            roshanNextPossibleSpawnTimestampLabel.Size = new Size(162, 19);
            roshanNextPossibleSpawnTimestampLabel.TabIndex = 7;
            roshanNextPossibleSpawnTimestampLabel.Text = "Next Spawn Interval: N/A";
            // 
            // aegisCarrierDiedButton
            // 
            aegisCarrierDiedButton.Location = new Point(23, 210);
            aegisCarrierDiedButton.Name = "aegisCarrierDiedButton";
            aegisCarrierDiedButton.Size = new Size(142, 51);
            aegisCarrierDiedButton.TabIndex = 8;
            aegisCarrierDiedButton.Text = "Aegis Carrier Died";
            aegisCarrierDiedButton.UseVisualStyleBackColor = true;
            aegisCarrierDiedButton.Click += aegisCarrierDiedButton_Click;
            // 
            // aegisInPlayLabel
            // 
            aegisInPlayLabel.AutoSize = true;
            aegisInPlayLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            aegisInPlayLabel.Location = new Point(174, 217);
            aegisInPlayLabel.Name = "aegisInPlayLabel";
            aegisInPlayLabel.Size = new Size(111, 19);
            aegisInPlayLabel.TabIndex = 9;
            aegisInPlayLabel.Text = "Aegis in Play: No";
            // 
            // aegisTimerLabel
            // 
            aegisTimerLabel.AutoSize = true;
            aegisTimerLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            aegisTimerLabel.Location = new Point(174, 236);
            aegisTimerLabel.Name = "aegisTimerLabel";
            aegisTimerLabel.Size = new Size(162, 19);
            aegisTimerLabel.TabIndex = 10;
            aegisTimerLabel.Text = "Current Aegis Timer: N/A";
            // 
            // radiantTormentorDeadButton
            // 
            radiantTormentorDeadButton.ForeColor = Color.ForestGreen;
            radiantTormentorDeadButton.Location = new Point(23, 267);
            radiantTormentorDeadButton.Name = "radiantTormentorDeadButton";
            radiantTormentorDeadButton.Size = new Size(163, 42);
            radiantTormentorDeadButton.TabIndex = 11;
            radiantTormentorDeadButton.Text = "Radiant Tormentor Dead";
            radiantTormentorDeadButton.UseVisualStyleBackColor = true;
            radiantTormentorDeadButton.Click += radiantTormentorDeadButton_Click;
            // 
            // direTormentorDeadButton
            // 
            direTormentorDeadButton.ForeColor = Color.Brown;
            direTormentorDeadButton.Location = new Point(298, 267);
            direTormentorDeadButton.Name = "direTormentorDeadButton";
            direTormentorDeadButton.Size = new Size(163, 42);
            direTormentorDeadButton.TabIndex = 12;
            direTormentorDeadButton.Text = "Dire Tormentor Dead";
            direTormentorDeadButton.UseVisualStyleBackColor = true;
            direTormentorDeadButton.Click += direTormentorDeadButton_Click;
            // 
            // radiantTormentorLabel
            // 
            radiantTormentorLabel.AutoSize = true;
            radiantTormentorLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radiantTormentorLabel.Location = new Point(25, 312);
            radiantTormentorLabel.Name = "radiantTormentorLabel";
            radiantTormentorLabel.Size = new Size(159, 19);
            radiantTormentorLabel.TabIndex = 13;
            radiantTormentorLabel.Text = "Tormentor Spawn: 20:00";
            // 
            // direTormentorLabel
            // 
            direTormentorLabel.AutoSize = true;
            direTormentorLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            direTormentorLabel.Location = new Point(300, 312);
            direTormentorLabel.Name = "direTormentorLabel";
            direTormentorLabel.Size = new Size(159, 19);
            direTormentorLabel.TabIndex = 14;
            direTormentorLabel.Text = "Tormentor Spawn: 20:00";
            // 
            // currentNeutralTierLabel
            // 
            currentNeutralTierLabel.AutoSize = true;
            currentNeutralTierLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentNeutralTierLabel.Location = new Point(75, 417);
            currentNeutralTierLabel.Name = "currentNeutralTierLabel";
            currentNeutralTierLabel.Size = new Size(317, 19);
            currentNeutralTierLabel.TabIndex = 15;
            currentNeutralTierLabel.Text = "Too early for Neutral drops. Next tier starts at 7:00";
            // 
            // nextLotusSpawnLabel
            // 
            nextLotusSpawnLabel.AutoSize = true;
            nextLotusSpawnLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nextLotusSpawnLabel.Location = new Point(75, 380);
            nextLotusSpawnLabel.Name = "nextLotusSpawnLabel";
            nextLotusSpawnLabel.Size = new Size(153, 19);
            nextLotusSpawnLabel.TabIndex = 16;
            nextLotusSpawnLabel.Text = "Next Lotus Spawn: 3:00";
            // 
            // nextWisdowRuneSpawn
            // 
            nextWisdowRuneSpawn.AutoSize = true;
            nextWisdowRuneSpawn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nextWisdowRuneSpawn.Location = new Point(75, 341);
            nextWisdowRuneSpawn.Name = "nextWisdowRuneSpawn";
            nextWisdowRuneSpawn.Size = new Size(202, 19);
            nextWisdowRuneSpawn.TabIndex = 17;
            nextWisdowRuneSpawn.Text = "Next Wisdow Rune Spawn: 7:00";
            // 
            // roshanDropsLabel
            // 
            roshanDropsLabel.AutoSize = true;
            roshanDropsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            roshanDropsLabel.Location = new Point(174, 157);
            roshanDropsLabel.Name = "roshanDropsLabel";
            roshanDropsLabel.Size = new Size(86, 19);
            roshanDropsLabel.TabIndex = 18;
            roshanDropsLabel.Text = "Drops: Aegis";
            // 
            // roshanPanel
            // 
            roshanPanel.BorderStyle = BorderStyle.FixedSingle;
            roshanPanel.Location = new Point(171, 129);
            roshanPanel.Name = "roshanPanel";
            roshanPanel.Size = new Size(290, 73);
            roshanPanel.TabIndex = 19;
            // 
            // aegisPanel
            // 
            aegisPanel.BorderStyle = BorderStyle.FixedSingle;
            aegisPanel.Location = new Point(171, 210);
            aegisPanel.Name = "aegisPanel";
            aegisPanel.Size = new Size(288, 51);
            aegisPanel.TabIndex = 20;
            // 
            // neutralItemPicture
            // 
            neutralItemPicture.Location = new Point(25, 410);
            neutralItemPicture.Name = "neutralItemPicture";
            neutralItemPicture.Size = new Size(44, 32);
            neutralItemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            neutralItemPicture.TabIndex = 21;
            neutralItemPicture.TabStop = false;
            // 
            // lotusPicture
            // 
            lotusPicture.Image = Properties.Resources.healingLotus;
            lotusPicture.Location = new Point(25, 372);
            lotusPicture.Name = "lotusPicture";
            lotusPicture.Size = new Size(44, 32);
            lotusPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            lotusPicture.TabIndex = 22;
            lotusPicture.TabStop = false;
            // 
            // wisdomRunePicture
            // 
            wisdomRunePicture.Image = Properties.Resources.wisdomRune;
            wisdomRunePicture.Location = new Point(25, 334);
            wisdomRunePicture.Name = "wisdomRunePicture";
            wisdomRunePicture.Size = new Size(44, 32);
            wisdomRunePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            wisdomRunePicture.TabIndex = 23;
            wisdomRunePicture.TabStop = false;
            // 
            // DotaTimerAppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(484, 463);
            Controls.Add(wisdomRunePicture);
            Controls.Add(lotusPicture);
            Controls.Add(neutralItemPicture);
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
            Controls.Add(roshanPanel);
            Controls.Add(aegisPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DotaTimerAppForm";
            Text = "Dota Game Timer App";
            ((System.ComponentModel.ISupportInitialize)neutralItemPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)lotusPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)wisdomRunePicture).EndInit();
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
        private Panel roshanPanel;
        private Panel aegisPanel;
        private PictureBox neutralItemPicture;
        private PictureBox lotusPicture;
        private PictureBox wisdomRunePicture;
    }
}