
using MiniRPG.Bancos;
using MiniRPG.ModelosPrincipais;

namespace MiniRPG.Menus;

internal class MenuRegistrarPlayer : Menu
{
    public override void Menuu(DAL<Player> playerDAL)
        
    {
        base.Menuu(playerDAL);
        ExibicaoTexto("Registro de jogador!");
        Thread.Sleep(1400);
        base.Menuu(playerDAL);
        Console.WriteLine("Insira o nome do seu personagem:");
        string namePlayer = Console.ReadLine()!;
        var verificarPlayer = playerDAL.RecuperarPor(p => p.Nome.Equals(namePlayer));
        if (verificarPlayer is not null)
        {
            Console.WriteLine("Esse nome já foi escolhido, por favor informe outro:");
            Console.ReadKey();
        }
        else
        {
            Player newPlayer = new Player(namePlayer);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            base.Menuu(playerDAL);
            Console.WriteLine($"Bem-Vindo ao MiniRPG {namePlayer}!");
            Thread.Sleep(1500);
            base.Menuu(playerDAL);
            Console.WriteLine("Agora escolha a sua classe:\n");
            newPlayer.ExibirClasses();
            string classeEscolhida = Console.ReadLine()!;
            base.Menuu(playerDAL);
            newPlayer.SelecaoDeClasse(classeEscolhida);
            Console.WriteLine($"Muito bem! Você escolheu a classe: {classeEscolhida}!\n");
            Console.WriteLine($"Seus atributos iniciais são:\n {newPlayer.Atributos}");
            playerDAL.Adicionar(newPlayer);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            base.Menuu(playerDAL);
            Console.WriteLine("Você vai evoluir durante as batalhas durante sua jornada! Boa sorte campeão.");
            CleanScreem();
        }
        

    }
}
