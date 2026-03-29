using autocheck.Models;

namespace autocheck.Views;

public partial class PerfilPage : ContentPage
{
    private DataBaseService _db;

    public PerfilPage()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "autocheck.db3");
        _db = new DataBaseService(dbPath);

        CarregarDados();
    }

    private async void CarregarDados()
    {
        int usuarioId = Preferences.Get("UsuarioId", 0);

        if (usuarioId == 0)
        {
            await DisplayAlert("Erro", "Usuário não logado", "OK");
            return;
        }

        var usuario = await _db.GetUsuario(usuarioId);
        var locacoes = await _db.GetLocacoesByUsuario(usuarioId);

        if (usuario != null)
        {
            nomeLabel.Text = usuario.Nome;
            emailLabel.Text = usuario.Email;
            fotoPerfil.Source = usuario.foto;
        }

        locacoesList.ItemsSource = locacoes;
    }
}