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

    enum VrstaKvara
    {
        FizickoOstecenje,
        ElektronskoOstecenje
    }

    enum Oprema
    {
        Rampa,
        Semafor,
        Kamera
    }

    enum VrstaVozila
    {
        Automobil,
        Kamion,
        Autobus
    }

    enum Valuta
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
