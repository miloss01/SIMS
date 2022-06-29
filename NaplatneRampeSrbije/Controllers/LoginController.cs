using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Windows;

namespace NaplatneRampeSrbije.Controllers
{
    class LoginController
    {
        public bool Login(string korisnickoIme, string lozinka)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
                {
                    string query = $"SELECT * FROM radnik WHERE korisnicko_ime = '{korisnickoIme}' AND lozinka = '{lozinka}'";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Globals.ulogovaniRadnik = new Radnik(reader);
                    reader.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Globals.ulogovaniRadnik = null;
            }

            return Globals.ulogovaniRadnik != null;
        }
    }
}
