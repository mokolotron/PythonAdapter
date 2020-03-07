//using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RunPythonScriptFromCS
{
    class PythonAdapter
    {
        string path_to_python;
        bool UseShellExecute = false;
        bool CreateNoWindow = true;
        bool RedirectStandardOutput = true;
        bool RedirectStandardError = true;
        public PythonAdapter(string path_to_python)
        {
             this.path_to_python = path_to_python;
        }

         public void Execute( string path_to_script, string[] args)
        {
          
            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = path_to_python;

            // 2) Provide script and arguments
            psi.Arguments = $"\"{path_to_script}\"";
            foreach (string arg in args)
            {
                psi.Arguments += $" \"{arg}\" ";
            }

            // 3) Process configuration
            psi.UseShellExecute = UseShellExecute;
            psi.CreateNoWindow = CreateNoWindow;
            psi.RedirectStandardOutput = RedirectStandardOutput;
            psi.RedirectStandardError = RedirectStandardError;

            // 4) Execute process and get output
            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            // 5) Display output

            Console.WriteLine("Python Output START \n ");
            Console.WriteLine("Results:");
            Console.WriteLine(results);
  
            if (!string.IsNullOrEmpty(errors))
            {
                Console.WriteLine("ERRORS:");
                Console.WriteLine(errors);
            }
            else
            {
                Console.WriteLine("Script has been executed without python errors \n ");
            }

            Console.WriteLine("Python Output END \n ");


        }

      
    }
}
