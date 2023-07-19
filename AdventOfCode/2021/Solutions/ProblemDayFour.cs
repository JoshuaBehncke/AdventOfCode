using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class ProblemDayFour {
        public static void Solve() {
            List<string> input = new(File.ReadLines("..\\..\\..\\2021\\inputs\\DayFourInput.txt"));
            //List<string> input = new(File.ReadLines("..\\..\\..\\2021\\TestInputs\\DayFourTest.txt"));

            List<int> draws = new();
            List<BoardNum[,]> boards = new();

            foreach (string s in input[0].Split(",")) {
                draws.Add(Convert.ToInt32(s));
            }

            for (int i = 2; i < input.Count; i += 6) {
                BoardNum[,] board = new BoardNum[5, 5];

                for (int j = 0; j < board.GetLength(0); j++) {
                    string[] nums = input[i + j].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < board.GetLength(1); k++) {
                        board[j, k].Value = Convert.ToInt32(nums[k]);
                        board[j, k].Marked = false;
                    }
                }

                boards.Add(board);
            }

            List<BoardNum[,]> losers = new();
            boards.ForEach(losers.Add);
            BoardNum[,] loser = null;
            bool gameover = false;
            
            for (int i = 0; i < draws.Count; i++) {
                MarkBoards(boards, draws[i]);
                List<BoardNum[,]> winners = FindWinners(boards);

                if (winners.Count > 0) {
                    losers.RemoveAll(winners.Contains);

                    if (!gameover) {
                        gameover = true;
                        Console.WriteLine("Winning Board: ");
                        PrintBoard(winners[0]);
                        Console.WriteLine("Final Draw: " + draws[i]);
                        Console.Write("Board Score: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(Score(winners[0], draws[i]));
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }

                if (losers.Count == 1) loser = losers[0];

                if (losers.Count == 0) {
                    Console.WriteLine("Worst Board: ");
                    PrintBoard(loser);
                    Console.WriteLine("Final Draw: " + draws[i]);
                    Console.Write("Board Score: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(Score(loser, draws[i]));
                    Console.ResetColor();
                    Console.WriteLine();
                    return;
                }
            }

            Console.WriteLine("Something went wrong");
        }

        static int Score(BoardNum[,] board, int winningDraw) {
            int sum = 0;
            foreach (BoardNum boardNum in board) {
                sum += boardNum.Marked ? 0 : boardNum.Value;
            }

            return sum * winningDraw;
        }

        static List<BoardNum[,]> FindWinners(List<BoardNum[,]> boards) {
            List<BoardNum[,]> output = new();

            foreach (BoardNum[,] board in boards) {
                for (int i = 0; i < board.GetLength(0); i++) {
                    bool rowMarked = true;
                    bool columnMarked = true;

                    for (int j = 0; j < board.GetLength(1); j++) {
                        rowMarked &= board[i, j].Marked;
                        columnMarked &= board[j, i].Marked;
                    }

                    if (rowMarked || columnMarked) output.Add(board);
                }
            }

            return output;
        }

        static void MarkBoards(List<BoardNum[,]> boards, int number) {
            foreach (BoardNum[,] board in boards) {
                for (int i = 0; i < board.GetLength(0); i++) {
                    for (int j = 0; j < board.GetLength(1); j++) {
                        if (!board[i, j].Marked) board[i, j].Marked = board[i, j].Value == number;
                    }
                }
            }
        }

        static void PrintBoards(List<BoardNum[,]> boards) {
            foreach (BoardNum[,] board in boards) {
                PrintBoard(board);
            }
        }

        static void PrintBoard(BoardNum[,] board) {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (board[i, j].Marked) Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(board[i, j].Value < 10 ? " " + board[i, j].Value + " " : board[i, j].Value + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        struct BoardNum : IEquatable<BoardNum>{
            public int Value;
            public bool Marked;
            public bool Equals(BoardNum other) {
                return (Value == other.Value) && (Marked == other.Marked);
            }

            public override string ToString() => "Value: " + Value + "; Marked: " + Marked;
        }
    }
}