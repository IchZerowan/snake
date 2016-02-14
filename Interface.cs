using ConsoleExtender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace consoleSnake
{
    class Interface
    {
        const int width = 80;
        const int height = 25;

        static void Main(string[] args)
        {
            int lvl = 0;
            ConsoleHelper.SetConsoleFont(3);
            ConsoleHelper.SetConsoleIcon(new Icon("zmeja.ico"));
            Console.SetWindowSize(width, height + 5);
            Console.SetBufferSize(width, height + 5);
            Console.Title = "Snake";
            Console.CursorVisible = false;

            do
            {
                int speed = 0;
                Console.Clear();
                ChooseParams();
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            break;
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                        else if ("123456789".Contains(key.KeyChar))
                        {
                            lvl = Convert.ToInt32(key.KeyChar) - 48;
                            break;
                        }
                    }
                }
                StartGameHint();
                while (speed == 0)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.KeyChar == '1')
                            speed = 1;
                        else if (key.KeyChar == '2')
                            speed = 2;
                        else if (key.KeyChar == '3')
                            speed = 3;
                        else if (key.KeyChar == '4')
                            speed = 4;
                        else if (key.KeyChar == '5')
                            speed = 5;
                    }
                }

                Game game = new Game(width, height, speed);
                if (lvl == 0)
                    EndGameInfo(game.Start());
                else
                {
                    int a = game.Start(lvl);
                    EndGameInfo(a);
                    lvl = 0;
                }
            } while (true);
        }

        static void EndGameInfo(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(34, 10);
            Console.Write("Игра окончена");
            Console.SetCursorPosition(30, 11);
            Console.Write("Вы набрали " + score.ToString() + " очков");
            line_horizontal l1 = new line_horizontal(23, 59, 8, 4);
            line_horizontal l2 = new line_horizontal(23, 59, 13, 4);
            Console.ForegroundColor = ConsoleColor.Green;
            l1.Draw();
            l2.Draw();
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1000);
        }

        static void ChooseParams()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            line_horizontal l1 = new line_horizontal(23, 59, 8, 4);
            l1.Draw();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(28, 10);
            Console.Write("Нажмите Space чтобы играть,");
            Console.SetCursorPosition(34, 11);
            Console.Write("Esc для выхода,");
            Console.SetCursorPosition(28, 12);
            Console.Write("или выберите уровень (1-9)");
        }

        static void StartGameHint()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            line_horizontal l1 = new line_horizontal(23, 59, 8, 4);
            l1.Draw();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(30, 10);
            Console.Write("Выберите скорость (1-5)");
        }
    }
}
