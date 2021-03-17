using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthentifiedAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine("Enter username : ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();

            Authenticator.IAuthenticator auth = new Authenticator.AuthenticatorClient();

            bool isvalid = auth.ValidateCredentials(username, password);
            if(isvalid)
            {
                Console.WriteLine("Your are authenticated!");
                Console.WriteLine("enter a city name:");
                string city = Console.ReadLine();
                ServiceAccess.IServiceAccess srv = new ServiceAccess.ServiceAccessClient();
                Console.WriteLine(srv.Weather(city));

            } 
            else
                Console.WriteLine("Your are NOT authenticated!");

            Console.WriteLine("press a key to exit");
            Console.ReadLine();     
        }
    }
}
