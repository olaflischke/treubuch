using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class Huhn : INotifyPropertyChanged
    {
        public event EventHandler EigenschaftGeaendert;
        public event PropertyChangedEventHandler PropertyChanged;

        public Huhn(string name)
        {
            this.Name = name;
            this.Gewicht = 1000;
        }

        private void OnEigenschaftGeaendert()
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new EventArgs());
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private double _gewicht;

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                //OnEigenschaftGeaendert();
                OnPropertyChanged("Gewicht");
            }
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                //OnEigenschaftGeaendert();
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        public void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }

        }

        public void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                //this.Gewicht = this.Gewicht + 100;
                this.Gewicht += 100;
            }
        }
    }
}
