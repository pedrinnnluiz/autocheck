namespace autocheck.Views;

public partial class ConfirmacaoPage : ContentPage
{
    public ConfirmacaoPage(string nome, string inicio, string fim, string veiculo, string total)
    {
        InitializeComponent();

        NomeLabel.Text = $"Cliente: {nome}";
        InicioLabel.Text = $"Data Início: {inicio}";
        FimLabel.Text = $"Data Término: {fim}";
        VeiculoLabel.Text = $"Veículo: {veiculo}";
        TotalLabel.Text = $"Valor Total: {total}";
    }

    private async void OnFinalizarClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
