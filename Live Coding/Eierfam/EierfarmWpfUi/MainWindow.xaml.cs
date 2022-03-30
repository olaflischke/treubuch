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

            //huhn.EigenschaftGeaendert += this.Huhn_EigenschaftGeaendert;

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        //private void Huhn_EigenschaftGeaendert(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("Huhn hat eine Eigenschaft geändert!");
        //    if (sender is Huhn huhn)
        //    {
        //        cbxTiere.SelectedItem = null;
        //        cbxTiere.SelectedItem = huhn;
        //    }
        //}

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is Huhn huhn)
            {
                huhn.EiLegen();
            }
            else
            {
                MessageBox.Show("Kein eilegefähiges Huhn gefunden.");
            }
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            Huhn huhn = cbxTiere.SelectedItem as Huhn; // SafeCast, liefert null, wenn Cast fehlschlägt
            if (huhn != null)
            {
                huhn.Fressen();
            }
            else
            {
                MessageBox.Show(messageBoxText: "Kein Huhn zum Füttern gefunden!");
            }
            
        }

    }
}
