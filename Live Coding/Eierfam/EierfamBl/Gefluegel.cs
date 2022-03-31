﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EierfamBl
{
    public abstract class Gefluegel : Tier, INotifyPropertyChanged, IEiLeger, IGefluegel
    {
        public Gefluegel(string name)
        {
            this.Name = name;
        }

        private string _name;

        private double _gewicht;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                //OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                //OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }

        
        private void OnPropertyChanged([CallerMemberName]string propName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public abstract void EiLegen(); // muss vom Erben implementiert werden

        public virtual void Fressen(double menge) // kann vom Erben implementiert werden
        {
            this.Gewicht += menge;
        }
    }
}