using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Adresa
    {
        public string ID { get; set; }
        public string Ulica { get; set; }
        public string PostanskiBroj { get; set; }
        public string MestoID { get; set; }

        public Adresa()
        {

        }

        public Adresa(string id, string ulica, string postanskiBroj, string mestoID)
        {
            ID = id;
            Ulica = ulica;
            PostanskiBroj = postanskiBroj;
            MestoID = mestoID;
        }

        public Adresa(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Ulica = reader[1].ToString();
            PostanskiBroj = reader[2].ToString();
            MestoID = reader[3].ToString();
        }
    }
}
