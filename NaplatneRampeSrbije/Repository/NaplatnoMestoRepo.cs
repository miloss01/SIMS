using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    class NaplatnoMestoRepo
    {
        public NaplatnoMesto GetNaplatnoMestoById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM naplatno_mesto WHERE naplatno_mesto_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                NaplatnoMesto nm = null;
                while (reader.Read())
                {
                    nm = new NaplatnoMesto(reader);
                }
                reader.Close();
                return nm;
            }
        }

        public List<NaplatnoMesto> GetAllNaplatnoMesto()
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM naplatno_mesto";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<NaplatnoMesto> naplatnaMesta = new List<NaplatnoMesto>();
                while (reader.Read())
                {
                    naplatnaMesta.Add(new NaplatnoMesto(reader));
                }
                reader.Close();
                return naplatnaMesta;
            }
        }

        public bool SaveNaplatnoMesto(NaplatnoMesto nm)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"INSERT INTO naplatno_mesto (naplatno_mesto_id, naplatna_stanica_id, el_naplata) VALUES ('{nm.ID}', '{nm.NaplatnaStanica.ID}', {nm.ElNaplata})";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool EditNaplatnoMesto(NaplatnoMesto nm)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"UPDATE naplatno_mesto SET naplatna_stanica_id = '{nm.NaplatnaStanica.ID}', el_naplata = {nm.ElNaplata} WHERE naplatno_mesto_id = '{nm.ID}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool DeleteNaplatnoMesto(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"DELETE FROM naplatno_mesto WHERE naplatno_mesto_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
