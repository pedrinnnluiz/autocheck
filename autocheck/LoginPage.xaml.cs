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
			string.IsNullOrWhiteSpace(EmailEntry.Text)) {
			await DisplayAlert("Atenção", "Insira todos os campos para prosseguir", "Ok");
		}

		var usuario = await App.Database.LoginAsync(
			SenhaEntry.Text,
			EmailEntry.Text);

		if (usuario != null) {
			_usuarioLogado = usuario;

			await DisplayAlert("Sucesso", "Bem vindo", "Seguir");

			await Navigation.PushAsync(new SelecaoPage());

			}
		else
		{
			await DisplayAlert("Não foi possível efetuar login", "Dados inválidos,", "Voltar");

		}

	} 
}
