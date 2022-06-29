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
    /// Interaction logic for PrijavaKvaraView.xaml
    /// </summary>
    public partial class PrijavaKvaraView : Window
    {
        private PrijavaKvaraController _prijavaKvaraController;
        public PrijavaKvaraView(KvarRepo kvarRepo)
        {
            _prijavaKvaraController = new PrijavaKvaraController(this, kvarRepo);
            InitializeComponent();
        }

        private void PosaljiButton_Click(object sender, RoutedEventArgs e)
        {
            _prijavaKvaraController.PokupiPodatke();
        }
    }
}
