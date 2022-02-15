namespace MineSweeperGraphic
{
    public class Generator
    {
        public void InitGeneration(Cell cell)
        {
            cell.x
        }
        
        public void GenerateBombs(int qnt, int N, Cell[,] cells)
        {
            Random rnd = new Random();

            for (int i = 0; i < qnt; i++)
            {
                //cells[rnd.Next(N), rnd.Next(N)].cell_state = Cell.State.Bomb;
            }
        }

        //public void GenerateDigits()
        //{
        //    int rows = cells.GetUpperBound(0) + 1;
        //    int column = cells.Length / rows;

        //    Console.WriteLine("Generating digits...");
        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < column; j++)
        //        {
        //            if (cells[i, j] != -1)
        //            {
        //                int bomb_cnt = 0;

        //                for (int k = i - 1; k <= i + 1; k++)
        //                {
        //                    for (int l = j - 1; l <= j + 1; l++)
        //                    {

        //                        if (k < 0 || k > 8 || l < 0 || l > 8) continue;
        //                        if (cells[k, l] == -1) bomb_cnt++;
        //                    }
        //                }

        //                cells[i, j] = bomb_cnt;
        //            }
        //        }
        //    }
        //    GenerateCellsProperty();
        //}
    }
}

