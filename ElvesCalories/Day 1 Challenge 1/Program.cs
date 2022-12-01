Console.WriteLine("Please enter the location of the file containing the list of Calories submitted by the Elves");
string elfCalorieListFile = Console.ReadLine();

while (string.IsNullOrEmpty(elfCalorieListFile))
{
    Console.WriteLine("There was no file to read provided, please provide a new file. Type 'e' to exit...");
    elfCalorieListFile = Console.ReadLine();
    if (elfCalorieListFile == "e")
        Environment.Exit(0);
}

using (StreamReader sr = new StreamReader(elfCalorieListFile))
{
    int elfWithMostCalories = 0;
    int highestNumberOfCalories = 0;
    int elfWithSecondMostCalories = 0;
    int secondHighestNumberOfCalories = 0;
    int elfWithThirdMostCalories = 0;
    int thirdHighestNumberOfCalories = 0;
    int elfCounter = 1;
    int calorieTotalForCurrentElf = 0;
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();

        if (string.IsNullOrEmpty(line))
        {            
            if (calorieTotalForCurrentElf > highestNumberOfCalories)
            {
                elfWithThirdMostCalories = elfWithSecondMostCalories;
                thirdHighestNumberOfCalories = secondHighestNumberOfCalories;
                elfWithSecondMostCalories = elfWithMostCalories;
                secondHighestNumberOfCalories = highestNumberOfCalories;
                highestNumberOfCalories = calorieTotalForCurrentElf;
                elfWithMostCalories = elfCounter;
            }
            else if (calorieTotalForCurrentElf > secondHighestNumberOfCalories)
            {
                elfWithThirdMostCalories = elfWithSecondMostCalories;
                thirdHighestNumberOfCalories = secondHighestNumberOfCalories;
                secondHighestNumberOfCalories = calorieTotalForCurrentElf;
                elfWithSecondMostCalories = elfCounter;
            }
            else if (calorieTotalForCurrentElf > thirdHighestNumberOfCalories)
            {
                thirdHighestNumberOfCalories = calorieTotalForCurrentElf;
                elfWithThirdMostCalories = elfCounter;
            }
            calorieTotalForCurrentElf = 0;
            elfCounter++;
            continue;
        }

        if(!int.TryParse(line, out int currentCalorie))
        {
            Console.WriteLine($"Error Converting calories with value: {line}. Exiting Application...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        calorieTotalForCurrentElf += currentCalorie;
    }

    int totalNumberOfCaloriesTopThree = highestNumberOfCalories + secondHighestNumberOfCalories + thirdHighestNumberOfCalories;

    Console.WriteLine($"The elves with the highest number of calories were {elfWithMostCalories}, {elfWithSecondMostCalories}, and {elfWithThirdMostCalories} and they were carrying {totalNumberOfCaloriesTopThree} calories");
}