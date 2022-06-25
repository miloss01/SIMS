using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Racun
    {
        public string ID { get; set; }
        public VrstaVozila VrstaVozila { get; set; }
        public double Cena { get; set; }
        public Valuta Valuta { get; set; }
        public DateTime VremeIzlaska { get; set; }
        public string NaplatnoMestoID { get; set; }

        public Racun()
        {

        }

        public Racun(string id, VrstaVozila vrstaVozila, double cena, Valuta valuta, DateTime vremeIzlaska, string naplatnoMestoID)
        {
            ID = id;
            VrstaVozila = vrstaVozila;
            Cena = cena;
            Valuta = valuta;
            VremeIzlaska = vremeIzlaska;
            NaplatnoMestoID = naplatnoMestoID;
        }

        public Racun(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            VrstaVozila = (VrstaVozila)reader[1];
            Cena = Convert.ToDouble(reader[2]);
            Valuta = (Valuta)reader[3];
            VremeIzlaska = DateTime.Parse(reader[4].ToString());
            NaplatnoMestoID = reader[5].ToString();

        }
    }
}
