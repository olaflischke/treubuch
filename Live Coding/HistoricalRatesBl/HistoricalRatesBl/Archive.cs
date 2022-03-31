using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HistoricalRatesBl
{
    public class Archive
    {
        public Archive(string url)
        {
            //this.TradingDays = ((XDocument.Load(url)).Root.Descendants()
            //                    .Where(de => de.Name == "Cube" && de.Attributes().Any(at => at.Name == "time"))
            //                    // Projektion auf TradingDay-Objektmenge
            //                    .Select(de => new TradingDay() { Date = Convert.ToDateTime(de.Attribute("time").Value) })).ToList();
            this.TradingDays = GetData(url);
        }

        private List<TradingDay> GetData(string url)
        {
            var a = new ExchangeRate(); // "type inference"

            List<TradingDay> days = new List<TradingDay>();

            XDocument document = XDocument.Load(url);

            var q = document.Root.Descendants()
                                .Where(de => de.Name.LocalName == "Cube" && de.Attributes().Any(at => at.Name.LocalName == "time"))
                                // Projektion auf TradingDay-Objektmenge
                                .Select(de => new TradingDay() { Date = Convert.ToDateTime(de.Attribute("time").Value) });

            //foreach (XElement item in q)
            //{
            //    TradingDay day = new TradingDay() { Date = Convert.ToDateTime(item.Attribute("time").Value) };
            //    days.Add(day);
            //}

            days = q.ToList();

            return days;
        }

        public List<TradingDay> TradingDays { get; set; }
    }
}