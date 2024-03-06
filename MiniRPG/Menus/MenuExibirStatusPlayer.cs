
using MiniRPG.ModelosPrincipais;

namespace MiniRPG.Menus;

internal class MenuExibirStatusPlayer : Menu
{
    public override void Menuu(Dictionary<string, Player> jogadorRegistrado)
    {
        base.Menuu(jogadorRegistrado);
        ExibicaoTexto("Status do jogador");
        Console.WriteLine();
        Thread.Sleep(1500);
        base.Menuu(jogadorRegistrado);

        Console.WriteLine("Informe o nome do jogador:");
        string nome = Console.ReadLine()!;
        Thread.Sleep(1500);
        base.Menuu(jogadorRegistrado);
        if (jogadorRegistrado.ContainsKey(nome))
        {
            Player player = jogadorRegistrado[nome];
            Console.WriteLine(player.Status);
            Console.WriteLine(player.XpAtual);

            Console.WriteLine("\nDigite qualquer tecla:");
            Console.ReadKey();

        }
        else
        {
            Console.WriteLine($"Jogador {nome} não existe!");
            Console.WriteLine("Digite qualquer tecla:");
            Console.ReadKey();
        }
   }
}
