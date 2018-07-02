using Sudoku1.Workers;
using System;
using System.Linq;

namespace Sudoku1.Strategies
{
    // returns a board filled with possible values for each empty case
    class SimpleMarkupStrategy : ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        private bool IsValidSingle(int cellDigit)
        {
            return cellDigit != 0 && cellDigit.ToString().Length == 1;
        }

        public SimpleMarkupStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        // for each cell, returns all the possible numbers in form of an integer (e.g. 1268) by checking rows and columns
        private int GetPossibilitiesInRowAndCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int col = 0; col < 9; col++)
            {
                if (IsValidSingle(sudokuBoard[givenRow, col]))
                {
                    possibilities[sudokuBoard[givenRow, col] - 1] = 0;
                }
            }

            for (int row = 0; row < 9; row++)
            {
                if (IsValidSingle(sudokuBoard[row, givenCol]))
                {
                    possibilities[sudokuBoard[row, givenCol] - 1] = 0;
                }
            }

            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        // for each cell, returns all the possible numbers in form of an integer (e.g. 1268) by checking block's rows and cols
        private int GetPossibilitiesInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _sudokuMapper.Find(givenRow, givenCol);

            for (int row = sudokuMap.StartRow; row <= sudokuMap.StartRow + 2; row++)
            {
                for (int col = sudokuMap.StartCol; col <= sudokuMap.StartCol + 2; col++)
                {
                    if (IsValidSingle(sudokuBoard[row, col]))
                    {
                        possibilities[sudokuBoard[row, col] - 1] = 0;
                    }
                }
            }

            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        // interesects both results and returns the matching numbers if any - narrowing down the possibilities
        private int GetPossibilityIntersection(int possibilitiesInRowAndCol, int possibilitiesInBlock)
        {
            var possibilitiesInRowAndColCharArray = possibilitiesInRowAndCol.ToString().ToCharArray();
            var possibilitiesInBlockCharArray = possibilitiesInBlock.ToString().ToCharArray();
            var possibilitiesSubset = possibilitiesInRowAndColCharArray.Intersect(possibilitiesInBlockCharArray);

            return Convert.ToInt32(String.Join(string.Empty, possibilitiesSubset));
        }

        // implementation of the Solve method from the interface, returns a partially or completely solved board
        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(sudokuBoard, row, col);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(sudokuBoard, row, col);
                        sudokuBoard[row, col] = GetPossibilityIntersection(possibilitiesInRowAndCol, possibilitiesInBlock);
                    }
                }
            }
            return sudokuBoard;
        }
    }
}