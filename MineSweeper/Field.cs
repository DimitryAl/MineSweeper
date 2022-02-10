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
        public Field()
        {  
        }
        public void GenerateDigits()
        {
            int rows = cells.GetUpperBound(0) + 1;
            int column = cells.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (cells[i,j] != -1)
                    {
                        // If not border row or column 
                        if (i != 0 && i != 8 && j != 0 && j != 8)
                        {

                        }
                        else
                        {

                        }
                    }    
                }
            }
        }
        public void GenerateBombs(int qnt)
        {
            Random rnd = new Random(); 
            for (int i = 0; i < qnt; i++)
            {
                cells[rnd.Next(N), rnd.Next(N)] = -1; 
            }
        }
        public void ShowField()
        {
            int rows = cells.GetUpperBound(0) + 1;
            int column = cells.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column;j++)
                {
                    Console.Write($"{cells[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
