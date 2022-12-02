// See https://aka.ms/new-console-template for more information
using Day_2_Challenge;

Console.WriteLine("Hello, World!");

var GameClient = new GameEvaluator();

using (StreamReader sr = new("Support/StrategyGuide.txt"))
{
    while (!sr.EndOfStream)
    {
        string[] line = sr.ReadLine().Split(" ");
        string myMove = GameClient.DetermineMyMove(line[0], line[1]);
        int roundScore = GameClient.EvaluateRound(line[0], myMove);
        Console.WriteLine($"Round Score = {roundScore}");
    }

    Console.WriteLine($"The total score for this game was {GameClient.TotalScore}");
}