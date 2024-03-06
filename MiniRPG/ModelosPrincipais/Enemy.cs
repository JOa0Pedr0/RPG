
namespace MiniRPG.ModelosPrincipais
{
    internal class Enemy
    {
        public Enemy(int dmg = 7, int def = 5, int health = 150 , string nome = "Inimigo básico", int lvl = 1)
        {
            Dmg = dmg;
            Def = def;
            Health = health;
            Nome = nome;
            Lvl = lvl;
        }
        public int Lvl { get; set; }
        public string Nome { get; set; }
        public int Dmg { get; set; }
        public int Def { get; set; }
        public int Health { get; set; }

    }
}
