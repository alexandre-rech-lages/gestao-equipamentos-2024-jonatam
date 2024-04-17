namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class TelaCadastroEquipamento
    {
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

        public void ExcluirEquipamento()
        {
            if (repositorioEquipamento.ListaEstaVazia())
            {
                Console.WriteLine("O inventário não possui nenhum equipamento!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos\n");

            string nomeEquipamentoParaTrocar = ReceberInformacao("Informe o nome do equipamento a ser editado: ");

            if (repositorioEquipamento.EquipamentoExiste(nomeEquipamentoParaTrocar))
            {
                repositorioEquipamento.RemoverEquipamento(nomeEquipamentoParaTrocar);

                AvisoColorido("Equipamento removido com sucesso!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não existem um equipamento com esse nome!");
                Console.ReadKey();
            }
        }

        public void EditarEquipamento()
        {
            if (repositorioEquipamento.ListaEstaVazia())
            {
                Console.WriteLine("O inventário não possui nenhum equipamento!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos\n");

            string nomeEquipamentoParaTrocar = ReceberInformacao("Informe o nome do equipamento a ser editado: ");

            if (repositorioEquipamento.EquipamentoExiste(nomeEquipamentoParaTrocar))
            {
                Equipamento equipamento = ObterEquipamento();

                repositorioEquipamento.EditarEquipamento(nomeEquipamentoParaTrocar, equipamento);

                AvisoColorido("Equipamento modificado com sucesso!");
                
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não existem um equipamento com esse nome!");
                Console.ReadKey();
            }
        }

        public void MostrarEquipamentos()
        {
            if (repositorioEquipamento.ListaEstaVazia())
            {
                Console.WriteLine("O inventário não possui nenhum equipamento!");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos\n");

            repositorioEquipamento.MostrarEquipamentos();
            Console.ReadKey();
        }

        public void InserirEquipamento()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos\n");                      

            Equipamento equipamento = ObterEquipamento();

            if (repositorioEquipamento.EquipamentoExiste(equipamento.RetornaNome()))
            {
                Notificador.ApresentarMensagem("Já existe um equipamento com esse nome!", ConsoleColor.Red);
                return;
            }

            bool inseriu = repositorioEquipamento.InserirEquipamento(equipamento);

            if (inseriu)
                Notificador.ApresentarMensagem("Equipamento adicionado com sucesso!", ConsoleColor.Green);
        }

        private Equipamento ObterEquipamento()
        {
            string nomeEquipamento;

            while (true)
            {
                nomeEquipamento = ReceberInformacao("Informe o nome do equipamento: ");

                if (nomeEquipamento.Length > 6)                
                    break;                                    

                Notificador.ApresentarMensagem("O nome deve possuir ao menos 6 caracteres!", ConsoleColor.Red);
            }

            string numeroSerie = ReceberInformacao("Informe o número de série do equipamento: ");
            string fabricante = ReceberInformacao("Informe o nome do fabricante: ");
            double valorEquipamento = double.Parse(ReceberInformacao("Informe o preço do equipamento: "));
            string dataFabricacao = ReceberInformacao("Informe a data de fabricação do equipamento: ");

            Equipamento equipamento = new Equipamento(nomeEquipamento, numeroSerie, fabricante, valorEquipamento, dataFabricacao);

            return equipamento;
        }

        public int ApresentarSubmenu()
        {
            char opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos\n");

                Console.WriteLine(" 1 - Inserir novo equipamento");
                Console.WriteLine(" 2 - Visualizar equipamentos");
                Console.WriteLine(" 3 - Editar equipamentos");
                Console.WriteLine(" 4 - Excluir equipamentos");
                Console.WriteLine(" 0 - Sair\n");

                opcao = Console.ReadLine()[0];

                if (char.IsNumber(opcao))
                    break;

                Notificador.ApresentarMensagem("Apenas numeros são permitidos! Tente novamente!", ConsoleColor.Red);

            } while (true);

            return Convert.ToInt32(opcao);
        }

        public int ApresentarMenu()
        {
            char opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos\n");
                Console.WriteLine(" 1 - Cadastrar Equipamentos");
                Console.WriteLine(" 0 - Sair\n");

                Console.WriteLine("Informe a opção desejada: ");

                opcao = Console.ReadLine()[0];

                if (char.IsNumber(opcao))
                    break;

                Notificador.ApresentarMensagem("Apenas numeros são permitidos! Tente novamente!", ConsoleColor.Red);

            } while (true);

            return Convert.ToInt32(opcao);
        }

        private string ReceberInformacao(string textoApresentado)
        {
            string informacao = "";
            while (informacao.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos\n");
                Console.WriteLine(textoApresentado);
                informacao = Console.ReadLine();
            }

            return informacao;
        }

        private void AvisoColorido(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texto);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
