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

        try
        {
            WeatherInfo.Root? weatherInfo = await apiCall.WeatherDataAsync(city);

            if (weatherInfo != null)
            {
                double tempKelvin = weatherInfo.Main.Temp;
                double tempCelsius = tempKelvin - 273.15;

                TemperatureTextBlock.Text = $"{tempCelsius:F1}°C";
                PressureTextBlock.Text = $"{weatherInfo.Main.Pressure} hPa";
                HumidityTextBlock.Text = $"{weatherInfo.Main.Humidity}%";
                SunriseTextBlock.Text = $"{UnixTimeStampToDateTime(weatherInfo.Sys.Sunrise)}";
                SunsetTextBlock.Text = $"{UnixTimeStampToDateTime(weatherInfo.Sys.Sunset)}";
                WindSpeedTextBlock.Text = $"{weatherInfo.Wind.Speed} m/s";

                ErrorTextBlock.Text = "";
            }
            else
            {
                ErrorTextBlock.Text = "Chybně zadané město";
            }
        }

        catch (Exception exception)
        {
            ErrorTextBlock.Text = $"Špatně zadané město";
        }
    }

    private string UnixTimeStampToDateTime(long unixTimeStamp)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var dateTime = epoch.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime.ToString("HH:mm:ss");
    }
}