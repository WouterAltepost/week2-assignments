using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    public class BatchProcessor
    {
        private List<BigDataLoader> loaders = new List<BigDataLoader>();

        public void AddLoader(BigDataLoader loader)
        {
            loaders.Add(loader);
        }

        public void ProcessBatch()
        {
            foreach (var loader in loaders)
            {
                loader.ETL();
            }
        }
    }
}
