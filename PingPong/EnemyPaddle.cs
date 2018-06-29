using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PingPong
{
    
    public class EnemyPaddle
    {
        public const int zPosition = 1600;
        public Point3D center;
        public int radius = 40;
        public int power;
        public int direction;
        public Point3D[] enemyPaddleLine;
        public Point3D[] enemyPaddleHandle1;
        public Point3D[] enemyPaddleHandle2;
        public static int points;
        public EnemyPaddle()
        {
            this.power = 1;
            direction = -1;
            center = new Point3D(458, 100, 1640);
        }

        public void Draw(Graphics g)
        {
            enemyPaddleLine = new Point3D[]{
                new Point3D(center.X - radius, center.Y - radius , zPosition), 
                new Point3D(center.X + radius, center.Y - radius, zPosition), 
                new Point3D(center.X + radius, center.Y + radius, zPosition), 
                new Point3D(center.X - radius, center.Y + radius, zPosition) };

            Camera.cameraMatrix.Transform(enemyPaddleLine);
            Point[] enemyPaddleArray = Camera.Transform(enemyPaddleLine);
            
            g.FillEllipse(Brushes.Red, enemyPaddleArray[0].X, enemyPaddleArray[0].Y, enemyPaddleArray[1].X - enemyPaddleArray[0].X, enemyPaddleArray[3].Y - enemyPaddleArray[0].Y);
            g.DrawEllipse(Pens.Black, enemyPaddleArray[0].X, enemyPaddleArray[0].Y, enemyPaddleArray[1].X - enemyPaddleArray[0].X, enemyPaddleArray[3].Y - enemyPaddleArray[0].Y);
            
            if (direction == 1)
            {
                enemyPaddleHandle1 = new Point3D[] {
                new Point3D(center.X + radius - 5, center.Y-5, zPosition),
                new Point3D(center.X + radius - 5 + 40, center.Y - 5, zPosition),
                new Point3D(center.X + radius - 5 + 40, center.Y + 5, zPosition),
                new Point3D(center.X + radius - 5, center.Y + 5, zPosition) };

                Camera.cameraMatrix.Transform(enemyPaddleHandle1);
                Point[] enemyHandleArray1 = Camera.Transform(enemyPaddleHandle1);
                g.FillPolygon(Brushes.Gray, enemyHandleArray1);
            }
            else
            {
                enemyPaddleHandle2 = new Point3D[] {
                new Point3D(center.X - radius + 5 - 40, center.Y-5, zPosition),
                new Point3D(center.X - radius + 5 , center.Y - 5, zPosition),
                new Point3D(center.X - radius + 5 , center.Y + 5, zPosition),
                new Point3D(center.X - radius + 5 - 40, center.Y + 5, zPosition) };

                Camera.cameraMatrix.Transform(enemyPaddleHandle2);
                Point[] enemyHandleArray2 = Camera.Transform(enemyPaddleHandle2);
                g.FillPolygon(Brushes.Gray, enemyHandleArray2);
            };
                
        }
        public void Move(Ball b)
        {
            if (!b.falling && b.angle > 0)
            {
                Point3D oldCenter = center;
                center.X = (b.center.X*5 + center.X*9) / 14;
                center.Y = (b.center.Y*5 + center.Y*9) / 14;
                if (center.Y < 20)
                    center.Y = 20;
                if (center.Y > 400)
                    center.Y = 400;
                if (center.X > oldCenter.X) direction = -1;
                else if (center.X < oldCenter.X) direction = 1;

            }
            
        }
    }
        
 }
    

