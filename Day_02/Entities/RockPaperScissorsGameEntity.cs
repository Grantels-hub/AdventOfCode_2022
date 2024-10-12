namespace Day_02.Entities
{
    public enum RPS
    {
        Rock,
        Paper,
        Scissors
    }

    public enum Outcome
    {
        Win = 6,
        Draw = 3,
        Lose = 0,
    }

    public abstract class RockPaperScissorsGameEntity
    {
        public RPS OwnHand { get; set; }
        public RPS OpponentHand { get; set; }
        public int TotalPoints { get; set; }
    }

    public class RockPaperScissorsGamePartOneEntity : RockPaperScissorsGameEntity
    {
        public int PointsBasedOnHand
        {
            get
            {
                return OwnHand switch
                {
                    RPS.Rock => 1,
                    RPS.Paper => 2,
                    RPS.Scissors => 3,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public static readonly int[,] PointsBasedOnGameOutcome = { { 3, 0, 6 }, { 6, 3, 0 }, { 0, 6, 3 } };

    }

    public class RockPaperScissorsGamePartTwoEntity : RockPaperScissorsGameEntity
    {
        public static readonly Enum[,] PossibleGameOutocomes = 
            { { Outcome.Draw, Outcome.Lose, Outcome.Win }, { Outcome.Win, Outcome.Draw, Outcome.Lose }, { Outcome.Lose, Outcome.Win, Outcome.Draw } };
    }
}
