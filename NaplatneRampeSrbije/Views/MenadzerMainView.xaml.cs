using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NaplatneRampeSrbije.Views
{
    /// <summary>
    /// Interaction logic for MenadzerMainView.xaml
    /// </summary>
    public partial class MenadzerMainView : Window
    {
        public MenadzerMainView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StatistikaValuteView statistikaValuteView = new StatistikaValuteView();
            statistikaValuteView.Show();
        }
    }
}
