
namespace MiniRPG.Menus;

using MiniRPG.Bancos;
using MiniRPG.ModelosPrincipais;
using System.Globalization;

internal class MenuBatalhar : Menu
{
    

    public override void Menuu(DAL<Player> playerDAL)
    {
        Console.Clear();
        //Por enquanto eu vou irei solicitar o nome do jogador para ele poder acessar as informações do registro 
        //Futuramente será o login do jogador 
        Console.WriteLine("Informe o nome do jogador:");
        string namePlayer = Console.ReadLine()!;
        base.Menuu(playerDAL);
        var playerInBattle = playerDAL.RecuperarPor(p => p.Nome.Equals(namePlayer));
        if(playerInBattle is not null)
        {
            Console.WriteLine("[1] - Normal Battle X [2] - Boss Battle X [3] - PVP");
            int resp = int.Parse(Console.ReadLine()!);
            base.Menuu(playerDAL);
            if (resp == 1)
            {
                ExibicaoTexto("NORMAL BATTLE");
                Enemy standardEnemy = new();
                Batalhas battle = new();
                battle.Batalhar(playerInBattle, standardEnemy);
                playerDAL.Atualizar(playerInBattle);
                Console.ReadKey();
                CleanScreem();
            }
            else if( resp == 2) 
            {
                ExibicaoTexto("BOSS BATTLE");
                Batalhas battle = new();
                battle.BossBattlle(playerInBattle);
                playerDAL.Atualizar(playerInBattle);
                CleanScreem();
            }else if (resp == 3)
            {
                ExibicaoTexto("PVP");
                Batalhas battle = new();
                Console.WriteLine("\nInforme o nome do segundo player");
                string namePlayer2 = Console.ReadLine()!;
                var player2 = playerDAL.RecuperarPor(p => p.Nome.Equals(namePlayer2));
                if (player2 is not null)
                {
                    if(player2.Nome != namePlayer2)
                    {
                        battle.Pvp(playerInBattle, player2);
                        playerDAL.Atualizar(playerInBattle);
                        playerDAL.Atualizar(player2);
                    }
                    else
                    {
                        base.Menuu(playerDAL);
                        Console.WriteLine($"O jogador {namePlayer} já está em batalha!");
                        Console.ReadKey();
                    }
                    

                }
                else
                {
                    base.Menuu(playerDAL);
                    Console.WriteLine($"O jogador {namePlayer2} não existe");
                    Console.ReadKey();
                    CleanScreem();
                }

            }
        }
        else
        {
            base.Menuu(playerDAL);
            Console.WriteLine($"O jogador {namePlayer} não existe!");
            Console.ReadKey();
        }


    }
}
