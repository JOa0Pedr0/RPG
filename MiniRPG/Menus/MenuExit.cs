
namespace MiniRPG.Menus;

using MiniRPG.ModelosPrincipais;

internal class MenuExit : Menu
{
    public override void Menuu(Dictionary<string,Player> jogadorRegistrado)
    {
        base.Menuu(jogadorRegistrado);

       ExibicaoTexto("Obrigado por jogar!");
        Console.WriteLine(":)");
 
    }
}
