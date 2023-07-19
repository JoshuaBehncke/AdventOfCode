using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDayOne {
        public static void Solve() {
            int[] input = new List<string>(File.ReadLines("..\\..\\..\\2021\\Inputs\\DayOneInput.txt")).ConvertAll(new Converter<string, int>(Convert.ToInt32)).ToArray();
            //int[] input = new List<string>(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DayOneTest.txt")).ConvertAll(new Converter<string, int>(Convert.ToInt32)).ToArray();

            Console.Write("Total Increases: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(DepthIncreases(input));
            Console.ResetColor();


            Console.Write("Total Increases with Three Measurement Window: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(DepthIncreasesThreeMeasurementSum(input));
            Console.ResetColor();
        }

        static int DepthIncreases(int[] depths) {
            int increases = 0;

            for (int i = 0; i < depths.Length - 1; i++) {
                if (depths[i] < depths[i + 1]) {
                    increases++;
                }
            }

            return increases;
        }

        static int DepthIncreasesThreeMeasurementSum(int[] depths) {
            List<int> newDepths = new();

            for (int i = 0; i < depths.Length - 2; i++) {
                newDepths.Add(depths[i] + depths[i + 1] + depths[i + 2]);
            }

            return DepthIncreases(newDepths.ToArray());
        }
    }
}
