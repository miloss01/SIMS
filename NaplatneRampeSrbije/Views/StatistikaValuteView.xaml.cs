using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;
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
    /// Interaction logic for StatistikaValuteView.xaml
    /// </summary>
    public partial class StatistikaValuteView : Window
    {
        private StatistikaValuteController statistikaValuteController = new StatistikaValuteController();

        public StatistikaValuteView()
        {
            InitializeComponent();
        }

        private void FillCombobox()
        {
            foreach (NaplatnaStanica ns in statistikaValuteController.GetAllNaplatnaStanica())
                combobox1.Items.Add(ns.ID);

            combobox2.Items.Add($"{Valuta.Dinar}");
            combobox2.Items.Add($"{Valuta.Evro}");
            combobox2.Items.Add($"{Valuta.Dolar}");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            FillCombobox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string naplatnaStanicaId = combobox1.SelectedValue == null ? "" : combobox1.SelectedValue.ToString();
            Valuta valuta = combobox2.SelectedValue == null ? Valuta.Dinar : (Valuta) Enum.Parse(typeof(Valuta), combobox2.SelectedValue.ToString());

            int brojPlacanja = statistikaValuteController.GetBrojPlacanjaUValutiZaStanicu(naplatnaStanicaId, valuta);
            double suma = statistikaValuteController.GetSumuPlacanjaUValutiZaStanicu(naplatnaStanicaId, valuta);

            label1.Content = "Broj placanja: " + brojPlacanja.ToString();
            label2.Content = "Ukupna suma: " + suma.ToString();
        }
    }
}
