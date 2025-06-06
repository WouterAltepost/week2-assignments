using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife
{
    public class HighLifeBehaviour : ILifeBehaviour
    {
        public bool CellShouldLive(bool isAlive, int liveNeighbors)
        {
            if (isAlive)
            {
                return liveNeighbors == 2 || liveNeighbors == 3;
            }
            else
            {
                return liveNeighbors == 3 || liveNeighbors == 6;
            }
        }
    }
}
