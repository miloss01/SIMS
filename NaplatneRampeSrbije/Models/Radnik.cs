using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Radnik
    {
        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string Telefon { get; set; }
        public RadnoMesto RadnoMesto { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string AdresaID { get; set; }
        public string MestoRadaID { get; set; }

        public Radnik()
        {

        }

        public Radnik(string id, string ime, string prezime, Pol pol, string telefon, RadnoMesto radnoMesto, string korisnickoIme, string lozinka, string adresaID, string mestoRadaID)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Telefon = telefon;
            RadnoMesto = radnoMesto;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            AdresaID = adresaID;
            MestoRadaID = mestoRadaID;
        }

        public Radnik(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Ime = reader[1].ToString();
            Prezime = reader[2].ToString();
            Pol = (Pol)reader[3];
            Telefon = reader[4].ToString();
            KorisnickoIme = reader[5].ToString();
            Lozinka = reader[6].ToString();
            RadnoMesto = (RadnoMesto)reader[7];
            AdresaID = reader[8].ToString();
            MestoRadaID = reader[9].ToString();
        }
    }
}
