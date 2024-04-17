using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaCadastroEquipamento telaEquipamento = new TelaCadastroEquipamento();

            while (true)
            {
                int menuPrincipal = telaEquipamento.ApresentarMenu();

                if (menuPrincipal == 0)
                    break;

                if (menuPrincipal != 1)
                {
                    Notificador.ApresentarMensagem("Função Indisponivel!", ConsoleColor.Red);
                    continue;
                }

                while (true)
                {
                    int menuSecundario = telaEquipamento.ApresentarSubmenu();

                    if (menuSecundario == 0)
                        break;

                    if (menuSecundario != 1 && menuSecundario != 2 && menuSecundario != 3 && menuSecundario != 4)
                    {
                        Notificador.ApresentarMensagem("Função Indisponivel!", ConsoleColor.Red);
                        continue;
                    }

                    if (menuSecundario == 1)
                        telaEquipamento.InserirEquipamento();

                    else if (menuSecundario == 2)
                        telaEquipamento.MostrarEquipamentos();

                    else if (menuSecundario == 3)
                        telaEquipamento.EditarEquipamento();

                    else if (menuSecundario == 4)
                        telaEquipamento.ExcluirEquipamento();
                }
            }
        }       
    }
}
