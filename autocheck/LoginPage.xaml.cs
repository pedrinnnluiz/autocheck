using autocheck.Models;
using autocheck.Views;

namespace autocheck;

public partial class LoginPage : ContentPage
{
    private Usuario _usuarioLogado;

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SenhaEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Atenção", "Insira todos os campos para prosseguir", "Ok");
            return;
        }

        var usuario = await App.Database.LoginAsync(
            EmailEntry.Text,
            SenhaEntry.Text);

        if (usuario != null)
        {
            _usuarioLogado = usuario;

            Preferences.Set("UsuarioId", usuario.Id);

            await DisplayAlert("Sucesso", "Bem-vindo!", "Seguir");
    
             await Navigation.PushAsync(new SelecaoPage());
        }
        else
        {
            await DisplayAlert("Erro", "Email ou senha inválidos", "OK");
        }
    }
}