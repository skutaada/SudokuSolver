using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Board instance = new Board();
            instance.Solve();
            instance.PrintBoard();
        }
    }
}
