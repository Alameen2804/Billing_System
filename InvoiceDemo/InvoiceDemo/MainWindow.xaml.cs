using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace InvoiceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CompanyDetails> CompanyData = new List<CompanyDetails>();
        List<InvoiceDetails> InvoiceData = new List<InvoiceDetails>();
        List<BillToDetails> Customer = new List<BillToDetails>();
        List<BillingTable> MainBill = new List<BillingTable>();
        List<FinalTotal> FinalBill = new List<FinalTotal>();
        List<Extras> Extra = new List<Extras>();

        string FileName = "InvoiceDemo";
        string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//RDLCDemo";

        public MainWindow()
        {
            InitializeComponent();
            LoadCompany();
            LoadInvoice();
            LoadCustomerData();
            LoadMainBill();
            LoadFinalBill();
            LoadExtras();
            Process();
        }
        void Process()
        {
            //STEP 1
            DataTable dt1 = new DataTable();
            dt1 = ConvertToDataTable(CompanyData);

            DataTable dt2 = new DataTable();
            dt2 = ConvertToDataTable(InvoiceData);

            DataTable dt3 = new DataTable();
            dt3 = ConvertToDataTable(Customer);

            DataTable dt4 = new DataTable();
            dt4 = ConvertToDataTable(MainBill);

            DataTable dt5 = new DataTable();
            dt5 = ConvertToDataTable(FinalBill);

            DataTable dt6 = new DataTable();
            dt6 = ConvertToDataTable(Extra);

            //STEP 2
            ReportDataSource reportdata1 = new ReportDataSource();
            reportdata1.Name = "DataSet1";
            reportdata1.Value = dt1;

            ReportDataSource reportdata2 = new ReportDataSource();
            reportdata2.Name = "DataSet2";
            reportdata2.Value = dt2;

            ReportDataSource reportdata3 = new ReportDataSource();
            reportdata3.Name = "DataSet3";
            reportdata3.Value = dt3;

            ReportDataSource reportdata4 = new ReportDataSource();
            reportdata4.Name = "DataSet4";
            reportdata4.Value = dt4;

            ReportDataSource reportdata5 = new ReportDataSource();
            reportdata5.Name = "DataSet5";
            reportdata5.Value = dt5;

            ReportDataSource reportdata6 = new ReportDataSource();
            reportdata6.Name = "DataSet6";
            reportdata6.Value = dt6;

            //STEP 3: MAIN PROCESS
            ReportViewer rv1 = new ReportViewer();
            rv1.LocalReport.ReportEmbeddedResource = "InvoiceDemo.Report1.rdlc";
            rv1.LocalReport.DataSources.Add(reportdata1);
            rv1.LocalReport.DataSources.Add(reportdata2);
            rv1.LocalReport.DataSources.Add(reportdata3);
            rv1.LocalReport.DataSources.Add(reportdata4);
            rv1.LocalReport.DataSources.Add(reportdata5);
            rv1.LocalReport.DataSources.Add(reportdata6);
            rv1.RefreshReport();
            rv1.ProcessingMode = ProcessingMode.Local;

            //STEP 4
            Warning[] warnings1;
            string[] streamids1;
            string mimeType1;
            string encoding1;
            string extension1;
            try
            {
                byte[] bytes = rv1.LocalReport.Render("PDF", null, out mimeType1, out encoding1, out extension1, out streamids1, out warnings1);
                string fullpath = System.IO.Path.Combine(FilePath + "\\" + FileName + ".pdf");
                FileStream fs = new FileStream(fullpath, FileMode.Create);
                var temps = fs.ToString();
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        void LoadCompany()
        {
            CompanyData.Add(new CompanyDetails("STANFORD PLUMBING & HEATING", "2nd FLOOR,\nBKG BUILDING,\nNO.86, MADURAI ROAD,\nTIRUCHIRAPPALLI-620 008."));
        }
        void LoadInvoice()
        {
            InvoiceData.Add(new InvoiceDetails());
        }
        void LoadCustomerData()
        {
            Customer.Add(new BillToDetails("ALAMEEN\nSENTHALAI,\nTHANJAVUR\najjuamin@gmail.com\n9876543210"));
        }
        void LoadMainBill()
        {
            MainBill.Add(new BillingTable("Installed new kitchen sink", 3, 50));
            MainBill.Add(new BillingTable("Toyo sink", 1, 500));
            MainBill.Add(new BillingTable("System filter", 1, 190));
            MainBill.Add(new BillingTable("Nest Smart", 1, 250));
            MainBill.Add(new BillingTable("30i", 1, 1500));
        }

        int subtotal = 0;
        void LoadFinalBill()
        {
            for (int i = 0; i < MainBill.Count(); i++)
            {
                subtotal += MainBill[i].Total;
            }
            FinalBill.Add(new FinalTotal(50, 10, subtotal));
        }

        void LoadExtras()
        {
            Extra.Add(new Extras());
        }
    }
}
