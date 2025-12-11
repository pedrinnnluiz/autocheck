namespace autocheck.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
                string.IsNullOrWhiteSpace(CpfEntry.Text) ||
                string.IsNullOrWhiteSpace(TelefoneEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(SenhaEntry.Text))
            {
                await DisplayAlert("Atenção", "Preencha todos os campos para continuar.", "OK");
                return;
            }

            await Shell.Current.GoToAsync(
     $"//SelecaoPage?ClienteNome={NomeEntry.Text}&Telefone={TelefoneEntry.Text}"
 );
        }
    }
}
