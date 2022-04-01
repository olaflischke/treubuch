using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    /// <summary>
    /// Stellt ein Ei dar.
    /// </summary>
    public class Ei
    {
        // Irgendwo im restlichen Code (zB. UI)
        // Ei ei = new Ei();
        public Ei()//IEiLeger mutter)
        {
            //this.Mutter = mutter;
            Random random = new Random();
            this.Gewicht = random.Next(45, 80);
            this.Farbe = (EiFarbe)random.Next(Enum.GetNames(typeof(EiFarbe)).Length); // DirectCast, kann Exception liefern, wenn der Cast fehlschlägt!
        }

        // ei.Gewicht2 = 60;
        // Öffentliches Feld
        //public double Gewicht2{ get; set; }

        // Full-qualified Property

        // Backing Field
        private double _gewicht;

        // Öffentlicher Teil
        public double Gewicht
        {
            // var g = ei.Gewicht;
            get { return _gewicht; }

            // ei.Gewicht = 60;
            set
            {
                if (value > 0)
                {
                    _gewicht = value;
                }
            }
        }

        // Auto-Property
        // Property mit automatisch generiertem Backing Field
        // Auto-Property-Initializer
        public DateTime Legedatum { get; private set; } = DateTime.Now;

        //private DateTime _legeDatum = DateTime.Now;

        //public DateTime Legedatum
        //{
        //    get { return _legeDatum; }
        //    private set { _legeDatum = value; }
        //}

        /// <summary>
        /// Gibt die Id des Eis zurück oder legt sie fest.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        //public IEiLeger Mutter { get; set; }

        public EiFarbe Farbe { get; set; }
    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }
}
