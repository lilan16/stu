
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace 设置默认浏览器
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *修改默认浏览器
             */
            //浏览器路径
            string exePath = @"F:\firefox\firefox.exe";
            //注册表项
            string reg = @"http\shell\open\command";
            string nameReg = @"http\shell\open\ddeexec\Application";

            RegistryKey key = null;
            try
            {
                key = Registry.ClassesRoot.OpenSubKey(reg, true);
                if (key != null)
                {
                    key.SetValue("", string.Format("\"{0}\" -- \"%1\"", exePath));
                    key.Close();

                    key = Registry.ClassesRoot.OpenSubKey(nameReg, true);
                    if (key != null)
                    {
                        key.SetValue("", Path.GetFileNameWithoutExtension(exePath));
                        key.Close();
                    }
                }
            }
            catch (Exception)
            {
                key.Close();
            }
        }


    }
}
