using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    internal class MestoRepo
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

        public List<Mesto> GetAll()
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM mesto";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Mesto> mesta = new List<Mesto>();
                while (reader.Read())
                {
                    Mesto m = null;
                    m = new Mesto(reader);
                    mesta.Add(m);
                }
                reader.Close();
                return mesta;
            }
        }

        public Mesto GetMestoByPostanskiBroj(string postanskiBroj)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM mesto WHERE postanski_broj = '{postanskiBroj}'";
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