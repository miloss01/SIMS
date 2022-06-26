using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    class NaplatnaStanicaRepo
    {
        public NaplatnaStanica GetNaplatnaStanicaById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM naplatna_stanica WHERE naplatna_stanica_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                NaplatnaStanica ns = null;
                while (reader.Read())
                {
                    ns = new NaplatnaStanica(reader);
                }
                reader.Close();
                return ns;
            }
        }

        public List<NaplatnaStanica> GetAllNaplatnaStanica()
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM naplatna_stanica";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<NaplatnaStanica> naplatneStanice = new List<NaplatnaStanica>();
                while (reader.Read())
                {
                    naplatneStanice.Add(new NaplatnaStanica(reader));
                }
                reader.Close();
                return naplatneStanice;
            }
        }
    }
}
