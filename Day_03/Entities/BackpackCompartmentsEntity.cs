namespace Day_03.Entities
{
    public abstract class BackpackEntity
    {
        public int Points { get; set; } = 0;
    }

    public class BackpackCompartmentsPartOneEntity : BackpackEntity
    {
        public Dictionary<char, int> FirstCompartment { get; set; } = [];

        public Dictionary<char, int> SecondCompartment { get; set; } = [];

        public Dictionary<char, int> SharedItems { get; set; } = [];
    }

    public class BackpacksPartTwoEntity : BackpackEntity
    {
        public Dictionary<char, int> FirstBackpack { get; set; } = [];

        public Dictionary<char, int> SecondBackpack { get; set; } = [];

        public Dictionary<char, int> ThirdBackpack { get; set; } = [];

        public char Badge { get; set; }
    }
}
