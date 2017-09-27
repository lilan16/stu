using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticConstruct.Demo.Test(new string[] { });
            Common.BeforeQuit();
        }
    }
}
