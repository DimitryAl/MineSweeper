using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!");
            
            Field field = new Field();
            field.GenerateBombs(10);
            field.GenerateDigits();
            Console.WriteLine("Ready to play!");

            // Cycle for playing
            while (true)
            {
            }

        }

    }
}