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
            PopulateParameters();
            Run();
            Repeat();
        }

        private static void Repeat()
        {
            Console.WriteLine("Press space to repeat with same parameters, press enter to run with new parameters...");
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        PopulateParameters();
                        Run();
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        Run();
                        break;
                    default: break;
                }
            }
            
        }

        private static void Run()
        {
            double _accountSize = accountSize;
            double _percentageRiskPerTrade = percentageRiskPerTrade;
            double _riskToReward = riskToReward;
            int _numberOfTrades = numberOfTrades;
            int winCounter = 0;
            Random rng = new Random();

            for (int i = 1; i <= _numberOfTrades; i++)
            {
                double tradedAmount = Math.Round(_accountSize * _percentageRiskPerTrade, 2);
                TradeResult result = (TradeResult)rng.Next(2);
                if (result == TradeResult.Win)
                {
                    Print(_accountSize, tradedAmount, result.ToString());
                    _accountSize = Math.Round(_accountSize, 2) + (tradedAmount * _riskToReward);
                    winCounter++;
                }else if (result == TradeResult.Lose)
                {
                    Print(_accountSize, tradedAmount, result.ToString());
                    _accountSize = Math.Round(_accountSize, 2) - (tradedAmount);
                }
            }
            double winPercentage = winCounter / numberOfTrades;
            Console.WriteLine(winPercentage);
           

        }

        private static void Print(double accountSize, double tradedAmount, string result)
        {
            Console.WriteLine($"Account Size: { accountSize}\t Result: {result}\t Amount Traded: {tradedAmount}");
        }

        private static void PopulateParameters()
        {
            Console.WriteLine("Account Size: ");
            accountSize = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("% risk per trade: ");
            percentageRiskPerTrade = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Risk to reward: ");
            riskToReward = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Total trades: ");
            numberOfTrades = Convert.ToInt32(Console.ReadLine());
        }
    }
}
