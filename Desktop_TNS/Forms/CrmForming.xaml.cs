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
using System.Windows.Shapes;

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для CrmForming.xaml
    /// </summary>
    public partial class CrmForming : Page
    {
        public CrmForming()
        {
            InitializeComponent();
        }

        private void clNext(object sender, RoutedEventArgs e)
        {
            var moda = Models.context.aGetContext().Abonents.Where(p => p.phone == tbPhone.Text && p.lastName == tbLastName.Text).FirstOrDefault();
            if (moda != null)
            {
                Forms.CrmCreateForm crm = new CrmCreateForm(moda);
                crm.Show();
            }
            else
            { MessageBox.Show("Проверьте правильность введенных данных"); }
        }
    }
}
