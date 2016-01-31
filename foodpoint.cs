using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class foodpoint
    {
        int whidth;
        int height;
        int s;

        Random rnd = new Random();

        public foodpoint(int width, int height, int s)
        {
            whidth = width;
            this.height = height;
            this.s = s;
        }

        public point next(snake Snake)
        {
            int x;
            int y;
            point p;
            do
            {
                x = rnd.Next(1, whidth - 1);
                y = rnd.Next(1, height - 1);
                p = new point(x, y, s);
            } while (Snake.IsHeat(p));
            return p;
        }
    }
}
