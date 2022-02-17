using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGraphic
{
    
    public class Drawer
    {
        readonly Pen pen = new Pen(Color.Black, 1);
        readonly Brush brush = new SolidBrush(Color.White);
        readonly PictureBox picturebox;
        readonly Graphics pictbox;

        public Drawer(PictureBox picturebox)
        {
            this.picturebox = picturebox;
            pictbox = Graphics.FromHwnd(picturebox.Handle);
        }

        public void DrawField(int N)
        {
            int cell_side = picturebox.Width / 9;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    pictbox.FillRectangle(brush, cell_side * j, cell_side * i, cell_side, cell_side);
                    pictbox.DrawRectangle(pen, cell_side * j, cell_side * i, cell_side, cell_side);
                }
            }
        }

        public void DrawBomb(Cell cell)
        {
            int cell_x = cell.x - 388 - 10;
            int cell_y = cell.y - 35 - 30;
            Brush brush_bomb = new SolidBrush(Color.Black);

            Point[] points1 =
            {
                new Point(cell_x + cell.side / 2, cell_y + cell.side / 8),
                new Point(cell_x + cell.side / 2, cell_y + cell.side / 4),
            };
            Point[] points2 =
            {
                new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side / 2),
                new Point(cell_x + cell.side * 7 / 8, cell_y + cell.side / 2)
            };
            Point[] points3 =
            {
                new Point(cell_x + cell.side / 2, cell_y + cell.side * 3 / 4),
                new Point(cell_x + cell.side / 2, cell_y + cell.side * 7 / 8) 
            };
            Point[] points4 =
            {
                new Point(cell_x + cell.side / 8, cell_y + cell.side / 2),
                new Point(cell_x + cell.side / 4, cell_y + cell.side / 2)
            };

            pictbox.FillEllipse(brush_bomb, cell_x + cell.side / 4, cell_y + cell.side / 4, cell.side / 2, cell.side / 2);
            pictbox.DrawLine(pen, points1[0], points1[1]);
            pictbox.DrawLine(pen, points2[0], points2[1]);
            pictbox.DrawLine(pen, points3[0], points3[1]);
            pictbox.DrawLine(pen, points4[0], points4[1]);
        }

        public void DrawFlag(Cell cell/*, int i, int j*/)
        {
            //cell coordinates minus coordinates of picturebox 
            //magic numbers 10, 30 are exist because of window borders
            int cell_x = cell.x - 388 - 10;
            int cell_y = cell.y - 35 - 30;
            Point[] points =
            {
                new Point(cell_x + cell.side / 2, cell_y + cell.side * 3 / 4),
                new Point(cell_x + cell.side / 2, cell_y + cell.side / 4),
                new Point(cell_x + cell.side * 3 / 4, cell_y+cell.side / 2),
                new Point(cell_x + cell.side / 2, cell_y + cell.side / 2)
            };
            ClearCell(cell);
            pictbox.DrawLines(pen, points);
        }

        internal void DrawDigit(Cell cell, int digit)
        {
            //cell coordinates minus coordinates of picturebox 
            //magic numbers 10, 30 are exist because of window borders
            int cell_x = cell.x - 388 - 10;
            int cell_y = cell.y - 35 - 30;

            switch (digit)
            {
                case 0:
                    Point[] points0 =
                    {
                        new Point(cell_x + cell.side / 4, cell_y + cell.side / 4),
                        new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side / 4),
                        new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side * 3 / 4),
                        new Point(cell_x + cell.side / 4, cell_y + cell.side * 3 / 4),
                        new Point(cell_x + cell.side / 4, cell_y + cell.side / 4),
                    };
                    pictbox.DrawLines(pen, points0);
                    break;
                case 1:
                    new Point(cell_x + cell.side / 4, cell_y + cell.side / 2);
                    new Point(cell_x + cell.side / 2, cell_y + cell.side / 4);
                    new Point(cell_x + cell.side / 2, cell_y + cell.side * 3 / 4);
                    pictbox.DrawLine(pen, new Point(cell_x + cell.side / 4, cell_y + cell.side / 2), new Point(cell_x + cell.side / 2, cell_y + cell.side / 4));
                    pictbox.DrawLine(pen, new Point(cell_x + cell.side / 2, cell_y + cell.side / 4), new Point(cell_x + cell.side / 2, cell_y + cell.side * 3 / 4));
                    break;
                case 2:
                    Point[] points2 =
                    {
                        new Point(cell_x + cell.side / 4, cell_y + cell.side / 4),
                        new Point(cell_x + cell.side / 2, cell_y + cell.side / 8),
                        new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side / 4),
                        new Point(cell_x + cell.side / 4, cell_y + cell.side * 3 / 4)
                    };
                    pictbox.DrawCurve(pen, points2);
                    pictbox.DrawLine(pen, new Point(cell_x + cell.side / 4, cell_y + cell.side * 3 / 4), new Point(cell_x + cell.side * 3/ 4, cell_y + cell.side * 3 / 4));
                    break;
                case 3:
                    Point[] points3_1 =
                    {
                        new Point(cell_x + cell.side / 2, cell_y + cell.side / 4),
                        new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side * 3 / 8),
                        new Point(cell_x + cell.side / 2, cell_y + cell.side / 2)
                    };
                    Point[] points3_2 =
                    {
                        new Point(cell_x + cell.side / 2, cell_y + cell.side / 2),
                        new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side * 5 / 8),
                        new Point(cell_x + cell.side / 2, cell_y + cell.side * 3 / 4)
                    };
                    pictbox.DrawCurve(pen, points3_1);
                    pictbox.DrawCurve(pen, points3_2);
                    break;
                case 4:
                    pictbox.DrawLine(pen, new Point(cell_x + cell.side / 4, cell_y + cell.side / 4), new Point(cell_x + cell.side / 4, cell_y + cell.side / 2));
                    pictbox.DrawLine(pen, new Point(cell_x + cell.side / 4, cell_y + cell.side / 2), new Point(cell_x + cell.side / 4, cell_y + cell.side / 2));
                    pictbox.DrawLine(pen, new Point(cell_x + cell.side / 4, cell_y + cell.side / 2), new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side / 2));
                    pictbox.DrawLine(pen, new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side / 4), new Point(cell_x + cell.side * 3 / 4, cell_y + cell.side * 3 / 4));
                    break;
            }

        }

        public void ClearCell(Cell cell)
        {
            //cell coordinates minus coordinates of picturebox 
            //magic numbers 10, 30 are exist because of window borders
            int cell_x = cell.x - 388 - 10;
            int cell_y = cell.y - 35 - 30;
            pictbox.FillRectangle(brush, cell_x + 1, cell_y + 1, cell.side - 1, cell.side - 1);
        }
    }
}
