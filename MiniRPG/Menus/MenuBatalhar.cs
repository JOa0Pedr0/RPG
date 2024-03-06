
namespace MiniRPG.Menus;

using MiniRPG.ModelosPrincipais;

internal class MenuBatalhar : Menu
{
    

    public override void Menuu(Dictionary<string, Player> jogadorRegistrado)
    {
        Console.Clear();
        //Por enquanto eu vou irei solicitar o nome do jogador para ele poder acessar as informações do registro 
        //Futuramente será o login do jogador 
        Console.WriteLine("Informe o nome do jogador:");
        string namePlayer = Console.ReadLine()!;
        Console.WriteLine("\nDigite qualquer tecla para continuar!");
        Console.ReadKey();
        base.Menuu(jogadorRegistrado);
        if (jogadorRegistrado.ContainsKey(namePlayer))
        {
            Console.WriteLine("[1] - Normal Battle X [2] - Boss Battle ");
            int resp = int.Parse(Console.ReadLine()!);
            base.Menuu(jogadorRegistrado);
            if (resp == 1)
            {
                ExibicaoTexto("Batalha Simples");
                Enemy standardEnemy = new();
                Batalhas battle = new();
                Player playerInBattle = jogadorRegistrado[namePlayer];
                battle.Batalhar(playerInBattle, standardEnemy);
                Console.WriteLine("\nDigite qualquer tecla para continuar!");
                Console.ReadKey();
            }
            else if( resp == 2) 
            {
                ExibicaoTexto("Batalha contra Chefe!");
                Player playerInBattle = jogadorRegistrado[namePlayer];
                Batalhas battle = new();
                battle.BossBattlle(playerInBattle);
                Console.WriteLine("\nDigite qualquer tecla para continuar!");
                Console.ReadKey();
            }
        }
        else
        {
            base.Menuu(jogadorRegistrado);
            Console.WriteLine($"O jogador {namePlayer} não existe!");
            Console.ReadKey();
        }


    }
}
