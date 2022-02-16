using System;
using System.Collections.Generic;
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

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для AbonentForm.xaml
    /// </summary>
    public partial class AbonentForm : Page
    {
        Models.Employee selectedEmp;
        public AbonentForm(Models.Employee emp)
        {
            InitializeComponent();
            selectedEmp = emp;
            lv.ItemsSource = Models.context.aGetContext().EmployeeInformations.Where(p => p.idEmployeeType == emp.idEmployeeType).ToList();
            cbActive.IsChecked = true;
            dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.ToList();
        }

        private void check(object sender, RoutedEventArgs e)
        {
            if(cbActive.IsChecked == true && cbNeActive.IsChecked == true)
            {
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.ToList();
            }
            else if(cbActive.IsChecked == true && cbNeActive.IsChecked == false)
            {
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p=>p.Contract.dateClosed == null).ToList();
            }
            else if(cbActive.IsChecked == false && cbNeActive.IsChecked == true)
            {
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p => p.Contract.dateClosed != null).ToList();
            }
            else
            {
                dgAbonents.ItemsSource = null;
            }
        }

        private void uncheck(object sender, RoutedEventArgs e)
        {
            if (cbActive.IsChecked == true && cbNeActive.IsChecked == true)
            {
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.ToList();
            }
            else if (cbActive.IsChecked == true && cbNeActive.IsChecked == false)
            {
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p => p.Contract.dateClosed == null).ToList();
            }
            else if (cbActive.IsChecked == false && cbNeActive.IsChecked == true)
            {
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p => p.Contract.dateClosed != null).ToList();
            }
            else
            {
                dgAbonents.ItemsSource = null;
            }
        }

        private void clUp(object sender, RoutedEventArgs e)
        {
            scrL.LineUp();
        }

        private void clDown(object sender, RoutedEventArgs e)
        {
            scrL.LineDown();
        }

        private void dgAbonents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
