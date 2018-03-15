using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuGame;

namespace SudokuTest
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestGamePlay()
        {
            Board board = new Board();

            board.SetSquareValue(1, 6, 2);
            board.SetSquareValue(1, 7, 1);

            board.SetSquareValue(2, 3, 4);
            board.SetSquareValue(2, 6, 8);
            board.SetSquareValue(2, 7, 7);

            board.SetSquareValue(3, 2, 2);
            board.SetSquareValue(3, 4, 3);
            board.SetSquareValue(3, 7, 9);

            board.SetSquareValue(4, 1, 6);
            board.SetSquareValue(4, 3, 2);
            board.SetSquareValue(4, 6, 3);
            board.SetSquareValue(4, 8, 4);

            board.SetSquareValue(6, 2, 5);
            board.SetSquareValue(6, 4, 6);
            board.SetSquareValue(6, 7, 3);
            board.SetSquareValue(6, 9, 1);

            board.SetSquareValue(7, 3, 3);
            board.SetSquareValue(7, 6, 5);
            board.SetSquareValue(7, 8, 8);

            board.SetSquareValue(8, 3, 8);
            board.SetSquareValue(8, 4, 2);
            board.SetSquareValue(8, 7, 5);

            board.SetSquareValue(9, 3, 9);
            board.SetSquareValue(9, 4, 7);

            int? result = 0;
            foreach (var square in board.Squares)
            {
                result = board.GetLastItem(9,9);
                Console.WriteLine(result);
            }

            Assert.AreNotEqual(0, result);
        }
    }
}
