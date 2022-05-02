using EierfamBl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmUi.ViewModel
{
    public class EierfarmViewModel : INotifyPropertyChanged
    {

        public EierfarmViewModel()
        {
            this.NeuesHuhnCommand = new RelayCommand(p => CanNeuesHuhn(), a => NeuesHuhn());
            this.NeueGansCommand = new RelayCommand(p => CanNeueGans(), a => NeueGans());
            this.NeuesSchnabeltierCommand = new RelayCommand(p => CanNeuesSchnabeltier(), a => NeuesSchnabeltier());
            this.FuetternCommand = new RelayCommand(p => CanFuettern(), a => Fuettern());
            this.EiLegenCommand = new RelayCommand(p => CanEiLegen(), a => EiLegen());
        }

        public ObservableCollection<IEiLeger> Tiere { get; set; } = new ObservableCollection<IEiLeger>();

        private IEiLeger _selected;
        public IEiLeger SelectedTier
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NeuesHuhnCommand { get; set; }
        public RelayCommand NeueGansCommand { get; set; }
        public RelayCommand NeuesSchnabeltierCommand { get; set; }
        public RelayCommand FuetternCommand { get; set; }
        public RelayCommand EiLegenCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void NeuesHuhn()
        {
            Huhn huhn = new Huhn("Neues Huhn");
            this.Tiere.Add(huhn);
            this.SelectedTier = huhn;
        }

        private bool CanNeuesHuhn()
        {
            return true;
        }

        private bool CanNeueGans()
        {
            return true;
        }

        private void NeueGans()
        {
            Gans gans = new Gans();
            this.Tiere.Add(gans);
            this.SelectedTier = gans;
        }
        private bool CanNeuesSchnabeltier()
        {
            return true;
        }

        private void NeuesSchnabeltier()
        {
            Schnabeltier schnabeltier = new Schnabeltier();
            this.Tiere.Add(schnabeltier);
            this.SelectedTier = schnabeltier;
        }

        private bool CanFuettern()
        {
            if (this.SelectedTier != null)
            {
                return true;
            }
            return false;
        }

        private void Fuettern()
        {
            if (this.SelectedTier is ITier tier)
                tier.Fressen();
        }

        private bool CanEiLegen()
        {
            if (this.SelectedTier != null)
            {
                return true;
            }
            return false;
        }

        private void EiLegen()
        {
            this.SelectedTier.EiLegen();
        }


    }
}
