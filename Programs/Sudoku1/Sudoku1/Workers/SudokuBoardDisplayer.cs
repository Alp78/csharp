using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku1.Workers
{
    class SudokuBoardDisplayer
    {
        public void Display (string title, int[,] sudokuBoard)
        {
            if(!title.Equals(string.Empty))
            {
                Console.WriteLine($"{title}{Environment.NewLine}");
            }

            // GetLength: the length of the row (first dimension 0) (not columns (second dimension 1))
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {

                Console.Write("|");
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    Console.Write($"{sudokuBoard[row, col]}|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
