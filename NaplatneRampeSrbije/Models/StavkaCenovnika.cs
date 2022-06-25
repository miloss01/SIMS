using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class StavkaCenovnika
    {
        public string ID { get; set; }
        public double Cena { get; set; }
        public VrstaVozila VrstaVozila { get; set; }
        public string CenovnikID { get; set; }
        public string DeonicaID { get; set; }

        public StavkaCenovnika()
        {

        }

        public StavkaCenovnika(string id, double cena, VrstaVozila vrstaVozila, string cenovnikID, string deonicaID)
        {
            ID = id;
            Cena = cena;
            VrstaVozila = vrstaVozila;
            CenovnikID = cenovnikID;
            DeonicaID = deonicaID;
        }

        public StavkaCenovnika(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Cena = Convert.ToDouble(reader[1]);
            VrstaVozila = (VrstaVozila)reader[2];
            DeonicaID = reader[3].ToString();
            CenovnikID = reader[4].ToString();
        }
    }
}
