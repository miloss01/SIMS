using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Kvar
    {
        public Oprema Oprema { get; set; }
        public string Opis { get; set; }
        public VrstaKvara VrstaKvara { get; set; }
        public NaplatnoMesto NaplatnoMesto { get; set; }

        public Kvar()
        {

        }

        public Kvar(Oprema oprema, string opis, VrstaKvara vrstaKvara, NaplatnoMesto naplatnoMesto)
        {
            Oprema = oprema;
            Opis = opis;
            VrstaKvara = vrstaKvara;
            NaplatnoMesto = naplatnoMesto;
        }
    }
}
