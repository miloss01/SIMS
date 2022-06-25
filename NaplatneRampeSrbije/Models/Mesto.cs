using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Mesto
    {
        public string ID { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public Mesto()
        {

        }

        public Mesto(string id, string naziv, string postanskiBroj)
        {
            ID = id;
            Naziv = naziv;
            PostanskiBroj = postanskiBroj;
        }

        public Mesto(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Naziv = reader[1].ToString();
            PostanskiBroj = reader[2].ToString();
        }
    }
}
