using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku1.Strategies
{
    interface ISudokuStrategy
    {
        int[,] Solve(int[,] sudokuBoard);
    }
}
