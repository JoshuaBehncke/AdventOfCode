using System;
using System.Reflection;

namespace AdventOfCode {
    class Solutions2021 {
        static readonly string[] days = new string[] {"1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", "14th", "15th", "16th", "17th", "18th", "19th", "20th", 
            "21st", "22nd", "23rd", "24th"};
        static readonly Type[] problemTypes = new Type[] {typeof(ProblemDayOne), typeof(ProblemDayTwo), typeof(ProblemDayThree), typeof(ProblemDayFour), typeof(ProblemDayFive), typeof(ProblemDaySix),
            typeof(ProblemDaySeven), typeof(ProblemDayEight)};

        public static void AllSolutions() {
            for (int i = 1; i <= problemTypes.Length; i++) {
                SolveProblem((Problem) i);
            }

            //SolveProblem(Problem.One);
        }

        static void SolveProblem(Problem problem) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(days[(int) problem - 1] + " Day:");
            Console.ResetColor();
            problemTypes[(int)problem - 1].GetMethod("Solve").Invoke(null, null);
            Console.WriteLine();
        }

        enum Problem {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8
        }
    }
}
