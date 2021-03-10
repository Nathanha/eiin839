using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string contrat = args[0];
            HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/stations?apiKey=67b2054c6e21e957152012426c86ed264fb1745c&contract="+contrat);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);

            StringBuilder sb = new StringBuilder("");
            foreach (var station in stations)
            {
                sb.Append(station+"\n");
            }
            Console.WriteLine(sb.ToString());
        }

        public class Station
        {
            public int number { get; set; }
            public string contractName { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public Position position { get; set; }
            public override string ToString()
            {
                return " number : " + number + "\n"
                     + " contractName : " + contractName + "\n"
                     + " name : " + name + "\n"
                     + " address : " + address + "\n"
                     + " position : [" + position + "]\n";
            }
        }
        public class Position
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
            public override string ToString()
            {
                return "latitude : " + latitude + " longitude : " + longitude;
            }
        }
    }
}
