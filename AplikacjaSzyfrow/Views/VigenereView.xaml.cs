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
    /// Interaction logic for VigenereView.xaml
    /// </summary>
    public partial class VigenereView : Window
    {
        public VigenereView()
        {
            InitializeComponent();
        }

        public void Szyfrowanie(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.JawnyTEXT.Text))
            {
                this.ZaszyfrowanyTEXT.Text = Decipher(this.JawnyTEXT.Text, "cipher");
            }
        }

        public void Odszyfruj(object sender, RoutedEventArgs e) 
        {
            if (!String.IsNullOrEmpty(this.ZaszyfrowanyTEXT.Text))
            {
                this.JawnyTEXT.Text = Encipher(this.ZaszyfrowanyTEXT.Text, "cipher");
            }
        }

        public void Clear(object sender, RoutedEventArgs e)
        {
            this.ZaszyfrowanyTEXT.Text = "";
            this.JawnyTEXT.Text = "";
        }

        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static string Cipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null; // Error

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        public static string Encipher(string input, string key)
        {
            return Cipher(input, key, true);
        }

        public static string Decipher(string input, string key)
        {
            return Cipher(input, key, false);
        }
    }
}
