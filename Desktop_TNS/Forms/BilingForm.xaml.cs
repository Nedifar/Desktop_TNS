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
using DevExpress.XtraPdfViewer;
using DevExpress.XtraSpreadsheet.Services;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Charts;
using DevExpress.Office.Services;

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для BilingForm.xaml
    /// </summary>
    public partial class BilingForm : Page
    {
        public BilingForm()
        {
            InitializeComponent();
            dpDate.SelectedDate = DateTime.Now;
            cbService.ItemsSource = Models.context.aGetContext().Services.ToList();
        }

        private void chk(object sender, RoutedEventArgs e)
        {
            var rad = (sender as RadioButton).Content;
            if (rad.ToString() == "по тарифу")
            {
                var list = Models.context.aGetContext().AbonentTarifs.Where(p => p.Abonent.Contract.dateClosed == null).ToList();
                dgTarifs.ItemsSource = list.OrderBy(p => p.listTarifs);
            }
            else
            {
                var list = Models.context.aGetContext().AbonentTarifs.Where(p => p.Abonent.Contract.dateClosed == null).ToList();
                dgTarifs.ItemsSource = list.OrderBy(p => p.zadol);
            }
        }

        private void clTarif(object sender, RoutedEventArgs e)
        {
            List<formir> formirs = new List<formir>();
            foreach (var l in Models.context.aGetContext().Tarifs.ToList())
            {
                int i = 0;
                foreach (var m in Models.context.aGetContext().AbonentTarifs.ToList())
                {
                    if (m.Tarifs.Contains(l))
                        if (m.Abonent.Contract.dateConclude >= dpTarifBegin.SelectedDate && m.Abonent.Contract.dateConclude <= dpTarifEnd.SelectedDate)
                        {
                            i++;
                        }
                }
                formirs.Add(new formir { name = l.name, count = i });
            }
            foreach (var l in formirs)
            {
                Console.WriteLine(l.name + " " + l.count);
            }
            OfficeCharts.Instance.ActivateCrossPlatformCharts();
            using (var proccesor = new RichEditDocumentServer())
            {
                Document doc = proccesor.Document;
                doc.BeginUpdate();
                var par1 = doc.Paragraphs.Append();
                doc.InsertText(par1.Range.Start, "Отчет по тарифам за период: " + dpTarifBegin.SelectedDate.Value.ToShortDateString() + "-" + dpTarifEnd.SelectedDate.Value.ToShortDateString());
                var par2 = doc.Paragraphs.Append();
                var table = doc.Tables.Create(par2.Range.Start, formirs.Count + 1, 2);
                doc.InsertText(table[0, 0].Range.Start, "Назавние тарифа");
                doc.InsertText(table[0, 1].Range.Start, "Количество договоров");
                var par3 = doc.Paragraphs.Append();
                var chartShape = doc.Shapes.InsertChart(par3.Range.Start, DevExpress.XtraRichEdit.API.Native.ChartType.ColumnClustered);

                chartShape.Name = "Pareto";
                ChartObject chart = (ChartObject)chartShape.ChartFormat.Chart;
                Worksheet worksheet = (Worksheet)chartShape.ChartFormat.Worksheet;
                for (int i = 1; i <= formirs.Count; i++)
                {
                    doc.InsertText(table[i, 0].Range.Start, formirs[i - 1].name);
                    worksheet[i, 0].Value = formirs[i - 1].name;
                    doc.InsertText(table[i, 1].Range.Start, formirs[i - 1].count.ToString());
                    worksheet[i, 1].Value = formirs[i - 1].count;

                }
                chart.SelectData(worksheet[$"A1:B{formirs.Count + 1}"]);
                proccesor.ExportToPdf($"{AppDomain.CurrentDomain.BaseDirectory}Отчет по тарифам за период {dpTarifBegin.SelectedDate.Value.ToShortDateString()} - {dpTarifEnd.SelectedDate.Value.ToShortDateString()}.pdf");
            }

        }

        private void clRaion(object sender, RoutedEventArgs e)
        {
            List<formir> formirs = new List<formir>();
            foreach (var m in Models.context.aGetContext().Raions.ToList())
            {
                int i = 0;
                foreach (var l in m.AbonentAddresses)
                {
                    foreach (var n in l.Abonents)
                    {
                        if (n.Contract.dateConclude >= dpNewBegin.SelectedDate && n.Contract.dateConclude <= dpNewEnd.SelectedDate)
                        {
                            i++;
                        }
                    }
                }
                formirs.Add(new formir { name = m.name, count = i });
            }
            foreach (var l in formirs)
            {
                Console.WriteLine(l.name + " " + l.count);
            }
            OfficeCharts.Instance.ActivateCrossPlatformCharts();
            using (var processor = new RichEditDocumentServer())
            {
                var doc = processor.Document;
                doc.BeginUpdate();
                var par1 = doc.Paragraphs.Append();
                doc.InsertText(par1.Range.Start, "Отчет по количеству новых подключений по районам за период: " + dpNewBegin.SelectedDate.Value.ToShortDateString() + "-" + dpNewEnd.SelectedDate.Value.ToShortDateString());
                var par2 = doc.Paragraphs.Append();
                var table = doc.Tables.Create(par2.Range.Start, formirs.Count + 1, 2);
                doc.InsertText(table[0, 0].Range.Start, "Назавние района");
                doc.InsertText(table[0, 1].Range.Start, "Количество подключений");
                var par3 = doc.Paragraphs.Append();
                var chartShape = doc.Shapes.InsertChart(par3.Range.Start, DevExpress.XtraRichEdit.API.Native.ChartType.ColumnClustered);

                chartShape.Name = "Histo";
                ChartObject chart = (ChartObject)chartShape.ChartFormat.Chart;
                Worksheet worksheet = (Worksheet)chartShape.ChartFormat.Worksheet;
                for (int i = 1; i <= formirs.Count; i++)
                {
                    doc.InsertText(table[i, 0].Range.Start, formirs[i - 1].name);
                    worksheet[i, 0].Value = formirs[i - 1].name;
                    doc.InsertText(table[i, 1].Range.Start, formirs[i - 1].count.ToString());
                    worksheet[i, 1].Value = formirs[i - 1].count;
                }
                chart.SelectData(worksheet[$"A1:B{formirs.Count + 1}"]);
                processor.ExportToPdf($"{AppDomain.CurrentDomain.BaseDirectory}Отчет по количеству новых подключений за период {dpNewBegin.SelectedDate.Value.ToShortDateString()} - {dpNewEnd.SelectedDate.Value.ToShortDateString()}.pdf");
            }
        }

        private void clPriority(object sender, RoutedEventArgs e)
        {
            List<rai> rais = new List<rai>();
            foreach (var m in Models.context.aGetContext().Raions.ToList())
            {
                List<formir> formirs = new List<formir>();
                foreach (var b in Models.context.aGetContext().Services.ToList())
                {
                    int i = 0;
                    foreach (var l in m.AbonentAddresses)
                    {
                        foreach (var n in l.Abonents)
                        {
                            foreach (var abo in n.AbonentTarifs)
                            {
                                foreach (var bb in abo.Tarifs)
                                    if (bb.Services.Contains(b))
                                        i++;
                            }
                        }
                    }
                    formirs.Add(new formir { name = b.name, count = i });
                }
                rais.Add(new rai { name = m.name, Formirs = formirs });
            }
            foreach (var l in rais)
            {
                foreach (var tar in l.Formirs)
                {
                    Console.WriteLine(l.name + " " + tar.name + " " + tar.count);

                }
            }

            OfficeCharts.Instance.ActivateCrossPlatformCharts();
            using (var processor = new RichEditDocumentServer())
            {
                var doc = processor.Document;
                doc.BeginUpdate();
                var par1 = doc.Paragraphs.Append();
                doc.InsertText(par1.Range.Start, "Отчет по приоритету услуг в районах: ");
                for (int i = 1; i <= rais.Count; i++)
                {
                    var par = doc.Paragraphs.Append();
                    doc.InsertText(par.Range.Start, rais[i - 1].name);
                    var para = doc.Paragraphs.Append();
                    var table = doc.Tables.Create(para.Range.Start, rais[i - 1].Formirs.Count + 1, 2);
                    doc.InsertText(table[0, 0].Range.Start, "Назавние услуги");
                    doc.InsertText(table[0, 1].Range.Start, "Количество договоров");
                    var par3 = doc.Paragraphs.Append();
                    var chartShape = doc.Shapes.InsertChart(par3.Range.Start, DevExpress.XtraRichEdit.API.Native.ChartType.ColumnClustered);
                    chartShape.Name = "Histo";
                    chartShape.TextWrapping = TextWrappingType.TopAndBottom;

                    ChartObject chart = (ChartObject)chartShape.ChartFormat.Chart;
                    Worksheet worksheet = (Worksheet)chartShape.ChartFormat.Worksheet;
                    for (int j = 1; j <= rais[i-1].Formirs.Count; j++)
                    {
                        doc.InsertText(table[j, 0].Range.Start, rais[i-1].Formirs[j - 1].name);
                        worksheet[j, 0].Value = rais[i - 1].Formirs[j - 1].name;
                        doc.InsertText(table[j, 1].Range.Start, rais[i - 1].Formirs[j - 1].count.ToString());
                        worksheet[j, 1].Value = rais[i - 1].Formirs[j - 1].count;
                    }
                    chart.SelectData(worksheet[$"A1:B{rais[i-1].Formirs.Count + 1}"]);
                    
                }

                processor.ExportToPdf($"{AppDomain.CurrentDomain.BaseDirectory}Отчет по приоритету услуг по райном.pdf");
            }

        }
        public class formir
        {
            public string name { get; set; }
            public int count { get; set; }
        }
        public class rai
        {
            public string name { get; set; }
            public List<formir> Formirs { get; set; } = new List<formir>();
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FrFame.selectedDate = dpDate.SelectedDate.Value;
            var list = Models.context.aGetContext().AbonentTarifs.Where(p=>p.Abonent.Contract.dateClosed == null).ToList();
            dgTarifs.ItemsSource = list;
            dgHistory.ItemsSource = null;
        }

        private void dgTarifs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mod = dgTarifs.SelectedItem as Models.AbonentTarif;
            dgHistory.ItemsSource = Models.context.aGetContext().AbonentPayments.Where(p => p.Abonent.AbonentNumber == mod.AbonentNumber).OrderBy(p=>p.datePayment).ToList();
        }

        private void cbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem as Models.Service;
            if (radTarif.IsChecked == true)
            {
                var list = Models.context.aGetContext().AbonentTarifs.Where(p => p.Abonent.Contract.dateClosed == null ).ToList();
                dgTarifs.ItemsSource = list.Where(p=>p.Abonent.Contract.Services.Contains(item)).OrderBy(p => p.listTarifs );
            }
            else if (radZad.IsChecked == true)
            {
                var list = Models.context.aGetContext().AbonentTarifs.Where(p => p.Abonent.Contract.dateClosed == null ).ToList();
                dgTarifs.ItemsSource = list.Where(p => p.Abonent.Contract.Services.Contains(item)).OrderBy(p => p.zadol);
            }
            else
            {
                var list = Models.context.aGetContext().AbonentTarifs.Where(p => p.Abonent.Contract.dateClosed == null ).ToList();
                dgTarifs.ItemsSource = list.Where(p => p.Abonent.Contract.Services.Contains(item));
            }
        }

        private void kvitPDF(object sender, RoutedEventArgs e)
        {
            var mod = dgTarifs.SelectedItem as Models.AbonentTarif;
            using(var proccesor = new RichEditDocumentServer())
            {
               
            }
        }
    }
}

