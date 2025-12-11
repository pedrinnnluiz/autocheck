namespace autocheck.Models
{
    public class VeiculoSelecionado
    {
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        public string Imagem { get; set; } = string.Empty;

        public string PrecoTexto => $"R$ {Preco:0.00} / dia";
    }
}
