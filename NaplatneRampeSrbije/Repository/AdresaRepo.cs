using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    class AdresaRepo
    {
        public Adresa GetAdresaById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM adresa WHERE adresa_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Adresa a = null;
                while (reader.Read())
                {
                    a = new Adresa(reader);
                }
                reader.Close();
                return a;
            }
        }
    }
}
