namespace autocheck.Models
{
    public class Carro
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }

        public string PrecoTexto => $"{Preco:C} / dia";
    }
}
