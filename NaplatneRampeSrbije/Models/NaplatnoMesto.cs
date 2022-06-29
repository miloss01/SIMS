using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    public class NaplatnoMesto
    {
        private NaplatnaStanicaRepo naplatnaStanicaRepo = new NaplatnaStanicaRepo();
        public string ID { get; set; }
        public NaplatnaStanica NaplatnaStanica { get; set; }
        public bool ElNaplata { get; set; }

        public NaplatnoMesto()
        {
        }

        public NaplatnoMesto(string id, NaplatnaStanica naplatnaStanica, bool elNaplata)
        {
            ID = id;
            NaplatnaStanica = naplatnaStanica;
            ElNaplata = elNaplata;
        }

        public NaplatnoMesto(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            NaplatnaStanica = naplatnaStanicaRepo.Get(reader[1].ToString());
            ElNaplata = Convert.ToBoolean(reader[2]);
        }

        public override string ToString()
        {
            return ID;
        }
    }
}