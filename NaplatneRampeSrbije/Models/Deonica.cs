using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Deonica
    {
        private NaplatnaStanicaRepo naplatnaStanicaRepo = new NaplatnaStanicaRepo();
        public string ID { get; set; }
        public int Duzina { get; set; }
        public NaplatnaStanica PocetnaNaplatnaStanicaID { get; set; }
        public NaplatnaStanica KrajnjaNaplatnaStanicaID { get; set; }

        public Deonica()
        {

        }

        public Deonica(string id, int duzina, NaplatnaStanica pocetnaNaplatnaStanica, NaplatnaStanica krajnjaNaplatnaStanica)
        {
            ID = id;
            Duzina = duzina;
            PocetnaNaplatnaStanicaID = pocetnaNaplatnaStanica;
            KrajnjaNaplatnaStanicaID = krajnjaNaplatnaStanica;
        }

        public Deonica(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Duzina = Convert.ToInt32(reader[1]);
            PocetnaNaplatnaStanicaID = naplatnaStanicaRepo.Get(reader[2].ToString());
            KrajnjaNaplatnaStanicaID = naplatnaStanicaRepo.Get(reader[3].ToString());
        }
    }
}
