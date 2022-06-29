using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
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
    /// Interaction logic for StatistikaBrojaNaplataZaOdabraniDan.xaml
    /// </summary>
    public partial class StatistikaBrojaNaplata : Window
    {
        private StatistikaBrojaNaplataController _controller;

        public StatistikaBrojaNaplata()
        {
            _controller = new StatistikaBrojaNaplataController();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string izabraniDatum = ZeljeniDatumPicker.Text;
                int brNaplata = _controller.PreuzmiBrojNaplata(izabraniDatum);
                double zarada = _controller.PreuzmiZaradu(izabraniDatum);
                UkupanBrojNaplata.Content = brNaplata.ToString();
                UkupnaZarada.Content = zarada.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}