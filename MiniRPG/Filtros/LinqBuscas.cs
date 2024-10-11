using MiniRPG.Bancos;
using MiniRPG.ModelosPrincipais;
using System.Diagnostics.Contracts;
using System.Linq;
namespace MiniRPG.Filtros;

internal static class LinqBuscas
{
    public static void BuscarJogadorPorLvl(DAL<Player> playerDAL)
    {
        Console.Clear();
        Console.WriteLine("[1] - Para lista de jogadores por nível");
        Console.WriteLine("[2] - Buscar lista de jogadores por classe");
        int opcao = int.Parse(Console.ReadLine()!);
        Console.Clear();
        var listaTodosPlayers = playerDAL.Listar();
        switch (opcao)
        {
            case 1:
                
                Console.WriteLine("Digite o nível de jogadores que deseja buscar");
                int lvl = int.Parse(Console.ReadLine()!);
                var listaDePlayerPorLVL = playerDAL.ListarPor(p => p.Lvl.Equals(lvl));
                if (listaDePlayerPorLVL is null)
                {
                    Console.Clear();
                    Console.WriteLine("Essa lista se encotra vazia!");
                    Console.ReadKey();
                }
               
                else
                {
                    Console.Clear();
                    int quantidadeL = listaDePlayerPorLVL.Count();
                    Console.WriteLine($"{quantidadeL} resultado(s) encontrado(s)");
                    Console.WriteLine($"Aqui estão jogadores do nível {lvl}");
                   foreach(var playerLvl in listaDePlayerPorLVL)
                    {
                        Console.WriteLine($"\nPlayer: {playerLvl.Nome}\nClasse: {playerLvl.Classe}");
                    }
                    Console.ReadKey();
                }
                break;
            case 2:
               
                Console.WriteLine("Digite a classe de jogador que deseja filtrar");
                string classe = Console.ReadLine()!;
                if(classe != "Mago".ToLower() && classe != "Guerreiro".ToLower() && classe != "Arqueiro".ToLower() && classe != "Curador".ToLower())
                {
                    Console.WriteLine($"classe {classe} não existe!");
                    Console.ReadKey();
                }
                var listaDePlayerPorClasse = playerDAL.ListarPor(p => p.Classe.Equals(classe));
                int quantidadeC = listaDePlayerPorClasse.Count();
                Console.Clear();
                Console.WriteLine($"{quantidadeC} resultados encontrados");
                Console.WriteLine($"Lita de jogadores da classe {classe}:");
                if(listaDePlayerPorClasse is null)
                {
                    Console.WriteLine("");

                }
                else
                {
                    foreach(var playerClass in listaDePlayerPorClasse)
                    {
                        Console.WriteLine($"\nPlayer: {playerClass.Nome}\n Level: {playerClass.Lvl}");
                       
                    }
                }
                Console.ReadKey();
               
                break;

            default:
                Console.WriteLine("Opção inválida!");
                break;
        }


    }
    
}
