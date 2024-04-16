﻿namespace GestaoEquipamentos.ConsoleApp {
    internal class Program {
        static void Main(string[] args) {
            int menuPrincipal, menuSecundario;
            Equipamento equipamento;
            Inventario inventario = new Inventario();

            while (true) {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos\n");
                Console.WriteLine(" 1 - Cadastrar Equipamentos");
                Console.WriteLine(" 2 - Controle de chamados");
                Console.WriteLine(" 0 - Sair\n");

                Console.WriteLine("Informe a opção desejada: ");

                try {
                    menuPrincipal = int.Parse(Console.ReadLine());
                }
                catch (Exception ex) {
                    Console.WriteLine("Apenas numeros são permitidos! Tente novamente!");
                    Console.Clear();
                    continue;
                }

                switch (menuPrincipal) {
                    case 0: return;

                    case 1:
                        string nomeEquipamentoParaTrocar, nomeEquipamento, numeroSerie, fabricante, dataFabricacao;
                        double valorEquipamento;
                        while (true) {
                            Console.Clear();
                            Console.WriteLine("Gestão de Equipamentos\n");
                            Console.WriteLine(" 1 - Inserir novo equipamento");
                            Console.WriteLine(" 2 - Visualizar equipamentos");
                            Console.WriteLine(" 3 - Editar equipamentos");
                            Console.WriteLine(" 4 - Excluir equipamentos");
                            Console.WriteLine(" 0 - Sair\n");

                            try {
                                menuSecundario = int.Parse(Console.ReadLine());
                            }
                            catch (Exception ex) {
                                Console.WriteLine("Apenas numeros são permitidos! Tente novamente!");
                                Console.Clear();
                                continue;
                            }

                            switch (menuSecundario) {
                                case 1:

                                    Console.Clear();
                                    Console.WriteLine("Gestão de Equipamentos\n");

                                    nomeEquipamento = ReceberInformacao("Informe o nome do equipamento: ");

                                    if (nomeEquipamento.Length < 6) {
                                        Console.WriteLine("O nome deve possuir ao menos 6 caracteres!");
                                        Console.ReadKey();
                                        continue;
                                    }

                                    //Evita duplicação de equipamentos
                                    if (inventario.EquipamentoExiste(nomeEquipamento)) {
                                        Console.WriteLine("Já existe um equipamento com esse nome!");
                                        break;
                                    }

                                    numeroSerie = ReceberInformacao("Informe o numero de serie do equipamento: ");
                                    fabricante = ReceberInformacao("Informe o nome do fabricante: ");
                                    valorEquipamento = double.Parse(ReceberInformacao("Informe o preço do equipamento: "));
                                    dataFabricacao = ReceberInformacao("Informe a data de fabricação do equipamento: ");

                                    equipamento = new Equipamento(nomeEquipamento, numeroSerie, fabricante, valorEquipamento, dataFabricacao);

                                    inventario.InserirEquipamento(equipamento);
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    if (inventario.ListaEstaVazia()) {
                                        Console.WriteLine("O inventário não possui nenhum equipamento!");
                                        Console.ReadKey();
                                        break;
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Gestão de Equipamentos\n");

                                    inventario.MostrarEquipamentos();
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    if (inventario.ListaEstaVazia()) {
                                        Console.WriteLine("O inventário não possui nenhum equipamento!");
                                        Console.ReadKey();
                                        break;
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Gestão de Equipamentos\n");

                                    nomeEquipamentoParaTrocar = ReceberInformacao("Informe o nome do equipamento a ser editado: ");

                                    if (inventario.EquipamentoExiste(nomeEquipamentoParaTrocar)) {
                                        nomeEquipamento = ReceberInformacao("Informe o nome do equipamento: ");
                                        numeroSerie = ReceberInformacao("Informe o numero de serie do equipamento: ");
                                        fabricante = ReceberInformacao("Informe o nome do fabricante: ");
                                        valorEquipamento = double.Parse(ReceberInformacao("Informe o preço do equipamento: "));
                                        dataFabricacao = ReceberInformacao("Informe a data de fabricação do equipamento: ");

                                        equipamento = new Equipamento(nomeEquipamento, numeroSerie, fabricante, valorEquipamento, dataFabricacao);

                                        inventario.EditarEquipamento(nomeEquipamentoParaTrocar, equipamento);
                                        AvisoColorido("Equipamento modificado com sucesso!");
                                        Console.ReadKey();
                                    }
                                    else {
                                        Console.WriteLine("Não existem um equipamento com esse nome!");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 4:
                                    if (inventario.ListaEstaVazia()) {
                                        Console.WriteLine("O inventário não possui nenhum equipamento!");
                                        Console.ReadKey();
                                        break;
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Gestão de Equipamentos\n");

                                    nomeEquipamentoParaTrocar = ReceberInformacao("Informe o nome do equipamento a ser editado: ");

                                    if (inventario.EquipamentoExiste(nomeEquipamentoParaTrocar)) {
                                        inventario.RemoverEquipamento(nomeEquipamentoParaTrocar);

                                        AvisoColorido("Equipamento removido com sucesso!");
                                        Console.ReadKey();
                                    }
                                    else {
                                        Console.WriteLine("Não existem um equipamento com esse nome!");
                                        Console.ReadKey();
                                    }
                                    break;
                            }
                            if (menuSecundario == 0) {
                                break;
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Função Indisponivel!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static string ReceberInformacao(string textoApresentado) {
            string informacao = "";
            while (informacao.Length == 0) {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos\n");
                Console.WriteLine(textoApresentado);
                informacao = Console.ReadLine();
            }

            return informacao;
        }

        static void AvisoColorido(string texto) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texto);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
