using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PingPong
{
    public class SoundFX
    {
        public static Random r = new Random();

        public static void Pong()
        {
            SoundPlayer player;
            int x = r.Next(3);
            if(x == 0) player = new SoundPlayer(Properties.Resources.PONG1);
            else if(x==1) player = new SoundPlayer(Properties.Resources.PONG2);
            else player = new SoundPlayer(Properties.Resources.PONG3);
            player.Play();
        }

    }
}
