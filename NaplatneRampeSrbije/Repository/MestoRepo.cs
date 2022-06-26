using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    class MestoRepo
    {
        public Mesto GetMestoById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM mesto WHERE mesto_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Mesto m = null;
                while (reader.Read())
                {
                    m = new Mesto(reader);
                }
                reader.Close();
                return m;
            }
        }
    }
}
