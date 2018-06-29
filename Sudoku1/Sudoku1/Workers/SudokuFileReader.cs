using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku1.Workers
{
    class SudokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sudokuBoard = new int[9, 9];

            try
            {
                var sudokuLines = File.ReadAllLines(filename);
                int row = 0;
                foreach (var sudokuLine in sudokuLines)
                {
                    string[] sudokuLineNumbers = sudokuLine.Split('|').Skip(1).Take(9).ToArray();

                    int col = 0;
                    foreach (var sudokuLineNumber in sudokuLineNumbers)
                    {
                        sudokuBoard[row, col] = sudokuLineNumber.Equals(" ") ? 0 : Convert.ToInt16(sudokuLineNumber);
                        col++;
                    }
                    row++;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Reading failed." + ex.Message);
            }
            return sudokuBoard;

        }
    }
}
