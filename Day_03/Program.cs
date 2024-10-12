using AdventOfCodeLibrary;
using Day_03.Services;

ResourceReader resourceReader = new();
BackpackCompartmentsCalculationService backpackCompartmentsCalculationService = new();

string rawData = resourceReader.GetResource(3);

Console.WriteLine("Solution Part 1:" + backpackCompartmentsCalculationService.SolvePart(Part.PartOne, rawData));
Console.WriteLine("Solution Part 2:" + backpackCompartmentsCalculationService.SolvePart(Part.PartTwo, rawData));