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
    /// Interaction logic for PregledKvarovaView.xaml
    /// </summary>
    public partial class PregledKvarovaView : Window
    {
        public DataTable _kvaroviDataTable;
        private DataRow _dataRow;
        private PregledKvarovaController _pregledKvarovaController;
        public PregledKvarovaView()
        {
            _pregledKvarovaController = new PregledKvarovaController(this);
            InitializeComponent();
            KreiranjeTabeleKvarova();
            _pregledKvarovaController.NapuniTabeluKvarova();
        }

        private void KreiranjeTabeleKvarova()
        {
            _kvaroviDataTable = new DataTable();
            DataColumn dc1 = new DataColumn("Kvar ID", typeof(string));
            DataColumn dc2 = new DataColumn("Oprema", typeof(int));
            DataColumn dc3 = new DataColumn("Opis", typeof(string));
            DataColumn dc4 = new DataColumn("Naplatno Mesto ID", typeof(string));
            DataColumn dc5 = new DataColumn("Vrsta Kvara", typeof (int));
            _kvaroviDataTable.Columns.Add(dc1);
            _kvaroviDataTable.Columns.Add(dc2);
            _kvaroviDataTable.Columns.Add(dc3);
            _kvaroviDataTable.Columns.Add(dc4);
            _kvaroviDataTable.Columns.Add(dc5);
        }

        public void DodajUTabelu(Kvar kvar)
        {
            _dataRow = _kvaroviDataTable.NewRow();
            _dataRow[0] = kvar.ID;
            _dataRow[1] = kvar.Oprema;
            _dataRow[2] = kvar.Opis;
            _dataRow[3] = kvar.NaplatnoMestoID;
            _dataRow[4] = kvar.VrstaKvara;
            _kvaroviDataTable.Rows.Add(_dataRow);

        }


    }
}
