using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EierfamBl
{
    public class Schnabeltier : Saeugetier, IEiLeger, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        private double _gewicht;

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Gewicht)));
            }
        }


        public void EiLegen()
        {
            if (this.Gewicht > 2000)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            this.Gewicht += 250;
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}