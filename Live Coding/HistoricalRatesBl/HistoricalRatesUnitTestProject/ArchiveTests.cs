using HistoricalRatesDal;
//using HistoricalRatesDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HistoricalRatesUnitTestProject
{
    [TestClass]
    public class ArchiveTests
    {
        string url;

        public ArchiveTests()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
            //url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist.xml";
        }

        [TestMethod]
        public void IsArchiveInitializing()
        {
            Archive archive = new Archive(url);
            Console.WriteLine($"Erster TradingDay: {archive.TradingDays.FirstOrDefault()?.Date.ToShortDateString()}");
            
            Assert.AreEqual(CountAttribute("time"), archive.TradingDays.Count);

        }

        [TestMethod]
        public void IsUsdCorrect()
        {
            Archive archive = new Archive(url);

            TradingDay first = archive.TradingDays.Where(td => td.Date==new DateTime(2022,3,31)).FirstOrDefault();
            ExchangeRate usd = first?.ExchangeRates.FirstOrDefault();

            Assert.AreEqual(1.1101, archive.TradingDays.FirstOrDefault()?.ExchangeRates.FirstOrDefault()?.Rate);
        }

        /// <summary>
        /// Zählt das Auftreten des gg. Attributnamens in einer Datei
        /// </summary>
        private int CountAttribute(string attribute)
        {
            // TODO: Ausprogrammieren
            return 64;
        }
    }
}
