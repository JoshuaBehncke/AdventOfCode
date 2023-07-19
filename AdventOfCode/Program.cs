using System;

namespace AdventOfCode {
    class Program {
        /**
         * The main method of the application. It currently starts the generation of the 2021 Solutions.
         */
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2021: ");
            Console.ResetColor();
            Console.WriteLine();
            Solutions2021.AllSolutions();
            Console.WriteLine();
        }
    }
}
