using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Windows;

namespace NaplatneRampeSrbije.Repository
{
    class RadnikRepo
    {
        public Radnik GetById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM radnik WHERE radnik_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Radnik r = null;
                while (reader.Read())
                {
                    r = new Radnik(reader);
                }
                reader.Close();
                return r;
            }
        }

        public List<Radnik> GetAll()
        {
            List<Radnik> sviRadnici = new List<Radnik>();
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = "SELECT * FROM radnik";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Radnik r = null;
                while (reader.Read())
                {
                    r = new Radnik(reader);
                    sviRadnici.Add(r);
                }
                reader.Close();
                return sviRadnici;
            }
        }

        public bool Save(Radnik r)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM radnik WHERE radnik_id = '{r.ID}' OR korisnicko_ime = '{r.KorisnickoIme}' OR lozinka = '{r.Lozinka}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Radnik r2 = null;
                while (reader.Read())
                {
                    r2 = new Radnik(reader);
                    if (r2 != null)
                    {
                        reader.Close();
                        return false;
                    }
                }
                reader.Close();
                query = $"INSERT INTO radnik (radnik_id, ime, prezime, pol, telefon, korisnicko_ime, lozinka, radno_mesto, adresa_id, mesto_rada_id) VALUES ('{r.ID}', '{r.Ime}', '{r.Prezime}', {Convert.ToInt32(r.Pol)}, '{r.Telefon}', '{r.KorisnickoIme}', '{r.Lozinka}', {Convert.ToInt32(r.RadnoMesto)}, '{r.Adresa.ID}', '{r.MestoRadaID}')";
                command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

                return true;
            }
        }

        public bool Izmijeni(string stariId, Radnik r)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM radnik WHERE radnik_id = '{r.ID}' OR korisnicko_ime = '{r.KorisnickoIme}' OR lozinka = '{r.Lozinka}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Radnik r2 = null;
                while (reader.Read())
                {
                    r2 = new Radnik(reader);
                    if (r2 != null && stariId != r2.ID)
                    {
                        reader.Close();
                        return false;
                    }
                }
                reader.Close();
                query = $"UPDATE radnik SET radnik_id = '{r.ID}', ime = '{r.Ime}', prezime = '{r.Prezime}', pol = {Convert.ToInt32(r.Pol)}, telefon = '{r.Telefon}', korisnicko_ime = '{r.KorisnickoIme}', lozinka = '{r.Lozinka}', radno_mesto = {Convert.ToInt32(r.RadnoMesto)}, adresa_id = '{r.Adresa.ID}', mesto_rada_id = '{r.MestoRadaID}'WHERE radnik_id = '{stariId}'";
                command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

                return true;
            }
        }

        public void Ukloni(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"DELETE FROM radnik WHERE radnik_iud = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
