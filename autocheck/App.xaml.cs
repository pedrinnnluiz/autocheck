using autocheck.Models;
using autocheck.Views;

namespace autocheck
{
    public partial class App : Application
    {
        public static DataBaseService DataBase { get; private set; }
        //Criação do encapsulamento da classe onde o DB estará
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(
               FileSystem.AppDataDirectory,
               "autocheck.db4");

            // O nome onde está localizado o banco de dados está combinado no diretório APPDataDirectiory

            DataBase = new DataBaseService(dbPath);

            MainPage = new NavigationPage(new LoginPage());
        }

    }
}