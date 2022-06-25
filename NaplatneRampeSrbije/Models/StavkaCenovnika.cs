using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class StavkaCenovnika
    {
        public double Cena { get; set; }
        public VrstaVozila VrstaVozila { get; set; }
        public string RedniBroj { get; set; }
        public Cenovnik Cenovnik { get; set; }
        public Deonica Deoncica { get; set; }

        public StavkaCenovnika()
        {

        }

        public StavkaCenovnika(VrstaVozila vrstaVozila, string redniBroj, Cenovnik cenovnik, Deonica deoncica)
        {
            VrstaVozila = vrstaVozila;
            RedniBroj = redniBroj;
            Cenovnik = cenovnik;
            Deoncica = deoncica;
        }
    }
}
