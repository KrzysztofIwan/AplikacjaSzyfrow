using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Web;

namespace AplikacjaSzyfrow.Views
{
    /// <summary>
    /// Interaction logic for CezarView.xaml
    /// </summary>
    public partial class CezarView : Window
    {
        public CezarView()
        {
            InitializeComponent();
        }

        public void Szyfrowanie(object sender, RoutedEventArgs e)
        {
            string text = this.JawnyTEXT.Text.ToString();
            int przesuniecie = 2;
            if (!String.IsNullOrEmpty(text))
            {
                StringBuilder zaszyforwane = WykonajSzyfrowanie(text, przesuniecie);
                this.ZaszyfrowanyTEXT.Text = zaszyforwane.ToString();
            }

        }

        public void Odszyfruj(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Odszyfrowywanie");
        }


        public static StringBuilder WykonajSzyfrowanie(String text, int s)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    char ch = (char)(((int)text[i] +
                                    s - 65) % 26 + 65);
                    result.Append(ch);
                }
                else
                {
                    char ch = (char)(((int)text[i] +
                                    s - 97) % 26 + 97);
                    result.Append(ch);
                }
            }
            return result;
        }
    }
}
