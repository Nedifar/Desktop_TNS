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

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для PersonalForm.xaml
    /// </summary>
    public partial class PersonalForm : Page
    {
        private Models.Employee emp;
        private Models.Event selectedEvent;
        public PersonalForm(Models.Event @event)
        {
            FrFame.prs = this;
            FrFame.dateT = @event.date;
            FrFame.crmT = @event.CRM;
            InitializeComponent();
            List<forTime> forTimes = new List<forTime>();
            DateTime date = new DateTime(2022, 2, 24, 0, 0, 0);
            for (int i = 0; i < 24; i++)
            {
                forTimes.Add(new forTime { time = date.AddHours(i).ToShortTimeString() });
            }
            lvTime.ItemsSource = forTimes;
            selectedEvent = @event;
            numberLC.Text = selectedEvent.CRM.Abonent.Contract.lc;
            viewService.Text = selectedEvent.CRM.serviceView;
            dateTimeT.Text = selectedEvent.date.ToShortDateString() + " " + selectedEvent.begin.ToShortTimeString() + "-" + selectedEvent.end.ToShortTimeString();
            lvPersonal.ItemsSource = Models.context.aGetContext().Employees.Where(p => p.idEmployeeType == 4).ToList();
        }

        private void clLeft(object sender, RoutedEventArgs e)
        {
            scrPersonal.LineLeft();
        }

        private void clPers(object sender, RoutedEventArgs e)
        {
            var b = (sender as Button).DataContext as Models.Employee;
            emp = b;
            txt.Text = b.lastName;
            lvDates.ItemsSource = Models.context.aGetContext().DateTables.Where(p => p.date == FrFame.dateT).ToList();
        }

        private void clRight(object sender, RoutedEventArgs e)
        {
            scrPersonal.LineRight();
        }

        private void clPersonalN(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите доавбить этого инженера к этой заявке?", "Внимание", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (emp != null)
                {
                    bool i = true;
                    foreach (var line in Models.context.aGetContext().Events.Where(p => p.date == selectedEvent.date && p.Employee.idEmployee == emp.idEmployee))
                    {
                        if (selectedEvent.begin >= line.rool || line.begin >= selectedEvent.rool)
                        { }
                        else
                            i = false;
                    }
                    if (i)
                    {
                        selectedEvent.Employee = emp;
                        Models.context.aGetContext().SaveChanges();
                        MessageBox.Show("Инженер успешно добавлен.");
                        lvDates.ItemsSource = Models.context.aGetContext().DateTables.Where(p => p.date == FrFame.dateT).ToList();
                    }
                    else
                        MessageBox.Show("Наложение времени.");
                }
                else
                    MessageBox.Show("Выберите инженера");
            }
        }

        private void clCSV(object sender, RoutedEventArgs e)
        {

            var csv = new StringBuilder();
            var line = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", selectedEvent.NumberCRM, selectedEvent.CRM.dateCreated, selectedEvent.CRM.AbonentNumber, selectedEvent.CRM.Service.name, selectedEvent.CRM.serviceType, selectedEvent.CRM.serviceView, selectedEvent.CRM.status, selectedEvent.CRM.equipmentType, selectedEvent.CRM.problem, selectedEvent.CRM.dateClosed, selectedEvent.CRM.typeProblem);
            csv.AppendLine(line);
            File.WriteAllText($@"{AppDomain.CurrentDomain.BaseDirectory}{selectedEvent.CRM.AbonentNumber}.csv", csv.ToString(), Encoding.Default);
            MessageBox.Show("Csv сформирован в папку Debug");
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
    }
}
