using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MultiThread
{
    class ClassMarshalByRefObject
    {
        public static void test()
        {
            Example.Main();
        }
    }
    

public class Worker : MarshalByRefObject
{
    public void PrintDomain() 
    { 
        Console.WriteLine("Object is executing in AppDomain \"{0}\"",
            AppDomain.CurrentDomain.FriendlyName); 
    }
}

class Example
{
    public static void Main()
    {
        // Create an ordinary instance in the current AppDomain
        Worker localWorker = new Worker();
        localWorker.PrintDomain();

        // Create a new application domain, create an instance
        // of Worker in the application domain, and execute code
        // there.
        AppDomain ad = AppDomain.CreateDomain("New domain");
        Worker remoteWorker = (Worker) ad.CreateInstanceAndUnwrap(
            Assembly.GetExecutingAssembly().FullName,
            "MultiThread.Worker");
        //补天就爱  不写MultiThread 发生异常 TypeLoadException 
        remoteWorker.PrintDomain();
    }
}

/* This code produces output similar to the following:

Object is executing in AppDomain "source.exe"
Object is executing in AppDomain "New domain"
 */
}
