using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Views;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Windows;

namespace NaplatneRampeSrbije.Controllers
{
    public class PregledKvarovaController
    {
        private PregledKvarovaView _window;
        public PregledKvarovaController(PregledKvarovaView window)
        {
            _window = window;
        }

        public void NapuniTabeluKvarova()
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                try
                {
                    string query = $"SELECT * FROM kvar";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Kvar kvar = new Kvar(reader);
                        _window.DodajUTabelu(kvar);
                    }
                    reader.Close();
                }catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno citanje iz baze");
                }
                _window.KvaroviDataGrid.ItemsSource = _window._kvaroviDataTable.DefaultView;
            }
        }
    }
}
