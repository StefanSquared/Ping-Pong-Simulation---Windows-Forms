using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace PingPong
{
    public partial class Form1 : Form
    {
        Table table;
        Ball ball;
        PlayerPaddle paddle;
        EnemyPaddle opponentPaddle;
        int Countdown;
        Random r;
        public Form1()
        {
            InitializeComponent();
            startNewGame_Click(null, null);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            table.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Move();
            tsBallInfo.Text = string.Format("ball position: {0:0.00}, {1:0.0}, {2:0.0}", ball.center.X, ball.center.Y, ball.center.Z);
            opponentPaddle.Move(ball);
            pointsEarned.Text = "Points: " + PlayerPaddle.points.ToString();
            opponentPointsEarned.Text = "Opponent points: " + EnemyPaddle.points.ToString();
            Invalidate(true);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            paddle.Move(e.Location);
            Invalidate(true);
        }

        private void startNewGame_Click(object sender, EventArgs e)
        {
            //clear past games
            timer3.Stop();
            timer2.Stop();
            paddlePower.Value = 0;
            lbCountdown.Visible = false;
            Countdown = 3;

            //generate objects
            table = new Table();
            r = new Random();
            double vAngled = r.Next(10) + 17;
            double vUp = r.Next(5) + 10;
            double bAngle = Math.PI / 2 + r.NextDouble() * 0.2;
            Point3D startPoint = new Point3D(450, 300, 400);
            ball = new Ball(this, table, startPoint, 10, vAngled, vUp, bAngle);
            paddle = new PlayerPaddle();
            opponentPaddle = new EnemyPaddle();

            //add references to other objects for interaction
            table.childBall = ball;
            table.opponentPaddle = opponentPaddle;
            table.ourPaddle = paddle;
            ball.playerPaddle = paddle;
            ball.opponentPaddle = opponentPaddle;

            //start game
            timer1.Start();
        }
        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer2.Start();
            paddle.chargeUp = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            paddle.Charge();
            paddlePower.Value = paddle.power * 10;
            if (!paddle.chargeUp)
            {
                paddle.Charge();
                paddle.Charge();
                paddle.Charge();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            Countdown--;
            lbCountdown.Text = Countdown.ToString();
            if (Countdown == 0)
            {
                lbCountdown.Visible = false;
                timer3.Stop();
                startNewGame_Click(null, null);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paddle.chargeUp = false;
        }

        public void startTimer()
        {
            Countdown = 3;
            lbCountdown.Text = Countdown.ToString();
            lbCountdown.Visible = true;
            timer3.Start();
            
        }
    }
}
