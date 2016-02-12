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

        public bool IsHit(figure f)
        {
            foreach (var p in pList)
            {
                if (f.IsHit(p))
                    return true;
            }
            return false;
        }

        public bool IsHit(point p)
        {
            foreach (var point in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
