using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistoricalRatesBl
{
    public class TradingDay
    {
        public DateTime Date { get; set; }

        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}