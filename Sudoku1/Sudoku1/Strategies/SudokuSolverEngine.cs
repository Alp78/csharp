using Sudoku1.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku1.Strategies
{
    class SudokuSolverEngine
    {
        /*
        If it's private and readonly, the benefit is that you can't inadvertently change it from another part of that class after it is initialized. 
        The readonly modifier ensures the field can only be given a value during its initialization or in its class constructor. 
        */
        private readonly SudokuBoardStateManager _sudokuBoardStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(SudokuBoardStateManager sudokuBoardStateManager, SudokuMapper sudokuMapper)
        {
            _sudokuBoardStateManager = sudokuBoardStateManager;
            _sudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] sudokuBoard)
        {
            List<ISudokuStrategy> strategies = new List<ISudokuStrategy>()
            {
                new SimpleMarkupStrategy(_sudokuMapper),
                new NakedPairsStrategy(_sudokuMapper)
            };

            var currentState = _sudokuBoardStateManager.GenerateState(sudokuBoard);
            var nextState = _sudokuBoardStateManager.GenerateState(strategies.First().Solve(sudokuBoard));

            while (!_sudokuBoardStateManager.IsSolved(sudokuBoard) && currentState != nextState)
            {
                currentState = nextState;

                foreach (var strategy in strategies)
                {
                    nextState = _sudokuBoardStateManager.GenerateState(strategy.Solve(sudokuBoard));
                }
            }

            return _sudokuBoardStateManager.IsSolved(sudokuBoard);
        }
    }
}
