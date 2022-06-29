using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Windows;

namespace NaplatneRampeSrbije.Repository
{
    public class KvarRepo
    {
        public Kvar GetKvarById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT * FROM adresa WHERE adresa_id = '{id}'";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Kvar kvar = null;
                while (reader.Read())
                {
                    kvar = new Kvar(reader);
                }
                reader.Close();
                return kvar;
            }
        }

        public string getLargestID() {
            String largestID = "-1";
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = $"SELECT max(kvar_id) FROM kvar";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();          
                largestID = reader[0].ToString();
                reader.Close();
            }
            if(largestID != "-1")            
                largestID = (int.Parse(largestID) + 1).ToString();      
                 
            return largestID;
        }

        internal void SaveKvar(Kvar kvar)
        {
            using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                try
                {
                    string query = $"INSERT INTO kvar (kvar_id, oprema, opis, naplatno_mesto_id, vrsta_kvara) VALUES ('{kvar.ID}', {Convert.ToInt32(kvar.Oprema)}, '{kvar.Opis}', '{kvar.NaplatnoMestoID}', {Convert.ToInt32(kvar.VrstaKvara)})";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Dodavanje uspesno");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dodavanje neuspesno");
                }
            }
        }
    }
}
