using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Cenovnik
    {
        public string ID;
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
        public List<string> StavkeID { get; set; }

        public Cenovnik()
        {

        }

        public Cenovnik(DateTime datumPocetka, DateTime datumKraja)
        {
            DatumPocetka = datumPocetka;
            DatumKraja = datumKraja;
            StavkeID = new List<string>();
        }

        public Cenovnik(OleDbDataReader reader)
        {
            ID = reader[0].ToString();
            DatumPocetka = DateTime.Parse(reader[1].ToString());
            DatumKraja = reader[2].ToString() == "null" ? new DateTime() : DateTime.Parse(reader[2].ToString());
            StavkeID = new List<string>();
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT stavka_cenovnika_id FROM stavka_cenovnika WHERE cenovnik_id = '{ID}'";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader readerStavki = command.ExecuteReader();
                while (readerStavki.Read())
                {
                    StavkeID.Add(readerStavki[0].ToString());
                }
                readerStavki.Close();
            }
        }

    }
}
