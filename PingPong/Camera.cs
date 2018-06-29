using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PingPong
{
    public class Camera
    {
        public static Matrix3D cameraMatrix = new Matrix3D(-1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1, 0, 450, -300, -500, 1);
        public static bool leftEyeView = true;

        public static Point[] Transform(Point3D[] inArray)
        {
            Point[] outArray = new Point[inArray.Length];

            for (int i = 0; i < inArray.Length; i++)
            {
                Point3D p = inArray[i];
                outArray[i] = new Point((int)(560 * p.X / p.Z) + 450, (int)(560 * p.Y / p.Z) + 200);
            }
            return outArray;
        }
    }
}
