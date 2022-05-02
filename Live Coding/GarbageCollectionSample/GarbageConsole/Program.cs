using System;
using System.IO;
using System.Net.Sockets;

namespace GarbageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UseDemo());
            GC.Collect(); // Kann(!) funktionieren, muss aber nicht.

            System.Threading.Thread.Sleep(100);

            Console.WriteLine(UseUsing());

            System.Threading.Thread.Sleep(100);

            Console.WriteLine(UseDispose());

            System.Threading.Thread.Sleep(100);
        }

        static string UseDemo()
        {
            Demo demo1 = new Demo("Demo1");
            return "Demo1 done.";
        }

        static string UseUsing()
        {
            using (Demo demo2 = new Demo("Demo2"))
            {
                return "Demo2 done.";
            }

            return null;
        }

        static string UseDispose()
        {
            Demo demo3 = new Demo("Demo3");
            demo3.Dispose();

            return "Demo3 done.";
        }
    }

    public class Demo : IDisposable
    {
        public string Name { get; set; }
        public double Wert { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name">Name des Objekts</param>
        public Demo(string name)
        {
            this.Name = name;
            this.Wert = (new Random()).NextDouble();
        }

        /// <summary>
        /// Destruktor
        /// </summary>
        /// <remarks>
        /// Wird aufgerufen, wenn die GarbageCollection das Objekt "entsorgt".
        /// Nichtdeterministisch: Wir haben keinen Einfluß darauf, wann dieser Code ausgeführt.
        /// </remarks>
        ~Demo()
        {
            string meldung = $"Destruktor von {this.Name}: {this.Wert:#,##0.00}";

            using (StreamWriter writer = new StreamWriter(@"c:\tmp\treubuch\destructor.txt"))
            {
                writer.WriteLine(meldung);
                writer.Flush();
            }

            Console.WriteLine(meldung);
        }

        // KEIN Finalize - so heißt der Destruktor in IL
        //void Finalize()
        //{

        //}

        /// <summary>
        /// Dispose-Methode aus IDisposable
        /// </summary>
        /// <remarks>
        /// Deterministisch: Wird ausgeführt, wenn Dispose aufgerufen wird.
        /// </remarks>
        public void Dispose()
        {
            // Einige Methoden zum Aufräumen und Dokumentieren
            string meldung = $"Dispose von {this.Name}: {this.Wert:#,##0.00}";

            using (StreamWriter writer = new StreamWriter(@"c:\tmp\treubuch\destructor.txt"))
            {
                writer.WriteLine(meldung);
                writer.Flush();
            }

            Console.WriteLine(meldung);

            // Dispose für abgeleitete Elemente
            Dispose(true);

            // Desktruktor-Aufruf verhindern
            // In den meisten Fällen: Redundante Codeausführung verhindern.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Abhängige Elemente disposen
                this.Client?.Dispose();
            }
        }

        public TcpClient Client { get; set; }
    }

}
