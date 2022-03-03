using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для AccsesFullForm.xaml
    /// </summary>
    public partial class AccsesFullForm : Window
    {
        Forms.ManageForm _man;
        Models.AccsesNetwork _acc;
        public AccsesFullForm(Models.AccsesNetwork accses, ManageForm manage)
        {
            InitializeComponent();
            _acc = accses;
            _man = manage;
            DataContext = _acc;
        }

        private async void clProverka(object sender, RoutedEventArgs e)
        {
            using (var http = new HttpClient())
            {
                var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={_acc.serialNumber}");
                request.EnsureSuccessStatusCode();
                var result = request.Content.ReadAsStringAsync().Result;
                if (result == "1")
                {
                    _acc.Equipment.work = true;
                    System.Windows.MessageBox.Show("Устройство работает.");
                }
                else
                {
                    _acc.Equipment.work = false;
                    System.Windows.MessageBox.Show("Устройство не работает.");
                }
                Models.context.aGetContext().SaveChanges();
                _man.dgAccess.ItemsSource = Models.context.aGetContext().AccsesNetworks.ToList();
            }
        }
    }
}
