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
using System.Data.Entity;

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для SupportForm.xaml
    /// </summary>
    public partial class SupportForm : Page
    {
        public SupportForm()
        {
            InitializeComponent();
            List<forTime> forTimes = new List<forTime>();
            DateTime date = new DateTime(2022, 2, 24, 0, 0, 0);
            for (int i = 0; i < 24; i++)
            {
                forTimes.Add(new forTime { time = date.AddHours(i).ToShortTimeString() });
            }
            cbAbonents.ItemsSource = Models.context.aGetContext().Abonents.ToList();
            cbAbonents.SelectedIndex = 7;
            lvTime.ItemsSource = forTimes;
            lvDates.ItemsSource = Models.context.aGetContext().DateTables.ToList();
        }


        private void up_Click(object sender, RoutedEventArgs e)
        {
            scrTime.LineUp();
            scrDate.LineUp();
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            scrTime.LineDown();
            scrDate.LineDown();
        }

        private void clInfo(object sender, RoutedEventArgs e)
        {
                sp.DataContext = (sender as Button).DataContext as Models.Event;
        }

        private void selChanged(object sender, SelectionChangedEventArgs e)
        {
            var r = cbAbonents.SelectedItem as Models.Abonent;
            txt.Text = r.AbonentNumber;
            lvDates.ItemsSource = Models.context.aGetContext().DateTables.ToList();
            //lvDates.ItemsSource = tables;
        }

        private void cl(object sender, MouseButtonEventArgs e)
        {
            var s = (sender as Button).DataContext as Models.Event;
            FrFame.MainFrame.Navigate(new Forms.PersonalForm(s));
        }
    }
    class forTime
    {
        public string time { get; set; }
    }
}
