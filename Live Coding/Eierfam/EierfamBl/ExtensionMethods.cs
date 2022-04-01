using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
  public static  class ExtensionMethods
    {
        
        public static void Fressen(this Gefluegel gefluegel, double menge)
        {
            gefluegel.Gewicht += 2 * menge;
        }
    }
}
