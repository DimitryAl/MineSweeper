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
            //Pen pen = new Pen(Color.Black, 1);
            //Graphics picturebox1 = Graphics.FromHwnd(pictbox.Handle);
           // pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            int cell_side = picturebox.Width / 9;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //pictbox.FillRectangle(brush, cell_side * j + 1, cell_side * i + 1, cell_side + 1, cell_side + 1);
                    pictbox.FillRectangle(brush, cell_side * j, cell_side * i, cell_side, cell_side);
                    pictbox.DrawRectangle(pen, cell_side * j, cell_side * i, cell_side, cell_side);
                }
            }
        }

        //public void ClearField(/*PictureBox pictureBox1*/)
        //{
        //    //Pen pen = new Pen(Color.Black, 1);
        //    //Graphics picturebox1 = Graphics.FromHwnd(pictureBox1.Handle);
        //    pictbox.DrawRectangle(pen, picturebox.Location.X, picturebox.Location.Y, picturebox.Width, picturebox.Height);
        //}
    
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
            pictbox.DrawLines(pen, points);
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
