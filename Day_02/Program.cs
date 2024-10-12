using AdventOfCodeLibrary;
using Day_02.Services;

ResourceReader resourceReader = new();
StrategyGuideCalculationService strategyGuideCalculationService = new();

string rawData = resourceReader.GetResource(2);

Console.WriteLine("Solution Part 1:" + strategyGuideCalculationService.SolvePart(Part.PartOne, rawData));
Console.WriteLine("Solution Part 2:" + strategyGuideCalculationService.SolvePart(Part.PartTwo, rawData));

Console.ReadKey();