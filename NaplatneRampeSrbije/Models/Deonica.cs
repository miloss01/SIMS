using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Deonica
    {
        public string ID { get; set; }
        public int Duzina { get; set; }
        public NaplatnaStanica Pocetak { get; set; }
        public NaplatnaStanica Kraj { get; set; }

        public Deonica()
        {

        }

        public Deonica(string id, int duzina, NaplatnaStanica pocetak, NaplatnaStanica kraj)
        {
            ID = id;
            Duzina = duzina;
            Pocetak = pocetak;
            Kraj = kraj;
        }
    }
}
