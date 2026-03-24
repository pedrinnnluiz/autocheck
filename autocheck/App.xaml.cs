using autocheck.Models;

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
                 
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

         
            Shell.Current?.GoToAsync("//LoginPage");

            return window;
        }


    }
}