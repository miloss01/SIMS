using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Cenovnik
    {
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }

        public Cenovnik()
        {

        }

        public Cenovnik(DateTime datumPocetka, DateTime datumKraja)
        {
            DatumPocetka = datumPocetka;
            DatumKraja = datumKraja;
        }
    }
}
