using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class OcitavanjeTablica
    {
        public string ID { get; set; }
        public string Tablica { get; set; }
        public string KarticaID { get; set; }

        public OcitavanjeTablica()
        {

        }

        public OcitavanjeTablica(string id, string tablica, string karticaID)
        {
            ID = id;
            Tablica = tablica;
            KarticaID = karticaID;
        }

        public OcitavanjeTablica(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Tablica = reader[1].ToString();
            KarticaID = reader[2].ToString();
        }
    }
}
