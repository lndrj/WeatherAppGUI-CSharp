using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WeatherApp_CSharpGUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public async void ShowWeatherButton_Click(object sender, RoutedEventArgs e)
    {
        ApiCall apiCall = new ApiCall();
        string city = CityTextBox.Text;
        WeatherInfo.Root? weatherInfo = await apiCall.WeatherDataAsync(city);
        
        
        
        if (weatherInfo != null)
        {
            double tempKelvin = weatherInfo.Main.Temp;
            double tempCelsius = tempKelvin - 273.15;
            
            TemperatureTextBlock.Text = $"{tempCelsius}°C";
            PressureTextBlock.Text = $"{weatherInfo.Main.Pressure} hPa";
            HumidityTextBlock.Text = $"{weatherInfo.Main.Humidity}%";
            SunriseTextBlock.Text = $"{UnixTimeStampToDateTime(weatherInfo.Sys.Sunrise)}";
            FeelsLikeTextBlock.Text = $"{weatherInfo.Main.FeelsLike}°C";
            WindSpeedTextBlock.Text = $"{weatherInfo.Wind.Speed} m/s";
            SunsetTextBlock.Text = $"{UnixTimeStampToDateTime(weatherInfo.Sys.Sunset)}";
        }
        else
        {
            TemperatureTextBlock.Text = "Chybně zadané město";
        }
    }

    private string UnixTimeStampToDateTime(long unixTimeStamp)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var dateTime = epoch.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime.ToString("HH:mm:ss");
    }
}