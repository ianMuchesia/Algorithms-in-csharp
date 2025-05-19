

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace DataStructuresAlgorithms.location
{public class IPLocationFinder
{
    public async Task<string> GetIPLocation(string ipAddress)
    {
        string apiUrl = $"https://ipapi.co/{ipAddress}/json/";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                    {
                        JsonElement root = doc.RootElement;

                        string city = root.GetProperty("city").GetString();
                        string region = root.GetProperty("region").GetString();
                        string country = root.GetProperty("country_name").GetString();
                        string latitude = root.GetProperty("latitude").GetString();
                        string longitude = root.GetProperty("longitude").GetString();

                        return $"Location: {city}, {region}, {country}\nCoordinates: {latitude}, {longitude}";
                    }
                }
                else
                {
                    return $"Error: Unable to retrieve location. Status code: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }

    // Example usage
    public static async Task Main(string[] args)
    {
        IPLocationFinder finder = new IPLocationFinder();
        string result = await finder.GetIPLocation("8.8.8.8"); // Example IP (Google's DNS)
        Console.WriteLine(result);
    }
}
}

