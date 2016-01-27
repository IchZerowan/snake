using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class controls
    {
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
    }
}
