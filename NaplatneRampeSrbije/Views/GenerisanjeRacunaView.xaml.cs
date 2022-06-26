using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Interaction logic for GenerisanjeRacunaView.xaml
    /// </summary>
    public partial class GenerisanjeRacunaView : Window
    {
        RacunController racunController = new RacunController();
        private VrstaVozila VrstaVozila { get; set; }
        private Valuta Valuta { get; set; }
        private string NaplatnoMestoUlazakId { get; set; }
        private DateTime VremeIzlaska { get; set; }
        public GenerisanjeRacunaView(VrstaVozila vrstaVozila, Valuta valuta, string naplatnoMestoUlazakId, DateTime vremeIzlaska)
        {
            InitializeComponent();
            VrstaVozila = vrstaVozila;
            Valuta = valuta;
            NaplatnoMestoUlazakId = naplatnoMestoUlazakId;
            VremeIzlaska = vremeIzlaska;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txtUlazakId.Text = NaplatnoMestoUlazakId;
            txtVozilo.Text = VrstaVozila.ToString();
            txtValuta.Text = Valuta.ToString();
            txtVremeIzlazak.Text = VremeIzlaska.ToString(Globals.formatDatumVreme);

            double zaPlacanje = racunController.GetCenaZaDeonicuIVozilo(NaplatnoMestoUlazakId, VrstaVozila);

            txtZaPlacanje.Text = zaPlacanje.ToString();
        }

        private void txtUplaceno_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUplaceno.Text))
                return;

            double uplaceno = double.Parse(txtUplaceno.Text);
            double zaPlacanje = double.Parse(txtZaPlacanje.Text);

            double kusur = uplaceno - zaPlacanje;

            txtKusur.Text = kusur.ToString();
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = true;
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string racunId = txtRacunId.Text;
            string vozilo = txtVozilo.Text;
            string cena = txtZaPlacanje.Text;
            string valuta = txtValuta.Text;
            DateTime vremeIzlaska = DateTime.Parse(txtVremeIzlazak.Text);
            string izlazakMestoId = Globals.ulogovaniRadnik.NaplatnoMesto.ID;
            string ulazakMestoId = txtUlazakId.Text;

            bool success = racunController.SaveRacun(racunId, vozilo, cena, valuta, vremeIzlaska, izlazakMestoId, ulazakMestoId);

            if (success)
                MessageBox.Show("Uspesno placanje.");
            else
                MessageBox.Show("Neuspesno placanje.");
        }
    }
}
