using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGraphic
{
    public struct Cell
    {
        public int side = 0;
        public int x = 0, y = 0;
        public int number = 0;
        public enum State
        {
            Opened,
            Closed,
            Flag,
            Bomb
        }
        public State cell_state = State.Closed;

        public Cell() { }

        public int ChangeCellState(Cell[,] cells, Drawer drawer, PictureBox pictureBox1, int i, int j, MouseEventArgs e, int N, ref int mines)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (cells[i, j].cell_state == State.Flag)
                {
                    cells[i, j].cell_state = State.Closed;
                    drawer.ClearCell(cells[i, j]);
                    mines++;
                    return 1;
                }
                else
                {
                    cells[i, j].cell_state = State.Flag;
                    mines--;
                    drawer.DrawFlag(cells[i, j]/*, i, j*/);
                    return 1;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (cells[i, j].number == -1)
                {
                    cells[i, j].cell_state = State.Bomb;
                    drawer.DrawBomb(cells[i, j]);
                    return 0;
                }
                cells[i, j].cell_state = State.Opened;
                drawer.DrawDigit(cells[i, j], cells[i, j].number);
                for (int k = i - 1; k <= i + 1; k++)
                {
                    for (int l = j - 1; l <= j + 1; l++)
                    {

                        if (k < 0 || k > N - 1 || l < 0 || l > N - 1) continue;
                        if (k == i && l == j) continue;
                        if (cells[k, l].number == 0 && cells[k, l].cell_state != State.Opened)
                            ChangeCellState(cells, drawer, pictureBox1, k, l, e, N, ref mines);
                        else
                        {
                            if (cells[k, l].number != -1)
                            {
                                cells[k, l].cell_state = State.Opened;
                                drawer.DrawDigit(cells[k, l], cells[k, l].number);
                            }
                        }
                    }
                }
                return 1;
            }
            else
            {
                return -1;
            }
            
        }

        public int FindCell(Form f, Cell[,] cells, Drawer drawer, PictureBox pictureBox1, MouseEventArgs e, int N, ref int mines)
        {
            //top left Form point
            int f_x = f.Location.X;
            int f_y = f.Location.Y;
            //position of the cursor
            int c_x = Cursor.Position.X;
            int c_y = Cursor.Position.Y;
            //relative position
            int r_x = c_x - f_x;
            int r_y = c_y - f_y;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //need to search right cell somehow
                    if (r_x > cells[i, j].x && r_x < cells[i, j].x + cells[i, j].side 
                        && r_y > cells[i, j].y && r_y < cells[i, j].y + cells[i, j].side) 
                    {
                        return ChangeCellState(cells, drawer, pictureBox1, i, j, e, N, ref mines);
                        //return true;
                    }
                    
                }
            }
            return -1;
        }

    }
}
