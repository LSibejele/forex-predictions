using System;
using System.Collections.Generic;

namespace Forex
{
    public enum TradeResult {
        Win,
        Lose
    }
    class Program
    {
        private static double accountSize;
        private static double percentageRiskPerTrade;
        private static double riskToReward;
        private static int numberOfTrades;

        static void Main(string[] args)
        {
            RunPredictions();
            while (true)
            {
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        RunPredictions();
                        break;
                    case ConsoleKey.Spacebar:
                        Run();
                        break;
                    default: break;    
                }
            }
        }

        private static void RunPredictions()
        {
            
            CollectParameters();
            Run();
        }

        private static void Run()
        {
            Console.Clear();
            double _accountSize = accountSize;
            double _percentageRiskPerTrade = percentageRiskPerTrade;
            double _numberOfTrades = numberOfTrades;
            double _riskToReward = riskToReward;
            Random rng = new Random();
            List<int> tradeResults = new List<int>();
            for (int i = 0; i < numberOfTrades; i++)
            {
                int tradeResult = rng.Next(2);
                tradeResults.Add(tradeResult);
            }
            double winCounter = 0;
            for (int i = 0; i < tradeResults.Count; i++)
            {
                var result = tradeResults[i];
                double tradedAmount = Math.Round(_accountSize * _percentageRiskPerTrade, 2);
                if (result == (int)TradeResult.Win)
                {
                    winCounter++;
                    _accountSize = Math.Round(_accountSize + (tradedAmount * _riskToReward), 2);
                    Console.WriteLine((i + 1) + ".\t Trade Result: Win \t Account Size: \t " + _accountSize);
                }
                if (result == (int)TradeResult.Lose)
                {
                    _accountSize = Math.Round(_accountSize - tradedAmount, 2);
                    Console.WriteLine((i + 1) + ".\t Trade Result: Lose \t Account Size: \t " + _accountSize);
                }
            }
            Console.WriteLine("Winning %: \t\t\t" + (winCounter / tradeResults.Count) * 100);
            Console.WriteLine("Press enter to run again.");
        }

        private static void CollectParameters()
        {
            Console.Clear();
            Console.WriteLine("Enter the account size: ");
            accountSize = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the the percentage risk per trade: ");
            percentageRiskPerTrade = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the risk to reward ratio: ");
            riskToReward = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the number of trades: ");
            numberOfTrades = Convert.ToInt32(Console.ReadLine());
        }
    }
}
