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
using System.Windows.Shapes;

namespace AplikacjaSzyfrow.Views
{
    /// <summary>
    /// Interaction logic for PolibiuszView.xaml
    /// </summary>
    public partial class PolibiuszView : Window
    {
        public PolibiuszView()
        {
            InitializeComponent();
        }

        public void Szyfrowanie(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Szyfrowanie");
        }

        public void Odszyfruj(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Odszyfrowywanie");
        }
    }
}
