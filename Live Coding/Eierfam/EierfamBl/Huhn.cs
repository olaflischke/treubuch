using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class Huhn : Gefluegel
    {

        public Huhn(string name) : base(name)
        {
            this.Name = name;
            this.Gewicht = 1000;
        }

        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }

        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                //this.Gewicht = this.Gewicht + 100;
                this.Gewicht += 100;
            }
        }

        //public override void Fressen(double menge)
        //{
        //    if (this.Gewicht < 3000)
        //    {
        //        this.Gewicht += menge;
        //    }
        //}
    }
}
