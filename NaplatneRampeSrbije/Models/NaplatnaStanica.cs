using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class NaplatnaStanica
    {
        public string ID { get; set; }
        public string AdresaID { get; set; }

        public NaplatnaStanica()
        {

        }

        public NaplatnaStanica(string iD, string adresaID)
        {
            ID = iD;
            AdresaID = adresaID;
        }

        public NaplatnaStanica(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            AdresaID = reader[1].ToString();
        }
    }
}
