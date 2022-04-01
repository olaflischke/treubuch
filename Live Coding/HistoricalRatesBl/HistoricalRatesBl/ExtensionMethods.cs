using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalRatesDal
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Prüft den String auf numerische Auswertbarkeit
        /// </summary>
        /// <param name="text">Der zu prüfende String</param>
        /// <returns>True, wenn der String als Zahl verwendbar ist.</returns>
        public static bool IsNumeric(this string text)
        {
            //double zahl;
            //if (double.TryParse(text, out zahl))
            //{
            //    return true;
            //}

            //return false;

            return double.TryParse(text, out _);
        }

        /// <summary>
        /// Fügt der Liste ein Element an, wenn es noch nicht vorhanden ist.
        /// </summary>
        /// <typeparam name="T">Typ des Elements</typeparam>
        /// <param name="list">Die Liste</param>
        /// <param name="element">Das hinzuzufügende Element</param>
        /// <remarks>Demo für ene generische Extension-Method, funktioniert wegen Contains nur für primitive Typen (int, double..)</remarks>
        public static void AddIfNew<T>(this List<T> list, T element)
        {
            if (!list.Contains(element))
            {
                list.Add(element);
            }
        }
    }
}
