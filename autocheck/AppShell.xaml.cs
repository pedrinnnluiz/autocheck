namespace autocheck
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

           
            Routing.RegisterRoute(nameof(Views.ConfirmacaoPage), typeof(Views.ConfirmacaoPage));
        }
    }
}
