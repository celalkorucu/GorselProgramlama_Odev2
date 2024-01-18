namespace Gorsel_programalama_odev_iki
{
    public partial class MainPage : ContentPage
    {
  

        public MainPage()
        {
            InitializeComponent();

            #region Menus
            //HOME
            var pageMainMenuItem = new ToolbarItem
            {
                
                IconImageSource = ImageSource.FromFile("home.png"),
                Text = "Ana sayfa",
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            pageMainMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MainPage());
            };

            ToolbarItems.Add(pageMainMenuItem);


            //NEWS
            var pageNewsMenuItem = new ToolbarItem
            {
                Text = "Haberler",
                IconImageSource = ImageSource.FromFile("news.png"),
                Order = ToolbarItemOrder.Primary,

                Priority = 1
            };

            pageNewsMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new News());
            };

            ToolbarItems.Add(pageNewsMenuItem);



            //RATE
            var pageRateMenuItem = new ToolbarItem
            {
                Text = "Kurlar",
                IconImageSource = ImageSource.FromFile("rates.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            pageRateMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Rate());
            };

            ToolbarItems.Add(pageRateMenuItem);


            //WEATHER
            var pageWeatherItem = new ToolbarItem
            {
                 Text = "Hava Durumu",
                IconImageSource = ImageSource.FromFile("weather.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            pageWeatherItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Weather());
            };

            ToolbarItems.Add(pageWeatherItem);


            //TODO
            var pageTodoMenuItem = new ToolbarItem
            {
                 Text = "Yapılacaklar",
                IconImageSource = ImageSource.FromFile("todo.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            pageTodoMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Todo());
            };

            ToolbarItems.Add(pageTodoMenuItem);


            //SETTING
            var pageSettingsMenuItem = new ToolbarItem
            {
                Text = "Ayarlar",
                IconImageSource = ImageSource.FromFile("settings.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            pageSettingsMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Settings());
            };

            ToolbarItems.Add(pageSettingsMenuItem);
            #endregion

        }
    }
}
