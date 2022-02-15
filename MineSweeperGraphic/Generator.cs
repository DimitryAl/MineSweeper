namespace MineSweeperGraphic
{
    public class Generator
    {
        Form f;
        PictureBox p;
        int rows;
        int cols;

        public Generator(Form f, PictureBox p, int rows, int cols)
        {
            this.f = f;
            this.p = p;
            this.rows = rows;
            this.cols = cols;
        }

        public void GenerateCells(Cell[,] cells)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    GenerateCell(cells[i, j], i, j);
                }
            }
        }

        public void GenerateCell(Cell cell, int i, int j)
        {
            //top left Form point
            int f_x = f.Location.X;                  
            int f_y = f.Location.Y;
            ////position of the cursor
            //int c_x = Cursor.Position.X;
            //int c_y = Cursor.Position.Y;
            //top left point of PictureBox
            int p_x = p.Location.X + 10;
            int p_y = p.Location.Y + 30;
            //side of cell
            int cell_side = p.Width / 9;

            cell.x = f_x - p_x + i * cell_side;
            cell.y = f_y - p_y + j * cell_side;
            cell.number = 0;
            cell.side = cell_side;
            cell.cell_state = Cell.State.Closed;
        }
        
        public void GenerateBombs(int qnt, int N, Cell[,] cells)
        {
            Random rnd = new Random();

            for (int i = 0; i < qnt; i++)
            {
                cells[rnd.Next(N), rnd.Next(N)].number = -1;
            }
        }

        public void GenerateDigits(Cell[,] cells)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (cells[i, j].number != -1)
                    {
                        int bomb_cnt = 0;

                        for (int k = i - 1; k <= i + 1; k++)
                        {
                            for (int l = j - 1; l <= j + 1; l++)
                            {

                                if (k < 0 || k > 8 || l < 0 || l > 8) continue;
                                if (cells[k, l].number == -1) bomb_cnt++;
                            }
                        }
                        cells[i, j].number = bomb_cnt;
                    }
                }
            }
        }
    }
}

