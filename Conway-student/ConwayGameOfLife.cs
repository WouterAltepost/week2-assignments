using System;

namespace ConwayGameOfLife
{
    public class ConwayGameOfLife
    {
        const int WIDTH = 300;
        const int HEIGHT = 150;
        const int LIVECHANCE = 10; // each cell has a chance to be (initially) alive

        public bool[,] Space { get; private set; }
        private ILifeBehaviour _lifeBehaviour;

        // constructor
        public ConwayGameOfLife(ILifeBehaviour lifeBehaviour)
        {
            this._lifeBehaviour = lifeBehaviour;
            this.Space = new bool[HEIGHT, WIDTH];
            InitializeLife();
        }

        public ILifeBehaviour LifeBehaviour
        {
            get { return _lifeBehaviour; }
            set { _lifeBehaviour = value; }
        }

        public void StoreSpace(bool[,] space, int rowOffset, int columnOffset)
        {
            for (int r = 0; r < space.GetLength(0); r++)
            {
                for (int c = 0; c < space.GetLength(1); c++)
                {
                    int row = rowOffset + r;
                    int col = columnOffset + c;

                    if (row < 0)
                        row += HEIGHT;
                    else if (row >= HEIGHT)
                        row -= HEIGHT;

                    if (col < 0)
                        col += WIDTH;
                    else if (col >= WIDTH)
                        col -= WIDTH;

                    this.Space[row, col] = space[r, c];
                }
            }
        }

        private void InitializeLife()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            for (int r = 0; r < HEIGHT; r++)
            {
                for (int c = 0; c < WIDTH; c++)
                {
                    this.Space[r, c] = (random.Next(1, (100 / LIVECHANCE)) == 1);
                }
            }
        }

        public void Reset()
        {
            InitializeLife();
        }

        public void ClearSpace()
        {
            for (int r = 0; r < HEIGHT; r++)
                for (int c = 0; c < WIDTH; c++)
                    this.Space[r, c] = false;
        }

        public void Evolve()
        {
            bool[,] copySpace = new bool[HEIGHT, WIDTH];
            for (int r = 0; r < HEIGHT; r++)
                for (int c = 0; c < WIDTH; c++)
                    copySpace[r, c] = this.Space[r, c];

            for (int r = 0; r < HEIGHT; r++)
            {
                for (int c = 0; c < WIDTH; c++)
                {
                    bool livingCell = copySpace[r, c];
                    int neighbourCount = GetLiveNeighbours(copySpace, r, c);
                    this.Space[r, c] = _lifeBehaviour.CellShouldLive(livingCell, neighbourCount);
                }
            }
        }

        private int GetLiveNeighbours(bool[,] space, int row, int column)
        {
            int count = 0;

            for (int r = -1; r <= 1; r++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    if ((r == 0) && (c == 0)) continue;

                    int r2 = row + r;
                    if (r2 < 0)
                        r2 += HEIGHT;
                    else if (r2 >= HEIGHT)
                        r2 -= HEIGHT;

                    int c2 = column + c;
                    if (c2 < 0)
                        c2 += WIDTH;
                    else if (c2 >= WIDTH)
                        c2 -= WIDTH;

                    if (space[r2, c2])
                        count++;
                }
            }

            return count;
        }

        public void SetCell(int r, int c, bool alive)
        {
            if ((r < 0) || (c < 0) || (r >= HEIGHT) || (c >= WIDTH))
                return;

            this.Space[r, c] = alive;
        }
    }
}
