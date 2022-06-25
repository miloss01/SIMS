using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Kvar
    {
        public string ID { get; set; }
        public Oprema Oprema { get; set; }
        public string Opis { get; set; }
        public VrstaKvara VrstaKvara { get; set; }
        public string NaplatnoMestoID { get; set; }

        public Kvar()
        {

        }

        public Kvar(string id, Oprema oprema, string opis, VrstaKvara vrstaKvara, string naplatnoMestoID)
        {
            ID = id;
            Oprema = oprema;
            Opis = opis;
            VrstaKvara = vrstaKvara;
            NaplatnoMestoID = naplatnoMestoID;
        }

        public Kvar(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Oprema = (Oprema)reader[1];
            Opis = reader[2].ToString();
            NaplatnoMestoID = reader[3].ToString();
            VrstaKvara = (VrstaKvara)reader[4];
        }
    }
}
