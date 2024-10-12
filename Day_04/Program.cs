using AdventOfCodeLibrary;
using Day_04.Services;

ResourceReader resourceReader = new();
CleaningSectionsCalculationService cleaningSectionsCalculationService = new();

string rawData = resourceReader.GetResource(4);

Console.WriteLine("Solution Part 1:" + cleaningSectionsCalculationService.SolvePart(Part.PartOne, rawData));
//Console.WriteLine("Solution Part 2:" + cleaningSectionsCalculationService.SolvePart(Part.PartTwo, rawData));

Console.ReadKey();