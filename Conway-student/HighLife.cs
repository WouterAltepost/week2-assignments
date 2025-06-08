using System.Windows;

namespace ConwayGameOfLife
{
    public class HighLife : ConwayGameOfLife
    {
        protected override bool CellShouldLive(bool livingCell, int neighbourCount)
       {
            // B36/S23

            // a cell is born if it has 3 or 6 neighbors
            if (!livingCell && (neighbourCount == 3 || neighbourCount == 6))
                return true;

            // a cell survives if it has 2 or 3 neighbors
            if (livingCell && (neighbourCount == 2 || neighbourCount == 3))
                return true;

            // dead cell
            return false;
        }
  }
}
