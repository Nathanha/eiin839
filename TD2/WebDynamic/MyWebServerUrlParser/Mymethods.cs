using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServerUrlParser
{
    class Mymethods
    {
        public string MyMethod(string param1, string param2)
        {
            return "<HTML><BODY> Hello " + param1 + " et " + param2 + "</BODY></HTML>";
        }

        public string ExternalMethod(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"D:\Nathan\Documents\Polytech\SI4\S8\Serv.Oriented Computing\eiin839\TD2\WebDynamic\ExternalMethod\bin\Debug\netcoreapp3.1\ExternalMethod.exe"; // Specify exe name.
            start.Arguments = param1 + " " + param2;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    return result;
                }
            }
        }
    }
}
