using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static WeatherStack.WeatherForecast;

namespace WeatherStack
{
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            // get the weather when app loads
            GetWeather();
        }

        private async void GetWeather()
        {
            // set the city name
            WeatherObject weather = await WeatherForecast.GetCurrentWeatherFromCityName("Parachute");
            //variable to hold image string
            var strimg = weather.current.weather_icons[0].ToString();
            // create bitmapimage object
            BitmapImage img = new BitmapImage(new Uri(strimg, UriKind.Absolute));

            try
            {
                LocationName.Text = "Location: " + weather.location.name;
                LocationRegion.Text ="State/Region:" + weather.location.region;
                CurrentTemp.Text = "Current Temp:" + weather.current.temperature.ToString();
                IMG.ImageSource = img;

            }
            catch (Exception)
            {
                LocationRegion.Text = "unable to get the weather";
            }
        }

    }
}
