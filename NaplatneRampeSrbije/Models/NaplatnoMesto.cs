using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class NaplatnoMesto
    {
        public string ID { get; set; }
        public string RedniBroj { get; set; }
        public bool ElNaplata { get; set; }

        public NaplatnoMesto()
        {

        }

        public NaplatnoMesto(string redniBroj, bool elNaplata)
        {
            RedniBroj = redniBroj;
            ElNaplata = elNaplata;
        }

        public NaplatnoMesto(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            RedniBroj = reader[1].ToString();
            ElNaplata = Convert.ToBoolean(reader[2]);
        }
    }
}
