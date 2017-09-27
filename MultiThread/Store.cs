using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    class Store
    {
    }

    class Construct
    {
        string _name;
        string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Construct()
        {

        }
        public Construct(string name)
        {
            Name = name;
            Console.WriteLine("实例构造函数");
        }
        static Construct()
        {
            Console.WriteLine("静态构造函数");
        }
        ~Construct()
        {
            Console.WriteLine("变量『{0}』：析构函数", Name);
        }


        void TestConstruce()
        {
            Construct c1 = new Construct("c1");
            Construct c2 = new Construct("c2");
            Console.ReadKey();

            Construct c3 = new Construct("c3");
            Construct c4 = new Construct("c4");
            c3 = null;
            Console.ReadKey();
            GC.Collect();
            Console.WriteLine("after gc.collect()");
            Console.ReadKey();
        }
        //静态构造函数
        //实例构造函数
        //实例构造函数
        //实例构造函数
        //实例构造函数
        //after gc.collect()
        //变量『c3』：析构函数
        //...

        public static void Call()
        {
            Construct program = new Construct();
            program.TestConstruce();
        }
    }

    class aa
    {
        void TestDotNet()
        {
            string h = "hello,China!";
            Console.WriteLine(h);
        }
    }
}
