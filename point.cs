using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class point
    {
        int x;
        int y;
        char s;

        public point(int _x, int _y, char _s)
        {
            x = _x;
            y = _y;
            s = _s;
        }

        public point(point p)
        {
            x = p.x;
            y = p.y;
            s = p.s;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

        public void move(int i, direction dir)
        {
            if (dir == direction.RIGHT)
                x = x + i;
            else if (dir == direction.LEFT)
                x = x - i;
            else if (dir == direction.DOWN)
                y = y + i;
            else if (dir == direction.UP)
                y = y - 1;
        }

        public void clear()
        {
            s = ' ';
            Draw();
        }

        public bool isHit(point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        public void ChangeChar(char NewChar)
        {
            s = NewChar;
            Draw();
        }


    }
}
