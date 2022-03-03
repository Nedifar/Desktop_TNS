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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для ManageForm.xaml
    /// </summary>
    public partial class ManageForm : Page
    {
        public ManageForm()
        {
            InitializeComponent();
            dgMagistral.ItemsSource = Models.context.aGetContext().Magistrals.ToList();
            dgAccess.ItemsSource = Models.context.aGetContext().AccsesNetworks.ToList();
            dgAbEq.ItemsSource = Models.context.aGetContext().AbonentEquipments.ToList();
        }

        private async void dgMagistral_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var magistarl = dgMagistral.SelectedItem as Models.Magistral;
            if (e.ClickCount == 1)
            {
                using (var http = new HttpClient())
                {
                    var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={magistarl.serialNumber}");
                    request.EnsureSuccessStatusCode();
                    var result = request.Content.ReadAsStringAsync().Result;
                    if (result == "1")
                    {
                        magistarl.Equipment.work = true;
                        System.Windows.MessageBox.Show("Устройство работает.");
                    }
                    else
                    {
                        magistarl.Equipment.work = false;
                        System.Windows.MessageBox.Show("Устройство не работает.");
                    }
                    Models.context.aGetContext().SaveChanges();
                    dgMagistral.ItemsSource = Models.context.aGetContext().Magistrals.ToList();
                }
            }
            else if (e.ClickCount == 2)
            {
                Forms.MagistralFullForm fullForm = new MagistralFullForm(magistarl, this);
                fullForm.Show();
            }
        }

        private async void clMagistralsFull(object sender, RoutedEventArgs e)
        {
            using (var http = new HttpClient())
            {
                foreach (var l in dgMagistral.Items)
                {
                    var t = l as Models.Magistral;
                    var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={t.serialNumber}");
                    request.EnsureSuccessStatusCode();
                    var result = request.Content.ReadAsStringAsync().Result;
                    if (result == "1")
                    {
                        t.Equipment.work = true;
                    }
                    else
                    {
                        t.Equipment.work = false;
                        var newCrm = new Models.CRM
                        {
                            dateCreated = DateTime.Now,
                            NumberCRM = t.serialNumber + "/" + DateTime.Now.ToString("dd/MM/yyyy"),
                            status = "Требут выезда",
                            equipmentType = t.Equipment.name
                        };
                        Models.context.aGetContext().CRMs.Add(newCrm);
                    }
                    Models.context.aGetContext().SaveChanges();
                }
            }
            dgMagistral.ItemsSource = Models.context.aGetContext().Magistrals.ToList();
            MessageBox.Show("Проверка магистралей завершена.");
        }

        private async void dgAccess_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var accses = dgAccess.SelectedItem as Models.AccsesNetwork;
            if (e.ClickCount == 1)
            {
                using (var http = new HttpClient())
                {
                    var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={accses.serialNumber}");
                    request.EnsureSuccessStatusCode();
                    var result = request.Content.ReadAsStringAsync().Result;
                    if (result == "1")
                    {
                        accses.Equipment.work = true;
                        System.Windows.MessageBox.Show("Устройство работает.");
                    }
                    else
                    {
                        accses.Equipment.work = false;
                        System.Windows.MessageBox.Show("Устройство не работает.");
                    }
                    Models.context.aGetContext().SaveChanges();
                    dgAccess.ItemsSource = Models.context.aGetContext().AccsesNetworks.ToList();
                }
            }
            else if (e.ClickCount == 2)
            {
                Forms.AccsesFullForm fullForm = new AccsesFullForm(accses, this);
                fullForm.Show();
            }
        }

        private async void clAccessFull(object sender, RoutedEventArgs e)
        {
            using (var http = new HttpClient())
            {
                foreach (var l in dgAccess.Items)
                {
                    var t = l as Models.AccsesNetwork;
                    var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={t.serialNumber}");
                    request.EnsureSuccessStatusCode();
                    var result = request.Content.ReadAsStringAsync().Result;
                    if (result == "1")
                    {
                        t.Equipment.work = true;
                    }
                    else
                    {
                        t.Equipment.work = false;
                        var newCrm = new Models.CRM
                        {
                            dateCreated = DateTime.Now,
                            NumberCRM = t.serialNumber + "/" + DateTime.Now.ToString("dd/MM/yyyy"),
                            status = "Требут выезда",
                            equipmentType = t.Equipment.name
                        };
                        Models.context.aGetContext().CRMs.Add(newCrm);
                    }
                    Models.context.aGetContext().SaveChanges();
                }
            }
            dgAccess.ItemsSource = Models.context.aGetContext().AccsesNetworks.ToList();
            MessageBox.Show("Проверка сетей доступа завершена.");
        }

        private async void clAbEqFull(object sender, RoutedEventArgs e)
        {
            using (var http = new HttpClient())
            {
                foreach (var l in dgAbEq.Items)
                {
                    var t = l as Models.AbonentEquipment;
                    var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={t.serialNumber}");
                    request.EnsureSuccessStatusCode();
                    var result = request.Content.ReadAsStringAsync().Result;
                    if (result == "1")
                    {
                        t.Equipment.work = true;
                    }
                    else
                    {
                        t.Equipment.work = false;
                        var newCrm = new Models.CRM
                        {
                            dateCreated = DateTime.Now,
                            NumberCRM = t.serialNumber + "/" + DateTime.Now.ToString("dd/MM/yyyy"),
                            status = "Требут выезда",
                            equipmentType = t.Equipment.name
                        };
                        Models.context.aGetContext().CRMs.Add(newCrm);
                    }
                    Models.context.aGetContext().SaveChanges();
                }
            }
            dgAbEq.ItemsSource = Models.context.aGetContext().AbonentEquipments.ToList();
            MessageBox.Show("Проверка абонентского оборудывания завершена.");
        }

        private async void dgAbEq_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var abEq = dgAbEq.SelectedItem as Models.AbonentEquipment;
            if (e.ClickCount == 1)
            {
                using (var http = new HttpClient())
                {
                    var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={abEq.serialNumber}");
                    request.EnsureSuccessStatusCode();
                    var result = request.Content.ReadAsStringAsync().Result;
                    if (result == "1")
                    {
                        abEq.Equipment.work = true;
                        System.Windows.MessageBox.Show("Устройство работает.");
                    }
                    else
                    {
                        abEq.Equipment.work = false;
                        System.Windows.MessageBox.Show("Устройство не работает.");
                    }
                    Models.context.aGetContext().SaveChanges();
                    dgAbEq.ItemsSource = Models.context.aGetContext().AbonentEquipments.ToList();
                }
            }
            else if (e.ClickCount == 2)
            {
                Forms.AbEqFullForm fullForm = new AbEqFullForm(abEq, this);
                fullForm.Show();
            }
        }

        private void nameChanged(object sender, TextChangedEventArgs e)
        {
            searchStreet.Text = "";
            if (searchName.Text.Trim() != "")
            {
                dgMagistral.ItemsSource = Models.context.aGetContext().Magistrals.Where(p => p.Equipment.name.Contains(searchName.Text)).ToList();
                dgAccess.ItemsSource = Models.context.aGetContext().AccsesNetworks.Where(p => p.Equipment.name.Contains(searchName.Text)).ToList();
                dgAbEq.ItemsSource = Models.context.aGetContext().AbonentEquipments.Where(p => p.Equipment.name.Contains(searchName.Text)).ToList();
            }
            else
            {
                dgMagistral.ItemsSource = Models.context.aGetContext().Magistrals.ToList();
                dgAccess.ItemsSource = Models.context.aGetContext().AccsesNetworks.ToList();
                dgAbEq.ItemsSource = Models.context.aGetContext().AbonentEquipments.ToList();
            }
        }

        private void streetChanged(object sender, TextChangedEventArgs e)
        {
            searchName.Text = "";
            if (searchStreet.Text.Trim() != "")
            {
                dgMagistral.ItemsSource = null;
                dgAbEq.ItemsSource = null;
                dgMagistral.Items.Clear();
                dgAbEq.Items.Clear();
                var s = Models.context.aGetContext().Magistrals.ToList();
                foreach (var l in s)
                {
                    if (l.getLocations.Contains(searchStreet.Text))
                        dgMagistral.Items.Add(l);
                }
                var d = Models.context.aGetContext().AbonentEquipments.ToList();
                foreach (var l in d)
                {
                    if (l.getAddress.Contains(searchStreet.Text))
                        dgAbEq.Items.Add(l);
                }
            }
            else
            {
                dgMagistral.Items.Clear();
                dgAbEq.Items.Clear();
                dgMagistral.ItemsSource = Models.context.aGetContext().Magistrals.ToList();
                dgAccess.ItemsSource = Models.context.aGetContext().AccsesNetworks.ToList();
                dgAbEq.ItemsSource = Models.context.aGetContext().AbonentEquipments.ToList();
            }
        }
    }
}
