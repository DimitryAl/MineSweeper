using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class Field
    {
        static readonly int N = 9;
        int[,] cells = new int[N, N];
        enum state
        {
            Opened,
            Closed,
            Flag,
            Bomb
        }
        state[,] cells_prop = new state[N, N];

        //public Field()
        //{  
        //}

        private void GenerateCellsProperty()
        {
            int rows = cells_prop.GetUpperBound(0) + 1;
            int column = cells_prop.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    cells_prop[i, j] = state.Closed;
                }
            }
        }

        public void GenerateDigits()
        {
            int rows = cells.GetUpperBound(0) + 1;
            int column = cells.Length / rows;

            Console.WriteLine("Generating digits...");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (cells[i,j] != -1)
                    {
                        int bomb_cnt = 0;

                        for (int k = i - 1; k <= i + 1; k++)
                        {
                            for (int l = j - 1; l <= j + 1; l++)
                            {

                                if (k < 0 || k > 8 || l < 0 || l > 8) continue;
                                if (cells[k, l] == -1) bomb_cnt++;
                            }
                        }

                        cells[i, j] = bomb_cnt;
                    }    
                }
            }
            GenerateCellsProperty();
        }

        public void GenerateBombs(int qnt)
        {
            Random rnd = new Random();

            Console.WriteLine("Generating bombs...");
            for (int i = 0; i < qnt; i++)
            {
                cells[rnd.Next(N), rnd.Next(N)] = -1; 
            }
        }

        public void ShowFieldCheat()
        {
            int rows = cells.GetUpperBound(0) + 1;
            int column = cells.Length / rows;

            Console.WriteLine("Current state of field:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column;j++)
                {
                    if (cells[i, j] == -1) Console.Write("*\t");
                    else Console.Write($"{cells[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        public void ShowField()
        {
            int rows = cells.GetUpperBound(0) + 1;
            int column = cells.Length / rows;

            Console.WriteLine("Current state of field:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //Console.Write("#\t");
                    switch (cells_prop[i, j])
                    {
                        case state.Opened:
                            Console.Write($"{cells[i, j]}\t");
                            break;
                        case state.Closed:
                            Console.Write($"#\t");
                            break;
                        case state.Flag:
                            Console.Write("!\t");
                            break;
                        case state.Bomb:
                            Console.Write("*\t");
                            break;

                    }
                }
                Console.WriteLine();
            }
        }

        public void ChangeCellState(int x, int y, int input)
        {
            if (cells[x, y] == -1 && input == 1)
            {
                cells_prop[x, y] = state.Bomb;
            }
            else
            {
                if (input == 2) cells_prop[x, y] = state.Flag;
                if (input == 1) cells_prop[x, y] = state.Opened;
            }
        }
    }
}
