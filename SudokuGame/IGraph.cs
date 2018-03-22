using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
   public interface IGraph
    {
        IEnumerable<Square> GetNeighbour(Square s);
    }
}
