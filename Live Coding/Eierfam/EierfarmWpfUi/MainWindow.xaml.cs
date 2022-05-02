using EierfamBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EierfarmWpfUi
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, RoutedEventArgs e)
        {
            Huhn huhn = new Huhn("Neues Huhn");

            huhn.EigenschaftGeaendert += this.Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void btnNeueGans_Click(object sender, RoutedEventArgs e)
        {
            Gans gans = new Gans();

            gans.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }


        private void Gefluegel_EigenschaftGeaendert(object sender, GefluegelEventArgs e)
        {
            //string hallo = "Hallo"; // Strings are immutable! String = Char[]
            //string welt = "Welt";
            //string meldung = hallo + " " + welt;

            //StringBuilder builder = new StringBuilder("Hallo");
            //builder.Append(" ");
            //builder.Append("Welt");
            //string meldung2 = builder.ToString();


            //MessageBox.Show($"Tier {((Gefluegel)sender).Name} hat Eigenschaft {e.GeaenderteEigenschaft} geändert!");

        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            //IEiLeger eiLeger = cbxTiere.SelectedItem as IEiLeger;
            //if (eiLeger != null)
            if (cbxTiere.SelectedItem is IEiLeger viech)
            {
                viech.EiLegen();
            }
            else
            {
                MessageBox.Show("Kein eilegefähiges viech gefunden.");
            }
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            ITier viech = cbxTiere.SelectedItem as ITier; // SafeCast, liefert null, wenn Cast fehlschlägt

            if (viech != null)
            {
                //if (viech is Huhn huhn)
                //{
                //    // Implementierung aus Gefluegel oder aus ExtensionMethod?
                //    // -> Gefluegel!
                //    huhn.Fressen(300);
                //}
                //else
                //{
                viech.Fressen();
                //}
            }
            else
            {
                MessageBox.Show(messageBoxText: "Kein Huhn zum Füttern gefunden!");
            }

        }

        private void btnNeuesSchnabeltier_Click(object sender, RoutedEventArgs e)
        {
            Schnabeltier schnabeltier = new Schnabeltier();

            cbxTiere.Items.Add(schnabeltier);
            cbxTiere.SelectedItem = schnabeltier;
        }
    }
}
