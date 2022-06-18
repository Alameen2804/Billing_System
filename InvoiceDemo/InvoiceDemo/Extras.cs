using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDemo
{
    public class Extras
    {
        public string Thank { get; set; }
        public string Terms { get; set; }

        public Extras()
        {
            this.Thank = "Thank you for your business!";
            this.Terms = "Please pay within 20 days by Paypal(ajju@paypal)\nInstalled products have 5 years warranty";
        }
    }
}
