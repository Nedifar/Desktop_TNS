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
    /// Логика взаимодействия для MagistralFullForm.xaml
    /// </summary>
    public partial class MagistralFullForm : Window
    {
        Forms.ManageForm _man;
        Models.Magistral _mag;
        public MagistralFullForm(Models.Magistral magistral, ManageForm manage)
        {
            InitializeComponent();
            _mag = magistral;
            _man = manage;
            DataContext = _mag;
        }

        private async void clProverka(object sender, RoutedEventArgs e)
        {
            using (var http = new HttpClient())
            {
                var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={_mag.serialNumber}");
                request.EnsureSuccessStatusCode();
                var result = request.Content.ReadAsStringAsync().Result;
                if (result == "1")
                {
                    _mag.Equipment.work = true;
                    System.Windows.MessageBox.Show("Устройство работает.");
                }
                else
                {
                    _mag.Equipment.work = false;
                    System.Windows.MessageBox.Show("Устройство не работает.");
                }
                Models.context.aGetContext().SaveChanges();
                _man.dgMagistral.ItemsSource = Models.context.aGetContext().Magistrals.ToList();
            }
        }
    }
}
