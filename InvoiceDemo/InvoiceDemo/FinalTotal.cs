using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDemo
{
    public class FinalTotal
    {
        public int Subtotal { get; set; }
        public int Discount { get; set; }
        public int SubTotalLessDis { get; set; }
        public int TaxRate { get; set; }
        public int TotalTax { get; set; }
        public int BalaceDue { get; set; }
        public string Subtotal2 { get; set; }
        public string Discount2 { get; set; }
        public string SubTotalLessDis2 { get; set; }
        public string TaxRate2 { get; set; }
        public string TotalTax2 { get; set; }
        public string BalanceDue2 { get; set; }

        public FinalTotal(int discount, int taxrate, int subtotal)
        {
            this.Subtotal = subtotal;
            this.Discount = discount;
            this.SubTotalLessDis = Subtotal - discount;
            this.TaxRate = taxrate;
            this.TotalTax = Subtotal * TaxRate / 100;
            this.BalaceDue = SubTotalLessDis + TotalTax;
            this.Subtotal2 = "SUB TOTAL";
            this.Discount2 = "DISCOUNT";
            this.SubTotalLessDis2 = "SUB TOTAL LESS DISCOUNT";
            this.TaxRate2 = "TAX RATE";
            this.TotalTax2 = "TOTAL TAX";
            this.BalanceDue2 = "BALANCE DUE";
        }
    }
}
