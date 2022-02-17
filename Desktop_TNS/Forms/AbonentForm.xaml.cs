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
            searchStreet.ItemsSource = Models.context.aGetContext().AbonentAddresses.GroupBy(x=>x.prefix).Select(x=>x.FirstOrDefault()).ToList();
        }

        private void check(object sender, RoutedEventArgs e)
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
            if (dgAbonents.SelectedItems.Count != 0)
            {
                Forms.AbonentFullInformationForm form = new AbonentFullInformationForm(dgAbonents.SelectedItem as Models.Abonent);
                form.Show();
            }
        }

        private void searchLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchLastName.Text.Trim() != "")
            {
                searchHome.SelectedIndex = -1;
                searchLc.Text = String.Empty;
                searchStreet.SelectedIndex = -1;
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p => p.lastName.Contains(searchLastName.Text)).ToList();
            }
            else
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.ToList();
        }

        private void searchLc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchLc.Text.Trim() != "")
            {
                searchHome.SelectedIndex = -1;
                searchLastName.Text = String.Empty;
                searchStreet.SelectedIndex = -1;
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p => p.Contract.lc.Contains(searchLc.Text)).ToList();
            }
            else
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.ToList();
        }

        private void searchStreet_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchStreet.SelectedIndex != -1)
            {
                var abo = (sender as ComboBox).SelectedItem as Models.AbonentAddress;
                searchHome.SelectedIndex = -1;
                searchLc.Text = String.Empty;
                searchLastName.Text = String.Empty;
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p => p.AbonentAddress.prefix.Contains(abo.getStreet)).ToList();
                searchHome.ItemsSource = Models.context.aGetContext().AbonentAddresses.Where(p => p.prefix.Contains(searchStreet.Text)).GroupBy(x=>x.house).Select(x=>x.FirstOrDefault()).ToList();
            }
            else
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.ToList();
        }

        private void searchHome_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchHome.SelectedIndex != -1)
            {
                var abo = (sender as ComboBox).SelectedItem as Models.AbonentAddress;
                searchLc.Text = String.Empty;
                searchLastName.Text = String.Empty;
                dgAbonents.ItemsSource = Models.context.aGetContext().Abonents.Where(p => p.AbonentAddress.house == abo.house && p.AbonentAddress.prefix.Contains(searchStreet.Text)).ToList();
            }
        }

        private void clClear(object sender, RoutedEventArgs e)
        {
            searchStreet.SelectedIndex = -1;
            searchHome.SelectedIndex = -1;
            searchLc.Text = String.Empty;
            searchLastName.Text = String.Empty;
            check(null, null);
        }
    }
}
