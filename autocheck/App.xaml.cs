namespace autocheck
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

         
            Shell.Current?.GoToAsync("//LoginPage");

            return window;
        }


    }
}