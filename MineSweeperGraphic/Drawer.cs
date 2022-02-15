using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGraphic
{
    internal class Drawer
    {
        public void DrawField(PictureBox pictureBox1, int N)
        {
            Pen pen = new Pen(Color.Black, 1);
            Graphics picturebox1 = Graphics.FromHwnd(pictureBox1.Handle);

            int cell_side = pictureBox1.Width / 9;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    picturebox1.DrawRectangle(pen, cell_side * j, cell_side * i, cell_side, cell_side);
                }
            }
        }
    }
}
