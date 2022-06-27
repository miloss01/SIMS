using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    public class NaplatnaStanica
    {
        private AdresaRepo adresaRepo = new AdresaRepo();
        public string ID { get; set; }
        public Adresa Adresa { get; set; }

        public NaplatnaStanica()
        {

        }

        public NaplatnaStanica(string iD, Adresa adresa)
        {
            ID = iD;
            Adresa = adresa;
        }

        public NaplatnaStanica(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Adresa = adresaRepo.GetAdresaById(reader[1].ToString());
        }

        public override string ToString()
        {
            return ID;
        }
    }
}
