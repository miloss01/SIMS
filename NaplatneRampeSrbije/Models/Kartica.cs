using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Kartica
    {
        public string ID;
        public VrstaVozila VrstaVozila { get; set; }
        public DateTime VremeUlaska { get; set; }
        public string NaplatnoMestoID { get; set; }

        public Kartica()
        {

        }

        public Kartica(string id, VrstaVozila vrstaVozila, DateTime vremeUlaska, string naplatnoMestoID)
        {
            ID = id;
            VrstaVozila = vrstaVozila;
            VremeUlaska = vremeUlaska;
            NaplatnoMestoID = naplatnoMestoID;
        }

        public Kartica(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            VrstaVozila = (VrstaVozila)reader[1];
            VremeUlaska = DateTime.Parse(reader[2].ToString());
            NaplatnoMestoID = reader[3].ToString();
        }
    }
}
