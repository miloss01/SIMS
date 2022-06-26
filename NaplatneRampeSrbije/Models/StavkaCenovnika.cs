using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class StavkaCenovnika
    {
        private DeonicaRepo deonicaRepo = new DeonicaRepo();
        public string ID { get; set; }
        public double Cena { get; set; }
        public VrstaVozila VrstaVozila { get; set; }
        public string CenovnikID { get; set; }
        public Deonica Deonica { get; set; }

        public StavkaCenovnika()
        {

        }

        public StavkaCenovnika(string id, double cena, VrstaVozila vrstaVozila, string cenovnikId, Deonica deonica)
        {
            ID = id;
            Cena = cena;
            VrstaVozila = vrstaVozila;
            CenovnikID = cenovnikId;
            Deonica = deonica;
        }

        public StavkaCenovnika(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            Cena = Convert.ToDouble(reader[1]);
            VrstaVozila = (VrstaVozila)reader[2];
            Deonica = deonicaRepo.GetDeonicaById(reader[3].ToString());
            CenovnikID = reader[4].ToString();
        }
    }
}
