// See https://aka.ms/new-console-template for more information

using Day_5.Helpers;
using Day_5.Models;

string[] inputData = File.ReadAllLines("Input\\Input.txt");

string[][] rowList = Helpers.ParseStackRows(inputData);

string[][] columnsList = Helpers.ConvertRowsToColumns(rowList);

List<CrateStack> crateStacks = new();
for (var column = 0; column < columnsList.Length; column++)
{
    crateStacks.Add(new CrateStack(column + 1, columnsList[column]));
}

int indexOfSplit = Array.IndexOf(inputData, string.Empty);

//Helpers.CrateMover9000Move(inputData, crateStacks, indexOfSplit);

Helpers.CrateMover9001Move(inputData, crateStacks, indexOfSplit);

string outputString = string.Empty;
foreach (var stack in crateStacks)
{
    outputString += stack.GetTopCrate().Marking;
}

Console.WriteLine($"For CrateMover 9001 = {outputString}");

