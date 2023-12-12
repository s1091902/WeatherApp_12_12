//using AudioToolbox;
using WeatherApp.Services;


namespace WeatherApp;



public partial class WeatherPage : ContentPage
{

    public List<Models.List> WeatherList;
    public WeatherPage()
	{
		InitializeComponent();
		WeatherList = new List<Models.List>();	
	}

   

    protected async override void OnAppearing()
	{
		base.OnAppearing();
		var result = await ApiService.GetWeather(24.1469,123.6839);
		
		foreach (var item in result.list)
		{
			WeatherList.Add(item);
		}

		CvWeather.ItemsSource = WeatherList;

		lblCity.Text = result.city.name;
		weatherDescription.Text = result.list[0].weather[0].description;
		LblTemperature.Text = result.list[0].main.tempertuare + "C";
		LblHumidity.Text = result.list[0].main.humidity + "%";
		LblWind.Text = result.list[0].wind.speed + "km/h";
	}


}