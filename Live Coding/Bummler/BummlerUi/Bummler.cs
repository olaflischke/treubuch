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

        public async Task<string> BummelnAsync()
        {
            double zahl = await Task.Run(() => Wurzelsumme(1e9));
            //await Task.Delay(2000);
            return "Fertig mit Bummeln";
        }

        public string Troedeln()
        {
            double zahl = Wurzelsumme(2e9);
            return "Fertig mit Trödeln";
        }

        public async Task<string> TroedelnAsync()
        {
            double zahl = await Task.Run(() => Wurzelsumme(2e9));
            return "Fertig mit Trödeln";
        }

        private double Wurzelsumme(double max)
        {
            double result = 0;

            for (int i = 0; i < max; i++)
            {
                result += Math.Sqrt(i);
            }

            return result;
        }


        private async void MultiTask()
        {
            try
            {
                Task t1 = new Task(() => Wurzelsumme(1e9));
                Task t2 = new Task(() => Wurzelsumme(1e9));
                Task t3 = new Task(() => Wurzelsumme(1e9));

                t1.Start();
                t2.Start();
                t3.Start();

            }
            catch (AggregateException ex)
            {

                throw;
            }   
            catch (Exception ex)
            {

            }

        }
    }

}
