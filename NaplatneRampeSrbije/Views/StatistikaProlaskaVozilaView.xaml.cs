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
    /// Interaction logic for StatistikaProlaskaVozilaView.xaml
    /// </summary>
    public partial class StatistikaProlaskaVozilaView : Window
    {
        private readonly NaplatnoMestoController _naplatnoMestoController;

        public StatistikaProlaskaVozilaView()
        {
            InitializeComponent();
            _naplatnoMestoController = new NaplatnoMestoController();
            PopuniNaplatnaMestaIdComboBox();
        }

        private void PopuniNaplatnaMestaIdComboBox()
        {
            foreach (NaplatnoMesto naplatnoMesto in _naplatnoMestoController.VratiSveNaplatneStanice())
            {
                naplatnoMestoIDTextBox.Items.Add(naplatnoMesto.ID);
                if (naplatnoMestoIDTextBox.SelectedItem == null)
                {
                    naplatnoMestoIDTextBox.SelectedItem = naplatnoMesto.ID;
                }
            }
        }

        private void generisiIzvestajButton_Click(object sender, RoutedEventArgs e)
        {
            string naplatnoMestoId = naplatnoMestoIDTextBox.Text;
            VrstaVozila najcesceVozilo = _naplatnoMestoController.VratiNajcesceProlazeceVozilo(naplatnoMestoId);
            najcescaVrstaVozilaTextBox.Text = najcesceVozilo.ToString();
        }
    }
}
