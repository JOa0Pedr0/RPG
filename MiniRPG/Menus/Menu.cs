
using MiniRPG.Bancos;
using MiniRPG.ModelosPrincipais;

namespace MiniRPG.Menus;

internal class Menu
{
    public void ExibicaoTexto(string Txt)
    {
        int quantLetras = Txt.Length;
        string letra = string.Empty.PadLeft(quantLetras, '*');
        Console.WriteLine(letra);
        Console.WriteLine(Txt);
        Console.WriteLine(letra);
    }
    public virtual void Menuu(DAL<Player> playerDAL)
    {
        Console.Clear();
    }
    public void CleanScreem()
    {
        Console.Clear();
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }
}
