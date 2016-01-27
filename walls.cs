using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleSnake
{
    class walls
    {
        List<figure> wallList;

        public walls(int whidth, int height)
        {
            wallList = new List<figure>();
            line_horizontal wall1 = new line_horizontal(1, whidth - 2, 0, '+');
            line_horizontal wall2 = new line_horizontal(1, whidth - 2, height - 1, '+');
            line_vertical wall3 = new line_vertical(1, height - 2, 0, '+');
            line_vertical wall4 = new line_vertical(1, height - 2, whidth - 1, '+');

            wallList.Add(wall1);
            wallList.Add(wall2);
            wallList.Add(wall3);
            wallList.Add(wall4);
            Draw();
        }

        public bool IsHeat(figure f)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHeat(f))
                    return true;
            }
            return false;
        }

        public void Draw()
        {
            foreach (figure wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
