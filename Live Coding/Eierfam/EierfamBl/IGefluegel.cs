using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EierfamBl
{
    public interface IGefluegel
    {
        ObservableCollection<Ei> Eier { get; set; }
        double Gewicht { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void EiLegen();
        void Fressen(double menge);
    }
}