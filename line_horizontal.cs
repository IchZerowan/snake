using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class line_horizontal : figure
    {

        public line_horizontal(int xl, int xr, int y, int s)
        {
            pList = new List<point>();
            for (int x = xl; x <= xr; x++)
            {
                point p = new point(x, y, s);
                pList.Add(p);
            }

        }
    }
}
