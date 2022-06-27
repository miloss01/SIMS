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

        public bool SaveRacun(Racun r)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string vreme = r.VremeIzlaska.ToString(Globals.formatDatumVreme);
                int vozilo = ((int)r.VrstaVozila);
                int valuta = ((int)r.Valuta);
    
                string query = $"INSERT INTO racun (racun_id, vozilo, cena, valuta, vreme_izlaska, izlazak_naplatno_mesto_id, ulazak_naplatno_mesto_id) VALUES ('{r.ID}', '{vozilo}', {r.Cena}, {valuta}, '{vreme}', '{r.MestoIzlaska.ID}', '{r.MestoUlaska.ID}')";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
