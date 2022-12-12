using System.Linq;

string[] fileContents = File.ReadAllLines("input.txt");
string valueString = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

int score = 0;

foreach (string line in fileContents)
{
    char[] compartmentOne = line.Substring(0, line.Length / 2).ToCharArray();
    char[] compartmentTwo = line.Substring(line.Length / 2, line.Length / 2).ToCharArray();
    foreach (var j in compartmentOne.SelectMany(i => compartmentTwo.Where(j => i == j)))
    {
        score += valueString.IndexOf(j);
        break;
    }
}

int badgeScore = 0;
for (int i = 0; i < fileContents.Length - 1; i += 3)
{
    char[] elf1 = fileContents[i].ToCharArray();
    char[] elf2 = fileContents[i + 1].ToCharArray();
    char[] elf3 = fileContents[i + 2].ToCharArray();

    var common = elf1.Intersect(elf2).Intersect(elf3);

    badgeScore += valueString.IndexOf(common.ToArray()[0]);
}

Console.WriteLine($"Priority score = {score}");
Console.WriteLine($"BadgeScore = {badgeScore}");