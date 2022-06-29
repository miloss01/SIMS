using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    public class Adresa
    {
        public string ID { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public Mesto Mesto { get; set; }

        public Adresa()
        {
        }

        public Adresa(string id, string ulica, string broj, Mesto mesto)
        {
            ID = id;
            Ulica = ulica;
            Broj = broj;
            Mesto = mesto;
        }

        public Adresa(string ulica, string broj, Mesto mesto)
        {
            AdresaRepo adresaRepo = new AdresaRepo();
            ID = Convert.ToInt32(adresaRepo.GetLargestID() + 1).ToString();
            Ulica = ulica;
            Broj = broj;
            Mesto = mesto;
        }

        public Adresa(OleDbDataReader reader)
        {
            MestoRepo mestoRepo = new MestoRepo();
            ID = reader[0].ToString();
            Ulica = reader[1].ToString();
            Broj = reader[2].ToString();
            Mesto = mestoRepo.GetMestoById(reader[3].ToString());
        }

        public override string ToString()
        {
            return Ulica + " " + Broj;
        }
    }
}