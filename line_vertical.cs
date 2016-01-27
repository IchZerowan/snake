using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class line_vertical : figure
    {
        public line_vertical(int yu, int yd, int x, char s)
        {
            pList = new List<point>();
            for (int y = yu; y <= yd; y++)
            {
                point p = new point(x, y, s);
                pList.Add(p);
            }

        }
    }
}
