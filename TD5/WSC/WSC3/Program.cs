using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSC3
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperations.IMathsOperations mathsOperationsWs = new MathsOperations.MathsOperationsClient("SoapEndPnt3");
            Console.WriteLine("--- 10 + 2 ---");
            Console.WriteLine(mathsOperationsWs.Add(10, 2));
            Console.WriteLine("--- 10 * 2 ---");
            Console.WriteLine(mathsOperationsWs.Multiply(10, 2));
            Console.WriteLine("--- 10 - 2 ---");
            Console.WriteLine(mathsOperationsWs.Subtract(10, 2));
            Console.WriteLine("--- 10 / 2 ---");
            Console.WriteLine(mathsOperationsWs.Divide(10, 2));
            Console.ReadLine();
        }
    }
}
