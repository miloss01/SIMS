using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;
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
    /// Interaction logic for KorisnikUView.xaml
    /// </summary>
    public partial class KorisnikUView : Window
    {
        private readonly KorisnikCRUDController _korisnikCRUDController;
        private readonly string _stariId;
        private readonly string _staroKorisnickoIme;
        private readonly string _staraLozinka;

        public KorisnikUView()
        {
            InitializeComponent();
        }

        public KorisnikUView(Radnik r)
        {
            InitializeComponent();
            PostaviVrijednosti(r);
            _stariId = r.ID;
            _korisnikCRUDController = new KorisnikCRUDController();
        }

        private void PostaviVrijednosti(Radnik r)
        {
            idTextBox.Text = r.ID;
            imeTextBox.Text = r.Ime;
            prezimeTextBox.Text = r.Prezime;
            telefonTextBox.Text = r.Telefon;
            korisnickoImeTextBox.Text = r.KorisnickoIme;
            lozinkaTextBox.Text = r.Lozinka;
            adresaIdTextBox.Text = r.Adresa.ID;

            string mestoRadaId = "";
            if (r.RadnoMesto == RadnoMesto.ReferentNaplate)
            {
                mestoRadaId = r.NaplatnoMesto.ID;
            }
            else if (r.RadnoMesto == RadnoMesto.SefNaplatneStanice)
            {
                mestoRadaId = r.NaplatnaStanica.ID;
            }
            mestoRadaIdTextBox.Text = mestoRadaId;
            switch (r.Pol)
            {
                case Pol.Muski:
                    muskoRadioButton.IsChecked = true;
                    break;
                case Pol.Zenski:
                    zenskoRadioButton.IsChecked = true;
                    break;
            }
            switch (r.RadnoMesto)
            {
                case RadnoMesto.ReferentNaplate:
                    referentNaplateRadioButton.IsChecked = true;
                    break;
                case RadnoMesto.SefNaplatneStanice:
                    sefNaplatneStaniceRadioButton.IsChecked = true;
                    break;
                case RadnoMesto.Menadzer:
                    menadzerRadioButton.IsChecked = true;
                    break;
                case RadnoMesto.Admininstrator:
                    administratorRadioButton.IsChecked = true;
                    break;
            }
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            KorisnikCRUDView korisnikCRUDView = new KorisnikCRUDView();
            korisnikCRUDView.Show();
        }

        private void izmeniRadnikaButton_Click(object sender, RoutedEventArgs e)
        {
            string id = idTextBox.Text;
            string ime = imeTextBox.Text;
            string prezime = prezimeTextBox.Text;
            Pol pol = Pol.Muski;
            string telefon = telefonTextBox.Text;
            RadnoMesto radnoMesto = RadnoMesto.ReferentNaplate;
            string korisnickoIme = korisnickoImeTextBox.Text;
            string lozinka = lozinkaTextBox.Text;
            string adresaId = adresaIdTextBox.Text;
            string mestoRadaId = mestoRadaIdTextBox.Text;

            if ((bool)zenskoRadioButton.IsChecked)
            {
                pol = Pol.Zenski;
            }

            if ((bool)sefNaplatneStaniceRadioButton.IsChecked)
            {
                radnoMesto = RadnoMesto.SefNaplatneStanice;
            }
            else if ((bool)menadzerRadioButton.IsChecked)
            {
                radnoMesto = RadnoMesto.Menadzer;
            }
            else if ((bool)administratorRadioButton.IsChecked)
            {
                radnoMesto = RadnoMesto.Admininstrator;
            }

            bool uspesno = _korisnikCRUDController.IzmijeniRadnika(_stariId, id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresaId, mestoRadaId);
            if (uspesno)
            {
                _ = MessageBox.Show("Radnik uspesno izmenjen");
                Close();
            }
            else
            {
                _ = MessageBox.Show("Neuspesna izmena");
            }
        }

        private void referentIliSefRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mestoRadaIdTextBox.IsEnabled = true;
        }

        private void menadzerIliAdministratorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mestoRadaIdTextBox.IsEnabled = false;
        }
    }
}
