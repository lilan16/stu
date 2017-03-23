using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security.Permissions;
namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example.Main00();
            SetObjectUriForMarshalTest.Main11();
        }
    }



//using System;
//using System.Runtime.Remoting;
//using System.Security.Permissions;
public class SetObjectUriForMarshalTest
    {

        class TestClass : MarshalByRefObject
        {
        }

        //[SecurityPermission(SecurityAction.Deny, Flags = SecurityPermissionFlag.RemotingConfiguration)]
        //警告	CS0618	“SecurityAction.Deny”已过时:“Deny is obsolete and will be removed in a future release of the .NET Framework. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.”	cs	c:\users\fwtlabb\documents\visual studio 2015\Projects\cs\cs\Program.cs	32	活动
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
        public static void Main11()
        {

            TestClass obj = new TestClass();

            RemotingServices.SetObjectUriForMarshal(obj, "testUri");
            //use deny
            //“System.NotSupportedException”类型的未经处理的异常在 mscorlib.dll 中发生
            //其他信息: The Deny stack modifier has been obsoleted by the.NET Framework.  Please see http://go.microsoft.com/fwlink/?LinkId=155571 for more information.

            RemotingServices.Marshal(obj);

            Console.WriteLine(RemotingServices.GetObjectUri(obj));
            ///921bdde7_277d_448e_896b_72211833cf82/testUri
        }
    }
}
//using System;
//using System.Reflection;
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
    public static void Main00()
    {
        // Create an ordinary instance in the current AppDomain
        Worker localWorker = new Worker();
        localWorker.PrintDomain();

        // Create a new application domain, create an instance
        // of Worker in the application domain, and execute code
        // there.
        AppDomain ad = AppDomain.CreateDomain("New domain");
        Worker remoteWorker = (Worker)ad.CreateInstanceAndUnwrap(
            Assembly.GetExecutingAssembly().FullName,
            "Worker");
        //“System.TypeLoadException”类型的未经处理的异常在 cs.exe 中发生 
        //其他信息: Could not load type 'Worker' from assembly 'cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'.

        //in worker don't :marshal...
        //“System.Runtime.Serialization.SerializationException”类型的未经处理的异常在 cs.exe 中发生
        //其他信息: Type 'Worker' in assembly 'cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' is not marked as serializable.
        remoteWorker.PrintDomain();
    }
}

/* This code produces output similar to the following:

Object is executing in AppDomain "source.exe"
Object is executing in AppDomain "New domain"
 */


