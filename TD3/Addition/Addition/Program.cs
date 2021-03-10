using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addition
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator.CalculatorSoapClient calculator = new Calculator.CalculatorSoapClient();
            Console.WriteLine(calculator.Add(10, 2));
            Console.ReadLine();
        }
    }
}
