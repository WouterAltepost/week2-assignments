using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    public class SensorDataLoader : BigDataLoader
    {
        protected override void Extract()
        {
            Console.WriteLine("extracting sensor data...");
        }

        protected override void Transform()
        {
            Console.WriteLine("transforming sensor data...");
        }
    }
}
