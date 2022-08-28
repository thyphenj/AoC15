string input = "1321131112";

string part1 = input;

for (int i = 0; i < 50; i++)
{
    part1 = part1.Replace("111", "A").Replace("222", "B").Replace("333", "C");
    part1 = part1.Replace("11", "D").Replace("22", "E").Replace("33", "F");
    part1 = part1.Replace("1", "11").Replace("2", "12").Replace("3", "13");
    part1 = part1.Replace("A", "31").Replace("B", "32").Replace("C", "33");
    part1 = part1.Replace("D", "21").Replace("E", "22").Replace("F", "23");
    if (i + 1 == 40)
        Console.WriteLine(part1.Length);
    if (i + 1 == 50)
        Console.WriteLine(part1.Length);
}