using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    class CenovnikRepo
    {
        public Cenovnik GetTrenutniCenovnik()
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM cenovnik WHERE datum_kraja = 'null'";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Cenovnik cenovnik = null;
                while (reader.Read())
                {
                    cenovnik = new Cenovnik(reader);
                }
                reader.Close();
                return cenovnik;
            }
        }
    }
}
