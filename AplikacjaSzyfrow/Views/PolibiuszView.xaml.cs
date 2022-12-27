using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            if (!String.IsNullOrEmpty(this.JawnyTEXT.Text))
            {
                this.ZaszyfrowanyTEXT.Text = SzyfrowaniePolibiusza(this.JawnyTEXT.Text).ToString();
            }
        }

        public void Odszyfruj(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ZaszyfrowanyTEXT.Text))
            {
                this.JawnyTEXT.Text = OdszyfrowaniePolibiusza(this.ZaszyfrowanyTEXT.Text).ToString();
            }
        }

        public void Clear(object sender, RoutedEventArgs e)
        {
            this.ZaszyfrowanyTEXT.Text = "";
            this.JawnyTEXT.Text = "";
        }

        public static StringBuilder SzyfrowaniePolibiusza(string text)
        {
            StringBuilder stringB = new StringBuilder();

            int row, col;

            for (int i = 0;
                 i < text.Length; i++)
            {
                // finding row of the table
                row = (int)Math.Floor((text[i] -
                             'a') / 5.0) + 1;

                // finding column
                // of the table
                col = ((text[i] - 'a') % 5) + 1;

                // if character is 'k'
                if (text[i] == 'k')
                {
                    row = row - 1;
                    col = 5 - col + 1;
                }

                // if character is
                // greater than 'j'
                else if (text[i] >= 'j')
                {
                    if (col == 1)
                    {
                        col = 6;
                        row = row - 1;
                    }
                    col = col - 1;
                }
                stringB.Append(row.ToString()+col.ToString());
            }

                return stringB;
        }

        public static String OdszyfrowaniePolibiusza(String crypt)
        {
            int len = crypt.Length;
            StringBuilder plain = new StringBuilder(len / 2);

            char[ , ] polybiusSquare = {{ 'A', 'B', 'C', 'D', 'E'},
                                        { 'F', 'G', 'H', 'I' /*and J*/, 'K'},
                                        { 'L', 'M', 'N', 'O', 'P'},
                                        { 'Q', 'R', 'S', 'T', 'U'},
                                        { 'V', 'W', 'X', 'Y', 'Z'},
        };

            for (int i = 0; i < len; i += 2)
            {
                int rowIndex = crypt.ElementAt(i) - '0' - 1;
                int colIndex = crypt.ElementAt(i+1) - '0' - 1;
                plain.Append(polybiusSquare[rowIndex,colIndex]);
            }

            return plain.ToString().ToLower();
        }
    }
}
