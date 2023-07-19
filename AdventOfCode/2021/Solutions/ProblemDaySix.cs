using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDaySix {
        public static void Solve() {
            string[] input = new List<string>(File.ReadLines("..\\..\\..\\2021\\inputs\\DaySixInput.txt"))[0].Split(",");
            //string[] input = new List<string>(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DaySixTest.txt"))[0].Split(",");

            long[] fish = new long[9];
            foreach (string s in input) fish[Convert.ToInt32(s)]++;

            for (int i = 1; i <= 80; i++) Update(fish);
            long fishNum = 0;
            foreach (long l in fish) fishNum += l;

            Console.Write("Number of Fish after  80 Days: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(fishNum);
            Console.ResetColor();

            for (int i = 81; i <= 256; i++) Update(fish);
            fishNum = 0;
            foreach (long l in fish) fishNum += l;

            Console.Write("Number of Fish after 256 Days: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(fishNum);
            Console.ResetColor();
        }

        static void Update(long[] fish) {
            long temp = fish[0];
            for (int i = 0; i < fish.Length - 1; i++) {
                fish[i] = fish[i + 1];
            }
            fish[6] += temp;
            fish[8] = temp;
        }
    }
}