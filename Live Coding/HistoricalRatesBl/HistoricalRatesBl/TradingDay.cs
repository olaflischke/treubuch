using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HistoricalRatesBl
{
    public class TradingDay
    {
        public TradingDay(XElement de)
        {
            // TODO: Datum festlegen (aus "time"-Attribut)

            // TODO: ExchangeRates ermitteln per LINQ
            // Tipp: var q = de.Elements...
        }

        public DateTime Date { get; set; }

        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}