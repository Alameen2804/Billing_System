using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDemo
{
    public class InvoiceDetails
    {
        public string invoiceletter { get; set; }
        public int invoiceNumber { get; set;}

        public InvoiceDetails()
        {
            this.invoiceletter = "INVOICE NUMBER";
             Random rand = new Random();
            this.invoiceNumber = rand.Next(150000, 200000);
        }
    }
}
