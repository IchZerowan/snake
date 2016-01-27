using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class snake : figure
    {
        direction Direction;

        public snake(point pos, int length, direction dir)
        {
            Direction = dir;
            pList = new List<point>();
            for (int i = 0; i < length; i++)
            {
                point p = new point(pos);
                p.move(i, dir);
                pList.Add(p);
            }
            Draw();
        }

        public void Move()
        {
            point tail = pList.First();
            pList.Remove(tail);
            point head = NextPoint();
            pList.Add(head);
            tail.clear();
            head.Draw();
            Draw();
        }

        public bool IsHeatTail()
        {
            var head = pList.Last();
            for (int i = 0; i<pList.Count-2; i++)
            {
                if (head.isHit(pList[i]))
                    return true;
            }
            return false;
            
        }

        point NextPoint()
        {
            point head = pList.Last();
            point NextPoint = new point(head);
            NextPoint.move(1, Direction);
            return NextPoint;
        }

        public void HandleSnake(ConsoleKey key)
        {
            if (key == ConsoleKey.RightArrow)
                Direction = direction.RIGHT;
            else if (key == ConsoleKey.LeftArrow)
                Direction = direction.LEFT;
            else if (key == ConsoleKey.UpArrow)
                Direction = direction.UP;
            else if (key == ConsoleKey.DownArrow)
                Direction = direction.DOWN;
        }

        public bool eat(point food)
        {
            point head = NextPoint();
            if (head.isHit(food))
            {
                food.ChangeChar('*');
                pList.Add(food);
                return true;
            }
            else
                return false;
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
