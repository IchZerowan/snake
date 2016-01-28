using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace consoleSnake
{
    class Game
    {
        int width;
        int height;
        int delay;
        int speed;
        walls wall;
        point pos;
        snake Snake;
        foodpoint fp;
        point food;
        controls Ctrl = new controls();

        public Game(int width, int height, int speed)
        {
            this.width = width;
            this.height = height;
            if (speed == 1)
                delay = 300;
            else if (speed == 2)
                delay = 200;
            else if (speed == 3)
                delay = 100;
            else if (speed == 4)
                delay = 50;
            else if (speed == 5)
                delay = 25;
            this.speed = speed;

            wall = new walls(width, height);
            pos = new point(10, 10, 3);
            Snake = new snake(pos, 4, direction.RIGHT);
            fp = new foodpoint(width, height, 2);
            food = fp.next();
            food.Draw();
        }

        public int Start()
        {
            while (true)
            {
                if (wall.IsHeat(Snake) || Snake.IsHeatTail())
                {
                    break;
                }

                if (Snake.eat(food))
                {
                    food = fp.next();
                    food.Draw();
                }
                else
                {
                    Snake.Move();
                }

                Thread.Sleep(delay);

                ctrl CtrlRes = Ctrl.GetCtrl();
                if (CtrlRes == ctrl.Spacebar)
                {
                    while (true)
                    {
                        CtrlRes = Ctrl.GetCtrl();
                        if (CtrlRes == ctrl.Spacebar)
                            break;
                    }
                }
                else if (CtrlRes == ctrl.Escape)
                {
                    break;
                }
                else if (CtrlRes == ctrl.Insert)
                {
                    food = fp.next();
                    food.Draw();
                }
                else
                    Snake.HandleSnake(CtrlRes);
            }
            return Snake.GetScore() * speed;
        }
    }
}
