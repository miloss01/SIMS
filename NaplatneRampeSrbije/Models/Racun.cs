using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Racun
    {
        public VrstaVozila VrstaVozila { get; set; }
        public double Cena { get; set; }
        public Valuta Valuta { get; set; }
        public DateTime VremeIzlaska { get; set; }
        public NaplatnoMesto NaplatnoMesto { get; set; }

        public Racun()
        {

        }

        public Racun(VrstaVozila vrstaVozila, double cena, Valuta valuta, DateTime vremeIzlaska, NaplatnoMesto naplatnoMesto)
        {
            VrstaVozila = vrstaVozila;
            Cena = cena;
            Valuta = valuta;
            VremeIzlaska = vremeIzlaska;
            NaplatnoMesto = naplatnoMesto;
        }
    }
}
