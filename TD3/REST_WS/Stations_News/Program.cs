using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stations_News
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string contrat = args[0];
            string stationId = args[1];
            
            HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/stations/"+stationId+"?apiKey=67b2054c6e21e957152012426c86ed264fb1745c&contract=" + contrat);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Station station = JsonSerializer.Deserialize<Station>(responseBody);

            Console.WriteLine(station);
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
