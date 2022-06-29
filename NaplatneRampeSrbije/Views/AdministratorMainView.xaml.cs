using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NaplatneRampeSrbije.Views
{
    /// <summary>
    /// Interaction logic for AdministratorMainView.xaml
    /// </summary>
    public partial class AdministratorMainView : Window
    {
        public AdministratorMainView()
        {
            InitializeComponent();
        }

        private void naplatnoMestoCRUD_Click(object sender, RoutedEventArgs e)
        {
            NaplatnoMestoCRUDView naplatnoMestoCRUDView = new NaplatnoMestoCRUDView();
            naplatnoMestoCRUDView.Show();
        }

        private void korisnikCreate_Click(object sender, RoutedEventArgs e)
        {
            KorisnikCRUDView korisnikCRUDView = new KorisnikCRUDView();
            korisnikCRUDView.Show();
        }

        private void naplatnaStanicaCRUD_Click(object sender, RoutedEventArgs e)
        {
            CRUDNaplatnaStanicaView naplatnaStanicaView = new CRUDNaplatnaStanicaView();
            naplatnaStanicaView.Show();
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            Globals.ulogovaniRadnik = null;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}