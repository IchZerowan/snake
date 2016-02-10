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

        public walls(int whidth, int height, int lvl)
        {
            wallList = new List<figure>();
            line_horizontal wall1 = new line_horizontal(1, whidth - 2, 0, 1);
            line_horizontal wall2 = new line_horizontal(1, whidth - 2, height - 1, 1);
            line_vertical wall3 = new line_vertical(1, height - 2, 0, 1);
            line_vertical wall4 = new line_vertical(1, height - 2, whidth - 1, 1);
            wallList.Add(wall1);
            wallList.Add(wall2);
            wallList.Add(wall3);
            wallList.Add(wall4);
            if (lvl == 2)
            {
                line_horizontal wall5 = new line_horizontal(3, whidth - 4, height / 2, 1);
                line_vertical wall6 = new line_vertical(3, height - 4, whidth / 2, 1);
                wallList.Add(wall5);
                wallList.Add(wall6);
            }
            if (lvl == 3)
            {
                line_vertical wall5 = new line_vertical(1, height / 2 - 1, 10, 1);
                line_vertical wall6 = new line_vertical(height / 2 + 3, height - 1, 10, 1);
                line_vertical wall7 = new line_vertical(1, height / 2 - 1, whidth - 11, 1);
                line_vertical wall8 = new line_vertical(height / 2 + 3, height - 1, whidth - 11, 1);
                line_horizontal wall9 = new line_horizontal(12, whidth - 13, height / 2 + 1, 1);
                wallList.Add(wall5);
                wallList.Add(wall6);
                wallList.Add(wall7);
                wallList.Add(wall8);
                wallList.Add(wall9);
            }
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

        public bool IsHeat(point p)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHeat(p))
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
