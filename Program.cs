

using WeatherApp_CSharp;

ApiCall apiCall = new ApiCall();

try
{
    string city = "prague";
    WeatherInfo.Root? weatherInfo = await apiCall.WeatherDataAsync(city);

    double tempKelvin = weatherInfo.Main.Temp;
    double tempCelsius = tempKelvin - 273.15;
    DateTime currentTime = DateTime.Now;
    
    Console.WriteLine($"Aktuální čas: {currentTime.ToString("HH:mm:ss")}\n");
    
    Console.WriteLine($"Teplota: {tempCelsius:N1}°C");
    Console.WriteLine($"Vlhkost: {weatherInfo.Main.Humidity}");
    Console.WriteLine($"Vlhkost: {weatherInfo.Weather[0].Main}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


