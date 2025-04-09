

using System.Threading.Tasks.Dataflow;

namespace MiniRPG.ModelosPrincipais;

internal class Player : ILevelUp
{
    public Player(string nome, int lvl = 1, int xp = 0, int gold = 0)
    {
        Nome = nome;
        Lvl = lvl;
        Xp = xp;
        Gold = gold;
        ContadorDeBatalhas = 0;
    }
    public List<string> Itens { get; set; } = new List<string>();
    public int Id { get; set; }
    public int ContadorDeBatalhas { get; set; } = 0;
    public int Gold { get; set; }
    public int Xp  { get; set; }
    public  string Nome { get; set; }
    public int Lvl { get; set; } = 1;
    public int Dmg { get; set; }
    public int Def { get; set; }
    public int Health { get; set; }

    public string? Classe { get; set; }
   
    public string Status => $"\nNome jogador: {Nome}\nNível atual: {Lvl}\nDano: {Dmg}\nDefesa:{Def}\nVida: {Health}\nOuro: {Gold}\nItens: {string.Join(",", Itens)}\nPartidas jogadas: {ContadorDeBatalhas}";
    public string Atributos => $"Dano: {Dmg}\nDefesa:{Def}\nVida: {Health}"; 
    public string XpAtual => $"Xp total = {Xp}";

    public void ExibirClasses()
    {
        Console.WriteLine("Classes Disponíveis:\n");
        Console.WriteLine("Mago\n - 50 DMG\n - 5 DEF\n - 30 HEALTH\n");
        Console.WriteLine("Guerreiro\n - 30 DMG\n - 50 DEF\n - 40 HEALTH\n");
        Console.WriteLine("Arqueiro\n - 45 DMG\n - 10 DEF\n - 25 HEALTH\n");
        Console.WriteLine("Curador\n - 25 DMG\n - 40 DEF\n - 50 HEALTH\n");
    }
    public void SelecaoDeClasse(string classe)
    { 
        Classe = classe;
        if (classe.Equals("Mago", StringComparison.OrdinalIgnoreCase))
        {
            Dmg = 50;
            Def = 5;
            Health = 30;

        }else if(classe.Equals("Guerreiro", StringComparison.OrdinalIgnoreCase))
        {
            Dmg = 30;
            Def = 50;
            Health = 60;
        }else if(classe.Equals("Arqueiro", StringComparison.OrdinalIgnoreCase))
        {
            Dmg = 45;
            Def = 10;
            Health = 25;


        }else if(classe.Equals("Curador",StringComparison.OrdinalIgnoreCase))
        {
            Dmg = 25;
            Def = 40; 
            Health = 50;
        }
        else
        {
            Console.WriteLine("Classe não existe");
            Dmg = 1; 
            Def = 1;
            Health = 1;
        }
    }
    public void ReceberItem()
    {
        Random sorteaItem = new Random();
        int sorteado = sorteaItem.Next(1, 4);
        switch (sorteado)
        {
           case 1:
                if (!Itens.Contains("Espada"))
                {
                    Console.WriteLine("Item recebido: espada!");
                    Itens.Add("Espada");
                    Dmg += 20;

                }
                else
                {
                    Console.WriteLine("Item já recebido");
                    Console.WriteLine("Item convertido em gold!");
                    Gold += 30;
                }
                break;

            case 2:
                if (!Itens.Contains("Armadura"))
                {
                    Console.WriteLine("Item recebido: armadura!");
                    Itens.Add("Armadura");
                    Def += 3;

                }
                else
                {
                    Console.WriteLine("Item já recebido");
                    Console.WriteLine("Item convertido em gold!");
                    Gold += 30;
                }
                break;
            case 3:
                if (!Itens.Contains("Colar Mágico"))
                {
                    Console.WriteLine("Item Recebido: colar mágico!");
                    Itens.Add("Colar Mágico");
                    Health += 10;

                }
                else
                {
                    Console.WriteLine("Item já recebido");
                    Console.WriteLine("Item convertido em gold!");
                    Gold += 30;
                }
                break;
            case 4:
                Gold += 10;
                break;
        }

    }
    public void Upar(Player player,Enemy enemy)
    {

        if (Xp >= 100)
        {
            Lvl += 1;
            Xp -= 100;

        }
    }
}
