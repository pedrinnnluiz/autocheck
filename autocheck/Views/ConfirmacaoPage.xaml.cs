using Microsoft.Maui.Controls;
using autocheck.Models;

namespace autocheck.Views
{
    [QueryProperty(nameof(Veiculo), "Veiculo")]
    [QueryProperty(nameof(Dias), "Dias")]
    [QueryProperty(nameof(Total), "Total")]
    [QueryProperty(nameof(ClienteNome), "ClienteNome")]
    [QueryProperty(nameof(Telefone), "Telefone")]
    public partial class ConfirmacaoPage : ContentPage
    {
        public VeiculoSelecionado Veiculo { get; set; }
        public double Dias { get; set; }
        public double Total { get; set; }

        public string ClienteNome { get; set; }
        public string Telefone { get; set; }

        public ConfirmacaoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NomeClienteLabel.Text = $"Cliente: {ClienteNome}";
            TelefoneLabel.Text = $"Telefone: {Telefone}";

            if (Veiculo != null)
            {
                NomeLabel.Text = $"Veículo: {Veiculo.Nome}";
                InicioLabel.Text = $"Dias de Aluguel: {Dias}";
                VeiculoLabel.Text = $"Preço por dia: R$ {Veiculo.Preco:0.00}";
                TotalLabel.Text = $"Total: R$ {Total:0.00}";
            }
        }

        private async void OnFinalizarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroPage());
        }
    }
}
