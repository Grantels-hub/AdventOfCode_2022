namespace Day_04.Entities
{
    public class CleaningSectionsEntity
    {
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
    }
    public class  CleaningPairs
    {
        public CleaningSectionsEntity CleaningSectionsFirstElf { get; set; } = new CleaningSectionsEntity();

        public CleaningSectionsEntity CleaningSectionsSecondElf { get; set; } = new CleaningSectionsEntity();
    }
}
