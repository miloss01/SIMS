using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    class RacunRepo
    {
        public List<Racun> GetAllRacun()
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM racun";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Racun> racuni = new List<Racun>();
                while (reader.Read())
                {
                    racuni.Add(new Racun(reader));
                }
                reader.Close();
                return racuni;
            }
        }
    }
}
