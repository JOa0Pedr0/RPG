
using MiniRPG.ModelosPrincipais;

namespace MiniRPG.Menus;

internal class MenuRegistrarPlayer : Menu
{
    public override void Menuu(Dictionary<string, Player> jogadorRegistrado)
        //transformar em um dicionario 
    {
        base.Menuu(jogadorRegistrado);
        ExibicaoTexto("Registro de jogador!");
        Thread.Sleep(1400);
        base.Menuu(jogadorRegistrado);
        Console.WriteLine("Insira o nome do seu personagem:");
        string namePlayer = Console.ReadLine()!;
        Player player = new (namePlayer);
        if (jogadorRegistrado.ContainsKey(namePlayer))
        {
            Console.WriteLine("Esse nome já foi escolhido, por favor informe outro:");
            Console.ReadKey();
        }
        else
        {
            jogadorRegistrado.Add(namePlayer, player);
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadKey();
            base.Menuu(jogadorRegistrado);
            Console.WriteLine($"Bem-Vindo ao MiniRPG {namePlayer}!");
            Thread.Sleep(1500);
            base.Menuu(jogadorRegistrado);
            Console.WriteLine("Agora escolha a sua classe:\n");
            player.ExibirClasses();
            string classeEscolhida = Console.ReadLine()!;
            base.Menuu(jogadorRegistrado);
            player.SelecaoDeClasse(classeEscolhida);
            Console.WriteLine($"Muito bem! Você escolheu a classe: {classeEscolhida}!\n");
            Console.WriteLine($"Seus atributos iniciais são: {player.Atributos}\n");
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadKey();
            base.Menuu(jogadorRegistrado);
            Console.WriteLine("Você vai evoluir durante as batalhas que enfrentará durante sua jornada!\n Boa sorte campeão.");
            Console.WriteLine("\nAperte qualquer tecla");
            Console.ReadKey();
        }
        

    }
}
