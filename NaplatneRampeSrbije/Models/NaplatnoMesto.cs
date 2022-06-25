using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class NaplatnoMesto
    {
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
    }
}
