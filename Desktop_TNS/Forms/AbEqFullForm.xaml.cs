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
    /// Логика взаимодействия для AbEqFullForm.xaml
    /// </summary>
    public partial class AbEqFullForm : Window
    {
        Forms.ManageForm _man;
        Models.AbonentEquipment _ab;
        public AbEqFullForm(Models.AbonentEquipment ab, ManageForm manage)
        {
            InitializeComponent();
            _ab = ab;
            _man = manage;
            DataContext = _ab;
        }

        private async void clProverka(object sender, RoutedEventArgs e)
        {
            using (var http = new HttpClient())
            {
                var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={_ab.serialNumber}");
                request.EnsureSuccessStatusCode();
                var result = request.Content.ReadAsStringAsync().Result;
                if (result == "1")
                {
                    _ab.Equipment.work = true;
                    System.Windows.MessageBox.Show("Устройство работает.");
                }
                else
                {
                    _ab.Equipment.work = false;
                    System.Windows.MessageBox.Show("Устройство не работает.");
                }
                Models.context.aGetContext().SaveChanges();
                _man.dgAbEq.ItemsSource = Models.context.aGetContext().AbonentEquipments.ToList();
            }
        }
    }
}
