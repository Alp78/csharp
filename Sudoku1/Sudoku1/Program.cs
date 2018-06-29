using Sudoku1.Strategies;
using Sudoku1.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();

                string path = @"./sudoku.txt";
                var sudokuBoard = sudokuFileReader.ReadFile(path);
                sudokuBoardDisplayer.Display("Initial state", sudokuBoard);

                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                sudokuBoardDisplayer.Display("Final state", sudokuBoard);

                Console.WriteLine(isSudokuSolved ? "Sudoku puzzle solved!" : "Sudoku puzzle cannot be solved!");

            }
            catch (Exception ex)
            {

                Console.WriteLine("{0} : {1}", "Sudoku Puzzle cannot be solved because there was an error: ", ex.Message);
            }

            Console.ReadKey();
        }
    }
}