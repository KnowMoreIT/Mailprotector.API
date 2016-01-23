using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class Invoice
    {
        public int id { get; set; }

        public int account_id { get; set; }

        public int number { get; set; }

        public DateTime invoice_date { get; set; }

        public DateTime due_date { get; set; }

        public string invoice_status { get; set; }

        public decimal discount { get; set; }

        public decimal total { get; set; }

        public int terms { get; set; }

        public string notes { get; set; }

        public InvoiceLine invoice_lines { get; set; }
    }
}
