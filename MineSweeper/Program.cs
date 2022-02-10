using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Field field = new Field();
            field.GenerateBombs(10);
            field.ShowField();
        }

    }
}