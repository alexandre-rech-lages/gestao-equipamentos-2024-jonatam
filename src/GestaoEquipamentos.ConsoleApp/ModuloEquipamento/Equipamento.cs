namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class Equipamento
    {
        private string nome, numeroSerie, fabricante, data;
        private double preco;

        public Equipamento(string nome, string numeroSerie, string fabricante, double preco, string data)
        {
            this.nome = nome;
            this.numeroSerie = numeroSerie;
            this.fabricante = fabricante;
            this.preco = preco;
            this.data = data;
        }

        public void MostrarEquipamento()
        {
            Console.WriteLine($"Nome: {nome}\nNumero de série: {numeroSerie}");
            Console.WriteLine($"Fabricante: {fabricante}\nData de fabricação: {data}");
            Console.WriteLine($"Preço: R${preco}");
            Console.WriteLine("------------------------");
        }

        public string RetornaNome()
        {
            return nome;
        }
    }
}
