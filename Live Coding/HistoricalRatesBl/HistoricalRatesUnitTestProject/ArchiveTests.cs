using HistoricalRatesBl;
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
        }

        [TestMethod]
        public void IsArchiveInitializing()
        {
            Archive archive = new Archive(url);
            Console.WriteLine($"Erster TradingDay: {archive.TradingDays.FirstOrDefault()?.Date.ToShortDateString()}");
            
            Assert.AreEqual(CountAttribute("time"), archive.TradingDays.Count);
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
