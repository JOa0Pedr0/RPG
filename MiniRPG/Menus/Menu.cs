
using MiniRPG.ModelosPrincipais;

namespace MiniRPG.Menus
{
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
        public virtual void Menuu(Dictionary<string, Player> jogadorRegistrado1)
        {
            Console.Clear();
        }
    }
}
