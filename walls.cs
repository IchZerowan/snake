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
        public portal Portal;

        public walls(int width, int height, int lvl)
        {
            wallList = new List<figure>();
            line_horizontal wall1 = new line_horizontal(0, width - 1, 0, 1);
            line_horizontal wall2 = new line_horizontal(0, width - 1, height - 1, 1);
            line_vertical wall3 = new line_vertical(0, height - 1, 0, 1);
            line_vertical wall4 = new line_vertical(0, height - 1, width - 1, 1);
            wallList.Add(wall1);
            wallList.Add(wall2);
            wallList.Add(wall3);
            wallList.Add(wall4);
            if (lvl == 2)
            {
                line_horizontal wall5 = new line_horizontal(3, width - 4, height / 2, 1);
                line_vertical wall6 = new line_vertical(3, height - 4, width / 2, 1);
                wallList.Add(wall5);
                wallList.Add(wall6);
            }
            if (lvl == 3 || lvl == 4)
            {
                line_vertical wall5 = new line_vertical(1, height / 2 - 1, 10, 1);
                line_vertical wall6 = new line_vertical(height / 2 + 3, height - 1, 10, 1);
                line_vertical wall7 = new line_vertical(1, height / 2 - 1, width - 11, 1);
                line_vertical wall8 = new line_vertical(height / 2 + 3, height - 1, width - 11, 1);

                wallList.Add(wall5);
                wallList.Add(wall6);
                wallList.Add(wall7);
                wallList.Add(wall8);

                line_horizontal wall9;
                if (lvl == 3)
                    wall9 = new line_horizontal(12, width - 13, height / 2 + 1, 1);
                else
                    wall9 = new line_horizontal(11, width - 12, height / 2 + 1, 1);
                wallList.Add(wall9);
                if (lvl == 4)
                {
                    line_vertical wall10 = new line_vertical(height / 2 - 2, height / 2 + 4, 7, 1);
                    line_vertical wall11 = new line_vertical(height / 2 - 2, height / 2 + 4, width - 8, 1);
                    line_horizontal wall12 = new line_horizontal(width / 2 - 5, width / 2 + 5, 5, 1);
                    line_horizontal wall13 = new line_horizontal(width / 2 - 5, width / 2 + 5, height - 6, 1);
                    wallList.Add(wall10);
                    wallList.Add(wall11);
                    wallList.Add(wall12);
                    wallList.Add(wall13);
                }
            }

            if (lvl == 5)
            {
                line_horizontal wall5 = new line_horizontal(2, width - 3, height / 2, 1);
                line_vertical wall6 = new line_vertical(2, height - 3, width / 2, 1);
                line_vertical wall7 = new line_vertical(1, height / 2 - 2, width / 4, 1);
                line_vertical wall8 = new line_vertical(height / 2 + 2, height - 2, width / 4, 1);
                line_vertical wall9 = new line_vertical(1, height / 2 - 2, width / 4 * 3, 1);
                line_vertical wall10 = new line_vertical(height / 2 + 2, height - 2, width / 4 * 3, 1);
                wallList.Add(wall5);
                wallList.Add(wall6);
                wallList.Add(wall7);
                wallList.Add(wall8);
                wallList.Add(wall9);
                wallList.Add(wall10);
            }

            if (lvl == 6 || lvl == 7)
            {
                line_vertical wall5 = new line_vertical(1, height - 2, width / 2, 1);
                wallList.Add(wall5);
                Portal = new portal(5, height / 2, width - 6, height / 2);
            }

            if (lvl == 7)
            {
                line_vertical wall6 = new line_vertical(1, height / 2 - 1, 10, 1);
                line_vertical wall7 = new line_vertical(height / 2 + 3, height - 1, 10, 1);
                line_vertical wall8 = new line_vertical(1, height / 2 - 1, width - 11, 1);
                line_vertical wall9 = new line_vertical(height / 2 + 3, height - 1, width - 11, 1);
                line_horizontal wall12 = new line_horizontal(12, width - 13, height / 2 + 1, 1);
                line_vertical wall10 = new line_vertical(height / 2 - 2, height / 2 + 4, 7, 1);
                line_vertical wall11 = new line_vertical(height / 2 - 2, height / 2 + 4, width - 8, 1);

                wallList.Add(wall9);
                wallList.Add(wall6);
                wallList.Add(wall7);
                wallList.Add(wall8);
                wallList.Add(wall10);
                wallList.Add(wall11);
                wallList.Add(wall12);
            }

            Draw();
        }

        public bool IsHit(figure f)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(f))
                    return true;
            }
            return false;
        }

        public bool IsHit(point p)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(p))
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
            if (Portal != null)
                Portal.Draw();
        }
    }
}
