using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Tag
    {
        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public VrstaVozila VrstaVozila { get; set; }
        public double NovcanaSredstva { get; set; }

        public Tag()
        {

        }

        public Tag(string iD, string ime, string prezime, VrstaVozila vrstaVozila, double novcanaSredstva)
        {
            ID = iD;
            Ime = ime;
            Prezime = prezime;
            VrstaVozila = vrstaVozila;
            NovcanaSredstva = novcanaSredstva;
        }

        public Tag(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Ime = reader[1].ToString();
            Prezime = reader[2].ToString();
            VrstaVozila = (VrstaVozila)reader[3];
            NovcanaSredstva = Convert.ToDouble(reader[4]);
        }
    }
}
