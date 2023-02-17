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
    /// Interaction logic for PlayfairView.xaml
    /// </summary>
    public partial class PlayfairView : Window
    {
        public PlayfairView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Losuj(object sender, RoutedEventArgs e)
        {
            string[] tablica = { "a", "ą", "b", "c", "ć", "d", "e", "ę", "f", "g", "h", "i", "j", "k", "l", "ł", "m", 
                "n", "ń", "o", "ó", "p", "q", "r", "s", "ś", "t", "u", "v", "w", "x", "y", "z", "ź", "ż" };

            object[] pola = {this.T1.Text, this.T2.Text, this.T3.Text, this.T4.Text, this.T5.Text, this.T6.Text, this.T7.Text, this.T8.Text,
                this.T9, this.T10.Text, this.T11.Text, this.T12.Text, this.T13.Text, this.T14.Text, this.T15.Text, this.T16.Text, this.T17.Text,
                this.T18.Text, this.T19.Text,this.T20.Text, this.T21.Text, this.T22.Text,this.T23.Text, this.T24.Text, this.T25.Text, this.T26.Text,
                this.T27.Text, this.T28.Text, this.T29.Text,this.T30.Text, this.T31.Text, this.T32.Text,this.T33.Text, this.T34.Text, this.T35.Text};
            tablica = tablica.OrderBy(x => Guid.NewGuid()).ToArray();
            int i = 0;

            this.T1.Text = tablica[0];
            this.T2.Text = tablica[1];
            this.T3.Text = tablica[2];
            this.T4.Text = tablica[3];
            this.T5.Text = tablica[4];
            this.T6.Text = tablica[5];
            this.T7.Text = tablica[6];
            this.T8.Text = tablica[7];
            this.T9.Text = tablica[8];
            this.T10.Text = tablica[9];
            this.T11.Text = tablica[10];
            this.T12.Text = tablica[11];
            this.T13.Text = tablica[12];
            this.T14.Text = tablica[13];
            this.T15.Text = tablica[14];
            this.T16.Text = tablica[15];
            this.T17.Text = tablica[16];
            this.T18.Text = tablica[17];
            this.T19.Text = tablica[18];
            this.T20.Text = tablica[19];
            this.T21.Text = tablica[20];
            this.T22.Text = tablica[21];
            this.T23.Text = tablica[22];
            this.T24.Text = tablica[23];
            this.T25.Text = tablica[24];
            this.T26.Text = tablica[25];
            this.T27.Text = tablica[26];
            this.T28.Text = tablica[27];
            this.T29.Text = tablica[28];
            this.T30.Text = tablica[29];
            this.T31.Text = tablica[30];
            this.T32.Text = tablica[31];
            this.T33.Text = tablica[32];
            this.T34.Text = tablica[33];
            this.T35.Text = tablica[34];
        }
    }
}
