
namespace MiniRPG.Menus;

using MiniRPG.Bancos;
using MiniRPG.ModelosPrincipais;

internal class MenuExit : Menu
{
    public override void Menuu(DAL<Player> playerDAL)
    {
        base.Menuu(playerDAL);

       ExibicaoTexto("Obrigado por jogar!");
        Console.WriteLine(":)");
 
    }
}
