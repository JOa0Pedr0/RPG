using MiniRPG.Menus;
using MiniRPG.ModelosPrincipais;
using System.Net.Http.Headers;
using System.Security.Cryptography;

Dictionary<string, Player> jogadorRegistrado = new();
Enemy enemy = new();
//possivelmente eu terei que jogar essas informações do meu player em um dicionario para que eu possa 
//acessa-lo em outros métodos 
//tentar fazer uma classe itens com venda de itens para aumentar os atributos do meu player
//aumentar a dificuldade do inimigo 
void ExibirMenu()
{
    Console.Clear();
    Console.WriteLine("[1] Para registrar player");
    Console.WriteLine("[2] Para batalhar");
    Console.WriteLine("[3] Para exibir status atual do jogador");
    Console.WriteLine("[-1]Para sair do jogo\n");

    Console.WriteLine("Digite o número relacionado a opção desejada:");
    int opcaoDigitada = int.Parse(Console.ReadLine()!);

    switch (opcaoDigitada)
    {
        case 1:
            Menu menu1 = new MenuRegistrarPlayer();
            menu1.Menuu(jogadorRegistrado);
            ExibirMenu();
            break;
        case 2:
            Menu menu2 = new MenuBatalhar();
            menu2.Menuu(jogadorRegistrado);
            ExibirMenu();
            break;

        case 3:
            Menu menu3 = new MenuExibirStatusPlayer();
            menu3.Menuu(jogadorRegistrado);
            ExibirMenu();
            break;
        case -1:
            Menu menuExit = new MenuExit();
            Console.Clear();
            Console.WriteLine("Ao escolher essa opção você perderá todo o seu progresso!");
            Console.WriteLine("Tem certeza que deseja sair? [S/N]:");
            string resp = Console.ReadLine()!;
            if (resp == "S")
            {
                menuExit.Menuu(jogadorRegistrado);
            }
            else if (resp == "N")
            {
                Console.WriteLine("Voltando para o menu principal...");
                Thread.Sleep(1000);
                ExibirMenu();
            }
            break;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}
//ExibirMenu();
Player p1 = new Player("jp");
Player p2 = new Player("kllr");
p1.SelecaoDeClasse("Mago");
p2.SelecaoDeClasse("Guerreiro");

Console.WriteLine(p1.Status);
Console.WriteLine("---------");
Console.WriteLine(p2.Status);

Batalhas b1 = new Batalhas();

b1.Pvp(p1, p2);















