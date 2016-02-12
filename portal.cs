using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class portal : figure
    {

        public portal(int x1, int y1, int x2, int y2)
        {
            pList = new List<point>();
            point port1 = new point(x1, y1, 5);
            pList.Add(port1);
            point port2 = new point(x2, y2, 5);
            pList.Add(port2);
            Draw();
        }

        public new point IsHit(point head)
        {
            if (head.IsHit(pList.First()))
                return pList.First();
            if (head.IsHit(pList.Last()))
                return pList.Last();
            return null;
        }

        public point OtherPoint(point p)
        {
            if (p == pList.First())
                return pList.Last();
            else
                return pList.First();
        }
    }
}
