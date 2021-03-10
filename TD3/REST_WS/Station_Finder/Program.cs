using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Station_Finder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string contrat = args[0];
            GeoCoordinate coord = new GeoCoordinate(Convert.ToDouble(args[1]), Convert.ToDouble(args[2]));

            HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/stations?apiKey=67b2054c6e21e957152012426c86ed264fb1745c&contract=" + contrat);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);

            Station nearestStation = null;
            double bestDistance = 0;

            foreach (var station in stations)
            {
                if (nearestStation == null)
                {
                    nearestStation = station;
                    bestDistance = coord.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude));
                }
                else if (coord.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude)) < bestDistance)
                {
                    nearestStation = station;
                    bestDistance = coord.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude));
                }
                
            }

            Console.WriteLine(nearestStation);
            Console.ReadLine();
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
