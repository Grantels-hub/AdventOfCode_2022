using Day_02.Entities;

namespace Day_02.Services
{
    public class StrategyGuideCalculationService
    {
        private string[] GamesAccordingToStrategyGuide { get; set; } = [];

        private const string NewLine = "\r\n";

        public int SolvePart(Part part, string rawData)
        {
            GamesAccordingToStrategyGuide = rawData.Split(NewLine);

            return part switch
            {
                Part.PartOne => PlayAccordingToStrategyGuidePartOne(),
                Part.PartTwo => PlayAccordingToStrategyGuidePartTwo(),
                _ => throw new NotImplementedException(),
            };
        }

        private int PlayAccordingToStrategyGuidePartOne()
        {
            List<RockPaperScissorsGamePartOneEntity> RockPaperScissorsGames = new();

            foreach (string item in GamesAccordingToStrategyGuide)
            {
                char opponentHand = item[0];

                char myHand = item[2];

                RockPaperScissorsGamePartOneEntity rockPaperScissorsEntity = new()
                {
                    OwnHand = MapToRPSEnum(myHand),
                    OpponentHand = MapToRPSEnum(opponentHand)
                };

                rockPaperScissorsEntity.TotalPoints = rockPaperScissorsEntity.PointsBasedOnHand + RockPaperScissorsGamePartOneEntity.PointsBasedOnGameOutcome[(int)rockPaperScissorsEntity.OwnHand, (int)rockPaperScissorsEntity.OpponentHand];

                RockPaperScissorsGames.Add(rockPaperScissorsEntity);
            }

            return RockPaperScissorsGames.Select(x => x.TotalPoints).Sum();
        }

        private int PlayAccordingToStrategyGuidePartTwo()
        {
            List<RockPaperScissorsGamePartTwoEntity> rockPaperScissorsGameEntities = new();

            foreach (string item in GamesAccordingToStrategyGuide)
            {
                RPS opponenetHand = MapToRPSEnum(item[0]);

                Outcome desiredOutcome = MapToOutcomeEnum(item[2]);

                RockPaperScissorsGamePartTwoEntity rockPaperScissorsGameEntity = new()
                {
                    OpponentHand = opponenetHand
                };

                for (int i = 0; i < 3; i++)
                {
                    if (desiredOutcome == (Outcome)RockPaperScissorsGamePartTwoEntity.PossibleGameOutocomes[i, (int)opponenetHand])
                    {
                        rockPaperScissorsGameEntity.TotalPoints += (int)desiredOutcome + i + 1;
                    }
                }

                rockPaperScissorsGameEntities.Add(rockPaperScissorsGameEntity);
            }

            return rockPaperScissorsGameEntities.Select(x => x.TotalPoints).Sum();
        }

        private RPS MapToRPSEnum(char c)
        {
            if (c == 'A' || c == 'X')
                return RPS.Rock;
            if (c == 'B' || c == 'Y')
                return RPS.Paper;
            return RPS.Scissors;
        }

        private Outcome MapToOutcomeEnum(char c)
        {
            if (c == 'X')
                return Outcome.Lose;
            if (c == 'Y')
                return Outcome.Draw;
            return Outcome.Win;
        }
    }

    public enum Part
    {
        PartOne,
        PartTwo,
    }
}
