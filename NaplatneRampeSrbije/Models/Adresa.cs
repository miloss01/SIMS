using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Adresa
    {
        public string Ulica { get; set; }
        public int PostanskiBroj { get; set; }
        public Mesto Mesto { get; set; }

        public Adresa()
        {

        }

        public Adresa(string ulica, int postanskiBroj, Mesto mesto)
        {
            Ulica = ulica;
            PostanskiBroj = postanskiBroj;
            Mesto = mesto;
        }
    }
}
