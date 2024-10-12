using Day_03.Entities;

namespace Day_03.Services
{
    public class BackpackCompartmentsCalculationService
    {
        private string[] Backpacks { get; set; } = [];

        private const string NewLine = "\r\n";

        public int SolvePart(Part part, string rawData)
        {
            Backpacks = rawData.Split(NewLine);

            return part switch
            {
                Part.PartOne => ReorganizeBackpackPartOne(),
                Part.PartTwo => ReorganizeBackpackPartTwo(),
                _ => throw new NotImplementedException(),
            };
        }

        public int ReorganizeBackpackPartOne()
        {
            List<BackpackCompartmentsPartOneEntity> backpackCompartmentsEntities = [];

            foreach (string backpackCompartment in Backpacks)
            {
                string firstCompartment = backpackCompartment[..(backpackCompartment.Length / 2)];
                string secondCompartment = backpackCompartment.Substring(backpackCompartment.Length / 2, backpackCompartment.Length / 2);

                if (firstCompartment.Length != secondCompartment.Length)
                    throw new Exception("Invalid input");

                int lengthOfCompartments = firstCompartment.Length;

                BackpackCompartmentsPartOneEntity backpackCompartmentsEntity = new();

                for (int i = 0; i < lengthOfCompartments; i++)
                {
                    if (!backpackCompartmentsEntity.FirstCompartment.ContainsKey(firstCompartment[i]))
                        backpackCompartmentsEntity.FirstCompartment.Add(firstCompartment[i], 1);
                    else
                        backpackCompartmentsEntity.FirstCompartment[firstCompartment[i]] += 1;

                    if (!backpackCompartmentsEntity.SecondCompartment.ContainsKey(secondCompartment[i]))
                        backpackCompartmentsEntity.SecondCompartment.Add(secondCompartment[i], 1);
                    else
                        backpackCompartmentsEntity.SecondCompartment[secondCompartment[i]] += 1;
                }

                foreach (var item in backpackCompartmentsEntity.SecondCompartment)
                {
                    if (backpackCompartmentsEntity.FirstCompartment.ContainsKey(item.Key))
                    {
                        backpackCompartmentsEntity.SharedItems.Add(item.Key, 0);

                        if (backpackCompartmentsEntity.SecondCompartment[item.Key] < backpackCompartmentsEntity.FirstCompartment[item.Key])
                            backpackCompartmentsEntity.SharedItems[item.Key] = backpackCompartmentsEntity.SecondCompartment[item.Key];
                        else
                            backpackCompartmentsEntity.SharedItems[item.Key] = backpackCompartmentsEntity.FirstCompartment[item.Key];
                    }
                }

                FillInPointsBasedOnSharedItems(backpackCompartmentsEntity);

                backpackCompartmentsEntities.Add(backpackCompartmentsEntity);
            }

            return backpackCompartmentsEntities.Select(x => x.Points).Sum();
        }

        public int ReorganizeBackpackPartTwo()
        {
            List<BackpacksPartTwoEntity> backpackEntities = [];

            for (int i = 0; i < (Backpacks.Length / 3); i++)
            {
                BackpacksPartTwoEntity backpackEntity = new()
                {
                    FirstBackpack = CreateDictFromBackpack(Backpacks[(i * 3)]),
                    SecondBackpack = CreateDictFromBackpack(Backpacks[1 + (i * 3)]),
                    ThirdBackpack = CreateDictFromBackpack(Backpacks[2 + (i * 3)]),
                };

                backpackEntities.Add(backpackEntity);
            }

            foreach (BackpacksPartTwoEntity backpackEntity in backpackEntities)
            {
                foreach (var item in backpackEntity.FirstBackpack)
                {
                    if (backpackEntity.SecondBackpack.ContainsKey(item.Key) && backpackEntity.ThirdBackpack.ContainsKey(item.Key))
                    {
                        backpackEntity.Badge = item.Key;
                    }
                }

                backpackEntity.Points = GetTranslatedPointsFromAscii(backpackEntity.Badge);
            }

            return backpackEntities.Select(x => x.Points).Sum();
        }

        private Dictionary<char, int> CreateDictFromBackpack(string s)
        {
            Dictionary<char, int> dict = new();

            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                    dict[c] += 1;
                else
                    dict.Add(c, 1);
            }

            return dict;
        }

        private void FillInPointsBasedOnSharedItems(BackpackCompartmentsPartOneEntity backpackCompartmentsEntity)
        {
            foreach (var item in backpackCompartmentsEntity.SharedItems)
            {
                backpackCompartmentsEntity.Points += GetTranslatedPointsFromAscii(item.Key);
            }
        }

        private int GetTranslatedPointsFromAscii(char c)
        {
            if (c >= 97 && c <= 122)
            {
                return (int)c - 96;
            }
            return (int)c - 38;
        }
    }

    public enum Part
    {
        PartOne,
        PartTwo,
    }
}
