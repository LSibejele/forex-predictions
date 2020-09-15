using System;
using System.Collections.Generic;
using System.Text;

namespace ForexEngine.Models
{
    public class ForexParameters
    {
        public double AccountSize { get; set; }
        public int TotalTrades { get; set; }
        public double RiskToRewardRatio { get; set; }
        public double PercentageRiskPerTrade { get; set; }
    }
}
