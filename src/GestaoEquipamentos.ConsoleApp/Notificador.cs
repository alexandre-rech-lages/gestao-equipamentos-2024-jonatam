namespace GestaoEquipamentos.ConsoleApp
{
    public class Notificador
    {
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ReadKey();
            Console.ResetColor();
        }
    }
}
