using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class Ente : Gefluegel
    {
        public Ente():base("Neue Ente")
        {
            this.Gewicht = 750;
        }

        public override void EiLegen()
        {
            if (this.Gewicht>1000)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht<2500)
            {
                this.Gewicht += 100;
            }
        }
    }
}
