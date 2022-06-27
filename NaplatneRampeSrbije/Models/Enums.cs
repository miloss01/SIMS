using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    public enum RadnoMesto
    {
        ReferentNaplate,
        SefNaplatneStanice,
        Menadzer,
        Admininstrator
    }

    public enum VrstaKvara
    {
        FizickoOstecenje,
        ElektronskoOstecenje
    }

    public enum Oprema
    {
        Rampa,
        Semafor,
        Kamera
    }

    public enum VrstaVozila
    {
        Automobil,
        Kamion,
        Autobus
    }

    public enum Valuta
    {
        Dinar,
        Evro,
        Dolar
    }

    public enum Pol
    {
        Muski,
        Zenski
    }
}
