
using MiniRPG.Bancos;
using MiniRPG.ModelosPrincipais;

namespace MiniRPG.Menus;

internal class MenuExibirStatusPlayer : Menu
{
    public override void Menuu(DAL<Player> playerDAL)
    {
        base.Menuu(playerDAL);
        ExibicaoTexto("Status do jogador");
        Console.WriteLine();
        Thread.Sleep(1500);
        base.Menuu(playerDAL);

        Console.WriteLine("Informe o nome do jogador:");
        string namePlayer = Console.ReadLine()!;
        Thread.Sleep(1500);
        base.Menuu(playerDAL);
        var jogadorBuscado = playerDAL.RecuperarPor(p => p.Nome.Equals(namePlayer));
        if (jogadorBuscado is not null)
        {
            Console.WriteLine(jogadorBuscado.Status);
            Console.WriteLine(jogadorBuscado.XpAtual);

            Console.WriteLine("\nDigite qualquer tecla:");
            Console.ReadKey();

        }
        else
        {
            Console.WriteLine($"Jogador {namePlayer} não existe!");
            Console.WriteLine("Digite qualquer tecla:");
            Console.ReadKey();
        }
   }
}
