using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class m100
    {
        static void Main(string[] args)
        {

            call();

        }

       static void call()
        {
            m100 m = new m100();
            //m.AssignmentString();
            //m.TestSort();
            m.SortList_Set();
        }

        //0725  sort
        //sort list
        void SortList_Set()
        {
            //SortedList<int> list=new SortedList<int> 
            SortedSet<int> set = new SortedSet<int>();
            int count = 20;

            //set.Count = count;
            Random r = new Random();
            for(int i=0;i<count;i++)
            {
               set.Add(r.Next(100));
            }
            set.All((m) => { Console.Write("{0}  ",m); return true; });
        }

        void TestSort()
        {
             int  count= 20;
            int[] arr=new int[count];
            //init arr
            Random r = new Random();
            for(int i=0;i<count;i++)
            {
                arr[i] = r.Next(100);
            }
            Console.WriteLine("output array");
            OutputArray(arr);

            Console.WriteLine("sort array");
            Sort(arr, arr.Length);

            Console.WriteLine("output array");
            OutputArray(arr);

        }
        void OutputArray(int[] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                Console.Write("{0}  ",arr[i]);
                //if(i%5==0)
                //    Console.WriteLine();
            }
            Console.WriteLine();
        }

        void Sort(int[] arr, int n)
        {
            int i, j, k;

            for (i = 0; i < n; i++)
            {
                k = i;
                for (j = i + 1; j < n; j++)
                {
                    if (arr[k] > arr[j])
                        k = j;
                }
                if (i != k)
                {
                    Swap(ref arr[i], ref arr[k]);
                }
            }
        }
        //swap two number
        void Swap(ref int i, ref int j)
        {
            int k;
            k = i;
            i = j;
            j = k;
        }

        void BubbleSort(int[] arr, int n)
        {
            int i, j, k;
            for (i = n; i > 0; i++)
            {
                for (j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(ref arr[j], ref arr[j + 1]);
                }
            }

            //for (i = 0; i < n; i++)
            //{
            //    for (j = 0; j < i; j++)
            //    {
            //        if (arr[j] > arr[j + 1])
            //            Swap(ref arr[j], ref arr[j + 1]);
            //    }
            //}
        }

        //0720
        //calculate operation hours
        //a b point same string object, modify a
        void AssignmentString()
        {
            string a = "hello", toa = a;
            Console.WriteLine("a:{0}    toa:{1}",a,toa);
            a = "hello new";
            Console.WriteLine("a:{0}    toa:{1}", a, toa);

            object objectA = "hello", toObjectA = objectA;
            Console.WriteLine("objectA:{0}    toObjectA:{1}", objectA, toObjectA);
            objectA = "hello new";
            Console.WriteLine("objectA:{0}    toObjectA:{1}", objectA, toObjectA);

            //object o = new object() { a = 1, b = 2 };

        }
        //a:hello toa:hello
        //a:hello new toa:hello
        //objectA:hello toObjectA:hello
        //objectA:hello new toObjectA:hello

        //singleton mode
        //static ,  non static ?
        class SingletonClass
        {
            private static SingletonClass _instance = null;
            SingletonClass _instance_instance = _instance;

            static SingletonClass()
            {
                
                //else
                //    return instance;
            }
            public static SingletonClass Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonClass();
                    }
                    return _instance;
                }
                //set
                //{
                    
                //}
            }
        }

        //-----------------------------
        Stack<int> sta = new Stack<int>();

        void Recursion_ReverseStack()
        {
            int head=sta.Pop();
            if (sta.Count == 1)
            {
                sta.Push(head);
            }
            else
            {
                Recursion_ReverseStack();
            }

        }


        StringBuilder bui = new StringBuilder();
        int fibonacci(int n)
        {
            //Console.WriteLine("n:{0}",n);
            //System.Diagnostics.Debug.Close();
            //System.Diagnostics.Trace.TraceInformation("n:{0}"+n.ToString());
            //very slow
            bui.AppendFormat("n:{0}    ",n.ToString());

            if (n == 0)
            {
                bui.Append(Environment.NewLine);
                return 0;
            }
            else if (n == 1)
                return 1;
            else
                return fibonacci(n - 2) + fibonacci(n - 1);
        }

        void CallFibonacci()
        {
            int n = 20;
            m100 p = new m100();

            Console.WriteLine("n=" + n.ToString());
            Console.WriteLine("result=" + p.fibonacci(n));

            Console.WriteLine();
            Console.WriteLine(p.bui.ToString());
        }
    }
}
