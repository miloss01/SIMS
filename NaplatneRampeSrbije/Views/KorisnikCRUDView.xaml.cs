using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for KorisnikCRUDView.xaml
    /// </summary>
    public partial class KorisnikCRUDView : Window
    {
        private readonly KorisnikCRUDController _korisnikCRUDController;

        public KorisnikCRUDView()
        {
            InitializeComponent();
            _korisnikCRUDController = new KorisnikCRUDController();
        }

        private void registrujRadnikaButton_Click(object sender, RoutedEventArgs e)
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

            bool uspesno = _korisnikCRUDController.NapraviRadnika(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresaId, mestoRadaId);
            if (uspesno)
            {
                _ = MessageBox.Show("Radnik uspesno registrovan"); 
                idTextBox.Clear();
                imeTextBox.Clear();
                prezimeTextBox.Clear();
                telefonTextBox.Clear();
                korisnickoImeTextBox.Clear();
                lozinkaTextBox.Clear();
                adresaIdTextBox.Clear();
                mestoRadaIdTextBox.Clear();
                muskoRadioButton.IsChecked = true;
                referentNaplateRadioButton.IsChecked = true;
            }
            else
            {
                _ = MessageBox.Show("Neuspesno registrovanje");
            }
        }

        private void prikaziSveRadnikeButton_Click(object sender, RoutedEventArgs e)
        {
            KorisnikRUDView korisnikRUDView = new KorisnikRUDView();
            korisnikRUDView.Show();
            Close();
        }
    }
}
