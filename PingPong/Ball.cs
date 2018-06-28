using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PingPong
{
    public class Ball
    {
        public double radius;
        public Point3D center;
        public double angle;
        public double velocityAngled;
        public double velocityUp;
        public static double bounciness = 0.9;
        public const double gravity = 1.5;
        public bool rolling;
        public bool falling;
        public Table parentTable;
        public Point screenCenter;
        public Form1 parentForm;
        public bool tapTwice;
        public int zIndex; // 0: pozadi table/enemy paddle, 1: pomegju e-paddle i net, 2: pomegju net i player-paddle, 3: pred player-paddle
        public int prevZIndex;

        Random r = new Random();
        public PlayerPaddle playerPaddle { get; set; }
        public EnemyPaddle opponentPaddle { get; set; }

        public Ball(Form1 f, Table t, Point3D position, double radius=10, double velocityAngled=0, double velocityUp=0, double angle=0)
        {
            rolling = false;
            falling = false;
            this.parentTable = t;
            zIndex = findZIndex();
            prevZIndex = -1;
            this.radius = radius;
            this.center = position;
            this.velocityAngled = velocityAngled;
            this.velocityUp = velocityUp;
            this.angle = angle;
            tapTwice = false;
            parentForm = f;
        }

        public void CheckPaddleHit()
        {
            if (Math.Abs(center.Z - PlayerPaddle.zPosition) < 40)
            {
                double diff = (screenCenter.X - playerPaddle.center.X) * (screenCenter.X - playerPaddle.center.X) + 
                    (screenCenter.Y - playerPaddle.center.Y) * (screenCenter.Y - playerPaddle.center.Y);
                if (diff <= playerPaddle.radius * playerPaddle.radius && angle < 0)
                    PaddleHit(diff);
            }
            
        }
        public void PaddleHit(double diff)
        {
            double hypotenuse = Math.Sqrt(diff);
            double adjacent = screenCenter.X - playerPaddle.center.X;
            double cosine = adjacent / hypotenuse;
            angle = Math.PI / 2;// + cosine*Math.PI/4;
            if (playerPaddle.center.X > 450)
                angle += r.NextDouble() * .2;
            else
                angle -= r.NextDouble() * .2;
            if (center.Y > 300)
            {
                velocityUp = -r.Next(10) + 5;
                velocityAngled *= 1.2;
            }
            else
                velocityUp = r.Next(6) + 20;
            velocityAngled *= ((1 + r.NextDouble() * .2 - 0.1) + (double)(playerPaddle.power / 20));
            SoundFX.Pong();

        }
        public void CheckEnemyPaddleHit()
        {
            if (Math.Abs(center.Z - EnemyPaddle.zPosition) < 20)
            {
                double diff = (center.X - opponentPaddle.center.X) * (center.X - opponentPaddle.center.X) + (center.Y - opponentPaddle.center.Y) * (center.Y - opponentPaddle.center.Y);
                if (diff <= opponentPaddle.radius * opponentPaddle.radius)
                    EnemyPaddleHit();
            }

        }
        public void EnemyPaddleHit()
        {
            angle = -Math.PI / 2;
            if (opponentPaddle.center.X < 450)
                angle += r.NextDouble() * .2;
            else
                angle -= r.NextDouble() * .2;
            if (center.Y > 300)
            {
                velocityUp = -r.Next(10)+5;
                velocityAngled *= 1.2;
            }
            else
                velocityUp = r.Next(6) + 20;
            velocityAngled *= (1 + r.NextDouble()*.2 - 0.1);
            SoundFX.Pong();
        }

        public void Move()
        {
            center.X += Math.Cos(angle) * velocityAngled;
            center.Z += Math.Sin(angle) * velocityAngled;
            CheckEnemyPaddleHit();
            CheckPaddleHit();
            zIndex = findZIndex();
            if (rolling && velocityAngled > 0)
            {
                velocityAngled -= 0.01;
                if(velocityAngled < 0)
                {
                    velocityAngled = 0;
                }
                if (IsOut() && center.Y <= 0)
                {
                    falling = true;
                    rolling = false;
                }
            }
           
            if (!rolling || falling)
            {
                velocityUp -= gravity;
                center.Y += velocityUp;
                
                if (!falling && velocityUp < 0 && center.Y <= radius)
                {
                    if (center.Y < radius) center.Y = radius;
                    if (!IsOut())
                    {
                        if (prevZIndex == zIndex)
                        {
                            awardPoint(zIndex);
                        }
                        BounceUp();
                    }
                    else
                    {   
                        falling = true;
                        if (center.Z > 1590/2)
                            PlayerPaddle.points++;
                        else
                            EnemyPaddle.points++;
                        parentForm.startTimer();
                    }
                }
            }
        }
        public void awardPoint(int a)
        {
            if (a == 2)
                EnemyPaddle.points++;
            else if (a == 3)
                PlayerPaddle.points++;

        }
        public int findZIndex()
        {
            if (falling) return 1;
            if (center.Z > EnemyPaddle.zPosition) return 0; // after paddle
            else if (center.Z > parentTable.originalArrayOutline[0].Z) return 1; //after table
            else if (center.Z > 770) return 2; //after net
            else if (center.Z > parentTable.originalArrayOutline[2].Z) return 3; // before net
            else return 4;  // before paddle
        }

        private void BounceUp()
        {
            if (!rolling)
            {
                velocityUp *= -1;
                velocityUp *= bounciness;
                SoundFX.Pong();
            }
            if (Math.Abs(velocityUp) < 1)
            {
                velocityUp = 0;
                rolling = true;
            }
        }

        
        public void Draw(Graphics g)
        {
            Point3D[] arrayBall = 
            {
                new Point3D(center.X - radius, center.Y + radius, center.Z),
                new Point3D(center.X - radius, center.Y - radius, center.Z),
                new Point3D(center.X + radius, center.Y - radius, center.Z),
                new Point3D(center.X + radius, center.Y + radius, center.Z)
            };

            Point3D[] arrayShadow =
            {
                new Point3D(center.X - radius, 0, center.Z + radius),
                new Point3D(center.X - radius, 0, center.Z - radius),
                new Point3D(center.X + radius, 0, center.Z - radius),
                new Point3D(center.X + radius, 0, center.Z + radius)
            };
            
            Camera.cameraMatrix.Transform(arrayBall);

            Point[] canvasArray = Camera.Transform(arrayBall);
            Rectangle ballRectangle = new Rectangle(canvasArray[0].X, canvasArray[0].Y, Math.Abs(canvasArray[2].X - canvasArray[0].X), Math.Abs(canvasArray[2].Y - canvasArray[0].Y));

            if (!IsOut())
            {
                Camera.cameraMatrix.Transform(arrayShadow);
                Point[] shadowArray = Camera.Transform(arrayShadow);
                Rectangle shadow = new Rectangle(shadowArray[0].X, shadowArray[0].Y, Math.Abs(shadowArray[2].X - shadowArray[0].X), Math.Abs(shadowArray[2].Y - shadowArray[0].Y));
                g.FillEllipse(Brushes.Black, shadow);

            }

            screenCenter = new Point(ballRectangle.X + ballRectangle.Width / 2, ballRectangle.Y + ballRectangle.Height / 2);

            g.FillEllipse(Brushes.White, ballRectangle);
            g.DrawEllipse(Pens.Black, ballRectangle);

        }

        public bool IsOut()
        {
            if (center.X < parentTable.originalArrayOutline[0].X || center.Z > parentTable.originalArrayOutline[0].Z || 
                center.X > parentTable.originalArrayOutline[2].X || center.Z < parentTable.originalArrayOutline[2].Z)
                return true;
            return false;
        }


    }
}
