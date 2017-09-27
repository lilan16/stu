using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class ClassInherit
    {
    }

    //'ConsoleApplicationTest.BaseClass.TestBody()' is abstract but it is contained in non-abstract class 'ConsoleApplicationTest.BaseClass'	
   abstract class BaseClass
    {
        public void Execute()
        {
            Console.WriteLine("BaseClass Execute()");
            InitializeTest();
            TestBody();  //运行完，接着执行 base class ？

            FinalizeTest();
        }  //1 

        protected virtual void InitializeTest()
        {
            Console.WriteLine("BaseClass InitializeTest()");
        } //3

        protected abstract void TestBody()
        ;

        protected void FinalizeTest()
        {
            Console.WriteLine("BaseClass FinalizeTest()");
            BeforeApplicationQuit();
            AfterApplicationQuit();
        }

        //inherit vsTestCase
	    protected virtual void  BeforeApplicationQuit()
        {

        }  
        //子类没有该函数，执行基类的？
        protected virtual void AfterApplicationQuit()
        {

        }

    }
   //Error	1	'ConsoleApplicationTest.DriveClass' does not implement inherited abstract member 'ConsoleApplicationTest.BaseClass.TestBody()'	
    abstract  class DriveClass : BaseClass
    {
        //void Execute()
        //{
        //    Console.WriteLine("DriveClass Execute()");
        //}
        protected override void InitializeTest()
        {
            Console.WriteLine("DriveClass InitializeTest()");
        } //2
    }
    class ThirdDriveClass
    {
        // don't have execute()
        //void Execute()
        //{
        //    Console.WriteLine("ThirdDriveClass Execute()");
        //}
        void InitializeTest()
        {
            Console.WriteLine("ThirdDriveClass InitializeTest()");
        }
        //protected abstract void TestBody()
        //{
        //    Console.WriteLine("BaseClass TestBody()");
        //}
        protected void TestBody()
        {
            Console.WriteLine("ThirdDriveClass TestBody()");
        }
    }
}
