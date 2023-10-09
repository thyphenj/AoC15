using AoC1521;

Person boss, player;

Item empty = new Item("*none*") { Cost = 0, Damage = 0, Armour = 0 };

List<Item> Weapons = new List<Item>
        {
            new Item("Dagger") { Cost = 8, Damage = 4 },
            new Item("Shortsword") { Cost = 10, Damage = 5 },
            new Item("Warhammer") { Cost = 25, Damage = 6 },
            new Item("Longsword") { Cost = 40, Damage = 7 },
            new Item("Greataxe") { Cost = 74, Damage = 8}
        };
List<Item> Armoury = new List<Item>
        {
            empty,
            new Item("Leather") { Cost = 13, Armour = 1 },
            new Item("Chainmail") { Cost = 31, Armour = 2 },
            new Item("Splintmail") { Cost = 53, Armour = 3 },
            new Item("Bandedmail") { Cost = 75, Armour = 4 },
            new Item("Platemail") { Cost = 102, Armour = 5 }
        };
List<Item> Rings = new List<Item>
        {
            empty,
            empty,
            new Item("Damage+1") { Cost = 25, Damage = 1 },
            new Item("Damage+2") { Cost = 50, Damage = 2 },
            new Item("Damage+3") { Cost = 100, Damage = 3 },
            new Item("Defense+1") { Cost = 20, Armour = 1 },
            new Item("Defense+2") { Cost = 40, Armour = 2 },
            new Item("Defense+3") { Cost = 80, Armour = 3 }
        };
int minCost = int.MaxValue;
int maxCost = 0;

string playerWins = "";
string bossWins = "";

foreach (var weapon in Weapons)
{
    foreach (var armour in Armoury)
    {
        for (int i = 0; i < Rings.Count; i++)
        {
            for (int j = i + 1; j < Rings.Count; j++)
            {
                int cost = weapon.Cost + armour.Cost + Rings[i].Cost + Rings[j].Cost;

                boss = ResetBoss();
                player = ResetPlayer(weapon, armour, new List<Item>() { Rings[i], Rings[j] });

                while (boss.SurvivesAttackBy(player) && player.SurvivesAttackBy(boss))
                { }

                if (player.Survives() && cost < minCost)
                {
                    minCost = cost;
                    playerWins = $"{weapon} {armour} {Rings[i]} {Rings[j]}   {cost} Player";
                }
                if (boss.Survives() && cost > maxCost)
                {
                    maxCost = cost;
                    bossWins = $"{weapon} {armour} {Rings[i]} {Rings[j]}   {cost}   Boss";
                }
            }
        }
    }
}
Console.WriteLine("    weapon     armour      ring1      ring2  cost winner");
Console.WriteLine("---------- ---------- ---------- ---------- ----- ------");
Console.WriteLine(playerWins);
Console.WriteLine(bossWins);

//----------------------------------------------------------------------------
Person ResetBoss()
{
    return new Person("boss", hitscore: 103, damage: 9, armour: 2);
}

Person ResetPlayer(Item weapon, Item armour, List<Item> rings)
{
    int d = weapon.Damage;

    int a = 0;
    if (armour is not null)
        a = armour.Armour;

    foreach (var ring in rings)
    {
        d += ring.Damage;
        a += ring.Armour;
    }

    return new Person("player", hitscore: 100, damage: d, armour: a);
}
