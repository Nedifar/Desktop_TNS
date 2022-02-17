using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для CrmCreateForm.xaml
    /// </summary>
    public partial class CrmCreateForm : Window
    {
        Models.Abonent ab;
        Models.CRM cr = new Models.CRM();
        public CrmCreateForm(Models.Abonent abonent)
        {
            InitializeComponent();
            ab = abonent;
            cr.NumberCRM = abonent.Contract.lc + "/" + DateTime.Now.ToString("dd/MM/yyyy");
            cr.dateCreated = DateTime.Now;
            cr.AbonentNumber = ab.AbonentNumber;
            cr.Abonent = ab;
            cbService.ItemsSource = Models.context.aGetContext().Services.ToList();
            cr.status = "Новая";
            DataContext = cr;
        }

        private void cbViewService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbViewService.SelectedIndex)
            {
                case 0:
                    cbTypeService.ItemsSource = null;
                    cbTypeService.Items.Add("Подключение услуг с новой инфраструктурой");
                    cbTypeService.Items.Add("Подключение услуг на существующей инфраструктуре");
                    break;
                case 1:
                    cbTypeService.ItemsSource = null;
                    cbTypeService.Items.Add("Изменение условий договора");
                    cbTypeService.Items.Add("Включение в договор дополнительной услуги");
                    cbTypeService.Items.Add("Изменение контактных данных");
                    break;
                case 2:
                    cbTypeService.ItemsSource = null;
                    cbTypeService.Items.Add("Изменение тарифа");
                    cbTypeService.Items.Add("Изменение адреса предоставления услуг");
                    cbTypeService.Items.Add("Отключение услуги");
                    cbTypeService.Items.Add("Приостановка предоставления услуги");
                    break;
                case 3:
                    cbTypeService.ItemsSource = null;
                    cbTypeService.Items.Add("Нет доступа к услуге");
                    cbTypeService.Items.Add("Разрыв соединения");
                    cbTypeService.Items.Add("Низкая скорость соединения");
                    break;
                case 4:
                    cbTypeService.ItemsSource = null;
                    cbTypeService.Items.Add("Выписка по платежам");
                    cbTypeService.Items.Add("Информация о платежах");
                    cbTypeService.Items.Add("Получение квитанции на оплату услуги");
                    break;
            }
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            try
            {
                Models.context.aGetContext().CRMs.Add(cr);
                Models.context.aGetContext().SaveChanges();
                System.Windows.MessageBox.Show("Заявка создана");
                Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("У данного абонента уже существует заявка на сегодняшний день.");
            }
        }

        private async void clProverka(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    this.Dispatcher.BeginInvoke(new MethodInvoker(delegate
                    {
                        updateProgressBar(i);
                    }));
                    Thread.Sleep(30);
                }
            }
            );
            using (var http = new HttpClient())
            {
                var request = await http.GetAsync($@"http://localhost:62727/api/equipment/state?serialNumber={ab.Contract.serialNumber}");
                request.EnsureSuccessStatusCode();
                var result = request.Content.ReadAsStringAsync().Result;
                if (result == "1")
                {
                    dtClosed.Text = DateTime.Now.ToString("dd.MM.yyyy");
                    st.Text = "Закрыта";
                    System.Windows.MessageBox.Show("Устройство работает.");
                }
                else
                {
                    st.Text = "Требует выезда";
                    System.Windows.MessageBox.Show("Устройство не работает.");
                }
                DataContext = cr;
            }
        }
        private void updateProgressBar(int i)
        {
            progress.Value = i;
        }
    }
}
