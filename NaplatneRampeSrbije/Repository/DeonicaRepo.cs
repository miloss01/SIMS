using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Repository
{
    class DeonicaRepo
    {
        NaplatnoMestoRepo naplatnoMestoRepo = new NaplatnoMestoRepo();
        public Deonica GetDeonicaById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM deonica WHERE deonica_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Deonica d = null;
                while (reader.Read())
                {
                    d = new Deonica(reader);
                }
                reader.Close();
                return d;
            }
        }

        public Deonica GetDeonicaByUlazakIIzlazak(string ulazakId, string izlazakId)
        {

            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM deonica WHERE pocetak_naplatna_stanica_id='{ulazakId}' AND kraj_naplatna_stanica_id='{izlazakId}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Deonica d = null;
                while (reader.Read())
                {
                    d = new Deonica(reader);
                }
                reader.Close();
                return d;
            }
        }
    }
}
