namespace PingPong
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.startNewGame = new System.Windows.Forms.Button();
            this.pointsEarned = new System.Windows.Forms.Label();
            this.opponentPointsEarned = new System.Windows.Forms.Label();
            this.paddlePower = new System.Windows.Forms.ProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsBallInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCountdown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(10, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 800);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // startNewGame
            // 
            this.startNewGame.Location = new System.Drawing.Point(380, 12);
            this.startNewGame.Name = "startNewGame";
            this.startNewGame.Size = new System.Drawing.Size(145, 32);
            this.startNewGame.TabIndex = 1;
            this.startNewGame.Text = "Start a New Game";
            this.startNewGame.UseVisualStyleBackColor = true;
            this.startNewGame.Click += new System.EventHandler(this.startNewGame_Click);
            // 
            // pointsEarned
            // 
            this.pointsEarned.AutoSize = true;
            this.pointsEarned.Location = new System.Drawing.Point(251, 19);
            this.pointsEarned.Name = "pointsEarned";
            this.pointsEarned.Size = new System.Drawing.Size(42, 13);
            this.pointsEarned.TabIndex = 2;
            this.pointsEarned.Text = "Points: ";
            // 
            // opponentPointsEarned
            // 
            this.opponentPointsEarned.AutoSize = true;
            this.opponentPointsEarned.Location = new System.Drawing.Point(617, 19);
            this.opponentPointsEarned.Name = "opponentPointsEarned";
            this.opponentPointsEarned.Size = new System.Drawing.Size(89, 13);
            this.opponentPointsEarned.TabIndex = 3;
            this.opponentPointsEarned.Text = "Opponent Points:";
            // 
            // paddlePower
            // 
            this.paddlePower.Location = new System.Drawing.Point(22, 14);
            this.paddlePower.Name = "paddlePower";
            this.paddlePower.Size = new System.Drawing.Size(124, 17);
            this.paddlePower.TabIndex = 4;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBallInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 850);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(917, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsBallInfo
            // 
            this.tsBallInfo.Name = "tsBallInfo";
            this.tsBallInfo.Size = new System.Drawing.Size(78, 17);
            this.tsBallInfo.Text = "Ball Position: ";
            // 
            // lbCountdown
            // 
            this.lbCountdown.AutoSize = true;
            this.lbCountdown.BackColor = System.Drawing.Color.Transparent;
            this.lbCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountdown.ForeColor = System.Drawing.Color.Red;
            this.lbCountdown.Location = new System.Drawing.Point(704, 50);
            this.lbCountdown.Name = "lbCountdown";
            this.lbCountdown.Size = new System.Drawing.Size(206, 226);
            this.lbCountdown.TabIndex = 6;
            this.lbCountdown.Text = "3";
            this.lbCountdown.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 872);
            this.Controls.Add(this.lbCountdown);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.paddlePower);
            this.Controls.Add(this.opponentPointsEarned);
            this.Controls.Add(this.pointsEarned);
            this.Controls.Add(this.startNewGame);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button startNewGame;
        private System.Windows.Forms.Label pointsEarned;
        private System.Windows.Forms.Label opponentPointsEarned;
        private System.Windows.Forms.ProgressBar paddlePower;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsBallInfo;
        private System.Windows.Forms.Label lbCountdown;
    }
}

