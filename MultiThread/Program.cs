using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest();
        }

        public static void RunTest()
        {
            ClassMutex.test();
            //ClassMarshalByRefObject.test();
            Console.ReadKey();
        }
    }
}
