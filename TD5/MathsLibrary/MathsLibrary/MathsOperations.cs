using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsLibrary
{
    public class MathsOperations : IMathsOperations
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new Exception("divise by 0");
            }
            else
            {
                return x / y;
            }
        }
    }
}
