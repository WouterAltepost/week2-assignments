using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    public class CallDataLoader : BigDataLoader
    {
        protected override void Extract()
        {
            Console.WriteLine("extracting call data...");
        }

        protected override void Transform()
        {
            Console.WriteLine("transforming call data...");
        }
    }
}
