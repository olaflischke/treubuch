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

namespace BummlerUi
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bummler bummler;

        public MainWindow()
        {
            InitializeComponent();

            bummler = new Bummler();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            lblBmmeln.Content = "";
            //lblBmmeln.Content = bummler.Bummeln();
            lblBmmeln.Content = await bummler.BummelnAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lblTroedeln.Content = "";
            //lblTroedeln.Content = bummler.Troedeln();
            lblTroedeln.Content = await bummler.TroedelnAsync();
        }
    }
}
