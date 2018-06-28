using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PingPong
{
    public class Table
    {
        public Point3D[] arrayOutline;
        public Point3D[] array;
        public Point3D[] arrayNet;
        public Point3D[] arrayLine;
        public Ball childBall;
        public PlayerPaddle ourPaddle;
        public EnemyPaddle opponentPaddle;
        public Point3D[] originalArrayOutline;
        public Table()
        {
            fillArrays();   
        }

        private void fillArrays()
        {
            array = new Point3D[] { new Point3D(50, 0, 1490), new Point3D(850, 0, 1490), new Point3D(850, 0, 50), new Point3D(50, 0, 50) };
            arrayOutline = new Point3D[] { new Point3D(35, 0, 1505), new Point3D(865, 0, 1505), new Point3D(865, 0, 35), new Point3D(35, 0, 35) };
            originalArrayOutline = new Point3D[] { new Point3D(35, 0, 1505), new Point3D(865, 0, 1505), new Point3D(865, 0, 35), new Point3D(35, 0, 35) };
            arrayNet = new Point3D[] { new Point3D(0, 50, 770), new Point3D(900, 50, 770), new Point3D(900, 0, 770), new Point3D(0, 0, 770) };
            arrayLine = new Point3D[] { new Point3D(445, 0, 1490), new Point3D(455, 0, 1490), new Point3D(455, 0, 50), new Point3D(445, 0, 50) };
        }

        public void Draw(Graphics g)
        {
            Camera.cameraMatrix.Transform(arrayNet);
            Camera.cameraMatrix.Transform(array);
            Camera.cameraMatrix.Transform(arrayOutline);
            Camera.cameraMatrix.Transform(arrayLine);
            
            Point[] netArray = Camera.Transform(arrayNet);
            Point[] canvasArray = Camera.Transform(array);
            Point[] canvasOutline = Camera.Transform(arrayOutline);
            Point[] lineArray = Camera.Transform(arrayLine);

            if (childBall.zIndex == 0) //if behind enemy paddle
                childBall.Draw(g);

            //draw enemy paddle
            opponentPaddle.Draw(g);

            if (childBall.zIndex == 1) //if between table and enemy paddle
                childBall.Draw(g);

            //draw table
            g.FillPolygon(Brushes.White, canvasOutline);
            g.FillPolygon(Brushes.Blue, canvasArray);
            g.FillPolygon(Brushes.White, lineArray);
            
            if (childBall.zIndex == 2) //if after net
                childBall.Draw(g);

            //draw net
            g.FillPolygon(new HatchBrush(HatchStyle.SmallGrid, Color.White, Color.Blue), netArray);
            g.DrawPolygon(new Pen(Color.White, 2), netArray);

            if (childBall.zIndex == 3) // if before net
                childBall.Draw(g);

            // draw paddle
            ourPaddle.Draw(g);

            if (childBall.zIndex == 4) //if before paddle
                childBall.Draw(g);           

            fillArrays();  //reset the transformed arrays
        }
    }
}
