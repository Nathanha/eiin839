using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OpenWeather
{
    [ServiceContract]
    public interface IServiceAccess
    {
        [OperationContract]
        string Weather(string city);
    }
}
