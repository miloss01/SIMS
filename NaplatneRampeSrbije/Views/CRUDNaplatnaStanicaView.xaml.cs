using NaplatneRampeSrbije.Controllers;
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
    /// Interaction logic for CRUDNaplatnaStanicaView.xaml
    /// </summary>
    public partial class CRUDNaplatnaStanicaView : Window
    {
        private NaplatnaStanicaCRUDController _controller;

        public CRUDNaplatnaStanicaView()
        {
            InitializeComponent();
            _controller = new NaplatnaStanicaCRUDController();
            NapuniDataGridNaplatneStanice();
        }

        private void NapuniDataGridNaplatneStanice()
        {
            DataGridNaplatneStanice.Items.Clear();
            List<NaplatnaStanicaDTO> naplatneStanice = _controller.PreuzmiNapltneStaniceZaPrikaz();
            foreach (NaplatnaStanicaDTO naplatnaStanica in naplatneStanice)
            {
                DataGridNaplatneStanice.Items.Add(naplatnaStanica);
            }
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ulica = UlicaTextBox.Text;
                string broj = BrojTextBox.Text;
                string postanskiBroj = PostanskiBrojTextBox.Text;
                _controller.KreirajNaplatnuStanicu(ulica, broj, postanskiBroj);
                MessageBox.Show("Uspesno ste kreirali naplatnu stanicu!");
                NapuniDataGridNaplatneStanice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = IdNaplatneStaniceTextBox.Text;
                string ulica = UlicaTextBox.Text;
                string broj = BrojTextBox.Text;
                string postanskiBroj = PostanskiBrojTextBox.Text;
                _controller.IzmeniNaplatnuStanicu(id, ulica, broj, postanskiBroj);
                MessageBox.Show("Uspesno ste izmenili naplatnu stanicu!");
                NapuniDataGridNaplatneStanice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = IdNaplatneStaniceTextBox.Text;
                _controller.IzbrisiNaplatnuStanicu(id);
                MessageBox.Show("Uspesno ste obrisali naplatnu stanicu!");
                NapuniDataGridNaplatneStanice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}