namespace AoC1521;

public class Person
{
    public string Name;
    public int HitScore;

    public int Damage;
    public int Armour;

    public Person(string name, int hitscore, int damage, int armour)
    {
        Name = name;
        HitScore = hitscore;
        Damage = damage;
        Armour = armour;
    }

    public int EffectiveDamage ()
    {
        return Damage;
    }

    public bool SurvivesAttackBy ( Person attacker)
    {

        int damageDone = attacker.EffectiveDamage() - Armour;
        HitScore -= (damageDone > 0 ? damageDone : 1);

        return HitScore > 0;
    }

    public bool Survives()
    {
        return HitScore > 0;
    }

    public override string ToString()
    {
        return $"{Name}: {HitScore,3}";
    }
}