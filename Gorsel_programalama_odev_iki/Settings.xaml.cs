namespace Gorsel_programalama_odev_iki;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();

	}


    private void DarkModeOnOff(object sender, ToggledEventArgs e)
    {
        if (e.Value)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}