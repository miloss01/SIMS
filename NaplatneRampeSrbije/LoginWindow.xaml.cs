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
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (_loginController.Login(usernameTextBox.Text, passwordBox.Password))
            {
                if (Globals.ulogovaniRadnik.RadnoMesto == RadnoMesto.Admininstrator)
                {
                    AdministratorMainView administratorMainView = new AdministratorMainView();
                    administratorMainView.Show();
                    Close();
                }
                else if (Globals.ulogovaniRadnik.RadnoMesto == RadnoMesto.Menadzer)
                {
                    MenadzerMainView menadzerMainView = new MenadzerMainView();
                    menadzerMainView.Show();
                }

                // ovaj else if mozes da izbrises sto se mene tice
                else if (Globals.ulogovaniRadnik.RadnoMesto == RadnoMesto.ReferentNaplate)
                {
                    // kada budes otvarao moj prozor za generisanje racuna moras da prosledis
                    // 1. vrstu vozila: VrstaVozila
                    // 2. valutu: Valuta
                    // 3. naplatno mesto ulazak id: string
                    // 4. vreme izlaska: DateTime
                    // za naplatno mesto ulaska pazi da ne bude sa iste naplatne stanice na kojoj radi referent jer ne postoji ta deonica u bazi pa ce da baca gresku
                    GenerisanjeRacunaView generisanjeRacunaView = new GenerisanjeRacunaView(VrstaVozila.Automobil, Valuta.Dinar, "5", new DateTime());
                    generisanjeRacunaView.Show();
                }

            }
            else
            {
                _ = MessageBox.Show("Nisam nasao radnika");
            }
        }
    }
}
