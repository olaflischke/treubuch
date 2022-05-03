using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class Archive
    {
        public Archive(string url)
        {
            //this.TradingDays = ((XDocument.Load(url)).Root.Descendants()
            //                    .Where(de => de.Name == "Cube" && de.Attributes().Any(at => at.Name == "time"))
            //                    // Projektion auf TradingDay-Objektmenge
            //                    .Select(de => new TradingDay() { Date = Convert.ToDateTime(de.Attribute("time").Value) })).ToList();
            //this.TradingDays = await GetData(url);
        }

        public async Task<List<TradingDay>> GetData(string url)
        {
            //Thread.Sleep(5000);
            await Task.Delay(5000); // Langes Laden simulieren

            var a = new ExchangeRate(); // "type inference"

            List<TradingDay> days = new List<TradingDay>();

            // XML-Dokument zu einer Basisobjektmenge machen
            XDocument document = XDocument.Load(url);

            // Aus der Basisobjektmenge die Objekte raussuche, die wir brauchen
            var q = document.Root.Descendants()
                                .Where(de => de.Name.LocalName == "Cube" && de.Attributes().Any(at => at.Name.LocalName == "time"))
                                //.Select(de => new { Name = de.Name, Attributcount = de.Attributes().Count() });
                                // Projektion auf TradingDay - Objektmenge
                                //.Select(de => new TradingDay() { Date = Convert.ToDateTime(de.Attribute("time").Value) });
                                .Select(de => new TradingDay(de));

            //foreach(var element in q)
            //{
            //    element.
            //}

            //DataGrid1.ItemsSource = q.ToList(); // Wenn DataGrid.AutgenerateColumns==true

            //foreach (XElement item in q)
            //{
            //    TradingDay day = new TradingDay() { Date = Convert.ToDateTime(item.Attribute("time").Value) };
            //    days.Add(day);
            //}

            days = q.ToList();

            return days;
        }


        public List<TradingDay> TradingDays { get; set; } //= new List<TradingDay>();
    }
}