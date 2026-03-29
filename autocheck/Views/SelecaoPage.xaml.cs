using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using autocheck.Models;

namespace autocheck.Views
{
    [QueryProperty(nameof(ClienteNome), "ClienteNome")]
    [QueryProperty(nameof(Telefone), "Telefone")]
    public partial class SelecaoPage : ContentPage
    {
      
        public string ClienteNome { get; set; }
        public string Telefone { get; set; }

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

            DataInicioPicker.Date = DateTime.Today;
            DataFimPicker.Date = DateTime.Today;

            DataInicioPicker.DateSelected += OnDateChanged;
            DataFimPicker.DateSelected += OnDateChanged;
        }

        private void CarrosView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            veiculoAtual = e.CurrentSelection.FirstOrDefault() as VeiculoSelecionado;

            if (veiculoAtual != null)
                valorDiaria = veiculoAtual.Preco;

            AtualizarDiasETotal();
        }

        private void OnDateChanged(object sender, DateChangedEventArgs e)
        {
            AtualizarDiasETotal();
        }

        private void AtualizarDiasETotal()
        {
            if (DataFimPicker.Date < DataInicioPicker.Date)
            {
                DiasLabel.Text = "Datas inválidas";
                TotalLabel.Text = "R$ 0,00";
                return;
            }

            int dias = (DataFimPicker.Date - DataInicioPicker.Date).Days + 1;
            DiasLabel.Text = dias + (dias == 1 ? " dia" : " dias");

            if (veiculoAtual == null)
            {
                TotalLabel.Text = "R$ 0,00";
                return;
            }

            double total = veiculoAtual.Preco * dias;
            TotalLabel.Text = $"R$ {total:0.00}";
        }

        private async void OnConfirmarClicked(object sender, EventArgs e)
        {
            if (veiculoAtual == null)
            {
                await DisplayAlert("Aviso", "Selecione um veículo!", "OK");
                return;
            }

            var parameters = new Dictionary<string, object>
            {
                { "Veiculo", veiculoAtual },
                { "Dias", (DataFimPicker.Date - DataInicioPicker.Date).Days + 1 },
                { "Total", veiculoAtual.Preco * ((DataFimPicker.Date - DataInicioPicker.Date).Days + 1) },

              
                { "ClienteNome", ClienteNome },
                { "Telefone", Telefone }
            };

            await Navigation.PushAsync(new ConfirmacaoPage());
        }
    }
}
