namespace SpaceInvadore
{
    partial class ZombieGame
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            player = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            lblScore = new Label();
            pnlSpawnZone = new Panel();
            lblWave = new Label();
            healthbar = new ProgressBar();
            DammageTimer = new System.Windows.Forms.Timer(components);
            lblMuni = new Label();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // player
            // 
            player.BackColor = Color.Transparent;
            player.Image = ZombiesInvader.Properties.Resources.up;
            player.Location = new Point(445, 618);
            player.Name = "player";
            player.Size = new Size(71, 100);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimer_Tick;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblScore.ForeColor = SystemColors.ButtonHighlight;
            lblScore.Location = new Point(436, 9);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(63, 19);
            lblScore.TabIndex = 3;
            lblScore.Text = "Score : 0";
            // 
            // pnlSpawnZone
            // 
            pnlSpawnZone.BackColor = Color.DarkTurquoise;
            pnlSpawnZone.Location = new Point(581, 598);
            pnlSpawnZone.Name = "pnlSpawnZone";
            pnlSpawnZone.Size = new Size(110, 110);
            pnlSpawnZone.TabIndex = 4;
            pnlSpawnZone.Visible = false;
            // 
            // lblWave
            // 
            lblWave.AutoSize = true;
            lblWave.BackColor = Color.Transparent;
            lblWave.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Italic, GraphicsUnit.Point);
            lblWave.ForeColor = Color.DarkRed;
            lblWave.Location = new Point(392, 312);
            lblWave.Name = "lblWave";
            lblWave.Size = new Size(167, 55);
            lblWave.TabIndex = 6;
            lblWave.Text = "label1";
            lblWave.Visible = false;
            // 
            // healthbar
            // 
            healthbar.Location = new Point(750, 9);
            healthbar.Name = "healthbar";
            healthbar.Size = new Size(216, 23);
            healthbar.TabIndex = 7;
            healthbar.Value = 100;
            // 
            // DammageTimer
            // 
            DammageTimer.Enabled = true;
            DammageTimer.Interval = 500;
            DammageTimer.Tick += DammageTimer_Tick;
            // 
            // lblMuni
            // 
            lblMuni.AutoSize = true;
            lblMuni.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMuni.ForeColor = SystemColors.ControlLightLight;
            lblMuni.Location = new Point(12, 9);
            lblMuni.Name = "lblMuni";
            lblMuni.Size = new Size(98, 19);
            lblMuni.TabIndex = 8;
            lblMuni.Text = "Munitions : 10";
            // 
            // ZombieGame
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(978, 744);
            Controls.Add(lblMuni);
            Controls.Add(healthbar);
            Controls.Add(lblWave);
            Controls.Add(pnlSpawnZone);
            Controls.Add(lblScore);
            Controls.Add(player);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "ZombieGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zombie Game";
            Load += ZombieGame_Load;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private Label lblScore;
        private Panel pnlSpawnZone;
        private Label lblWave;
        private ProgressBar healthbar;
        private System.Windows.Forms.Timer DammageTimer;
        private PictureBox pictureBox1;
        private Label lblMuni;
    }
}