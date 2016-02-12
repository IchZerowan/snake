using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace consoleSnake
{
    class controls
    {
        int width;
        int height;

        public controls(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public ctrl GetCtrl()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Spacebar)
                    return ctrl.Spacebar;
                else if (key.Key == ConsoleKey.Escape)
                    return ctrl.Escape;
                else if (key.Key == ConsoleKey.RightArrow)
                    return ctrl.RightArrow;
                else if (key.Key == ConsoleKey.LeftArrow)
                    return ctrl.LeftArrow;
                else if (key.Key == ConsoleKey.UpArrow)
                    return ctrl.UpArrow;
                else if (key.Key == ConsoleKey.DownArrow)
                    return ctrl.DownArrow;
                else if (key.Key == ConsoleKey.Insert)
                    return ctrl.Insert;
                else
                    return ctrl.nil;
            }
            else
                return ctrl.nil;
        }

        public void StartInfo(int lvl)
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

        public void ShowScore(int Score)
        {
            Console.SetCursorPosition(5, height + 3);
            Console.Write(Score);
        }
    }
}
