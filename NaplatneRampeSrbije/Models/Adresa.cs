using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Adresa
    {
        private MestoRepo mestoRepo = new MestoRepo();
        public string ID { get; set; }
        public string Ulica { get; set; }
        public string PostanskiBroj { get; set; }
        public Mesto Mesto { get; set; }

        public Adresa()
        {

        }

        public Adresa(string id, string ulica, string postanskiBroj, Mesto mesto)
        {
            ID = id;
            Ulica = ulica;
            PostanskiBroj = postanskiBroj;
            Mesto = mesto;
        }

        public Adresa(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Ulica = reader[1].ToString();
            PostanskiBroj = reader[2].ToString();
            Mesto = mestoRepo.GetMestoById(reader[3].ToString());
        }
    }
}
