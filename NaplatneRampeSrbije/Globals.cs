using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NaplatneRampeSrbije
{
    class Globals
    {
        public static Radnik ulogovaniRadnik = null;
        public static string putanjaKonekcije = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\baza.accdb");
        public static string formatDatum = "dd.mm.yyyy.";
        public static string formatDatumVreme = "dd.mm.yyyy. HH:MM";

    }
}
