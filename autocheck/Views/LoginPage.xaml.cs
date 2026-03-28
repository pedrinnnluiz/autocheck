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
            // Valida se todos os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
                string.IsNullOrWhiteSpace(CpfEntry.Text) ||
                string.IsNullOrWhiteSpace(TelefoneEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(SenhaEntry.Text))
            {
                await DisplayAlert("Atenção", "Preencha todos os campos para continuar.", "OK");
                return;
            }

            // Valida email
            if (!(EmailEntry.Text.Contains("@gmail.com") ||
                  EmailEntry.Text.Contains("@outlook.com") ||
                  EmailEntry.Text.Contains("@hotmail.com")))
            {
                await DisplayAlert("Erro", "O email precisa ser válido (@gmail, @outlook ou @hotmail).", "OK");
                return;
            }

            // Valida CPF
            if (CpfEntry.Text.Length != 11 || !long.TryParse(CpfEntry.Text, out long cpfConvertido))
            {
                await DisplayAlert("Atenção", "O CPF deve conter 11 dígitos numéricos.", "OK");
                return;
            }

            // Valida senha
            if (SenhaEntry.Text.Length < 8)
            {
                await DisplayAlert("Erro", "A senha precisa ter ao menos 8 caracteres.", "OK");
                return;
            }

            // Valida telefone
            if (TelefoneEntry.Text.Length < 11)
            {
                await DisplayAlert("Erro", "O número de telefone deve ter DDD e 9 dígitos.", "OK");
                return;
            }
          
            
            var usuario = new Usuario
            {
                Nome = NomeEntry.Text,
                Telefone = TelefoneEntry.Text,
                Cpf = cpfConvertido,
                Senha = SenhaEntry.Text,
                Email = EmailEntry.Text
            };

            // Salva no banco
            await App.Database.SalvarUsuario(usuario);

            // Navega para próxima página
            await Navigation.PushAsync(new SelecaoPage());
        }

        private async void Possuicadastro_Clicked(object sender, EventArgs e)
        {
            bool confirmar = await DisplayAlert("Já possui cadastro?", "Deseja prosseguir?", "Sim", "Não");
            if (confirmar)
            {
              
            }
        }
    }
}