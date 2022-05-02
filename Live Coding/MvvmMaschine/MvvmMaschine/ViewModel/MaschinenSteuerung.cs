using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmMaschine.ViewModel
{
    public class MaschinenSteuerung //: INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public MaschinenSteuerung()
        {
            this.Maschine = new TennisballWurfmaschine();

            this.StartenCommand = new RelayCommand(p => CanStarten(), a => Starten());
            this.StoppenCommand = new RelayCommand(p => CanStoppen(), a => Stoppen());
        }

        private bool CanStoppen()
        {
            return this.Maschine.IstAmLaufen;
        }

        private async void Stoppen()
        {
            this.Maschine.Stopp();
            //try
            //  {
            //      //this.Maschine.Stopp();
            //      await Task.Run(() => this.Maschine.StoppAsync());

            //  }
            //  catch (Exception)
            //  {

            //      throw;
            //  }
        }


        private bool CanStarten()
        {
            return !this.Maschine.IstAmLaufen;
        }

        private void Starten()
        {
            this.Maschine.Start();
        }

        public TennisballWurfmaschine Maschine { get; set; }

        public RelayCommand StartenCommand { get; set; }
        public RelayCommand StoppenCommand { get; set; }
    }
}
