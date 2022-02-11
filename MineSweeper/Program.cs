using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int input;
            Field field = new Field();


            Console.WriteLine("Welcome to Minesweeper!");
            
            field.GenerateBombs(10);
            field.GenerateDigits();
            Console.WriteLine("Ready to play!");
            field.ShowField();

            // Cycle for playing
            while (true)
            {
                Console.WriteLine("Choose action:\n1)Choose cell\n2)Exit");
                Console.Write("Input:\t");
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Input coordinates");
                        int x, y;
                        Console.Write("x = \t");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y = \t");
                        y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Choose action:\n1)Open cell\n2)Put flag");
                        Console.Write("Input:\t");
                        input = Convert.ToInt32(Console.ReadLine());
                        field.ChangeCellState(x-1, y-1, input);
                        field.ShowField();
                        break;
                    case 2:
                        Console.WriteLine("Bye!");
                        return;
                    default:
                        break;
                }
            }

        }

    }
}