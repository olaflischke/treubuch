using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BummlerUi
{
    public class Bummler
    {
        public string Bummeln()
        {
            double zahl = Wurzelsumme(1e9);
            //Thread.Sleep(2000);
            return "Fertig mit Bummeln";
        }

        public string Troedeln()
        {
            double zahl = Wurzelsumme(2e9);
            return "Fertig mit Trödeln";
        }

        #region Asynchrone Implementierung
        public async Task<string> BummelnAsync()
        {
            double zahl = await Task.Run(() => Wurzelsumme(1e9)); // asynchrone Ausführung
            //await Task.Delay(2000);
            return "Fertig mit Bummeln";
        }


        public async Task<string> TroedelnAsync()
        {
            double zahl = await Task.Run(() => Wurzelsumme(2e9));
            return "Fertig mit Trödeln";
        }


        #endregion

        private double Wurzelsumme(double max)
        {
            double result = 0;

            for (int i = 0; i < max; i++)
            {
                result += Math.Sqrt(i);
            }

            return result;
        }
    }

}
