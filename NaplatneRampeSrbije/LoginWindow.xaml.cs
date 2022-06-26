using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Views;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace NaplatneRampeSrbije
{
    public partial class LoginWindow : Window
    {
        private LoginController _loginController;

        public LoginWindow()
        {
            InitializeComponent();
            _loginController = new LoginController();
           /* using (OleDbConnection connection = new OleDbConnection(Globals.putanjaKonekcije))
            {
                string query = "SELECT * FROM racun";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Racun c = new Racun(reader);
                    _ = MessageBox.Show(c.VremeIzlaska.ToString());
                }
                reader.Close();
            }*/
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (_loginController.Login(usernameTextBox.Text, passwordBox.Password))
            {
                if (Globals.ulogovaniRadnik.RadnoMesto == RadnoMesto.Admininstrator)
                {
                    AdministratorMainView administratorMainView = new AdministratorMainView();
                    administratorMainView.Show();
                }

            }
            else
            {
                _ = MessageBox.Show("Nisam nasao radnika");
            }
        }
    }
}
