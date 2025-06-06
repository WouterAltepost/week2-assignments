using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    public abstract class BigDataLoader
    {
        public void ETL()
        {
            Console.WriteLine("[ETL-proces started]");
            Extract();
            Transform();
            Load();
            Console.WriteLine("[ETL-proces finished]");
        }

        protected abstract void Extract();
        protected abstract void Transform();
        protected virtual void Load()
        {
            Console.WriteLine("loading transformed data...");
        }
    }
}
