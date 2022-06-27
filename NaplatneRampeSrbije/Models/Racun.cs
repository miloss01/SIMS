using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Racun
    {
        private NaplatnoMestoRepo naplatnoMestoRepo = new NaplatnoMestoRepo();
        public string ID { get; set; }
        public VrstaVozila VrstaVozila { get; set; }
        public double Cena { get; set; }
        public Valuta Valuta { get; set; }
        public DateTime VremeIzlaska { get; set; }
        public NaplatnoMesto MestoIzlaska { get; set; }
        public NaplatnoMesto MestoUlaska { get; set; }

        public Racun()
        {

        }

        public Racun(string id, VrstaVozila vrstaVozila, double cena, Valuta valuta, DateTime vremeIzlaska, NaplatnoMesto naplatnoMesto, NaplatnoMesto mestoUlaska)
        {
            ID = id;
            VrstaVozila = vrstaVozila;
            Cena = cena;
            Valuta = valuta;
            VremeIzlaska = vremeIzlaska;
            MestoIzlaska = naplatnoMesto;
            MestoUlaska = mestoUlaska;
        }

        public Racun(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            VrstaVozila = (VrstaVozila)reader[1];
            Cena = Convert.ToDouble(reader[2]);
            Valuta = (Valuta)reader[3];
            VremeIzlaska = DateTime.Parse(reader[4].ToString());
            MestoIzlaska = naplatnoMestoRepo.GetNaplatnoMestoById(reader[5].ToString());
            MestoUlaska = naplatnoMestoRepo.GetNaplatnoMestoById(reader[6].ToString());
        }
    }
}
