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
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);
            bool CanClose;

            do
            {
                int speed = 0;
                Console.Clear();
                StartGameHint();
                while (speed == 0)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.KeyChar == '1')
                            speed = 200;
                        else if (key.KeyChar == '2')
                            speed = 100;
                        else if (key.KeyChar == '3')
                            speed = 50;
                        else if (key.KeyChar == '4')
                            speed = 20;
                    }
                }

                Console.Clear();
                walls wall = new walls(80, 25);
                point pos = new point(10, 10, '*');
                snake Snake = new snake(pos, 4, direction.RIGHT);
                foodpoint fp = new foodpoint(80, 25, '$');
                point food = fp.next();
                food.Draw();

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

                    Thread.Sleep(speed);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            while (true)
                            {
                                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Spacebar)
                                    break;
                            }
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        else
                            Snake.HandleSnake(key.Key);
                    }
                    Thread.Sleep(100);
                }

                EndGameInfo();

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            CanClose = false;
                            break;
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            CanClose = true;
                            break;
                        }
                    }
                }
            } while (!CanClose);
        }

        static void EndGameInfo()
        {
            Console.Clear();
            Console.SetCursorPosition(34, 10);
            Console.WriteLine("Игра окончена");
            Console.SetCursorPosition(25, 12);
            Console.WriteLine("Нажмите Space чтобы играть заново,");
            Console.SetCursorPosition(34, 13);
            Console.WriteLine("Esc для выхода");
            line_horizontal l1 = new line_horizontal(23, 59, 8, '*');
            line_horizontal l2 = new line_horizontal(23, 59, 15, '*');
            Console.ForegroundColor = ConsoleColor.Green;
            l1.Draw();
            l2.Draw();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Beep();
        }

        static void StartGameHint()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            line_horizontal l1 = new line_horizontal(23, 59, 8, '*');
            l1.Draw();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(30, 10);
            Console.Write("Выберите скорость (1-4)");
        }
    }
}
