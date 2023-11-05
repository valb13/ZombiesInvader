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
            lblScore.Size = new Size(90, 28);
            lblScore.TabIndex = 3;
            lblScore.Text = "Score : 0";
            // 
            // ZombieGame
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(978, 744);
            Controls.Add(lblScore);
            Controls.Add(player);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "ZombieGame";
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
    }
}