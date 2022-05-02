using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1; // = 0

            int? a2 = null; // Wert aus einem Feld in der DB, das NULL deklariert
            System.Nullable<int> a2n = null;

            // Ohne Nullable:
            string a2s = null;
            int a2z = -1; // -99;

            // ZUsamenarbeit von Nullables mit Nicht-Nullables
            int b1 = a2.HasValue ? a2.Value : 0;
            int b2 = a2 ?? 0;


        }
    }
}
