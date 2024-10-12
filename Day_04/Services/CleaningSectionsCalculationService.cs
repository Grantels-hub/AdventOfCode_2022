using Day_04.Entities;

namespace Day_04.Services
{
    public class CleaningSectionsCalculationService
    {
        private string[] ElfPairs { get; set; } = [];

        private const string ElfPairDivider = ",";
        private const string NewLine = "\r\n";

        public int SolvePart(Part part, string rawData)
        {
            ElfPairs = rawData.Split(NewLine);

            return part switch
            {
                Part.PartOne => CalculateCleaningSectionsPartOne(),
                Part.PartTwo => CalculateCleaningSectionsPartTwo(),
                _ => throw new NotImplementedException(),
            };
        }

        public int CalculateCleaningSectionsPartOne()
        {
            List<CleaningPairs> cleaningPairs = new();

            foreach (var pair in ElfPairs)
            {
                string[] individualSections = pair.Split(ElfPairDivider);

                CleaningPairs cleaningPair = new CleaningPairs
                {
                    CleaningSectionsFirstElf = new CleaningSectionsEntity
                    {
                        LowerLimit = int.Parse(individualSections[0].Split("-")[0]),
                        UpperLimit = int.Parse(individualSections[0].Split("-")[1])
                    },
                    CleaningSectionsSecondElf = new CleaningSectionsEntity
                    {
                        LowerLimit = int.Parse(individualSections[1].Split("-")[0]),
                        UpperLimit = int.Parse(individualSections[1].Split("-")[1])
                    }
                };

                cleaningPairs.Add(cleaningPair);
            }

            int overlaps = 0;

            foreach (var item in cleaningPairs)
            {
                if (item.CleaningSectionsFirstElf.LowerLimit <= item.CleaningSectionsSecondElf.LowerLimit)
                {
                    if (item.CleaningSectionsFirstElf.UpperLimit >= item.CleaningSectionsSecondElf.UpperLimit)
                    {
                        overlaps += 1;
                        continue;
                    }
                }
                if (item.CleaningSectionsFirstElf.LowerLimit >= item.CleaningSectionsSecondElf.LowerLimit)
                {
                    if (item.CleaningSectionsFirstElf.UpperLimit <= item.CleaningSectionsSecondElf.UpperLimit)
                    {
                        overlaps += 1;
                        continue;
                    }
                }
            }

            return overlaps;
        }

        public int CalculateCleaningSectionsPartTwo()
        {
            throw new NotImplementedException();
        }

    }

    public enum Part
    {
        PartOne,
        PartTwo,
    }
}
