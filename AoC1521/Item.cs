namespace AoC1521;

public class Item
{
    public string Name;

    public int Cost;
    public int Damage;
    public int Armour;

    public Item(string name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return $"{Name.PadLeft(10)}";
    }
}