using autocheck.Models;
using SQLite;

namespace autocheck.Views
{
    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
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

       
            if (!(EmailEntry.Text.Contains("@gmail.com") ||
                  EmailEntry.Text.Contains("@outlook.com") ||
                  EmailEntry.Text.Contains("@hotmail.com")))
            {
                await DisplayAlert("Erro", "O email precisa ser válido (@gmail, @outlook ou @hotmail).", "OK");
                return;
            }

           
            if (CpfEntry.Text.Length != 11 || !long.TryParse(CpfEntry.Text, out long cpfConvertido))
            {
                await DisplayAlert("Atenção", "O CPF deve conter 11 dígitos numéricos.", "OK");
                return;
            }

           
            if (SenhaEntry.Text.Length < 8)
            {
                await DisplayAlert("Erro", "A senha precisa ter ao menos 8 caracteres.", "OK");
                return;
            }

            if (TelefoneEntry.Text.Length < 11 ||
    !long.TryParse(TelefoneEntry.Text, out long telefoneConvertido))
            {
                await DisplayAlert("Erro", "O telefone deve conter 11 dígitos numéricos.", "OK");
                return;
            }


            var usuario = new Usuario
            {
                Nome = NomeEntry.Text,
                Telefone = telefoneConvertido,
                Cpf = cpfConvertido,
                Senha = SenhaEntry.Text,
                Email = EmailEntry.Text
            };

           
            await App.Database.SalvarUsuario(usuario);

          
            await Navigation.PushAsync(new SelecaoPage());
        }

        private async void Possuicadastro_Clicked(object sender, EventArgs e)
        {
            bool confirmar = await DisplayAlert("Já possui cadastro?", "Deseja prosseguir?", "Sim", "Não");
            if (confirmar)
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}