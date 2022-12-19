using AplikacjaSzyfrow.ViewModels;
using AplikacjaSzyfrow.Views;
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

namespace AplikacjaSzyfrow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CerazShow(object sender, RoutedEventArgs e)
        {
            DataContext = new CezarModel();
            CezarView page = new CezarView();
            page.ShowDialog();
        }
        public void PolibiuszShow(object sender, RoutedEventArgs e)
        {
            DataContext = new PolibiuszModel();
            PolibiuszView page = new PolibiuszView();
            page.ShowDialog();
        }
        public void VigenèreShow(object sender, RoutedEventArgs e)
        {
            DataContext = new VigenereModel();
            VigenereView page = new VigenereView();
            page.ShowDialog();
        }
    }
}
