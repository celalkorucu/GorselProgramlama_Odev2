using Gorsel_programalama_odev_iki.WeatherModel;
using System.Collections.ObjectModel;

namespace Gorsel_programalama_odev_iki;

public partial class Weather : ContentPage
{

    public ObservableCollection<CityWeather> ImageList { get; set; } = new ObservableCollection<CityWeather>();

    public Weather()
	{
		InitializeComponent();


        ImageCollection.ItemsSource = ImageList;
    }

    public void OnButtonClick(object sender, EventArgs e)
    {

        a();
     
    }

    public async Task a()
    {
        string sehir =await DisplayPromptAsync("Þehir:", "Þehir ismi", "OK", "Cancel");
        sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
        sehir = sehir.Replace('Ç', 'C');
        sehir = sehir.Replace('Ð', 'G');
        sehir = sehir.Replace('Ý', 'I');
        sehir = sehir.Replace('Ö', 'O');
        sehir = sehir.Replace('Ü', 'U');
        sehir = sehir.Replace('Þ', 'S');
        ImageList.Add(new CityWeather { Name = sehir });

        string src = new CityWeather { Name = sehir }.Source;

       Console.WriteLine(src);
    }


    private void ImageCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            string selectedImageUrl = e.CurrentSelection[0] as string;
            Console.WriteLine(selectedImageUrl);

            if (!string.IsNullOrEmpty(selectedImageUrl))
            {
                DisplayAlert("Seçilen Resim", $"Seçilen Resim: {selectedImageUrl}", "Tamam");
            }

            ImageCollection.SelectedItem = null;
        }
    }
}