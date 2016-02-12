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

        bool Play(int lvl)
        {
            while (true)
            {
                wall.Draw();
                food.Draw();

                if (Snake.GetScore() == 10 * lvl)
                    return true;

                if (wall.IsHit(Snake) || Snake.IsHitTail())
                {
                    return false;
                }

                if (wall.Portal != null)
                {
                    point p = wall.Portal.IsHit(Snake.GetHead());
                    if (p != null)
                    {
                        Snake.Teleport(wall.Portal.OtherPoint(p));
                    }
                }

                if (Snake.Eat(food))
                {
                    Console.SetCursorPosition(5, height + 3);
                    Console.Write(Snake.GetScore() * speed);
                    food = fp.Next(Snake, wall);
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
                    food = fp.Next(Snake, wall);
                    food.Draw();
                }
                else
                    Snake.HandleSnake(CtrlRes);
            }
        }

        public int Start()
        {
            for (int i = 1; i <= 7; i++)
            {
                StartInfo(i);
                Initialize(i);
                if (!Play(i))
                    break;
            }
            int sc = Snake.GetScore() * speed;
            Snake.ResetScore();
            return sc;
        }

        public int Start(int lvl)
        {
            StartInfo(lvl);
            Initialize(lvl);
            Play(1);
            int sc = Snake.GetScore() * speed;
            Snake.ResetScore();
            return sc;
        }

        void StartInfo(int lvl)
        {
            Console.Clear();
            Console.SetCursorPosition(width / 2 - 5, height / 2);
            Console.Write("Уровень " + lvl.ToString());
            Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition(3, height + 2);
            Console.Write("Счет:");
            Console.SetCursorPosition(10, height + 2);
            Console.Write("Уровень:");
            Console.SetCursorPosition(13, height + 3);
            Console.Write(lvl);
        }

        void Initialize(int lvl)
        {
            Snake = new snake(pos, 4, direction.RIGHT);
            Console.SetCursorPosition(5, height + 3);
            Console.Write(Snake.GetScore() * speed);
            wall = new walls(width, height, lvl);
            fp = new foodpoint(width, height, 2);
            food = fp.Next(Snake, wall);
            food.Draw();
        }
    }
}
