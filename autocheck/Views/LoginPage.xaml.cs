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
            if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
                string.IsNullOrWhiteSpace(CpfEntry.Text) ||
                string.IsNullOrWhiteSpace(TelefoneEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(SenhaEntry.Text))
            {
                await DisplayAlert("Atenção", "Preencha todos os campos para continuar.", "OK");
                return;
            }

            int clienteId;

            if (!int.TryParse(CpfEntry.Text, out clienteId))
            {
                await DisplayAlert("Erro", "Digite um número válido", "OK");
                return;
            } 
            var usuario = new Usuario
            {
                Nome = NomeEntry.Text,
                Telefone = TelefoneEntry.Text,
                Cpf = CpfEntry.Text,
                Senha = SenhaEntry.Text,
                Email = EmailEntry.Text,

               
            };
            await Shell.Current.GoToAsync(
     $"//SelecaoPage?ClienteNome={NomeEntry.Text}&Telefone={TelefoneEntry.Text}"
 );
        }

        private async void Possuicadastro_Clicked(object sender, EventArgs e)
        {
            bool confirmar = await DisplayAlert("Confirmar", "Tem certeza de que deseja excluir sua conta", "sim", "nao");

            if (confirmar) {
                await db.DeletarUsuario(usuario.id);
        } }

    }
}
