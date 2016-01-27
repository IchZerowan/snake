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

        public point next()
        {
            int x = rnd.Next(1, whidth - 1);
            int y = rnd.Next(1, height - 1);
            return new point(x, y, s);
        }
    }
}
