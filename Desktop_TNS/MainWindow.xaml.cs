using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Desktop_TNS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Models.Employee selEmp;
        Forms.AbonentForm abForm;
        public MainWindow()
        {
            InitializeComponent();

            //import();
            //json();




            FrFame.MainFrame = frame;
            cbAbonents.ItemsSource = Models.context.aGetContext().Employees.ToList();
            cbAbonents.SelectedIndex = 2;
            abForm = new Forms.AbonentForm(selEmp);
            FrFame.MainFrame.Navigate(abForm);
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (col1.Width.Value == 5)
                sizeChange();
        }

        private void sizeChange()
        {
            col1.Width = new GridLength((col1.Width.Value == 5 ? 2 : 5), GridUnitType.Star);
        }

        private void clAbonent(object sender, RoutedEventArgs e)
        {
            mainText.Text = "Абоненты ТНС";
            if (col1.Width.Value == 2)
                sizeChange();
            abForm = new Forms.AbonentForm(selEmp);
            FrFame.MainFrame.Navigate(abForm);
        }

        private void clManage(object sender, RoutedEventArgs e)
        {
            mainText.Text = "Управление оборудыванием";
            if (col1.Width.Value == 2)
                sizeChange();
        }

        private void clActive(object sender, RoutedEventArgs e)
        {
            mainText.Text = "Активы";
            if (col1.Width.Value == 2)
                sizeChange();
        }

        private void clBilling(object sender, RoutedEventArgs e)
        {
            mainText.Text = "Биллинг";
            if (col1.Width.Value == 2)
                sizeChange();
        }

        private void clSupport(object sender, RoutedEventArgs e)
        {
            mainText.Text = "Поддержка пользователей";
            if (col1.Width.Value == 2)
                sizeChange();
        }

        private void clCRM(object sender, RoutedEventArgs e)
        {
            FrFame.MainFrame.Navigate(new Forms.CrmForming());
            mainText.Text = "CRM";
            if (col1.Width.Value == 2)
                sizeChange();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (sender as ComboBox).SelectedItem as Models.Employee;
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}AboImages/{selected.imagePath}.jpg"))
            {
                imageAbonent.Source = new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}AboImages/{selected.imagePath}.jpg"));
            }
            else
                imageAbonent.Source = new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}AboImages/glush.jpg"));
            selEmp = selected;
            if (abForm != null)
                abForm.lv.ItemsSource = Models.context.aGetContext().EmployeeInformations.Where(p => p.idEmployeeType == selEmp.idEmployeeType).ToList();
            switch (selected.idEmployeeType)
            {
                case 1:
                    {
                        btAbonent.Visibility = Visibility.Visible;
                        btActive.Visibility = Visibility.Collapsed;
                        btBilling.Visibility = Visibility.Visible;
                        btCRM.Visibility = Visibility.Visible;
                        btManage.Visibility = Visibility.Collapsed;
                        btSupport.Visibility = Visibility.Collapsed;
                        break;
                    }
                case 2:
                    {
                        btAbonent.Visibility = Visibility.Visible;
                        btActive.Visibility = Visibility.Collapsed;
                        btBilling.Visibility = Visibility.Collapsed;
                        btCRM.Visibility = Visibility.Visible;
                        btManage.Visibility = Visibility.Collapsed;
                        btSupport.Visibility = Visibility.Collapsed;
                        break;
                    }
                case 3:
                    {
                        btAbonent.Visibility = Visibility.Visible;
                        btActive.Visibility = Visibility.Collapsed;
                        btBilling.Visibility = Visibility.Collapsed;
                        btCRM.Visibility = Visibility.Visible;
                        btManage.Visibility = Visibility.Visible;
                        btSupport.Visibility = Visibility.Visible;
                        break;
                    }
                case 4:
                    {
                        btAbonent.Visibility = Visibility.Visible;
                        btActive.Visibility = Visibility.Collapsed;
                        btBilling.Visibility = Visibility.Collapsed;
                        btCRM.Visibility = Visibility.Visible;
                        btManage.Visibility = Visibility.Visible;
                        btSupport.Visibility = Visibility.Visible;
                        break;
                    }
                case 5:
                    {
                        btAbonent.Visibility = Visibility.Visible;
                        btActive.Visibility = Visibility.Visible;
                        btBilling.Visibility = Visibility.Visible;
                        btCRM.Visibility = Visibility.Collapsed;
                        btManage.Visibility = Visibility.Collapsed;
                        btSupport.Visibility = Visibility.Collapsed;
                        break;
                    }
                case 6:
                    {
                        btAbonent.Visibility = Visibility.Visible;
                        btActive.Visibility = Visibility.Visible;
                        btBilling.Visibility = Visibility.Visible;
                        btCRM.Visibility = Visibility.Visible;
                        btManage.Visibility = Visibility.Visible;
                        btSupport.Visibility = Visibility.Visible;
                        break;
                    }
                case 7:
                    {
                        btAbonent.Visibility = Visibility.Visible;
                        btActive.Visibility = Visibility.Visible;
                        btBilling.Visibility = Visibility.Collapsed;
                        btCRM.Visibility = Visibility.Visible;
                        btManage.Visibility = Visibility.Visible;
                        btSupport.Visibility = Visibility.Collapsed;
                        break;
                    }
            }
        }






        public void import()
        {
            var lines = File.ReadAllLines(@"C:\Users\gazimov.ii0794\Desktop\врменная\Заявки CRM.txt");
            foreach (var line in lines)
            {
                string[] m = line.Split('\t');
                string l = m[2];
                string d = m[3];
                var red = new Models.CRM
                {
                   NumberCRM = m[0],
                   dateCreated = Convert.ToDateTime(m[1]),
                   AbonentNumber = Models.context.aGetContext().Abonents.Where(p=>p.Contract.lc == l).FirstOrDefault().AbonentNumber,
                   idService = Models.context.aGetContext().Services.Where(p=>p.name == d).FirstOrDefault().idService,
                   serviceView = m[4],
                   serviceType = m[5],
                   status = m[6],
                   typeProblem = m[10],
                   problem = m[8],
                   equipmentType = m[7]
                };
                if (m[9].Trim() != "")
                    red.dateClosed = Convert.ToDateTime(m[9]);
                Models.context.aGetContext().CRMs.Add(red);
                Models.context.aGetContext().SaveChanges();
            }
        }
        public void json()
        {
            var file = File.ReadAllText(@"F:\_____\2_Основные\Сессия 2\Абоненты\Адреса абонентов.json");
            var json = JsonConvert.DeserializeObject<List<Models.AbonentAddress>>(file);
            foreach (var js in json)
            {
                Models.context.aGetContext().AbonentAddresses.Add(js);
            }
            Models.context.aGetContext().SaveChanges();
        }
    }
}
