using System.Text;

namespace Sudoku1.Workers
{
    class SudokuBoardStateManager
    {

        public string GenerateState(int[,] sudokuBoard)
        {
            StringBuilder key = new StringBuilder();

            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    key.Append(sudokuBoard[row, col]);
                }
            }

            return key.ToString();
        }

        public bool IsSolved(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    // if the cell is null or longer than 1 (more than 1 possible number for this spot), then return false
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


    }
}
