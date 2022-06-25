using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Tag
    {
        public string ID { get; set; }
        public string Ime { get; set; }
        public VrstaVozila VrstaVozila { get; set; }
        public double NovcanaSredstva { get; set; }

        public Tag()
        {

        }

        public Tag(string iD, string ime, VrstaVozila vrstaVozila, double novcanaSredstva)
        {
            ID = iD;
            Ime = ime;
            VrstaVozila = vrstaVozila;
            NovcanaSredstva = novcanaSredstva;
        }
    }
}
