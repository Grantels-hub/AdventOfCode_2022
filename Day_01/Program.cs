using AdventOfCodeLibrary;
using Day_01.Services;

ResourceReader resourceReader = new();
CaloriesCalculationService caloriesCalculateService = new();

string rawData = resourceReader.GetResource(1);

caloriesCalculateService.CalculateCaloriesForAllElfs(rawData);

Console.WriteLine("Solution Part 1:" + caloriesCalculateService.GetHighestCalorieAmountOfElfs());
Console.WriteLine("Solution Part 2:" + caloriesCalculateService.GetTopNCalorieAmountOfElfs(3));

Console.ReadKey();