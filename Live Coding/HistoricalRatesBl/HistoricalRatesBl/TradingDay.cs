using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            // Zahlen- und andere Formate aus anderen Kulturen
            CultureInfo ciEcb = CultureInfo.InvariantCulture;  //new CultureInfo("de-DE");
            NumberFormatInfo nfiEcb = ciEcb.NumberFormat;
            DateTimeFormatInfo dtiEcb = ciEcb.DateTimeFormat;

            // Dezimaltrennzeichen selbst setzen:
            //NumberFormatInfo nfiEcb = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator="" };

            // Datum festlegen (aus "time"-Attribut)
            this.Date = Convert.ToDateTime(tradingDayNode.Attribute("time").Value);

            // ExchangeRates ermitteln per LINQ
            var q = tradingDayNode.Elements().Select(el => new ExchangeRate()
                                                {
                                                    Symbol = el.Attribute("currency").Value,
                                                    Rate = Convert.ToDouble(el.Attribute("rate").Value, nfiEcb)
                                                }
                                        );

            this.ExchangeRates = q.ToList(); // Deferred Execution: Zugriff auf die Ergebnismenge führt IEnumerable.GetEnumerator() aus.
        }

        public DateTime Date { get; set; }

        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}