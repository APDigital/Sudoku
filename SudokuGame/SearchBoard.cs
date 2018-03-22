using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public static class SearchBoard
    {
        public static IEnumerable<Square> DepthFirstTraversal(this Board board, Square start)
        {
            var visited = new HashSet<Square>();
            var stack = new Stack<Square>();

            stack.Push(start);

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (!visited.Add(current))
                    continue;

                yield return current;

                var neighbours = board.GetNeighbours(current).Where(n => !visited.Contains(n));
                
            }
        }
    }
}
