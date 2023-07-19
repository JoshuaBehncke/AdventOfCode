using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDayTwo {
        public static void Solve() {
            List<string> input = new(File.ReadLines("..\\..\\..\\2021\\Inputs\\DayTwoInput.txt"));
            //List<string> input = new(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DayTwoTest.txt"));

            Console.WriteLine("For Commands without Aim:");
            int[] outputWithoutAim = CalculateNewPosition(0, 0, input);
            Console.WriteLine("  - Horizontal Position: " + outputWithoutAim[0]);
            Console.WriteLine("  - Depth: " + outputWithoutAim[1]);
            Console.Write("  - Their Product: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(outputWithoutAim[0] * outputWithoutAim[1]);
            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine("For Commands with Aim:");
            int[] outputWithAim = CalculateNewPosition(0, 0, 0, input);
            Console.WriteLine("  - Horizontal Position: " + outputWithAim[0]);
            Console.WriteLine("  - Depth: " + outputWithAim[1]);
            Console.Write("  - Their Product: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(outputWithAim[0] * outputWithAim[1]);
            Console.ResetColor();
        }

        static int[] CalculateNewPosition(int horizontalPosition, int depth, List<string> commands) {
            int[] output = new int[2];

            foreach (string command in commands) {
                string[] splitCommand = command.Split(" ");

                switch (splitCommand[0]) {
                    case "forward":
                        horizontalPosition += Convert.ToInt32(splitCommand[1]);
                        break;
                    case "down":
                        depth += Convert.ToInt32(splitCommand[1]);
                        break;
                    case "up":
                        depth -= Convert.ToInt32(splitCommand[1]);
                        break;
                }
            }

            output[0] = horizontalPosition;
            output[1] = depth;

            return output;
        }

        static int[] CalculateNewPosition(int horizontalPosition, int depth, int aim, List<string> commands) {
            int[] output = new int[2];

            foreach (string command in commands) {
                string[] splitCommand = command.Split(" ");

                switch (splitCommand[0]) {
                    case "forward":
                        horizontalPosition += Convert.ToInt32(splitCommand[1]);
                        depth += Convert.ToInt32(splitCommand[1]) * aim;
                        break;
                    case "down":
                        aim += Convert.ToInt32(splitCommand[1]);
                        break;
                    case "up":
                        aim -= Convert.ToInt32(splitCommand[1]);
                        break;
                }
            }

            output[0] = horizontalPosition;
            output[1] = depth;

            return output;
        }
    }
}