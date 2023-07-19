using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDayThree {
        public static void Solve() {
            List<string> input = new(File.ReadLines("..\\..\\..\\2021\\Inputs\\DayThreeInput.txt"));
            //List<string> input = new(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DayThreeTest.txt"));

            int gammaRate = (int) GammaRate(input);
            int epsilonRate = (int) EpsilonRate(input);
            Console.WriteLine("Gamma Rate: " + gammaRate);
            Console.WriteLine("Epsilon Rate: " + epsilonRate);
            Console.Write("Power Consumption: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine((gammaRate * epsilonRate));
            Console.ResetColor();

            Console.WriteLine();

            int oxygenRating = OxygenRating(input);
            int co2Rating = Co2Rating(input);
            Console.WriteLine("Oxygen Generator Rating: " + oxygenRating);
            Console.WriteLine("CO2 Scrubber Rating: " + co2Rating);
            Console.Write("Life Support Rating: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine((oxygenRating * co2Rating));
            Console.ResetColor();
        }

        static int OxygenRating(List<string> input) {
            List<string> output = new();
            input.ForEach(output.Add);

            for (int i = 0; i < output[0].Length; i++) {
                if (output.Count == 1) break;

                List<string> newOutput = new();
                int numOfOnes = 0;
                for (int j = 0; j < output.Count; j++) {
                    if (Convert.ToInt32(output[j][i].ToString()) == 1) numOfOnes++;
                }

                if ((numOfOnes / (decimal) output.Count) >= 0.5m) {
                    for (int j = 0; j < output.Count; j++) {
                        if (Convert.ToInt32(output[j][i].ToString()) == 1) newOutput.Add(output[j]);
                    }
                } else {
                    for (int j = 0; j < output.Count; j++) {
                        if (Convert.ToInt32(output[j][i].ToString()) == 0) newOutput.Add(output[j]);
                    }
                }

                output.Clear();
                newOutput.ForEach(output.Add);
            }

            return Convert.ToInt32(output[0], 2);
        }

        static int Co2Rating(List<string> input) {
            List<string> output = new();
            input.ForEach(output.Add);

            for (int i = 0; i < output[0].Length; i++) {
                if (output.Count == 1) break;

                List<string> newOutput = new();
                int numOfOnes = 0;
                for (int j = 0; j < output.Count; j++) {
                    if (Convert.ToInt32(output[j][i].ToString()) == 1) numOfOnes++;
                }

                if ((numOfOnes / (decimal) output.Count) >= 0.5m) {
                    for (int j = 0; j < output.Count; j++) {
                        if (Convert.ToInt32(output[j][i].ToString()) == 0) newOutput.Add(output[j]);
                    }
                } else {
                    for (int j = 0; j < output.Count; j++) {
                        if (Convert.ToInt32(output[j][i].ToString()) == 1) newOutput.Add(output[j]);
                    }
                }

                output.Clear();
                newOutput.ForEach(output.Add);
            }

            return Convert.ToInt32(output[0], 2);
        }

        static int? GammaRate(List<string> input) {
            string output = "";

            for (int i = 0; i < input[0].Length; i++) {
                int numOfOnes = 0;
                for (int j = 0; j < input.Count; j++) {
                    if (Convert.ToInt32(input[j][i].ToString()) == 1) numOfOnes++;
                }

                if ((numOfOnes / (decimal) input.Count) > 0.5m) {
                    output += 1;
                } else if ((numOfOnes / (decimal) input.Count) == 0.5m) {
                    Console.WriteLine("Even Split");
                    return null;
                } else {
                    output += 0;
                }
            }

            return Convert.ToInt32(output, 2);
        }

        static int? EpsilonRate(List<string> input) {
            string output = "";

            for (int i = 0; i < input[0].Length; i++) {
                int numOfOnes = 0;
                for (int j = 0; j < input.Count; j++) {
                    if (Convert.ToInt32(input[j][i].ToString()) == 1) numOfOnes++;
                }

                if ((numOfOnes / (decimal) input.Count) < 0.5m) {
                    output += 1;
                } else if ((numOfOnes / (decimal) input.Count) == 0.5m) {
                    Console.WriteLine("Even Split");
                    return null;
                } else {
                    output += 0;
                }
            }

            return Convert.ToInt32(output, 2);
        }
    }
}
