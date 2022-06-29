using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows;

namespace NaplatneRampeSrbije.Controllers
{
    public class SefNaplatneStaniceController
    {
        public void GenerisanjeIzvestaja()
        {
            String fileName = "IzvestajOPrihodu.txt";
            using (StreamWriter writer = new StreamWriter(@"../../../../Izvestaji/" + fileName))
            {
                int[] naplatneStaniceZarada;
                int[] naplatnaMestaZarada;
                GenerisanjePodatakaONaplatnomMestu(writer);
                GenerisanjePodatakaONaplatnojStanici(writer);
                MessageBox.Show("Izvestaj zapisan u fajl " + fileName);
            }
        }

        private void GenerisanjePodatakaONaplatnojStanici(StreamWriter writer)
        {
            writer.WriteLine("Izvestaj o zaradi na naplatnim stanicama:");
            writer.WriteLine("---------------------------------------");
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT naplatna_stanica_id,sum(cena) FROM racun,naplatno_mesto where racun.izlazak_naplatno_mesto_id = naplatno_mesto.naplatno_mesto_id group by naplatna_stanica_id";

                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String output = reader[0].ToString() + ":" + reader[1].ToString();
                    writer.WriteLine(output);
                }
                reader.Close();
            }
        }

        private void GenerisanjePodatakaONaplatnomMestu(StreamWriter writer)
        {
            writer.WriteLine("Izvestaj o zaradi na naplatnim mestima:");
            writer.WriteLine("---------------------------------------");
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT izlazak_naplatno_mesto_id,sum(cena) FROM racun group by izlazak_naplatno_mesto_id";

                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String output = reader[0].ToString() + ":" + reader[1].ToString();
                    writer.WriteLine(output);
                }
                reader.Close();
            }
        }
    }
}
