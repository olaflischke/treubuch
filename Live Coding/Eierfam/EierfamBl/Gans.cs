using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfamBl
{
    public class Gans : Gefluegel
    {
        public Gans() : base("Neue Gans")
        {
            this.Gewicht = 2000;
        }

        public Gans(string name) : this() // Konstrutkoren-Kaskade
        {
            this.Name = name;
        }

        public override void EiLegen()
        {
            if (this.Gewicht>2000)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }        }

        public override void Fressen()
        {
            if (this.Gewicht < 5000)
            {
                base.Fressen(250);
            }
        }

        /// <summary>
        /// Das Tier frisst
        /// </summary>
        /// <param name="menge">Die Menge, die direkt auf das Gewicht des Tiers aufgeschlagen wird.</param>
        public override void Fressen(double menge)
        {
            if (this.Gewicht < 5000)
            {
                base.Fressen(menge);
            }
        }

        /// <summary>
        /// Die Gans fliegt, eventuell den gg. Steuerkurs.
        /// </summary>
        /// <param name="steuerkurs">Den Kurs, den die Gans fliegen soll (optional).</param>
        /// <remarks>Wird der Steuerkus nicht angegeben, fliegt die Gans einfach Kreise um ihren aktuellen Standort.</remarks>
        public void Fliegen(int steuerkurs = -1) // optionaler Parameter
        {
            if (steuerkurs > -1)
            {
                // Fliegen nach Steuerkurs
            }
            else
            {
                // einfach rumfliegen
            }
        }

        //public void Fliegen()
        //{

        //}

        //public void Fliegen(int steuerkurs, double hoehe)
        //{

        //}
    }
}