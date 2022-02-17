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
    /// Логика взаимодействия для AbonentFullInformationForm.xaml
    /// </summary>
    public partial class AbonentFullInformationForm : Window
    {
        public AbonentFullInformationForm(Models.Abonent abonent)
        {
            InitializeComponent();
            DataContext = abonent;
        }
    }
}
