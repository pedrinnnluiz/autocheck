using System.Collections.ObjectModel;

namespace autocheck.Views;

public partial class SelecaoPage : ContentPage
{
    double valorDiaria = 0;
    VeiculoSelecionado veiculoAtual;

    public ObservableCollection<VeiculoSelecionado> Veiculos { get; set; }

    public SelecaoPage()
    {
        InitializeComponent();

        Veiculos = new ObservableCollection<VeiculoSelecionado>
        {
            new VeiculoSelecionado { Nome = "Fiat Argo", Preco = 100, Imagem = "argo.jpg" },
            new VeiculoSelecionado { Nome = "Chevrolet Onix", Preco = 120, Imagem = "onix.jpg" },
            new VeiculoSelecionado { Nome = "Toyota Corolla", Preco = 200, Imagem = "corolla.jpg" },
            new VeiculoSelecionado { Nome = "Hyundai HB20", Preco = 110, Imagem = "hb20.jpg" },
            new VeiculoSelecionado { Nome = "Honda Civic", Preco = 230, Imagem = "civic.jpg" },
            new VeiculoSelecionado { Nome = "Jeep Renegade", Preco = 250, Imagem = "renegade.jpg" },
            new VeiculoSelecionado { Nome = "Hyundai Creta", Preco = 240, Imagem = "creta.jpg" },
            new VeiculoSelecionado { Nome = "Jeep Compass", Preco = 280, Imagem = "compass.jpg" }
        };

        CarrosView.ItemsSource = Veiculos;
        CarrosView.SelectionChanged += CarrosView_SelectionChanged;
        DiasStepper.ValueChanged += AtualizarTotal;
    }

    private void CarrosView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        veiculoAtual = e.CurrentSelection.FirstOrDefault() as VeiculoSelecionado;

        if (veiculoAtual != null)
            valorDiaria = veiculoAtual.Preco;

        AtualizarTotal(null, null);
    }

    void AtualizarTotal(object sender, EventArgs e)
    {
        if (veiculoAtual == null)
            return;

        DiasLabel.Text = $"{DiasStepper.Value} dias";
        double total = valorDiaria * DiasStepper.Value;
        TotalLabel.Text = $"R$ {total:0.00}";
    }

    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        if (veiculoAtual == null)
        {
            await DisplayAlert("Erro", "Selecione um veículo!", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
            string.IsNullOrWhiteSpace(CpfEntry.Text) ||
            string.IsNullOrWhiteSpace(TelefoneEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Atenção", "Preencha todos os dados do cliente.", "OK");
            return;
        }

        string nome = NomeEntry.Text;
        string cpf = CpfEntry.Text;
        string telefone = TelefoneEntry.Text;
        string email = EmailEntry.Text;

        string veiculo = veiculoAtual.Nome;
        string inicio = InicioPicker.Date.ToString("dd/MM/yyyy");
        DateTime termino = InicioPicker.Date.AddDays(DiasStepper.Value);
        string fim = termino.ToString("dd/MM/yyyy");
        string total = TotalLabel.Text;

        await Navigation.PushAsync(
            new ConfirmacaoPage(nome, cpf, telefone, email, inicio, fim, veiculo, total)
        );
    }
}

public class VeiculoSelecionado
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Imagem { get; set; }

    public string PrecoTexto => $"R$ {Preco:0.00} / dia";
}
