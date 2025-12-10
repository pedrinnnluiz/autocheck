namespace autocheck.Views;

public partial class PricesPage : ContentPage
{
    public PricesPage(string carro, decimal valor)
    {
        InitializeComponent();

        Titulo.Text = $"🚗 {carro}";
        NomeCarro.Text = carro;
        Preco.Text = $"R$ {valor:0.00}";
    }
}
