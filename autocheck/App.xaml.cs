using autocheck.Models;

using autocheck.Views;


namespace autocheck
{
    public partial class App : Application
    {


        public static DataBaseService Database { get; private set; }
        
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "autocheck.db2");
            Database = new DataBaseService(dbPath);
                
            MainPage = new NavigationPage(new LoginPage());

        }

    }
}