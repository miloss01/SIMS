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
    /// Interaction logic for NaplatnoMestoCRUDView.xaml
    /// </summary>
    public partial class NaplatnoMestoCRUDView : Window
    {
        private class NaplatnoMestoOverview
        {
            public string ID { get; set; }
            public string NaplatnaStanicaID { get; set; }
            public bool ElNaplata { get; set; }
        }


        private NaplatnoMestoCRUDController naplatnoMestoCRUDController;

        public NaplatnoMestoCRUDView()
        {
            InitializeComponent();
            naplatnoMestoCRUDController = new NaplatnoMestoCRUDController();
        }

        private void InitDataGrid()
        {
            DataGridTextColumn col1 = new DataGridTextColumn();
            DataGridTextColumn col2 = new DataGridTextColumn();
            DataGridTextColumn col3 = new DataGridTextColumn();
            dataGrid.Columns.Add(col1);
            dataGrid.Columns.Add(col2);
            dataGrid.Columns.Add(col3);
            col1.Binding = new Binding("ID");
            col2.Binding = new Binding("NaplatnaStanicaID");
            col3.Binding = new Binding("ElNaplata");
            col1.Header = "Naplatno Mesto ID";
            col2.Header = "Naplatna Stanica ID";
            col3.Header = "Elektronska naplata";
        }

        private void FillCombobox()
        {
            foreach (NaplatnaStanica ns in naplatnoMestoCRUDController.GetAllNaplatnaStanica())
                combobox.Items.Add(ns.ID);
        }

        private void FillDataGrid()
        {
            dataGrid.Items.Clear();
            foreach (NaplatnoMesto nm in naplatnoMestoCRUDController.GetAllNaplatnoMesto())
                dataGrid.Items.Add(new NaplatnoMestoOverview { ID=nm.ID, NaplatnaStanicaID=nm.NaplatnaStanica.ID, ElNaplata=nm.ElNaplata });
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            FillCombobox();
            InitDataGrid();
            FillDataGrid();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NaplatnoMestoOverview selected = dataGrid.SelectedItem as NaplatnoMestoOverview;
            if (selected != null)
            {
                textbox.Text = selected.ID;
                combobox.SelectedItem = selected.NaplatnaStanicaID;
                checkbox.IsChecked = selected.ElNaplata;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = textbox.Text;
            string naplatnaStanicaId = combobox.SelectedValue == null ? "" : combobox.SelectedValue.ToString();
            bool elNaplata = (bool) checkbox.IsChecked;

            bool success = naplatnoMestoCRUDController.SaveNaplatnoMesto(id, naplatnaStanicaId, elNaplata);

            if (success)
            {
                MessageBox.Show("Uspesno dodato naplatno mesto.");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("Neuspesno dodavanje naplatnog mesta.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string id = textbox.Text;
            string naplatnaStanicaId = combobox.SelectedValue == null ? "" : combobox.SelectedValue.ToString();
            bool elNaplata = (bool)checkbox.IsChecked;

            bool success = naplatnoMestoCRUDController.EditNaplatnoMesto(id, naplatnaStanicaId, elNaplata);

            if (success)
            {
                MessageBox.Show("Uspesno izmenjeno naplatno mesto.");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("Neuspesna izmena naplatnog mesta.");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string id = textbox.Text;

            bool success = naplatnoMestoCRUDController.DeleteNaplatnoMesto(id);

            if (success)
            {
                MessageBox.Show("Uspesno izbrisano naplatno mesto.");
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("Neuspesno brisanje naplatnog mesta.");
            }
        }
    }
}
