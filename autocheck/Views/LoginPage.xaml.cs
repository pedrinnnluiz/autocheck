using autocheck.Models;

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
            var usuario = new Usuario
            {
                Senha = SenhaEntry.Text,
                Nome = NomeEntry.Text,
                Telefone = TelefoneEntry.Text,
            };
                await App.Database.SalvarUsuario(usuario);
                if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
                string.IsNullOrWhiteSpace(CpfEntry.Text) ||
                string.IsNullOrWhiteSpace(TelefoneEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(SenhaEntry.Text))
            {
                await DisplayAlert("Atenção", "Preencha todos os campos para continuar.", "OK");
                return;
            }

            if (!(EmailEntry.Text.Contains("@gmail.com") || EmailEntry.Text.Contains("@outlook.com") || EmailEntry.Text.Contains("@hotmail.com") ))
            {
                await DisplayAlert("Erro", "O email precisa ter @ endereçamento", "Ok");
                return;
            }

            if (SenhaEntry.Text.Length < 8)
            {
                await DisplayAlert("Erro", "A senha precisa ter ao menos 8 Caracteres", "OK");
                return;
            }   

            if (TelefoneEntry.Text.Length < 11)
            {
                await DisplayAlert("ERRO!", "O número de telefone deve ter DDD e os 9 números", "OK");
            }

            await Shell.Current.GoToAsync(
     $"//SelecaoPage?ClienteNome={NomeEntry.Text}&Telefone={TelefoneEntry.Text}"
 );
        }
    }
}
