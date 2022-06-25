using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class OcitavanjeTablica
    {
        public string Tablica { get; set; }
        public Kartica Kartica { get; set; }

        public OcitavanjeTablica()
        {

        }

        public OcitavanjeTablica(string tablica, Kartica kartica)
        {
            Tablica = tablica;
            Kartica = kartica;
        }
    }
}
