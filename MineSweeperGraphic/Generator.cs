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

        public void GenerateCells(/*ref*/ Cell[,] cells)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    GenerateCell(i, j, ref cells[i, j]);

                }
            }
        }

        //public void GenerateCell(Cell cell, int i, int j)
        public void GenerateCell(int i, int j, ref Cell cell)
        {
            //top left point of PictureBox
            //magic numbers 10, 30 are exist because of window border
            int p_x = p.Location.X + 10;
            int p_y = p.Location.Y + 30;
            //side of cell
            int cell_side = p.Width / 9;

            cell.x = p_x + i * cell_side;
            cell.y = p_y + j * cell_side;
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

