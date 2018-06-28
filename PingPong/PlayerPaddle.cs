using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PingPong
{
    public class PlayerPaddle
    {
        public const int zPosition = 0;
        public Point center;
        public int radius = 40;
        public int power;
        public int direction;
        public static int points;
        public bool chargeUp;
        public PlayerPaddle()
        {
            chargeUp = true;
            this.power = 0;
            direction = -1;
            center = new Point(458, 200);
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
            g.DrawEllipse(Pens.Black, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

            if(direction == 1)
            {
                g.FillRectangle(Brushes.Gray, center.X + radius - 5 , center.Y-5, 40+power, 10+power/2);
            }
            else
            {
                g.FillRectangle(Brushes.Gray, center.X - radius - 35 - power, center.Y - 5, 40+power, 10+power/2);
            }
        }

        public void Move(Point newPosition)
        {
            if (newPosition.X  > center.X) direction = -1;
            else if (newPosition.X  < center.X) direction = 1;
            center = newPosition;
        }

        public void Charge()
        {
            if (chargeUp && power < 10)
            {
                power++;
                radius++;
            }
            else if(!chargeUp && power > 0)
            {
                power--;
                radius--;
            }
            
        }

    }
}
