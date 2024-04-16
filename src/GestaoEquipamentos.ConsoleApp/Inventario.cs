namespace GestaoEquipamentos.ConsoleApp {
    internal class Inventario {
        private Equipamento[] ListaEquipamentos;

        public Inventario() {
            ListaEquipamentos = new Equipamento[20];
        }
        private bool ListaEstaVazia() {
            int contador = 0;
            for (int i = 0; i < ListaEquipamentos.Length; i++) {
                if (ListaEquipamentos[i] is not null) contador++;
            }
            return contador == 0;
        }
        public void InserirEquipamento(Equipamento equipamento) {
            for (int i = 0; i < ListaEquipamentos.Length; i++) {
                if (ListaEquipamentos[i] is null) {
                    ListaEquipamentos[i] = equipamento;

                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Equipamento adicionado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MostrarEquipamentos() {
            if (ListaEstaVazia()) {
                Console.WriteLine("O inventário não possui nenhum equipamento!");
                return;
            }
            for (int i = 0; i < ListaEquipamentos.Length; i++) {
                ListaEquipamentos[i].MostrarEquipamento();
            }
        }

        public void EditarEquipamento(string nomeEquipamento, Equipamento novoEquipamento) {
            if (ListaEstaVazia()) {
                Console.WriteLine("O inventário não possui nenhum equipamento!");
                return;
            }
            for (int i = 0; i < ListaEquipamentos.Length; i++) {
                if (ListaEquipamentos[i].RetornaNome() == nomeEquipamento) {
                    ListaEquipamentos[i] = novoEquipamento;
                }
            }
        }

        public void RemoverEquipamento(string nomeEquipamento) {
            if (ListaEstaVazia()) {
                Console.WriteLine("O inventário não possui nenhum equipamento!");
                return;
            }
            for (int i = 0; i < ListaEquipamentos.Length; i++) {
                if (ListaEquipamentos[i].RetornaNome() == nomeEquipamento) {
                    ListaEquipamentos[i] = null;
                }
            }
        }
        public bool EquipamentoExiste(string nomeEquipamento) {
            for (int i = 0; i < ListaEquipamentos.Length; i++) {
                if (ListaEquipamentos[i].RetornaNome() == nomeEquipamento) {
                    return true;
                }
            }
            return false;
        }
    }
}
