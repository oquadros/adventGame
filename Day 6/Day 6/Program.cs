

string[] inputDataStream = File.ReadAllLines(@"Input\Input.txt");

char[] streamSplit = inputDataStream[0].ToCharArray();

var headCountStartOfPacket = 0;

for (int i = 3; i < streamSplit.Length; i++)
{
    char[] intermediaryList = new char[4]{streamSplit[i-3], streamSplit[i - 2], streamSplit[i - 1], streamSplit[i] };

    if (intermediaryList.Distinct().Count() != 4)
        continue;

    headCountStartOfPacket += i + 1;
    break;

}

int headCountStartOfMessage = 0;

for (int i = 13; i < streamSplit.Length; i++)
{
    List<char> intermediaryList = new();
    for (int j = i-13; j <= i; j++)
    {
        intermediaryList.Add(streamSplit[j]);
    }

    if (intermediaryList.Distinct().Count() != 14)
    {
        Console.WriteLine(intermediaryList.Distinct().Count());
        continue;
    }

    headCountStartOfMessage += i + 1;
    break;

}


Console.WriteLine($"Need to read {headCountStartOfPacket} characters before the first start-of-packet block.");
Console.WriteLine($"Need to read {headCountStartOfMessage} characters before the first start-of-message block.");




