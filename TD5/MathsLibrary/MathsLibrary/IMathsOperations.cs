using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsLibrary
{
    [ServiceContract]
    public interface IMathsOperations
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        int Multiply(int x, int y);

        [OperationContract]
        int Subtract(int x, int y);

        [OperationContract]
        double Divide(double x, double y);
    }
}
