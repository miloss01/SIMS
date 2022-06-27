using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Radnik
    {
        private NaplatnoMestoRepo naplatnoMestoRepo = new NaplatnoMestoRepo();
        private NaplatnaStanicaRepo naplatnaStanicaRepo = new NaplatnaStanicaRepo();
        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string Telefon { get; set; }
        public RadnoMesto RadnoMesto { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string AdresaID { get; set; }
        public NaplatnoMesto NaplatnoMesto { get; set; }
        public NaplatnaStanica NaplatnaStanica { get; set; }

        public Radnik()
        {

        }

        public Radnik(string id, string ime, string prezime, Pol pol, string telefon, RadnoMesto radnoMesto, string korisnickoIme, string lozinka, string adresaID, NaplatnoMesto naplatnoMesto, NaplatnaStanica naplatnaStanica)
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
            NaplatnoMesto = naplatnoMesto;
            NaplatnaStanica = naplatnaStanica;
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
            if (RadnoMesto == RadnoMesto.ReferentNaplate)
            {
                NaplatnoMesto = naplatnoMestoRepo.GetNaplatnoMestoById(reader[9].ToString());
                NaplatnaStanica = null;
            }
            else if (RadnoMesto == RadnoMesto.SefNaplatneStanice)
            {
                NaplatnoMesto = null;
                NaplatnaStanica = naplatnaStanicaRepo.GetNaplatnaStanicaById(reader[9].ToString());
            }
            else
            {
                NaplatnoMesto = null;
                NaplatnaStanica = null;
            }
        }
    }
}
