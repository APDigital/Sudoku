using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGamePT2
{
    public class Board
    {
        public List<Square> Squares { get; set; }
        Validation validation = new Validation();

        public Board()
        {
            Squares = new List<Square>();
            for (int row = 1; row < 9; row++)
            {
                for (int col = 1; col < 9; col++)
                {
                    Square newSquare = new Square(row, col,null);
                    Squares.Add(newSquare);
                }
            }
            var nullSquares = 0;
            var previousNullSquares = 0;

            while (validation.IsValid(Squares))
            {
                FindValidPotentialValues();
                previousNullSquares = nullSquares;
                nullSquares = Squares.Where(s => s.Value == 0).Count();
                if (previousNullSquares == nullSquares)
                {
                    break;
                }

            }
        }

        public void FindValidPotentialValues()
        {
            IEnumerable<Square> IsNull = Squares.Where(s => s.Value == null);
            IEnumerable<Square> IsSolved = Squares.Where(s => s.Value != null);


            foreach (Square s in IsSolved)
            {
                foreach (Square n in IsNull)
                {
                    if (s.Row == n.Row)
                    {
                        n.PotentialValues.Remove(s.Value.Value);
                    }
                    if (s.Column == n.Column)
                    {
                        n.PotentialValues.Remove(s.Value.Value);
                    }
                    if (s.Block == n.Block)
                    {
                        n.PotentialValues.Remove(s.Value.Value);
                    }
                }
            }
            var definateAnswers = IsNull.Where(s => s.PotentialValues.Count == 1);

            if (definateAnswers.Count() >= 1)
            {
                foreach (var item in definateAnswers)
                {
                    var value = item.PotentialValues.First();
                    SetSquareValue(item.Row, item.Column, value);
                }
            }
        }

        public void SetSquareValue(int row, int column, int? value)
        {
            Square activeSquare = Squares.Single(x => (x.Row == row) && (x.Column == column));
            activeSquare.Value = value;
        }
        public int GetLastItem(int row, int col)
        {
            Square square = Squares.Single(x => (x.Row == row) && (x.Column == col));
            int result = 0;
            while (row == 9 && col == 9)
            {
                result = square.Value.Value;
            }
            return result;
        }
    }
}
