﻿using System;
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
using AplikacjaSzyfrow.ViewModels;

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
            DataContext = new CezarModel();
        }
    }
}
