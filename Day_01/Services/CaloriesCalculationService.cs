using Day_01.Entities;

namespace Day_01.Services
{
    public class CaloriesCalculationService
    {
        private List<ElfEntity> Elfs { get; set; } = [];

        private const string EmptyCell = "\r\n\r\n";
        private const string NewLine = "\r\n";

        public void CalculateCaloriesForAllElfs(string rawData)
        {
            string[] caloriesOfEachElf = rawData.Split(EmptyCell);

            foreach (var calories in caloriesOfEachElf)
            {
                string[] caloriesOfElf = calories.Split(NewLine);

                ElfEntity elf = new();

                foreach (string calorie in caloriesOfElf)
                {
                    elf.Calories += int.Parse(calorie);
                }

                Elfs.Add(elf);
            }
        }

        /// <summary>
        /// Gets the highest calorie amount of all Elfs.
        /// </summary>
        public int GetHighestCalorieAmountOfElfs()
        {
            Elfs = Elfs.OrderByDescending(x => x.Calories).ToList();

            return Elfs.First().Calories;
        }

        /// <summary>
        /// Gets the sum of the top N calorie amount of all Elfs.
        /// </summary>
        public int GetTopNCalorieAmountOfElfs(int topN)
        {
            if (topN > Elfs.Count)
                throw new ArgumentOutOfRangeException("Top N value is greater than the number of Elfs.");
            
            int totalCalories = 0;

            Elfs = Elfs.OrderByDescending(x => x.Calories).ToList();

            for (int i = 0; i < topN; i++)
            {
                totalCalories += Elfs[i].Calories;
            }

            return totalCalories;
        }
    }
}
