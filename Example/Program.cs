
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RunPythonScriptFromCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Execute python process...");

            PythonAdapter python = new PythonAdapter(@"D:\program\AnacondaPython\python.exe");

            python.Execute(@"C:\Users\Admin\source\repos\CS_test_project\CS_test_project\DaysBetweenDates.py",
                new[] { "2019-1-1", "2019-1-22" });

        }

    }
}