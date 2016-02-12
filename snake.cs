using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace consoleSnake
{
    class snake : figure
    {
        direction Direction;
        private static int score = 0;

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

        public void HandleSnake(ctrl key)
        {
            if (key == ctrl.RightArrow && Direction != direction.LEFT)
                Direction = direction.RIGHT;
            else if (key == ctrl.LeftArrow && Direction != direction.RIGHT)
                Direction = direction.LEFT;
            else if (key == ctrl.UpArrow && Direction != direction.DOWN)
                Direction = direction.UP;
            else if (key == ctrl.DownArrow && Direction != direction.UP)
                Direction = direction.DOWN;
        }

        public bool eat(point food)
        {
            point head = NextPoint();
            if (head.isHit(food))
            {
                pList.Add(food);
                food.ChangeChar(3);    
                score++;
                return true;
            }
            else
                return false;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public int GetScore()
        {
            return score;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public void teleport(point port)
        {
            var tail = pList.Last();
            pList.Remove(tail);
            tail.clear();
            var head = new point(port, 3);
            head.move(1, Direction);
            pList.Add(head);
        }

        public point GetHead()
        {
            return new point(pList.Last());
        }
    }
}
