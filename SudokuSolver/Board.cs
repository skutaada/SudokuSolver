using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SudokuSolver
{
    class Board
    {
        public int[,] board = new int[,] { { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                                           { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                                           { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                                           { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                                           { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                                           { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                                           { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                                           { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                                           { 0, 0, 0, 0, 8, 0, 0, 7, 9 } };

        public bool Solve()
        {
            int[] nextMove = FindIndex();
            if(nextMove[0] == -1)
            {
                return true;
            }

            for(int number = 1; number < 10; number++)
            {
                if(CheckValid(nextMove, number))
                {
                    board[nextMove[0], nextMove[1]] = number;

                    if(Solve())
                    {
                        return true;
                    } else
                    {
                        board[nextMove[0], nextMove[1]] = 0;
                    }
                }
            }

            return false;
        }

        // Finds the first zero(empty) element on board and returns its index
        private int[] FindIndex()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(board[i, j] == 0)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        // Check if number placed on the board would be a valid move according to Sudoku rules
        private bool CheckValid(int[] aNextMove, int aNumber)
        {
            for(int i = 0; i < 9; i++)
            {
                if(board[aNextMove[0], i] == aNumber) // Check in the same col
                {
                    return false;
                }

                if(board[i, aNextMove[1]] == aNumber) // Check in the same row
                {
                    return false;
                }
            }

            int startBoxX = aNextMove[0] - aNextMove[0] % 3;
            int startBoxY = aNextMove[1] - aNextMove[1] % 3;

            for(int i = startBoxX; i < startBoxX + 3; i++)
            {
                for(int j = startBoxY; j < startBoxY + 3; j++)
                {
                    if(board[i, j] == aNumber)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PrintBoard()
        {
            for(int i = 0; i < 9; i++)
            {
                List<int> row = new List<int>();
                for(int j = 0; j < 9; j++)
                {
                    row.Add(board[i, j]);
                }
                var line = string.Join('|', row);
                Console.WriteLine(line);
            }
        }
    }
}
