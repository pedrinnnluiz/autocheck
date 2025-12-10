using autocheck.Views;

namespace autocheck;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new LoginPage());
    }
}
