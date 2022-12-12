// See https://aka.ms/new-console-template for more information

using Day_4;

string inputFile = "Input\\Input.txt";

string[] inputData = File.ReadAllLines(inputFile);

List<Pairing> allPairings = new() ;

foreach (var pairing in inputData)
{
    allPairings.Add(new Pairing(pairing));
}

int fullyContainedPairings = allPairings.Where(c => c.AnyFullyContained).Count();
int overlappingPairings = allPairings.Where(c => c.AnyOverlap).Count();

Console.WriteLine($"Number of contained pairs = {fullyContainedPairings}");
Console.WriteLine($"Number of overlapping pairs = {overlappingPairings}");

