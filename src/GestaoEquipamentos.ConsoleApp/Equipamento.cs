namespace GestaoEquipamentos.ConsoleApp {
    internal class Equipamento {
        private string nome, numeroSerie, fabricante, data;
        private double preco;

        public Equipamento(string nome, string numeroSerie, string fabricante, double preco, string data) {
            if (nome.Length < 6) {
                Console.WriteLine("Nome deve possuir no minimo 6 caracteres.");
                return;
            }
            this.nome = nome;
            this.numeroSerie = numeroSerie;
            this.fabricante = fabricante;
            this.preco = preco;
            this.data = data;
        }

    }
}
