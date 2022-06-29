using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    public class NaplatnaStanicaRepo
    {
        public List<NaplatnaStanica> GetAll()
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

        public NaplatnaStanica Get(string id)
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

        public string GetLargestID()
        {
            List<NaplatnaStanica> naplatneStanice = GetAll();
            naplatneStanice.Sort((x, y) => x.ID.CompareTo(y.ID));
            if (naplatneStanice.Count == 0)
            {
                return "0";
            }

            return naplatneStanice[naplatneStanice.Count - 1].ID;
        }

        public bool Save(NaplatnaStanica ns)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"INSERT INTO naplatna_stanica (naplatna_stanica_id, adresa_id) VALUES ('{ns.ID}', '{ns.Adresa.ID}')";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool Update(NaplatnaStanica ns)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"UPDATE naplatna_stanica SET naplatna_stanica_id = '{ns.ID}', adresa_id = {ns.Adresa.ID} WHERE naplatna_stanica_id = '{ns.ID}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool Delete(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"DELETE FROM naplatna_stanica WHERE naplatna_stanica_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}