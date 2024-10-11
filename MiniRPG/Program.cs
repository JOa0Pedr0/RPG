using MiniRPG.Bancos;
using MiniRPG.Filtros;
using MiniRPG.Menus;
using MiniRPG.ModelosPrincipais;

MiniRPGContext context = new MiniRPGContext();
DAL<Player> playerDAL = new DAL<Player>(context);


void ExibirMenu()
{
    Console.Clear();
    Console.WriteLine("[1] Para registrar player");
    Console.WriteLine("[2] Para batalhar");
    Console.WriteLine("[3] Para exibir status atual do jogador");
    Console.WriteLine("[-1]Para sair do jogo");
    Console.WriteLine("[4] Para fazer buscas de jogadores:\n");
    Console.WriteLine("Digite o número relacionado a opção desejada:");
    int opcaoDigitada = int.Parse(Console.ReadLine()!);

    switch (opcaoDigitada)
    {

        case 1:
            Menu menu1 = new MenuRegistrarPlayer();
            menu1.Menuu(playerDAL);
            ExibirMenu();
            break;
        case 2:
            Menu menu2 = new MenuBatalhar();
            menu2.Menuu(playerDAL);
            ExibirMenu();
            break;

        case 3:
            Menu menu3 = new MenuExibirStatusPlayer();
            menu3.Menuu(playerDAL);
            ExibirMenu();
            break;

        case 4:
            LinqBuscas.BuscarJogadorPorLvl(playerDAL);
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
                menuExit.Menuu(playerDAL);
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
ExibirMenu();
















