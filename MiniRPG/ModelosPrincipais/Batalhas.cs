
using MiniRPG.Bancos;

namespace MiniRPG.ModelosPrincipais;

internal  class Batalhas : ILevelUp
{
    public void Batalhar(Player p1, Enemy enemy)
    {
        int danoMinimo = 1;
        Console.WriteLine($"{p1.Nome} está entrando em combate!");
        p1.ContadorDeBatalhas++;
        if(p1.Lvl > 5 && p1.Lvl <= 9)
        {
            enemy.Dmg *= 2;
            enemy.Health *= 2;
            enemy.Def *= 2;
            danoMinimo = enemy.Dmg / 2;
        }else if (p1.Lvl < 10 && p1.Lvl <= 14)
        {
            enemy.Dmg *= 3;
            enemy.Health *= 3;
            enemy.Def *= 3;
            danoMinimo = enemy.Dmg / 3;
        }else if( p1.Lvl > 15)
        {
            enemy.Dmg *= 4;
            enemy.Health *= 4;
            enemy.Def *= 4;
            danoMinimo = enemy.Dmg;
        }
        int resLife = p1.Health;
        int resLifeEnemy = enemy.Health;
        int totalDamage = 0;
        int totalDamageEnemy = 0;
        Random randDmgPlayer = new Random();
        Random randDmgEnemy = new Random();
        List<string> itensGanhos = new();

        Console.WriteLine("Inciando a Batalha...\n");
        Console.WriteLine(enemy.Dmg);


        while (enemy.Health >0 || p1.Health >0)
        {
            int dmgRoundPlayer = randDmgPlayer.Next(1, p1.Dmg);
            Thread.Sleep(1400);
            Console.WriteLine($"Player Turn: {dmgRoundPlayer}");
            int dmgEnemyRound = randDmgEnemy.Next(danoMinimo, enemy.Dmg);
            if(dmgEnemyRound == p1.Def)
            {
                dmgEnemyRound = 0;
                Thread.Sleep(1400);
                Console.WriteLine(" Enemy: Miss!\n");

                p1.Health -= dmgEnemyRound;
            }
            else
            {
                Thread.Sleep(1400);
                Console.WriteLine($"Enemy Turn: {dmgEnemyRound}\n");

                p1.Health -= dmgEnemyRound;
                enemy.Health -= dmgRoundPlayer ;

            }
            Console.WriteLine($"Vida turno jogador {p1.Health}");
            totalDamage += dmgRoundPlayer;
            totalDamageEnemy += dmgEnemyRound;
            if(enemy.Health < 0)
            {
                break;
            }else if(p1.Health < 0)
            {
                break;
            }

        }
        Console.WriteLine();
        for (int life = 0; life < p1.Health; life++)
            {
               Console.Write("|");
            }
        if (enemy.Health <= 0)
        {
            enemy.Health = resLifeEnemy;

            Console.WriteLine("\nVitória do jogador!");
            p1.Health = resLife;

           
            p1.ReceberItem();
            //no final de uma partida o jogador irá receber algum item, podendo ser ouro ou arma[OK] :
            //criar uma lista na classe player e adicionar assim que o jogador ganhar[OK]
            //usar o metodo random e atribuir um numero para ser item (ex 2) e outro para ouro(ex 1) fazendo com que sendo um dos dois ele irá receber o refernte[OK]
            //criar uma funcao na classe Player que  exiba meu inventário [ainda n feito]
            //quando criar ganhar um item tenho que add o player e o item na lista? ou só o item na minha lista??[não, pois só foi preciso criar uma lista na classe Player e adicionar os Itens na lista]
            //o ouro vai ser um atributo da classe Player sendo usado numa futura classe de vendas de Itens ou poder
            Console.WriteLine($"Dano causado na partida: [{totalDamage}]");
            Console.WriteLine($"Dano recebido na partida: [{totalDamageEnemy}]");
            p1.Xp += 30;
            totalDamage = 0;
            if (p1.Xp >= 100)
            {
                Upar(p1,enemy);
            }
        }
         if(p1.Health <= 0) 
        {
            Console.WriteLine("\nVocê foi derrotado!");
            p1.Health = resLife;
            Console.WriteLine($"Dano causado na partida: [{totalDamage}]");
            Console.WriteLine($"Dano recebido na partida: [{totalDamageEnemy}]");
        }


        //caso o player vença, ele irá receber uma quantia de xp [feito]
    }
    public void BossBattlle(Player p1)
    {
        if(p1.Lvl >= 10)
        {
            int resPlayerLife = p1.Health;
            Random randDmgPlayer = new Random();
            Random randDmgEnemy = new Random();
            int danoTotalPlayer = 0;
            int danoTotalInimigo = 0;

            Console.WriteLine("Você está entrando em uma área de risco!");
            Console.WriteLine("Você perderá 60 pontos de XP caso seja derrotado!");
            Console.WriteLine("\nDigite qualquer tecla para continuar!");
            Console.ReadKey();
            Console.Clear();
            Enemy boss = new();
            boss.Dmg += 2*p1.Lvl  ; 
            boss.Health *= 2;
            int resBossLife = boss.Health;
            Console.WriteLine("Iniciando combate...");

            while (boss.Health > 0 &&  p1.Health > 0)
            {
                int dmgPlayerTurn = randDmgPlayer.Next(p1.Dmg/2, p1.Dmg);
                int dmgEnemyTurn = randDmgEnemy.Next(boss.Dmg / 2, boss.Dmg);

                if(boss.Dmg == p1.Def || p1.Dmg == boss.Dmg)
                {
                    dmgEnemyTurn = 0;
                    Console.WriteLine("Enemy turn: Miss!");
                    Thread.Sleep(1400);
                    dmgPlayerTurn = 0;
                    Console.WriteLine("Player turn: Miss!");
                }
                else
                {
                    Console.WriteLine($"Player turn: {dmgPlayerTurn}");
                    Thread.Sleep(1400);
                    Console.WriteLine($"Enemy turn: {dmgEnemyTurn}");
                }

                boss.Health -= dmgPlayerTurn;
                p1.Health -= dmgEnemyTurn;

                danoTotalInimigo += dmgEnemyTurn;
                danoTotalPlayer += dmgPlayerTurn;
                
            }
            for (int life = 0; life < p1.Health; life++)
            {
                Console.Write("|");
            }
            if(boss.Health <= 0)
            {
                p1.Health = resPlayerLife;
                boss.Health = resBossLife;
                Console.WriteLine("Vitória do jogador!");
                p1.Xp += 80;
                if (p1.Xp >= 100)
                {
                    Upar(p1, boss);
                }
                //receber um item novo para aumentar os atributos do jodor!

                Console.WriteLine($"Dano causado: {danoTotalPlayer}");
                Console.WriteLine($"Dano recebido: {danoTotalInimigo}");
            }
            else if (p1.Health <= 0)
            {
                Console.WriteLine("Você foi derrotado!");
                p1.Xp -= 60;
                p1.Health = resPlayerLife;
                boss.Health = resBossLife;
            }
            
        }
        else
        {
            Console.WriteLine("Você ainda não está apto para acessar esse modo!\n");
            Console.WriteLine("Volte quando estiver mais forte");
            Thread.Sleep(1600);
            Console.Clear();

        }

    }

    public void Pvp(Player p1, Player p2)
    {
      
        Console.WriteLine($"{p1.Nome} VS {p2.Nome}");

        int respP1Life = p1.Health;
        int respP2Life = p2.Health;

        int totalP1Damage = 0;
        int totalP2Damage = 0;

        Random randomP1Dmg = new Random();
        Random randomP2Dmg = new Random();

        while(p1.Health >= 0 || p2.Health >= 0)
        {
            int dmgP1Turn = randomP1Dmg.Next(p1.Dmg / 2, p1.Dmg);
            int dmgP2Turn = randomP2Dmg.Next(p2.Dmg / 2, p2.Dmg);
            if(dmgP2Turn == p1.Def || dmgP1Turn == p2.Def)
            {
                dmgP1Turn = 0;
                dmgP2Turn = 0;
                Console.WriteLine($"{p1.Nome} Damage turn: Miss!");
                Thread.Sleep(1400);
                Console.WriteLine($"{p2.Nome} Damage turn: Miss!\n");

            }
            else
            {
                Console.WriteLine($"{p1.Nome} Damage turn: {dmgP1Turn}");
                Thread.Sleep(1400);
                Console.WriteLine($"{p2.Nome} Damage turn: {dmgP2Turn}\n");
            }
            Console.WriteLine($"Vida {p1.Nome}: {p1.Health}");
            Console.WriteLine($"Vida {p2.Nome}: {p2.Health}\n");

            totalP1Damage += dmgP1Turn;
            totalP2Damage += dmgP2Turn;

            p1.Health -= dmgP2Turn;
            p2.Health -= dmgP1Turn;

            if (p1.Health < p2.Health )
            {
                Console.WriteLine($"\nVitória de {p2.Nome}!");

            }
            else 
            {
                Console.WriteLine($"\nVitória de {p1.Nome}!");
            }
            if (p1.Health < 0)
            {
                break;
            }
            else if (p2.Health < 0)
            {
                break;
            }
        }
        
        Console.WriteLine($"HP final da batalha:\n{p1.Nome} - ({p1.Health})\n{p2.Nome} - ({p2.Health})");
        Console.WriteLine("Aperte qualquer tecla para continuar!");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine($"Dano causado por {p1.Nome}: {totalP1Damage}");
        Console.WriteLine($"Dano causado por {p2.Nome}: {totalP2Damage}");
        p1.Health = respP1Life;
        p2.Health = respP2Life;
    }

    public void Upar(Player p1, Enemy enemy)
    {
        if (p1.Xp >= 100)
        {
            p1.Lvl += 1;
            p1.Xp -= 100;
            p1.Def += 2;
            p1.Health += 5;
            p1.Dmg += 8;

            enemy.Dmg += 6;
            enemy.Health += 8;
        }
    }


}
