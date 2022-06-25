using NaplatneRampeSrbije.Controllers;
using NaplatneRampeSrbije.Models;
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
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (_loginController.Login(usernameTextBox.Text, passwordBox.Password))
            {
                _ = MessageBox.Show(Globals.ulogovaniRadnik.Ime + " " + Globals.ulogovaniRadnik.Prezime);
            }
            else
            {
                _ = MessageBox.Show("Nisam nasa radnika");
            }
        }
    }
}
