using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDemo
{
    public class CompanyDetails
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Datetime { get; set; }

        public CompanyDetails(string companyname, string address)
        {
            this.CompanyName = companyname;
            this.Address = address;
            this.Datetime = DateTime.Now.ToString("F");
        }
    }
}
