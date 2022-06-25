using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Deonica
    {
        public string ID { get; set; }
        public int Duzina { get; set; }
        public string PocetnaNaplatnaStanicaID { get; set; }
        public string KrajnjaNaplatnaStanicaID { get; set; }

        public Deonica()
        {

        }

        public Deonica(string id, int duzina, string pocetnaNaplatnaStanicaID, string krajnjaNaplatnaStanicaID)
        {
            ID = id;
            Duzina = duzina;
            PocetnaNaplatnaStanicaID = pocetnaNaplatnaStanicaID;
            KrajnjaNaplatnaStanicaID = krajnjaNaplatnaStanicaID;
        }

        public Deonica(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Duzina = Convert.ToInt32(reader[1]);
            PocetnaNaplatnaStanicaID = reader[2].ToString();
            KrajnjaNaplatnaStanicaID = reader[3].ToString();
        }
    }
}
