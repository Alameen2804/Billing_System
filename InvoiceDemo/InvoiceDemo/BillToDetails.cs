using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDemo
{
    public class BillToDetails
    {
        public string Customer { get; set; }

        public BillToDetails(string customer)
        {
            this.Customer = customer;
        }
    }
}
