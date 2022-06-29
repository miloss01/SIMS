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
    /// Interaction logic for SefNaplatneStaniceView.xaml
    /// </summary>
    public partial class SefNaplatneStaniceView : Window
    {
        private KvarRepo kvarRepo;
        public SefNaplatneStaniceView()
        {
            kvarRepo = new KvarRepo();
            InitializeComponent();
        }

        private void PrijavaKvaraButton_Click(object sender, RoutedEventArgs e)
        {
            PrijavaKvaraView prijavaKvaraView = new PrijavaKvaraView(kvarRepo);
            prijavaKvaraView.Show();
        }

        private void PregledKvarovaButton_Click(object sender, RoutedEventArgs e)
        {
            PregledKvarovaView pregledKvarovaView = new PregledKvarovaView();
            pregledKvarovaView.Show();
        }
    }
}
