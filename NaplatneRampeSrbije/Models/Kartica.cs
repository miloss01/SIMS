using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Kartica
    {
        public VrstaVozila VrstaVozila { get; set; }
        public DateTime VremeUlaska { get; set; }
        public NaplatnoMesto NaplatnoMesto { get; set; }

        public Kartica()
        {

        }

        public Kartica(VrstaVozila vrstaVozila, DateTime vremeUlaska, NaplatnoMesto naplatnoMesto)
        {
            VrstaVozila = vrstaVozila;
            VremeUlaska = vremeUlaska;
            NaplatnoMesto = naplatnoMesto;
        }
    }
}
