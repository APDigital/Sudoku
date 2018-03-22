using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGamePT2
{
    public class DepthFirst
    {
        public static void DepthFirstSearch(Board board)
        {
            Validation valid = new Validation();
            List<Square> potentialSquares = new List<Square>();
            List<int?> squareOriginalPotentialValues = new List<int?>();
            IEnumerable<Square> nullSpaces = board.Squares.Where(s => s.Value == 0);

            int nullCount = 0;
            int previousNullCount = 0;


            foreach (var item in nullSpaces)
            {
                foreach (var value in item.PotentialValues)
                {
                    potentialSquares.Add(new Square(item.Row, item.Column, value));
                }
            }
            var potentialSquaresLessOne = potentialSquares.Where(s => s.Column != 1 && s.Row != 1);

            foreach (var item in potentialSquares)
            {
                board.SetSquareValue(item.Row, item.Column, item.Value);

                foreach (var square in potentialSquaresLessOne)
                {
                    board.SetSquareValue(square.Row, square.Column, square.Value);
                    while (valid.IsValid(board.Squares) == true)
                    {
                        board.FindValidPotentialValues();
                        previousNullCount = nullCount;
                        nullCount = board.Squares.Where(s => s.Value == null).Count();
                        if (previousNullCount == nullCount)
                        {
                            break;
                        }
                    }
                    if (board.Squares.Where(s => s.Value == null).Count() > 0)
                    {
                        board = new Board();
                        board.SetSquareValue(item.Row, item.Column, item.Value);
                    }
                    else
                    {
                        Console.WriteLine("SolutionComplete");
                        break;
                    }
                }
                if (board.Squares.Where(s => s.Value == null).Count() == 0)
                {
                    break;
                }
            }

        }
    }
}

