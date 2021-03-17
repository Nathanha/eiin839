using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace Authentification
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Authenticator : IAuthenticator
    {
        private Dictionary<string, string> Credentials = new Dictionary<string, string>();
        public Authenticator()
        {
            string[] logins = File.ReadAllLines(@"..\..\..\passwd.csv");
            foreach (string login in logins)
            {
                string[] parts = login.Split(';');
                Credentials.Add(parts[0].Trim(), parts[1].Trim());
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            return Credentials.Any(entry => entry.Key == username && entry.Value == password);
        }
    }
}
