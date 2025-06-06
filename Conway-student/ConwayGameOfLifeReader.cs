using System.IO;

namespace ConwayGameOfLife
{
    public class ConwayGameOfLifeReader
    {
        public ConwayGameOfLifeReader()
        {
            // ...
        }

        public bool[,] Read(string filename)
        {
            if (!File.Exists(filename))
                return null;

            StreamReader reader = new StreamReader(filename);
            int nrOfRows = int.Parse(reader.ReadLine());
            int nrOfColumns = int.Parse(reader.ReadLine());

            // create and fill array
            bool[,] mySpace = new bool[nrOfRows, nrOfColumns];
            for (int r = 0; r < nrOfRows; r++)
            {
                string line = reader.ReadLine();

                for (int c = 0; c < nrOfColumns; c++)
                {
                    mySpace[r, c] = (line[c] == '1') ? true : false;
                }
            }

            reader.Close();

            // return read space
            return mySpace;
        }
    }
}