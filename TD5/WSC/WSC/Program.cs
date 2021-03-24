using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSC
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperations.IMathsOperations mathsOperations = new MathsOperations.MathsOperationsClient("SoapEndPnt1");
            Console.WriteLine("--- 10 + 2 ---");
            Console.WriteLine(mathsOperations.Add(10, 2));
            Console.WriteLine("--- 10 * 2 ---");
            Console.WriteLine(mathsOperations.Multiply(10, 2));
            Console.WriteLine("--- 10 - 2 ---");
            Console.WriteLine(mathsOperations.Subtract(10, 2));
            Console.WriteLine("--- 10 / 2 ---");
            Console.WriteLine(mathsOperations.Divide(10, 2));
            Console.ReadLine();
        }
    }
}
