using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDayEight {
        public static void Solve() {
            List<string> input = new List<string>(File.ReadLines("..\\..\\..\\2021\\inputs\\DayEightInput.txt"));
            //List<string> input = new List<string>(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DayEightTest.txt"));

            // 0->6, 1->2, 2->5, 3->5 4->4, 5->5, 6->6, 7->3, 8->7, 9-> 6

            List<string[]> signals = new();
            foreach (string signal in input) signals.Add(signal.Split(" "));

            Console.Write("Number of digits 1, 4, 7 and 8: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CountEasyNumbers(signals));
            Console.ResetColor();

            Console.WriteLine();
        }

        static int CountEasyNumbers(List<string[]> signals) {
            int output = 0;

            foreach (string[] signal in signals) {
                for (int i = 11; i <= 14; i++) {
                    if (signal[i].Length == 2 || signal[i].Length == 4 || signal[i].Length == 3 || signal[i].Length == 7) output++;
                }
            }
            
            return output;
        }
    }
}
