using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace REST_WS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/contracts?apiKey=67b2054c6e21e957152012426c86ed264fb1745c");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Contrat> json = JsonSerializer.Deserialize<List<Contrat>>(responseBody);

            foreach (var contrat in json)
            {
                Console.WriteLine(contrat);
            }
            Console.WriteLine("Choose a contract : ");
            string contratRead = Console.ReadLine();

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"D:\Nathan\Documents\Polytech\SI4\S8\Serv.Oriented Computing\eiin839\TD3\REST_WS\Stations\bin\Debug\Stations.exe"; // Specify exe name.
            start.Arguments = contratRead;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine("Choose a station number: ");
            string stationIdRead = Console.ReadLine();

            ProcessStartInfo startNews = new ProcessStartInfo();
            startNews.FileName = @"D:\Nathan\Documents\Polytech\SI4\S8\Serv.Oriented Computing\eiin839\TD3\REST_WS\Stations_News\bin\Debug\Stations_News.exe"; // Specify exe name.
            startNews.Arguments = contratRead + " " + stationIdRead;
            startNews.UseShellExecute = false;
            startNews.RedirectStandardOutput = true;

            using (Process process = Process.Start(startNews))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }

            Console.ReadLine();
        }
    }

    class Contrat
    {
        public string name { get; set; }
        string commercial_name { get; set; }
        string[] cities { get; set; }
        string country_code { get; set; }

        public override string ToString()
        {
            return "Contrat: " + name;
        }
    }
}
