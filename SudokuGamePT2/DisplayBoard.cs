using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGamePT2
{
    public class DisplayBoard
    {
        public void Display(Board board)
        {
            List<int?> values = new List<int?>();

            foreach (var item in board.Squares)
            {
                values.Add(item.Value);
            }
            int counter = 0;
            int rowCounter = 0;

            Console.WriteLine("-------------------------------");
            for (int i = 0; i < values.Count; i++)
            {
                var num = values.ElementAt(i).ToString();
                if (counter == 0 || counter == 3 || counter == 6)
                {
                    Console.Write("|");
                }
                if (num == "")
                {
                    counter += 1;
                    Console.Write(" . ");
                }
                else if (num != "")
                {
                    counter += 1;
                    Console.Write($" {values.ElementAt(i)} ");
                }
                if (counter == 9)
                {
                    counter = 0;
                    rowCounter += 1;
                    Console.Write("| \n");
                }

                if (rowCounter == 3)
                {
                    rowCounter = 0;
                    Console.Write("------------------------------- \n");
                }
            }
        }
    }
}
