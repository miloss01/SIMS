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
using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;

namespace NaplatneRampeSrbije.Views
{
    /// <summary>
    /// Interaction logic for RucnaNaplataPutarineView.xaml
    /// </summary>
    public partial class RucnaNaplataPutarineView : Window
    {
        private readonly NaplatnoMestoController _naplatnoMestoController;

        public RucnaNaplataPutarineView()
        {
            InitializeComponent();
            _naplatnoMestoController = new NaplatnoMestoController();
            PopuniNaplatnaMestaIdComboBox();
            PopuniVrstaVozilaComboBox();
            PopuniValutaComboBox();
        }

        private void PopuniNaplatnaMestaIdComboBox()
        {
            foreach (NaplatnoMesto naplatnoMesto in _naplatnoMestoController.VratiSveNaplatneStanice())
            {
                mestoUlaskaIDComboBox.Items.Add(naplatnoMesto.ID);
                if (mestoUlaskaIDComboBox.SelectedItem == null)
                {
                    mestoUlaskaIDComboBox.SelectedItem = naplatnoMesto.ID;
                }
            }
        }

        private void PopuniVrstaVozilaComboBox()
        {
            vrstaVozilaComboBox.Items.Add(VrstaVozila.Automobil);
            vrstaVozilaComboBox.Items.Add(VrstaVozila.Kamion);
            vrstaVozilaComboBox.Items.Add(VrstaVozila.Autobus);
            vrstaVozilaComboBox.SelectedItem = VrstaVozila.Automobil;
        }

        private void PopuniValutaComboBox()
        {
            valutaComboBox.Items.Add(Valuta.Dinar);
            valutaComboBox.Items.Add(Valuta.Evro);
            valutaComboBox.Items.Add(Valuta.Dolar);
            valutaComboBox.SelectedItem = Valuta.Dinar;
        }

        private void generisanjeRacunaButton_Click(object sender, RoutedEventArgs e)
        {
            string mestoUlaskaID = mestoUlaskaIDComboBox.SelectedItem.ToString();
            VrstaVozila vrstaVozila = (VrstaVozila)vrstaVozilaComboBox.SelectedItem;
            Valuta valuta = (Valuta)valutaComboBox.SelectedItem;
            DateTime vremeIzlaska = DateTime.Now;

            if (_naplatnoMestoController.IstaNaplatnaStanica(mestoUlaskaID, Globals.ulogovaniRadnik.NaplatnoMesto.ID))
            {
                MessageBox.Show("Nije validan ID mesta ulaska");
                return;
            }

            GenerisanjeRacunaView generisanjeRacunaView = new GenerisanjeRacunaView(vrstaVozila, valuta, mestoUlaskaID, vremeIzlaska);
            generisanjeRacunaView.Show();
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            Globals.ulogovaniRadnik = null;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void kontrolaRampeButton_Click(object sender, RoutedEventArgs e)
        {
            mestoUlaskaIDComboBox.IsEnabled = !mestoUlaskaIDComboBox.IsEnabled;
            vrstaVozilaComboBox.IsEnabled = !vrstaVozilaComboBox.IsEnabled;
            valutaComboBox.IsEnabled = !valutaComboBox.IsEnabled;
            rampaJeBlokiranaCheckBox.IsChecked = !rampaJeBlokiranaCheckBox.IsChecked;
            generisanjeRacunaButton.IsEnabled = !generisanjeRacunaButton.IsEnabled;
            blokirajRampuButton.IsEnabled = !blokirajRampuButton.IsEnabled;
            odblokirajRampuButton.IsEnabled = !odblokirajRampuButton.IsEnabled;
        }
    }
}
