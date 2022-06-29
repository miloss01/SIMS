using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void statistikaValuteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StatistikaValuteView statistikaValuteView = new StatistikaValuteView();
            statistikaValuteView.Show();
        }

        private void statistikaProlaskaVozilaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StatistikaProlaskaVozilaView statistikaProlaskaVozila = new StatistikaProlaskaVozilaView();
            statistikaProlaskaVozila.Show();
        }

        private void statistikaONaplatamaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StatistikaBrojaNaplata statistikaBrojaNaplata = new StatistikaBrojaNaplata();
            statistikaBrojaNaplata.Show();
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            Globals.ulogovaniRadnik = null;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}