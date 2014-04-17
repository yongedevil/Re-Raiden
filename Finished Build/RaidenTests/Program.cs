using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidenTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_AI testAI = new Test_AI();
            Test.RunTests();

            Console.ReadKey();
        }
    }
}
