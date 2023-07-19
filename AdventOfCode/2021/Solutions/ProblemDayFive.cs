using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDayFive {
        public static void Solve() {
            List<string> input = new(File.ReadLines("..\\..\\..\\2021\\inputs\\DayFiveInput.txt"));
            //List<string> input = new(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DayFiveTest.txt"));

            List<Line> lines = new();
            Point fieldSize = new Point(0, 0);

            foreach (string line in input) {
                string[] points = line.Split(" -> ");
                Line newLine = new();

                newLine.Start.X = Convert.ToInt32(points[0].Split(",")[0]);
                newLine.Start.Y = Convert.ToInt32(points[0].Split(",")[1]);
                newLine.End.X = Convert.ToInt32(points[1].Split(",")[0]);
                newLine.End.Y = Convert.ToInt32(points[1].Split(",")[1]);

                lines.Add(newLine);

                fieldSize.X = newLine.Start.X > fieldSize.X ? newLine.Start.X : fieldSize.X;
                fieldSize.X = newLine.End.X   > fieldSize.X ? newLine.End.X   : fieldSize.X;
                fieldSize.Y = newLine.Start.Y > fieldSize.Y ? newLine.Start.Y : fieldSize.Y;
                fieldSize.Y = newLine.End.Y   > fieldSize.Y ? newLine.End.Y   : fieldSize.Y;
            }

            //foreach (Line line in lines) Console.WriteLine(line);
            //Console.WriteLine();

            int[,] field = new int[fieldSize.Y + 1, fieldSize.X + 1];

            for (int i = 0; i < field.GetLength(0); i++) {
                for (int j = 0; j < field.GetLength(1); j++) {
                    field[i, j] = 0;
                }
            }

            MarkPoints(field, lines, false);
            //DrawField(field);
            //Console.WriteLine();

            int count = 0;
            foreach (int i in field) if (i > 1) count++;
            Console.Write("Total Line Overlaps without Diagonals: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(count);
            Console.ResetColor();
            Console.WriteLine();

            //Console.WriteLine();

            for (int i = 0; i < field.GetLength(0); i++) {
                for (int j = 0; j < field.GetLength(1); j++) {
                    field[i, j] = 0;
                }
            }

            MarkPoints(field, lines, true);
            //DrawField(field);
            //Console.WriteLine();

            count = 0;
            foreach (int i in field) if (i > 1) count++;
            Console.Write("Total Line Overlaps with Diagonals: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(count);
            Console.ResetColor();
            Console.WriteLine();
        }

        static void DrawField(int[,] field) {
            for (int i = 0; i < field.GetLength(0); i++) {
                for (int j = 0; j < field.GetLength(1); j++) {
                    Console.Write(field[i, j] == 0 ? "." : "" + field[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void MarkPoints(int[,] field, List<Line> lines, bool diagonals) {
            foreach (Line line in lines) MarkPoints(field, line, diagonals);
        }

        static void MarkPoints(int[,] field, Line line, bool diagonals) {
            if (line.Start.X == line.End.X) {
                bool b = line.Start.Y < line.End.Y;
                for (int i = b ? line.Start.Y : line.End.Y; i <= (b ? line.End.Y : line.Start.Y); i++) {
                    field[i, line.Start.X]++;
                }
            } else if (line.Start.Y == line.End.Y) {
                bool b = line.Start.X < line.End.X;
                for (int i = b ? line.Start.X : line.End.X; i <= (b ? line.End.X : line.Start.X); i++) {
                    field[line.Start.Y, i]++;
                }
            } else if (diagonals) {
                int i = line.Start.Y;
                int j = line.Start.X;

                while (i != line.End.Y) {
                    field[i, j]++;

                    i += line.Start.Y < line.End.Y ? 1 : -1;
                    j += line.Start.X < line.End.X ? 1 : -1;
                }

                field[i, j]++;
            }
        }

        struct Point {
            public int X;
            public int Y;

            public Point(int x, int y) {
                X = x;
                Y = y;
            }

            public static bool operator == (Point a, Point b) {
                return a.Equals(b);
            }

            public static bool operator != (Point a, Point b) {
                return !a.Equals(b);
            }

            public override string ToString() => "X: " + X + " Y: " + Y;

            public override bool Equals(object obj) {
                return (this.X == ((Point) obj).X) && (this.Y == ((Point) obj).Y);
            }

            public override int GetHashCode() {
                throw new NotImplementedException();
            }
        }

        struct Line {
            public Point Start;
            public Point End;

            public Line(Point start, Point end) {
                Start = start;
                End = end;
            }

            public override string ToString() => Start.X + "," + Start.Y + " -> " + End.X + "," + End.Y;
        }
    }
}