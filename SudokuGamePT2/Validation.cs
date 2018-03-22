using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGamePT2
{
    public class Validation
    {
        public bool IsValid(List<Square> Squares)
        {
            bool valid = false;

            // check rows are valid
            for (int i = 1; i < 10; i++)
            {
                var row = Squares.Where(s => s.Row == i);
                var rowValues = new List<int?>();
                foreach (var item in row)
                {
                    if (item.Value != null)
                    {
                        rowValues.Add(item.Value);
                    }
                }
                if (rowValues.Count() != rowValues.Distinct().Count())
                {
                    return valid = false;

                }
                else
                {
                    valid = true;
                }
            }
            if (valid == true)
            {
                //check cols are valid
                for (int i = 1; i < 10; i++)
                {
                    var col = Squares.Where(s => s.Column == i);
                    var colValues = new List<int?>();
                    foreach (var item in col)
                    {
                        if (item.Value != null)
                        {
                            colValues.Add(item.Value);
                        }
                    }
                    if (colValues.Count() != colValues.Distinct().Count() && colValues.Count() > 0)
                    {
                        return valid = false;
                    }
                    else
                    {
                        valid = true;
                    }
                }
            }
            if (valid == true)
            {
                //check squares are valid
                for (int i = 1; i < 8; i = i + 3)
                {
                    var col = Squares.Where(s => s.Column == i && s.Column == i + 1 && s.Column == i + 2);

                    for (int j = 1; j < 8; j = j + 3)
                    {
                        var square = col.Where(s => s.Row == j && s.Row == j + 1 && s.Row == j + 2);
                        var squareValues = new List<int?>();
                        foreach (var item in col)
                        {
                            if (item.Value != null)
                            {
                                squareValues.Add(item.Value);
                            }
                        }
                        if (squareValues.Count() != squareValues.Distinct().Count())
                        {
                            valid = false;
                        }
                        else
                        {
                            return valid = true;
                        }
                    }

                }
            }
            return valid;
        }
    }
}
