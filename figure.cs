using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class figure
    {
        protected List<point> pList;

        public virtual void Draw()
        {
            foreach (point p in pList)
            {
                p.Draw();
            }
        }

        public bool IsHeat(figure f)
        {
            foreach (var p in pList)
            {
                if (f.IsHeat(p))
                    return true;
            }
            return false;
        }

        public bool IsHeat(point p)
        {
            foreach (var point in pList)
            {
                if (p.isHit(point))
                    return true;
            }
            return false;
        }
    }
}
