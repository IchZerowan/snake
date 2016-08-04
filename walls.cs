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
            wallList.Add(new line_horizontal(0, width - 1, 0, 1));
            wallList.Add(new line_horizontal(0, width - 1, height - 1, 1));
            wallList.Add(new line_vertical(0, height - 1, 0, 1));
            wallList.Add(new line_vertical(0, height - 1, width - 1, 1));

            if (lvl == 2)
            {
                wallList.Add(new line_horizontal(3, width - 4, height / 2, 1));
                wallList.Add(new line_vertical(3, height - 4, width / 2, 1));
            }

            if (lvl == 3 || lvl == 4)
            {
                wallList.Add(new line_vertical(1, height / 2 - 1, 10, 1));
                wallList.Add(new line_vertical(height / 2 + 3, height - 1, 10, 1));
                wallList.Add(new line_vertical(1, height / 2 - 1, width - 11, 1));
                wallList.Add(new line_vertical(height / 2 + 3, height - 1, width - 11, 1));
                if (lvl == 3)
                    wallList.Add(new line_horizontal(12, width - 13, height / 2 + 1, 1));
                else
                    wallList.Add(new line_horizontal(11, width - 12, height / 2 + 1, 1));
                if (lvl == 4)
                {
                    wallList.Add(new line_vertical(height / 2 - 2, height / 2 + 4, 7, 1));
                    wallList.Add(new line_vertical(height / 2 - 2, height / 2 + 4, width - 8, 1));
                    wallList.Add(new line_horizontal(width / 2 - 5, width / 2 + 5, 5, 1));
                    wallList.Add(new line_horizontal(width / 2 - 5, width / 2 + 5, height - 6, 1));
                }
            }

            if (lvl == 5)
            {
                wallList.Add(new line_horizontal(2, width - 3, height / 2, 1));
                wallList.Add(new line_vertical(2, height - 3, width / 2, 1));
                wallList.Add(new line_vertical(1, height / 2 - 2, width / 4, 1));
                wallList.Add(new line_vertical(height / 2 + 2, height - 2, width / 4, 1));
                wallList.Add(new line_vertical(1, height / 2 - 2, width / 4 * 3, 1));
                wallList.Add(new line_vertical(height / 2 + 2, height - 2, width / 4 * 3, 1));
            }

            if (lvl == 6 || lvl == 7)
            {
                wallList.Add(new line_vertical(1, height - 2, width / 2, 1));
                Portal = new portal(5, height / 2, width - 6, height / 2);
            }

            if (lvl == 7)
            {
                wallList.Add(new line_vertical(1, height / 2 - 1, 10, 1));
                wallList.Add(new line_vertical(height / 2 + 3, height - 1, 10, 1));
                wallList.Add(new line_vertical(1, height / 2 - 1, width - 11, 1));
                wallList.Add(new line_vertical(height / 2 + 3, height - 1, width - 11, 1));
                wallList.Add(new line_horizontal(12, width - 13, height / 2 + 1, 1));
                wallList.Add(new line_vertical(height / 2 - 2, height / 2 + 4, 7, 1));
                wallList.Add(new line_vertical(height / 2 - 2, height / 2 + 4, width - 8, 1));
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

        public void reDraw(point p)
        {
            if(IsHit(p))
            {
                p.Draw();
            }
        }
    }
}
