using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGamePT2
{
    public class Square
    {
       
        //cases for each square
        internal enum Blocks
        {
            UpperLeft,
            UpperMiddle,
            UpperRight,
            MiddleLeft,
            Middle,
            MiddleRight,
            LowerLeft,
            LowerMiddle,
            LowerRight
        }
        public List<int> PotentialValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int Row { get; set; }
        public int Column { get;  set; }
        public int? Value { get; set; }
        
        internal Blocks Block
        {
            get
            {
                if (Row < 4)
                {
                    if (Column < 4)
                    {
                        return Blocks.UpperLeft;
                    }
                    if (Column < 7)
                    {
                        return Blocks.UpperMiddle;
                    }
                    else
                    {
                        return Blocks.UpperLeft;
                    }
                }
                if (Row < 7)
                {
                    if (Column < 4)
                    {
                        return Blocks.MiddleLeft;
                    }
                    if (Column < 7)
                    {
                        return Blocks.Middle;
                    }
                    else
                    {
                        return Blocks.MiddleRight;
                    }
                }
                if (Column < 4)
                {
                    return Blocks.LowerLeft;
                }
                if (Column < 7)
                {
                    return Blocks.LowerMiddle;
                }
                else
                {
                    return Blocks.LowerRight;
                }
            }
        }
        
        public Square(int row, int column, int? value)
        {
            Row = row;
            Column = column;
            Value = value;
        }
    }
}

