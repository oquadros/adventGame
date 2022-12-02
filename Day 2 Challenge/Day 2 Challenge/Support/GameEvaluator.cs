using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_Challenge
{
    internal class GameEvaluator
    {
        private int _totalScore;
        public int TotalScore { get => _totalScore; }
        
        private readonly List<string> MyScorePossibilities = new() { "", "X", "Y", "Z"};
        private readonly List<string> RoundOutcomePossibilities = new() { "X", "Y", "Z" };
        private readonly List<string> OpponentScorePossibilities = new() { "", "A", "B", "C" };

        private enum Scoring
        {
            Loss = 0,
            Tie = 3,
            Win = 6
        };

        private enum HandValue
        {
            Rock = 1,
            Paper = 2,
            Scissor = 3
        };

        private readonly Dictionary<HandValue, HandValue> Victories = new();
        private readonly Dictionary<HandValue, HandValue> Losses = new();

        public GameEvaluator()
        {
            _totalScore = 0;
            Victories.Add(HandValue.Rock, HandValue.Paper);
            Victories.Add(HandValue.Paper, HandValue.Scissor);
            Victories.Add(HandValue.Scissor, HandValue.Rock);

            Losses.Add(HandValue.Rock, HandValue.Scissor);
            Losses.Add(HandValue.Paper, HandValue.Rock);
            Losses.Add(HandValue.Scissor, HandValue.Paper);
        }

        public string DetermineMyMove(string opponent, string expectedRoundOutcome)
        {
            HandValue opponentMoveScore = (HandValue)OpponentScorePossibilities.IndexOf(opponent.ToUpper());
            Scoring expectedRoundResult = (Scoring) (RoundOutcomePossibilities.IndexOf(expectedRoundOutcome.ToUpper()) * 3);

            HandValue winningAction = Victories[opponentMoveScore];
            HandValue losingAction = Losses[opponentMoveScore];


            HandValue myExpectedAction;
            if (expectedRoundResult == Scoring.Tie)
            {
                myExpectedAction = opponentMoveScore;
            }
            else if (expectedRoundResult == Scoring.Win)
            {
                myExpectedAction = winningAction;
            }
            else
            {
                myExpectedAction = losingAction;
            }

            return MyScorePossibilities[(int)myExpectedAction];
        }

        public int EvaluateRound(string opponent, string mine)
        {
            HandValue myMoveScore = (HandValue) MyScorePossibilities.IndexOf(mine.ToUpper());
            HandValue opponentMoveScore = (HandValue) OpponentScorePossibilities.IndexOf(opponent.ToUpper());
            HandValue defeat = Victories[myMoveScore];

            int roundScore;
            if (myMoveScore == opponentMoveScore)
            {
                roundScore = (int)Scoring.Tie;
            }
            else if (opponentMoveScore == defeat)
            {
                roundScore = (int)Scoring.Loss;
            }
            else
            {
                roundScore = (int)Scoring.Win;
            }
            roundScore += (int)myMoveScore;
            
            _totalScore += roundScore;

            return roundScore;
        }
    }
}
