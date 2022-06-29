using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    internal class AdresaRepo
    {
        public List<Adresa> GetAll()
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM adresa";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Adresa> adrese = new List<Adresa>();
                while (reader.Read())
                {
                    Adresa a = null;
                    a = new Adresa(reader);
                    adrese.Add(a);
                }
                reader.Close();
                return adrese;
            }
        }

        public string GetLargestID()
        {
            List<Adresa> adrese = GetAll();
            adrese.Sort((x, y) => x.ID.CompareTo(y.ID));
            if (adrese.Count == 0)
            {
                return "0";
            }

            return adrese[adrese.Count - 1].ID;
        }

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

        public bool Save(Adresa a)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"INSERT INTO adresa (adresa_id, ulica, broj, mesto_id) VALUES ('{a.ID}', '{a.Ulica}','{a.Broj}','{a.Mesto.ID}')";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool Update(Adresa a)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"UPDATE adresa SET adresa_id = '{a.ID}', ulica = {a.Ulica}, broj = {a.Broj}, mesto_id = {a.Mesto.ID} WHERE adresa_id = '{a.ID}'";
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
                string query = $"DELETE FROM adresa WHERE adresa_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}