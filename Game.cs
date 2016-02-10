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
            pos = new point(11, 11, 3);
        }

        bool play(int lvl)
        {
            while (true)
            {
                wall.Draw();

                if (Snake.GetScore() == 10 * lvl)
                    return true;

                if (wall.IsHeat(Snake) || Snake.IsHeatTail())
                {
                    return false;
                }

                if (Snake.eat(food))
                {
                    food = fp.next(Snake, wall);
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
                    return false;
                }
                else if (CtrlRes == ctrl.Insert)
                {
                    food = fp.next(Snake, wall);
                    food.Draw();
                }
                else
                    Snake.HandleSnake(CtrlRes);
            }
        }

        public int Start()
        {
            for (int i = 1; i < 5; i++)
            {
                Console.Clear();
                Console.SetCursorPosition(width / 2 - 5, height / 2);
                Console.Write("Игра начинается...");
                Thread.Sleep(1000);
                Console.Clear();
                Snake = new snake(pos, 4, direction.RIGHT);
                wall = new walls(width, height, i);
                fp = new foodpoint(width, height, 2);
                food = fp.next(Snake, wall);
                food.Draw();
                if (!play(i))
                    break;
            }
            int sc = Snake.GetScore() * speed;
            Snake.ResetScore();
            return sc;
        }
    }
}
