using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Large[] larges = new Large[10240];
            Large large= new Large();
            large.l = new long[10000];
            StackOverflow(large);

        }
        static void StackOverflow(Large[] large)
        {
            Console.WriteLine("StackOverflow");
        }
        static void StackOverflow(Large large)
        {
            Console.WriteLine("StackOverflow");
        }

        struct Large
        {
            //int[] i=new int[1024];
            int i;
           internal long[] l;
        }
    }
}
