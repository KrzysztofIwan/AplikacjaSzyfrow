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
            if (!String.IsNullOrEmpty(this.JawnyTEXT.Text.ToString()) && int.Parse(this.Przesuniecie.Text) > 0)
            {
                this.ZaszyfrowanyTEXT.Text = Encipher(this.JawnyTEXT.Text.ToString(), int.Parse(this.Przesuniecie.Text));
            }

        }

        public void Odszyfruj(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ZaszyfrowanyTEXT.Text.ToString()) && int.Parse(this.Przesuniecie.Text) > 0)
            {
                this.JawnyTEXT.Text = Decipher(this.ZaszyfrowanyTEXT.Text.ToString(), int.Parse(this.Przesuniecie.Text));
            }
        }

        public void Clear(object sender, RoutedEventArgs e)
        {
            this.JawnyTEXT.Text = "";
            this.ZaszyfrowanyTEXT.Text = "";
            this.Przesuniecie.Text = "";
        }


        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }


        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
    }
}
