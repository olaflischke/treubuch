using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public static class ExtensionMethods
    {
        public static void PrintOut<T>(this IList<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }


        public static void Fressen(this Gefluegel gefluegel, double menge)
        {
            gefluegel.Gewicht += 2 * menge;
        }
    }
}
