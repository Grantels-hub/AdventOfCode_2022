using Day_01.Services;
using ResourceReader = AdventOfCodeLibrary.ResourceReader;

ResourceReader resourceReader = new();
HistoricallySignificantLocationService historicallySignificantLocationService = new();

string rawData = resourceReader.GetResource(1);
historicallySignificantLocationService.CreateTheHistoricallySiginificantLocationIDLists(rawData);

Console.WriteLine("Solution Part 1:" + historicallySignificantLocationService.GetCalculatedDistanceBetweenLocations());
Console.WriteLine("Solution Part 2:" + historicallySignificantLocationService.GetSimiliarityScore());

Console.ReadLine();