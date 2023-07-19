using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDaySeven {
        public static void Solve() {
            string[] input = new List<string>(File.ReadLines("..\\..\\..\\2021\\inputs\\DaySevenInput.txt"))[0].Split(",");
            //string[] input = new List<string>(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DaySevenTest.txt"))[0].Split(",");

            int[] crabs = new int[input.Length];
            for (int i = 0; i < crabs.Length; i++) crabs[i] = Convert.ToInt32(input[i]);

            int bestPosition = FindBestPosition(crabs);

            Console.WriteLine("Best Alignment Position: " +  bestPosition);
            Console.Write("According Fuel Cost: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CalculateFuelCost(crabs, bestPosition));
            Console.ResetColor();

            Console.WriteLine();

            int newBestPosition = FindNewBestPosition(crabs);

            Console.WriteLine("New Best Alignment Position: " + newBestPosition);
            Console.Write("According Fuel Cost: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CalculateNewFuelCost(crabs, newBestPosition));
            Console.ResetColor();
        }

        static int FindNewBestPosition(int[] crabs) {
            int largestPosition = 0;
            int lowestPosition = 0;
            foreach (int crab in crabs) {
                largestPosition = largestPosition < crab ? crab : largestPosition;
                lowestPosition = lowestPosition > crab ? crab : lowestPosition;
            }

            int lowestFuelCost = int.MaxValue;
            int bestPosition = -1;
            for (int i = lowestPosition; i <= largestPosition; i++) {
                int fuelCost = CalculateNewFuelCost(crabs, i);
                if (fuelCost < lowestFuelCost) {
                    lowestFuelCost = fuelCost;
                    bestPosition = i;
                }
            }

            return bestPosition;
        }

        static int CalculateNewFuelCost(int[] crabs, int targetPosition) {
            int fuelCost = 0;

            foreach (int crab in crabs) for (int i = 1; i <= Math.Abs(crab - targetPosition); i++) fuelCost += i;

            return fuelCost;
        }

        static int FindBestPosition(int[] crabs) {
            int largestPosition = 0;
            int lowestPosition = 0;
            foreach (int crab in crabs) {
                largestPosition = largestPosition < crab ? crab : largestPosition;
                lowestPosition = lowestPosition > crab ? crab : lowestPosition;
            }

            int lowestFuelCost = int.MaxValue;
            int bestPosition = -1;
            for (int i = lowestPosition; i <= largestPosition; i++) {
                int fuelCost = CalculateFuelCost(crabs, i);
                if (fuelCost < lowestFuelCost) {
                    lowestFuelCost = fuelCost;
                    bestPosition = i;
                }
            }
            
            return bestPosition;
        }

        static int CalculateFuelCost(int[] crabs, int targetPosition) {
            int fuelCost = 0;

            foreach (int crab in crabs) fuelCost += Math.Abs(crab - targetPosition);

            return fuelCost;
        }
    }
}
