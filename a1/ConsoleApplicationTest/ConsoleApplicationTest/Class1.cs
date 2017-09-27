using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class Class1
    {
        void Overflow()
        {
            int count = 0;
            for (int i = 0; i < 2 << 32; i++)
            {
                count++;
            }
        }
        //wait



    }


}
namespace StaticConstruct
{
    public class A
    {
        public static string strText;

        static A()
        {
            strText = "aaaaaa";

        }
    }

    public class B : A
    {

        static B()
        {
            strText = "bbbbbb";
            // 在执行 b = new b() ,时 执行静态构造函数
            //并且先 执行a 的静态构造函数
        }
    }

    public class Demo
    {

        public static void Test(string[] args)
        {

            B b = new B();
            A a = new A();

            Console.WriteLine(B.strText);
        }
    }
}
