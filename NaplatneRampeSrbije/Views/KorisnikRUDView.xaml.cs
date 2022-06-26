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
    /// Interaction logic for KorisnikRUDView.xaml
    /// </summary>
    public partial class KorisnikRUDView : Window
    {
        private readonly KorisnikCRUDController _korisnikCRUDController;
        private bool otvaranjeIzmjeneRadnika;

        public KorisnikRUDView()
        {
            InitializeComponent();
            _korisnikCRUDController = new KorisnikCRUDController();
            KreirajRadnikTabelu();
            NapuniRadnikTabelu();
            otvaranjeIzmjeneRadnika = false;
        }

        private void KreirajRadnikTabelu()
        {
            DataGridTextColumn col1 = new DataGridTextColumn();
            DataGridTextColumn col2 = new DataGridTextColumn();
            DataGridTextColumn col3 = new DataGridTextColumn();
            DataGridTextColumn col4 = new DataGridTextColumn();
            DataGridTextColumn col5 = new DataGridTextColumn();
            DataGridTextColumn col6 = new DataGridTextColumn();
            DataGridTextColumn col7 = new DataGridTextColumn();
            DataGridTextColumn col8 = new DataGridTextColumn();
            DataGridTextColumn col9 = new DataGridTextColumn();
            DataGridTextColumn col10 = new DataGridTextColumn();
            radniciDataGrid.Columns.Add(col1);
            radniciDataGrid.Columns.Add(col2);
            radniciDataGrid.Columns.Add(col3);
            radniciDataGrid.Columns.Add(col4);
            radniciDataGrid.Columns.Add(col5);
            radniciDataGrid.Columns.Add(col6);
            radniciDataGrid.Columns.Add(col7);
            radniciDataGrid.Columns.Add(col8);
            radniciDataGrid.Columns.Add(col9);
            radniciDataGrid.Columns.Add(col10);
            col1.Binding = new Binding("ID");
            col2.Binding = new Binding("Ime");
            col3.Binding = new Binding("Prezime");
            col4.Binding = new Binding("Pol");
            col5.Binding = new Binding("Telefon");
            col6.Binding = new Binding("RadnoMesto");
            col7.Binding = new Binding("KorisnickoIme");
            col8.Binding = new Binding("Lozinka");
            col9.Binding = new Binding("Adresa");
            col10.Binding = new Binding("MestoRadaID");
            col1.Header = "ID";
            col2.Header = "Ime";
            col3.Header = "Prezime";
            col4.Header = "Pol";
            col5.Header = "Telefon";
            col6.Header = "Radno mesto";
            col7.Header = "Korisnicko ime";
            col8.Header = "Lozinka";
            col9.Header = "Adresa";
            col10.Header = "Mesto rada ID";
        }

        private void NapuniRadnikTabelu()
        {
            foreach (Radnik radnik in _korisnikCRUDController.VratiSveRadnike())
            {
                radniciDataGrid.Items.Add(radnik);
            }
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            if (!otvaranjeIzmjeneRadnika)
            {
                KorisnikCRUDView korisnikCRUDView = new KorisnikCRUDView();
                korisnikCRUDView.Show();
            }
        }

        private void izmenaRadnikaButton_Click(object sender, RoutedEventArgs e)
        {
            Radnik r = radniciDataGrid.SelectedItem as Radnik;
            if (r == null)
            {
                MessageBox.Show("Radnik nije izabran");
                return;
            }

            KorisnikUView korisnikUView = new KorisnikUView(r);
            korisnikUView.Show();
            otvaranjeIzmjeneRadnika = true;
            Close();
        }

        private void ukloniRadnikaButton_Click(object sender, RoutedEventArgs e)
        {
            Radnik r = radniciDataGrid.SelectedItem as Radnik;
            if (r == null)
            {
                MessageBox.Show("Radnik nije izabran");
                return;
            }

            _korisnikCRUDController.UkloniRadnika(r.ID);
            MessageBox.Show("Uspesno uklonjen radnik");
            Close();
        }
    }
}
