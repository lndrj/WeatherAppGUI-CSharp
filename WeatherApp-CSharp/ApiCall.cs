using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WeatherApp_CSharp;

public class ApiCall
{
    private string apiKey = "";
    private HttpClient client = new();

    public async Task<WeatherInfo.Root?> WeatherDataAsync(string city)
    {
        try
        {
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();

                WeatherInfo.Root weatherInfo = JsonConvert.DeserializeObject<WeatherInfo.Root>(jsonContent);
                
                return weatherInfo;
            }
            else
            {
                throw new Exception($"Chyba: {response.StatusCode}");
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Chyba exception: {e.Message}");

        }
    }
}
