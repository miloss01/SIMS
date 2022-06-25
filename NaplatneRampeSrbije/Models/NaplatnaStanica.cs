using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class NaplatnaStanica
    {
        public string ID { get; set; }
        public Adresa Adresa { get; set; }

        public NaplatnaStanica()
        {

        }

        public NaplatnaStanica(string iD, Adresa adresa)
        {
            ID = iD;
            Adresa = adresa;
        }
    }
}
